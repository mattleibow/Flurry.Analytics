using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PortableClassLibrary
{
    public static class TaskExtensions
    {
        public static Task Delay(this TaskFactory factory, int milliseconds)
        {
            var tcs = new TaskCompletionSource<object>();
            new Timer(_ => tcs.SetResult(null), null, milliseconds, -1);
            return tcs.Task;
        }
    }
}
