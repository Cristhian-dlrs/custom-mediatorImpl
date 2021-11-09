namespace InvertApp.Interfaces
{
    public interface IMediator 
    {
        TResponse Send<TResponse>(IRequest<TResponse> request);
    }
}