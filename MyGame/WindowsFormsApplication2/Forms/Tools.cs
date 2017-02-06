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
    //класс-форма для выбора уровня сложности игры
    public partial class Tools : Form
    {
        private int key;

        public int Key
        {
            get
            {
                return key;
            }

            private set
            {
                key = value;
            }
        }

        public Tools()
        {
            InitializeComponent();            
        }
        //события, срабатывающее при выборе уровня сложности и нажатии кнопки Ок
        private void btnOk_Click(object sender, EventArgs e)
        {
            RadioButton level = GetChecked();
            key = Int32.Parse(level.Tag.ToString());//приведение значения тага, выбранного RadioButton к int
            this.DialogResult = DialogResult.OK;
        }
        //метод, возвращающий выбранный RadioButton
        private RadioButton GetChecked()
        {
            RadioButton rb = new RadioButton();
            foreach (RadioButton item in rbTools.Controls)
            {
                if (item.Checked)
                { 
                    rb = item;
                    break;
                }
            }
            return rb;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}