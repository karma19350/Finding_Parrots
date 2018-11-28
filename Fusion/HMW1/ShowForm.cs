using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMW1
{
    public partial class ShowForm : Form
    {
        public ShowForm(Bitmap Image)
        {
            InitializeComponent();
            this.Width = Image.Width;
            this.Height = Image.Height;
            this.pictureBox1.Image = new Bitmap(Image);
        }

    }
}
