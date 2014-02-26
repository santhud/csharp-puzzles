using System;

namespace Core_With_Tests
{
    public interface IAgent
    {
        event EventHandler<SuccessEventArgs> Success;
        event EventHandler<FailureEventArgs> Failure;
    }
    public interface IPriceGenerator
    {
        void Handle(string name, decimal value);
    }
    public interface IDAL
    {
        void PostA(string name, int id);
        void PostB(string name, int id);
    }
    public class FailureEventArgs : EventArgs
    {
        public string ErrorMessage { get; set; }
    }
    public class SuccessEventArgs : EventArgs
    {
        public string StatusMessage { get; set; }
    }
    public class BackendException : Exception
    {
        public BackendException(string info)
            : base(info)
        {
        }
    }
}
