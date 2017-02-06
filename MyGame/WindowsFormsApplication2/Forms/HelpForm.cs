using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    //класс для отображения формы-помощи, показывающей изображение целиком
    public partial class HelpForm : Form
    {
        private Rectangle rect = new Rectangle(0, 0, 600, 600);
        private Bitmap picture;

        public HelpForm(Bitmap pic)
        {
            InitializeComponent();
            picture = pic;
            this.Text = "Картинка целиком!";
        }

        private void HelpForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImage(picture, rect);
        }
    }
}
