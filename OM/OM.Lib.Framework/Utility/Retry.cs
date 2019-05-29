using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Lib.Framework.Utility
{
    public static class Retry
    {
        public static void RetryAction(Action action, int numRetries, int retryTimeout)
        {
            if (action == null)
                throw new ArgumentNullException("action");
            do
            {
                try
                {
                    action();
                    return;
                }
                catch
                {
                    if (numRetries <= 0) throw;
                    else System.Threading.Thread.Sleep(retryTimeout);
                }
            } while (numRetries-- > 0);
        }
    }
}
