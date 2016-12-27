using System;
using System.Drawing;
using System.Windows.Forms;

namespace Notification
{
    public partial class FormTest : Form
    {
        private Image img;
        private Color _color;
        private string _soundPath;
        public FormTest()
        {
            InitializeComponent();
        }

        private void buttonImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog of = new OpenFileDialog())
            {
                if (of.ShowDialog() == DialogResult.OK)
                {
                    img = Image.FromFile(of.FileName);
                }
            }
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {

            NodeNotification notification = new NodeNotification(img, textBoxTitle.Text, textBoxMessage.Text, _color);
            if (_soundPath != null)
                notification.SoundPath = _soundPath;
            if (numericUpDownSeconds.Value > 0)
                notification.Seconds = (int)numericUpDownSeconds.Value;
            notification.Show();
        }

        private void buttonPickColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog dialog = new ColorDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxColor.CreateGraphics().Clear(dialog.Color);
                    _color = dialog.Color;
                }
            }
        }

        private void buttonPickSound_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog of = new OpenFileDialog())
            {
                if (of.ShowDialog() == DialogResult.OK)
                {
                    _soundPath = of.FileName;
                }
            }
        }
    }
}
