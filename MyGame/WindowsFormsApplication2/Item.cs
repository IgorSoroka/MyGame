using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class Item : IComparable<Item>
    {
        private Bitmap pic;
        private int number;

        public Bitmap Pic
        {
            get
            {
                return pic;
            }

            set
            {
                pic = value;
            }
        }

        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                number = value;
            }
        }

        public int CompareTo(Item other)
        {
            if (this.Number > other.Number)
                return 1;
            if (this.Number < other.Number)
                return -1;
            else
                return 0;
        }
    }
}
