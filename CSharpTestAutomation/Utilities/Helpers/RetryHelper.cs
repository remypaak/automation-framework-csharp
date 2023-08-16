namespace CloseTestAutomation.Utilities.Helpers
{
    public interface IRetryCondition<TResult>
    {
        TResult Until(Func<TResult, bool> condition);
    }

    public class RetryCondition<TResult> : IRetryCondition<TResult>
    {
        private TResult _value;
        private Func<IRetryCondition<TResult>> _retry;

        public RetryCondition(TResult value, Func<IRetryCondition<TResult>> retry)
        {
            _value = value;
            _retry = retry;
        }

        public TResult Until(Func<TResult, bool> condition)
        {
            return condition(_value) ? _value : _retry().Until(condition);
        }
    }
    public static class Retry
    {
        // Return an IRetryCondition<T> instance
        public static IRetryCondition<T> RetryUntilConditionIsMet<T>(
           Func<T> action,
           TimeSpan retryInterval,
           int retryCount = 3)
        {
            var exceptions = new List<Exception>();

            for (int retry = 0; retry < retryCount; retry++)
            {
                try
                {
                    if (retry > 0)
                        Thread.Sleep(retryInterval);
                    return new RetryCondition<T>(action(), () => RetryUntilConditionIsMet(action, retryInterval, retryCount));
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }

            throw new AggregateException(exceptions);
        }
    }
}
