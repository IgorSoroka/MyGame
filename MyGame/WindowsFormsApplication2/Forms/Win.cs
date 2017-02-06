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
    //класс-форма, отображающий изображение при победе
    public partial class Win : Form
    {
        private Rectangle rect = new Rectangle(0, 0, 400, 400);
        private Bitmap picture = new Bitmap("win.jpg");        

        public Win()
        {
            InitializeComponent();            
        } 

        private void Win_Paint(object sender, PaintEventArgs e)
        {
            Bitmap win = new Bitmap(picture, new Size(400, 400));
            Graphics graphics = e.Graphics;
            graphics.DrawImage(win, rect);
        }
    }
}