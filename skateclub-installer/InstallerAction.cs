using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skateclub_installer
{
    public struct OpResult
    {
        public bool success;
        public object response;
    }
    public interface IInstallerOperation
    {
        bool CanCancelOperation { get; }

        string Status { get; }
        float Progress { get; }

        Task<OpResult> Perform();
        Task Terminate();
    }

    public interface IScreen
    {
        string WindowTitle { get; }
        Control ScreenControl { get; }

        Task<bool> Close();
    }
}
