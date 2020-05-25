using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1         
{
    public partial class Form1 : Form
    {
        public Bitmap mainMenuBackground = Resource1.mainMenu;
        public Bitmap firstLevelBackground = Resource1.firstLevel;
        public Bitmap secondLevelBackground = Resource1.secondLevel;
        public bool firstLevel = false;
        public int circleCount = 49;
        List<int> arrayCircles;
        List<int> arrayCircles2;
        int mouseClick_X, mouseClick_Y;
        int chosenCircle_i, chosenCircle_j;
        int usersStep = 1;
        Graphics g;
        Bitmap bmp;
        CirclesListCreator levelFirst;
        CirclesArrayModification FLmodification;
        CirclesListCreator levelSecond;
        CirclesArrayModification SLmodification;
        int i = 82;
        int delta_i = 90;
        int j = 184;
        int delta_j = 95;
        private int i2 = 15;
        private int delta_i2 = 89;
        private int j2 = 86;
        private int delta_j2 = 86;
        private bool helpForFirstM = false;
        private bool helpForSecondM = true;
        private bool canDoSecondStep = false;
        bool b_;
        bool mainManu = true;
        int restartLevel = 1;
        int pig = 1;

        private void Button1_Click(object sender, EventArgs e)
        {
            FirstLevel();
            button2.Visible = true;
        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (canDoSecondStep == false && !mainManu)
            {
                FullArrayCircles firstLevelEnd = new FullArrayCircles();
                helpForFirstM = firstLevelEnd.IsEnd(49, arrayCircles);
                if (helpForFirstM && helpForSecondM)
                {
                    MessageBox.Show("Congratulations!!!!");
                    SecondLevel();
                    helpForSecondM = false;
                    helpForFirstM = false;
                }
                if (helpForFirstM == false && helpForSecondM)
                {
                    if (usersStep % 2 == 1 && pig % 2 == 1)
                    {
                        Refresh();

                        mouseClick_X = e.X;
                        mouseClick_Y = e.Y;

                        chosenCircle_i = (mouseClick_X - 85) / 90;
                        chosenCircle_j = (mouseClick_Y - 185) / 100;

                        FLmodification = new CirclesArrayModification(arrayCircles, 49, chosenCircle_i, chosenCircle_j, 1, 1);

                        FirstLevel FL = new FirstLevel(i, delta_i, j, delta_j);
                        FL.Draw(g, FLmodification.GetList());

                        pig++;

                        Refresh();
                    }
                    if (usersStep % 2 == 0 && pig % 2 == 0)
                    {
                        Refresh();

                        mouseClick_X = e.X;
                        mouseClick_Y = e.Y;

                        chosenCircle_i = (mouseClick_X - 85) / 90;
                        chosenCircle_j = (mouseClick_Y - 185) / 100;

                        FLmodification = new CirclesArrayModification(arrayCircles, 49, chosenCircle_i, chosenCircle_j, 2, 2);

                        FirstLevel FL = new FirstLevel(i, delta_i, j, delta_j);
                        FL.Draw(g, FLmodification.GetList());

                        pig++;

                        Refresh();
                    }
                }
            }

            else if (!mainManu)
            {
                FullArrayCircles secondLevelEnd = new FullArrayCircles();
                b_ = secondLevelEnd.IsEnd(81, arrayCircles2);
                if (b_)
                {
                    MessageBox.Show("Congratulations!!!!");
                    Close();
                }
                if (b_ == false)
                {
                    if (usersStep % 2 == 1 && pig % 2 == 1)
                    {
                        Refresh();

                        mouseClick_X = e.X;
                        mouseClick_Y = e.Y;

                        chosenCircle_i = (mouseClick_X - 12) / 85;
                        chosenCircle_j = (mouseClick_Y - 90) / 84;

                        SLmodification = new CirclesArrayModification(arrayCircles2, 81, chosenCircle_i, chosenCircle_j, 1, 1);

                        SecondLevel SL = new SecondLevel(i2, delta_i2, j2, delta_j2);
                        SL.Draw(g, SLmodification.GetList());

                        pig++;

                        Refresh();
                    }
                    if (usersStep % 2 == 0 && pig % 2 == 0)
                    {
                        Refresh();

                        mouseClick_X = e.X;
                        mouseClick_Y = e.Y;

                        chosenCircle_i = (mouseClick_X - 12) / 85;
                        chosenCircle_j = (mouseClick_Y - 90) / 84;

                        SLmodification = new CirclesArrayModification(arrayCircles2, 81, chosenCircle_i, chosenCircle_j, 2, 2);

                        SecondLevel SL = new SecondLevel(i2, delta_i2, j2, delta_j2);
                        SL.Draw(g, SLmodification.GetList());

                        pig++;

                        Refresh();
                    }
                }
            }
        }

        public Form1()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.UserPaint,
                true);

            UpdateStyles();
            button2.Visible = false;
            button3.Visible = false;
            button5.Visible = false;
            MainMenu();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            usersStep++;

            if (usersStep % 2 == 1)
            {
                button2.Text = "to tan step";
            }
            else
            {
                button2.Text = "to black step";
            }
        }

        private void MainMenu()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            g.DrawImage(mainMenuBackground, new Rectangle(0, 0, mainMenuBackground.Width, mainMenuBackground.Height));
            pictureBox1.Image = bmp;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            usersStep++;

            if (usersStep % 2 == 1)
            {
                button3.Text = "to tan step";
            }
            else
            {
                button3.Text = "to black step";
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (restartLevel == 1)
            {
                FirstLevel();
            }
            if(restartLevel == 2)
            {
                SecondLevel();
            }
        }

        private void FirstLevel()
        {
            button1.Visible = false;
            button5.Visible = true;

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);

            levelFirst = new CirclesListCreator();
            FirstLevel firstLevel = new FirstLevel(i, delta_i, j, delta_j);

            arrayCircles = levelFirst.GetList();

            firstLevel.DrawBackground(g);
            firstLevel.Draw(g, arrayCircles);

            Refresh();

            mainManu = false;

            pictureBox1.Image = bmp;
        }

        private void SecondLevel()
        {
            restartLevel = 2;
            pig = 1;
            usersStep = 1;

            Refresh();

            button4.Left = 11;
            button4.Top = 11;
            button5.Top = 11;

            button2.Visible = false;
            button3.Visible = true;

            levelSecond = new CirclesListCreator(81);
            SecondLevel secondLevel = new SecondLevel(i2, delta_i2, j2, delta_j2);

            arrayCircles2 = levelSecond.GetList();

            secondLevel.DrawBackground(g);
            Refresh();
            secondLevel.Draw(g, arrayCircles2);
            Refresh();

            canDoSecondStep = true;
        }
    }

    class CirclesListCreator
    {
        public List<int> arrayCircles;
        int count;

        public CirclesListCreator(int x = 49)
        {
            count = x;
            arrayCircles = new List<int>();
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                int simp = rnd.Next(1, 3);
                arrayCircles.Add(simp);
            }
        }

        public List<int> GetList()
        {
            return arrayCircles;
        }
    }

    class CirclesArrayModification 
    {
        List<int> arrayCircles;

        public CirclesArrayModification(List<int> arrFrom, int count, int chosenCircle_i, int chosenCircle_j, int colour, int typeOfChange) 
        {
            arrayCircles = arrFrom;

            double countDb = Math.Sqrt(Convert.ToDouble(count));
            int[,] arr = new int[(int)countDb, (int)countDb];

            int k = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = arrayCircles[k];
                    k++;
                }
            }

            Random rnd = new Random();
            int typeOfString = rnd.Next(1, 3);
            if (typeOfString == 1)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    arr[chosenCircle_i, j] = typeOfChange;
                }
            }
            else if (typeOfString == 2)
            {
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    arr[i, chosenCircle_j] = typeOfChange;
                }
            }
            arrayCircles.Clear();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arrayCircles.Add(arr[i, j]);
                }
            }
        }

        public List<int> GetList()
        {
            return arrayCircles;
        }
    }

    class FullArrayCircles 
    {
        int victory_1 = 0;
        int victory_2 = 0;

        public bool IsEnd(int count, List<int> arrayCircles) 
        {
            for (int i = 0; i < count; i++)
            {
                if (arrayCircles[i] == 1)
                    victory_1++;
                else
                    victory_2++;
            }
            if (victory_1 == count)
            {
                return true;
            }
            if (victory_2 == count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    abstract class Level
    {
        private int _i;
        private int delta_i;
        private int _j;
        private int delta_j;

        public Level(int _i, int delta_i, int _j, int delta_j)
        {
            this._i = _i;
            this.delta_i = delta_i;
            this._j = _j;
            this.delta_j = delta_j;
        }

        public void Draw(Graphics g, List<int> arr)
        {
            int listCount = 0;

            for (int i = _i; i < 790; i = i + delta_i)
            {
                for (int j = _j; j < 820; j = j + delta_j)
                {
                    if (listCount == arr.Count())
                    {
                        break;
                    }
                    if (arr[listCount] == 1)
                    {
                        g.DrawEllipse(new Pen(Color.Black, 5), i, j, 75, 75);
                        g.FillEllipse(new SolidBrush(Color.Black), i, j, 75, 75);
                        listCount++;
                    }
                    else if (arr[listCount] == 2)
                    {
                        g.DrawEllipse(new Pen(Color.Black, 5), i, j, 75, 75);
                        g.FillEllipse(new SolidBrush(Color.Tan), i, j, 75, 75);
                        listCount++;
                    }
                }
            }
        }
        public abstract void DrawBackground(Graphics g);
    }

    class FirstLevel : Level
    {
        //private int i = 82;
        //private int delta_i = 90;
        //private int j = 184;
        //private int delta_j = 95;

        public FirstLevel(int i, int delta_i, int j, int delta_j) : base(i, delta_i, j, delta_j)
        {
        }

        public override void DrawBackground(Graphics g)
        {
            g.DrawImage(Resource1.firstLevel, new Rectangle(0, 0, 790, 864));
        }
    }

    class SecondLevel : Level
    {
        //private int i = 15;
        //private int delta_i = 89;
        //private int j = 86;
        //private int delta_j = 86;

        public SecondLevel(int i, int delta_i, int j, int delta_j) : base(i, delta_j, j, delta_j)
        {
        }

        public override void DrawBackground(Graphics g)
        {
            g.DrawImage(Resource1.secondLevel, new Rectangle(0, 0, 790, 864));
        }
    }
}