using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class GameForm : Form
    {
        private Bitmap bmp;//переменная для хранения исходного рисунка или рисунока пользователя
        private Bitmap newPicPart;//переменная для хранения рисунка для работы в программе
        private List<Item>pictures = new List<Item>();//коллекция элементов Item, которые будут отображены на элементах Button    
        private List<Button>buttons = new List<Button>();//коллекция Button, которые будут отображены на форме
        private int size = 600;//переменная, хранящая размер игрового поля
        private int count = 4;//количество частей, на которое нужно разделить игровое поле (уровень сложности), начальное значение - 4
        private int indexInList;

        public GameForm()
        {
            InitializeComponent();            
        }
        //событие, срабатывающее при нажатии на любой элемент из коллекции buttons и перемещающий, если это возможно, изображение на пустое место
        private void Clicked(Object sender, EventArgs e)
        {               
            Button clbutton = (Button)sender;
            Button freebutton = FindFreeButton(clbutton);//с помощью метода FindFreeButton находим пустую кнопку по-соседству или null, если ее нет

            int first = buttons.IndexOf(clbutton);
            int second = buttons.IndexOf(freebutton);

            if (freebutton != null)
            {
                bool flag = false;
                Item temp = null;                

                freebutton.Image = clbutton.Image;//обмениваем изображения кнопок
                clbutton.Image = null;

                temp = pictures[first];//меняем положение соответсвующих изображений в листе pictures
                pictures[first] = pictures[second];
                pictures[second] = temp;

                for (int i = 0; i < pictures.Count; i++)//проверяем, на выигрыш - все ли пордковые номера картинок (number) расположены по очереди
                {
                    if (pictures[i].Number == i)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag == true)
                {
                    Win child = new Win();
                    child.ShowDialog();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap("1.jpg");
            newPicPart = new Bitmap(bmp, new Size(size, size));
            PaintButtons();            
        }
        //событие, срабатывающее при нажатии на элемент "Перемешать", которое перемешивает и отображает на форме части изображения в рандомном порядке
        private void miShake_Click(object sender, EventArgs e)
        {
            Mix();
            Painting();
        }
        //событие, срабатывающее при нажатии на элемент "Настройки", отображающее форму-Tools и меняющее уровень сложности (количество частей рисунка) игры 
        private void miTools_Click(object sender, EventArgs e)
        {
            using (Tools child = new Tools())
            {
                child.StartPosition = FormStartPosition.CenterScreen;

                DialogResult dr = child.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    RemoveAllButtons();
                    count = child.Key;
                    PaintButtons();
                }               
            }           
        }
        //событие, срабатывающее при нажатии на элемент "Восстановить", которое восстанавливает порядок элементов на форме
        private void miRecover_Click(object sender, EventArgs e)
        {
            pictures.Sort();
            Painting();
        }
        //событие, срабатывающее при нажатии на элемент с номером изображения и отображающее его на форме
        private void ts_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem click = (ToolStripMenuItem)sender;

            int key = Int32.Parse(click.Tag.ToString());//записываем в переменную key, значение тага, выбранного элемента ToolStripMenuItem

            bmp = Repository.Pics[key];
            newPicPart = new Bitmap(bmp, new Size(size, size));

            RemoveAllButtons();
            PaintButtons();
        }
        //событие, срабатывающее при нажатии на элемент "помощь" и отображающее форму-помощь
        private void tsHelp_Click(object sender, EventArgs e)
        {
            HelpForm child = new HelpForm(newPicPart);
            child.ShowDialog();
        }
        //событие, срабатывающее при нажатии на элемент "загрузить файл" и отображающиее на форме выбранное изображение
        private void tsMenuOpenFile_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.ShowDialog();

            if (!String.IsNullOrWhiteSpace(openFileDialog1.FileName))
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            bmp = new Bitmap(openFileDialog1.FileName);
                            newPicPart = new Bitmap(bmp, new Size(size, size));

                            RemoveAllButtons();
                            PaintButtons();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно загрузить файл. Ошибка: " + ex.Message);
                }
            }
        }
        /// <summary>
        /// метод, удаляющий все кнопки с формы
        /// </summary>
        private void RemoveAllButtons()
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is Button)
                {
                    this.Controls.RemoveAt(i);
                    i--;
                }
            }
        }
        /// <summary>
        /// метод, перерисовывающий кнопки с изображениями на форме
        /// </summary>
        private void PaintButtons()
        {
            buttons.Clear();
            pictures.Clear();
            DivisionPictureOnParts();
            DivisionFieldOnParts();
            Painting();
        }
        /// <summary>
        /// метод, перемешивающий кнопки на форме
        /// </summary>
        private void Mix()
        {
            var rand = new Random();
            for (int i = pictures.Count - 1; i >= 0; i--)
            {
                int j = rand.Next(i);
                var temp = pictures[i];
                pictures[i] = pictures[j];
                pictures[j] = temp;
            }
        }
        /// <summary>
        /// метод, разделяющий изображение на необходимое количество частей
        /// </summary>
        private void DivisionPictureOnParts()
        {
            indexInList = 0;
            for (int i = 0, n = size / count; i <= ((size / count) * (count - 1)); i += size / count)
            {
                for (int j = 0, m = size / count; j <= ((size / count) * (count - 1)); j += size / count)
                {
                    pictures.Add(new Item { Number = indexInList, Pic = newPicPart.Clone(new Rectangle(j, i, m, n), PixelFormat.DontCare) });
                    indexInList++;
                }
            }
            pictures[pictures.Count - 1].Pic = null;
        }
        /// <summary>
        /// метод, делящий форму на необходимое число частей и добавляющий кнопки расположенные на этих частях в контролы формы
        /// </summary>
        private void DivisionFieldOnParts()
        {
            for (int i = 25, n = size / count; i <= (((size / count) * (count - 1) + 25)); i += size / count)
            {
                for (int j = 0, m = size / count; j <= ((size / count) * (count - 1)); j += size / count)
                {
                    Button but = new Button();
                    but.Location = new Point(j, i);
                    but.Size = new Size(m, n);
                    buttons.Add(but);

                    but.Click += new EventHandler(this.Clicked);
                    this.Controls.Add(but);
                }
            }
        }  
        /// <summary>
        /// метод, который ищет есть ли по соседству с нажатой кнопкой пустой кнопки 
        /// </summary>
        /// <param name="clicked">ссылка на нажатую кнопку</param>
        /// <returns>пустая кнопка или null если такой нет</returns>
        private Button FindFreeButton(Button clicked)
        {
            int index = buttons.IndexOf(clicked);//находим индекс нажатой кнопки
            Button free = null;

            if(index >= count)
            {
                if(buttons[index - count].Image == null)
                      free = buttons[index - count];
            }

            if(index < (count * count - count))
            {
                if (buttons[index + count].Image == null)
                      free = buttons[index + count];                
            }

            if (index % count != 0)
            {
                if (buttons[index - 1].Image == null)
                      free = buttons[index - 1];
                
            }

            if(((index + 1) % count) != 0)
            {
                if (buttons[index + 1].Image == null)
                     free = buttons[index + 1];                
            }
            return free;
        }
        /// <summary>
        /// метод, помещающий изображения из коллекции pictures на элементы из коллекции buttons
        /// </summary>
        private void Painting()
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Image = pictures[i].Pic;
            }
        }
    }
}