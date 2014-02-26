using System;

namespace Core_With_Tests
{
    public class Agent : IAgent, IPriceGenerator
    {
        public string Company { get; private set; }
        public int Qty { get; private set; }
        public decimal TargetPrice { get; private set; }
        public IDAL Dal { get; private set; }

        public Agent(string company, int qty, decimal targetPrice, IDAL dal)
        {
            this.Company = company;
            this.Qty = qty;
            this.TargetPrice = targetPrice;
            this.Dal = dal;
        }
        
        public event EventHandler<SuccessEventArgs> Success;
        public event EventHandler<FailureEventArgs> Failure;
        
        public void Handle(string name, decimal value)
        {
            if (!IsOkToBuyStockFor(name, value))
            {
                return;
            }
            try
            {
                this.Dal.PostA(Company, Qty);
                var tmpS = this.Success;
                if (tmpS != null)
                {
                    this.Success(this, new SuccessEventArgs { StatusMessage = "Success" });
                }
            }
            catch (BackendException bex)
            {
                var tmpF = this.Failure;
                if (tmpF != null)
                {
                    this.Failure(this, new FailureEventArgs { ErrorMessage = string.Format("something went wrong. Detials:{0}", bex.InnerException) });
                }
            }
        }

        private bool IsOkToBuyStockFor(string name, decimal value)
        {
            return value <= this.TargetPrice && name.Equals(this.Company);
        }
    }
}
