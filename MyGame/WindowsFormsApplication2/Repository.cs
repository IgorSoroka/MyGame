using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    //статический класс репозитория для хранения ссылок на начальные изображения
    public static class Repository
    {
        private static BindingList<Bitmap> pics;

        public static BindingList<Bitmap> Pics
        {
            get
            {
                return pics;
            }

            set
            {
                pics = value;
            }
        }

        static Repository()
        {
            Pics = new BindingList<Bitmap>()
            {
               new Bitmap("1.jpg"),
               new Bitmap("2.jpg"),
               new Bitmap("3.jpg"),
               new Bitmap("4.jpg"),
               new Bitmap("5.jpg"),
               new Bitmap("6.jpg"),
            };
        }
    }
}