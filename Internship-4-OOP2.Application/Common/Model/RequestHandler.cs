namespace Internship_4_OOP2.Application.Common.Model
{
    public abstract class RequestHandler<TRequest, TResult> where TRequest : class where TResult : class
    {
        public Guid RequestId => Guid.NewGuid();
    }
}
