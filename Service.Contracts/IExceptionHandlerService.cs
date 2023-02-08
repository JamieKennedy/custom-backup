namespace Service.Contracts
{
    public interface IExceptionHandlerService
    {
        void HandleException(Exception ex);
    }
}