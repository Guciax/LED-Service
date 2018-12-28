using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LED_Service
{
    public partial class ShowFailureImages : Form
    {
        private readonly List<Image> imgList;

        public ShowFailureImages(List<Image> imgList)
        {
            InitializeComponent();
            this.imgList = imgList;
        }

        private void ShowFailureImages_Load(object sender, EventArgs e)
        {
            foreach (var img in imgList)
            {
                PictureBox picBox = new PictureBox();
                picBox.Image = img;
                picBox.MouseClick += PicBox_MouseClick;
                picBox.SizeMode = PictureBoxSizeMode.Zoom;
                flowLayoutPanel1.Controls.Add(picBox);
            }

            if (flowLayoutPanel1.Controls.Count>0)
            {
                PictureBox pb = (PictureBox)flowLayoutPanel1.Controls[0];
                pictureBox1.Image = pb.Image;
            }
        }

        private void PicBox_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox thumb = (PictureBox)sender;
            pictureBox1.Image = thumb.Image;
        }
    }
}
