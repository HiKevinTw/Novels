using System.Windows.Forms;

namespace Novels.Machine.Jobs
{
    static class Extension
    {
        /// <summary>
        /// 若有需要的話，做援引呼叫。
        /// </summary>
        /// <param name="control"></param>
        /// <param name="action"></param>
        public static void InvokeIfNecessary(this Control control, MethodInvoker action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}
