using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skateclub_installer.Screens
{
    public partial class FinishScreen : UserControl, IScreen
    {
        public FinishScreen()
        {
            InitializeComponent();
        }

        public string WindowTitle => throw new NotImplementedException();

        public Control ScreenControl => throw new NotImplementedException();

        public async Task<bool> Close() => true;
    }
}
