using skateclub_installer.Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skateclub_installer
{
    public partial class Window : Form
    {
        public static Window instance;

        static bool finished;

        public Window()
        {
            InitializeComponent();

            FormClosing += async (s, a) =>
            {
                if(!finished)
                    a.Cancel = !await activeScreen.Close();
            };

            instance = this;
        }

        public static IScreen activeScreen { get; private set; }

        public static DialogResult MessageError(string text, MessageBoxButtons buttons = MessageBoxButtons.OK) => MessageBox.Show(text, "skateclub", buttons, MessageBoxIcon.Error);
        public static DialogResult MessageWarning(string text, MessageBoxButtons buttons = MessageBoxButtons.OK) => MessageBox.Show(text, "skateclub", buttons, MessageBoxIcon.Warning);
        public static DialogResult Message(string text, MessageBoxButtons buttons = MessageBoxButtons.OK) => MessageBox.Show(text, "skateclub", buttons, MessageBoxIcon.Information);

        public static readonly Timer UIUpdateClock = new Timer();

        public static void Finished()
        {
            finished = true;
            instance.Close();
        }

        public static void SetScreen(IScreen screen)
        {
            if (activeScreen != null)
            {
                instance.screenPanel.Controls.Add(activeScreen.ScreenControl);
                activeScreen.ScreenControl.Hide();
            }

            instance.screenPanel.Controls.Add(screen.ScreenControl);

            screen.ScreenControl.Location = new Point(0, 0);
            screen.ScreenControl.Size = instance.screenPanel.Size;

            screen.ScreenControl.Anchor = instance.screenPanel.Anchor;

            screen.ScreenControl.Update();

            activeScreen = screen;
        }

        private void discordBox_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/skateclub");
        }

        private void Window_Load(object sender, EventArgs e)
        {
            SetScreen(new SetupScreen());

            UIUpdateClock.Interval = 50;
            UIUpdateClock.Start();
            UIUpdateClock.Tick += (s, a) =>
            {
                if (activeScreen != null)
                    Text = $"skateclub Installer - {activeScreen.WindowTitle}";
            };
        }

        private void logo_Click(object sender, EventArgs e)
        {
            Message("Made by Meerkat <3");
        }
    }
}
