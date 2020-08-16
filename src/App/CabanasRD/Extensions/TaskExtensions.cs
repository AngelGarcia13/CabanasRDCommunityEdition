using System;
using System.Threading.Tasks;

namespace CabanasRD.Extensions
{
    public static class TaskExtensions
    {
        public static async void Await(this Task task, Action completedCallback, Action<Exception> errorCallBack)
        {
            try
            {
                await task;
                completedCallback?.Invoke();
            }
            catch (Exception exception)
            {
                errorCallBack?.Invoke(exception);
            }
        }
    }
}
