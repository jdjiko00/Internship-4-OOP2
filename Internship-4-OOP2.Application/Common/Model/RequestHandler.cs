namespace Internship_4_OOP2.Application.Common.Model
{
    public abstract class RequestHandler<TRequest, TResult> where TRequest : class where TResult : class
    {
        public Guid RequestId => Guid.NewGuid();

        public async Task<Result<TResult>> ProcessAuthorizedRequestAsync(TRequest request)
        {
            var result = new Result<TResult>();

            if (!await IsAuthorized())
            {
                result.SetUnauthorizedResult();
                return result;
            }

            await HandleRequest(request, result);

            return result;
        }

        protected abstract Task HandleRequest(TRequest request, Result<TResult> result);

        protected abstract Task<bool> IsAuthorized();
    }
}
