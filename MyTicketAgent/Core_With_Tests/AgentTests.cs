using NUnit.Framework;

namespace Core_With_Tests
{
    [TestFixture]
    public class AgentTests
    {
        private TestDal testDal;
        private Agent agent;

        [SetUp]
        public void SetUp()
        {
            testDal = new TestDal();
            agent = new Agent("GOOG", 100, 12.5m, testDal);
        }

        [Test]
        public void ShouldBeConfigurableWithCompanyAndQtyAndThreashold()
        {
            var agent = new Agent("GOOG", 100, 12.5m, null);
            Assert.AreEqual("GOOG", agent.Company);
            Assert.AreEqual(100, agent.Qty);
            Assert.AreEqual(12.5m, agent.TargetPrice);
        }

        [Test]
        public void ShouldInvokeTheBackendWhenTheHandlerIsInvokedWithTargetPriceForMatchingCompany()
        {
            agent.Handle("GOOG", 12.5m);

            EnsureBackendIsCalledWith("GOOG", 100, "sell");
        }

        [Test]
        public void ShouldInvokeTheBackendWhenTheHandlerIsInvokedWithLessThanTargetPriceForMatchingCompany()
        {
            agent.Handle("GOOG", 12.0m);

            EnsureBackendIsCalledWith("GOOG", 100, "sell");
        }

        [Test]
        public void ShouldNotInvokeTheBackendWhenTheHandlerIsInvokedWithMoreThanTargetPriceForMatchingCompany()
        {
            agent.Handle("GOOG", 12.9m);

            EnsureBackendIsNotCalled();
        }

        [Test]
        public void ShouldNotInvokeTheBackendWhenTheHandlerIsInvokedForNonMatchingCompanyAndMoreThanTargetPrice()
        {
            agent.Handle("MSFT", 12.9m);

            EnsureBackendIsNotCalled();
        }

        [Test]
        public void ShouldNotInvokeTheBackendWhenTheHandlerIsInvokedForNonMatchingCompanyAndLessThanTargetPrice()
        {
            agent.Handle("MSFT", 12.0m);

            EnsureBackendIsNotCalled();
        }

        [Test]
        public void ShouldNotInvokeTheBackendWhenTheHandlerIsInvokedForNonMatchingCompanyAndEqlThanTargetPrice()
        {
            agent.Handle("MSFT", 12.5m);

            EnsureBackendIsNotCalled();
        }

        [Test]
        public void ShouldTriggerSuccessEventIfBackendDidNotReportAnyFailure()
        {
            var successResponse = string.Empty;
            agent.Success += (sender, args) => successResponse = "OK";

            agent.Handle("GOOG", 12.0m);

            Assert.AreEqual("OK", successResponse);
        }

        [Test]
        public void ShouldTriggerFailedEventIfBackendReportsAnyFailure()
        {
            testDal.TriggerFailure = true;
            var failureResponse = string.Empty;
            agent.Failure  += (sender, args) => failureResponse = "failed";

            agent.Handle("GOOG", 12.0m);

            Assert.AreEqual("failed", failureResponse);
        }

        private void EnsureBackendIsNotCalled()
        {
            Assert.AreEqual(null, testDal.Company);
            Assert.AreEqual(0, testDal.Qty);
            Assert.AreEqual(null, testDal.OperationType);
        }

        private void EnsureBackendIsCalledWith(string c, int q, string opr)
        {
            Assert.AreEqual(c, testDal.Company);
            Assert.AreEqual(q, testDal.Qty);
            Assert.AreEqual(opr, testDal.OperationType);
        }

        private class TestDal : IDAL
        {
            public string Company { get; private set; }
            public int Qty { get; private set; }
            public string OperationType { get; private set; }
            internal bool TriggerFailure { get; set; }
            public void PostA(string name, int id)
            {
                if (this.TriggerFailure)
                {
                    this.TriggerFailure = false;
                    throw new BackendException("xxxxxxxxxxxx");
                }
                this.Company = name;
                this.Qty = id;
                this.OperationType = "sell";
            }

            public void PostB(string name, int id)
            {
                throw new System.NotImplementedException();
            }
        }

    }
}
