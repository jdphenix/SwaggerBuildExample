namespace WebApplication2
{
    public static class TaskExtensions
    {
        public static async Task<Result<T>> UnwrapError<T>(this Task<T> task, ILogger logger) where T : class
        {
            try
            {
                var result = await task;
                return await Task.FromResult(new Result<T>(result, null));
            }
            catch (ApiException<ProblemDetails> ex)
            {
                logger.LogWarning(
                    "ApiException ({Url}): {Title}: {Detail}", 
                    ex.Result.Type, 
                    ex.Result.Title, 
                    ex.Result.Detail);

                return await Task.FromResult(new Result<T>(null, ex.Result));
            }
        }
    }
}