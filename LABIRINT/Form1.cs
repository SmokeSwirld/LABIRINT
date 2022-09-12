namespace LABIRINT
{
    public partial class Form1 : Form
    {
        private Button buttonPLAYER = new Button();
        private int cordX = 1;
        private int cordY = 1;
        private int randoms = 2;
        private int[] array = new int[2];
        private const int height = 51;
        private const int width = 29;
        private Button[,] buttonLOC = new Button[height, width];
        private Button[] buttonBUM = new Button[100];
        private Button[] buttonEnergy = new Button[30];
        private Button[] buttonXP = new Button[30];
        private Button[] buttonMedal = new Button[30];
        private bool[,] buttonLOC2 = new bool[height, width];

        private int playrX = 0;
        private int playrY = 1;
        private int playrEnergy = 1000;
        private int playrXP = 2000;
        private int playrMedal = 0;

        public Form1()
        {
            MaximumSize = new Size(832, 503);
            MinimumSize = new Size(832, 503);
            BackgroundImage = new Bitmap(@"C:\1\hall.png");
            StartPosition = FormStartPosition.CenterScreen;
            generate();
            InitializeComponent();
            KeyPreview = true;
            KeyDown += Form1_KeyDown;
        }
        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W && buttonLOC2[playrX, playrY - 1] == true)
            {
                buttonPLAYER.Location = new Point(buttonPLAYER.Location.X, buttonPLAYER.Location.Y - 16);
                playrY--;
                playrEnergy -= 5;
                
            }
            if (e.KeyCode == Keys.S && buttonLOC2[playrX, playrY + 1] == true)
            {
                buttonPLAYER.Location = new Point(buttonPLAYER.Location.X, buttonPLAYER.Location.Y + 16);
                playrY++;
                playrEnergy -= 5;
                
            }
            if (e.KeyCode == Keys.A && buttonLOC2[playrX - 1, playrY] == true && buttonPLAYER.Location.X>=0)
            {
                buttonPLAYER.Location = new Point(buttonPLAYER.Location.X - 16, buttonPLAYER.Location.Y);
                playrX--;
                playrEnergy -= 5;
               
            }
            if (e.KeyCode == Keys.D && buttonLOC2[playrX + 1, playrY] == true)
            {
                buttonPLAYER.Location = new Point(buttonPLAYER.Location.X + 16, buttonPLAYER.Location.Y);
                playrX++;
                playrEnergy -= 5;
                
            }
            BUM();
            Text = buttonPLAYER.Location.ToString() + "  Energy : " + playrEnergy.ToString() 
                + "  XP : "+ playrXP.ToString()+"  Medals : "+ playrMedal.ToString();
            if(buttonPLAYER.Location.X==800) 
            {
                MessageBox.Show("you win");
            }
        }
        private void BUM() 
        {
            for (int i = 0; i < 100; i++)
            {
                if (buttonPLAYER.Location.X == buttonBUM[i].Location.X
                     && buttonPLAYER.Location.Y == buttonBUM[i].Location.Y
                     && buttonBUM[i].Visible == true)
                {
                    playrXP -= 100;
                    buttonBUM[i].Visible = false;
                }
            }
            for (int i = 0; i < 30; i++)
            {
                if (buttonPLAYER.Location.X == buttonEnergy[i].Location.X
                     && buttonPLAYER.Location.Y == buttonEnergy[i].Location.Y
                     && buttonEnergy[i].Visible == true)
                {
                    playrEnergy += 100;
                    buttonEnergy[i].Visible = false;
                }
                if (buttonPLAYER.Location.X == buttonXP[i].Location.X
                     && buttonPLAYER.Location.Y == buttonXP[i].Location.Y
                     && buttonXP[i].Visible == true)
                {
                    playrXP += 500;
                    buttonXP[i].Visible = false;
                }
                if (buttonPLAYER.Location.X == buttonMedal[i].Location.X
                     && buttonPLAYER.Location.Y == buttonMedal[i].Location.Y
                     && buttonMedal[i].Visible == true)
                {
                    playrMedal++;
                    buttonMedal[i].Visible = false;
                }
            }
        }
        private void generate()
        {
            buttonPLAYER = new Button();
            buttonPLAYER.Text = "";
            buttonPLAYER.Image = new Bitmap(@"C:\1\PL.png");
            buttonPLAYER.Location = new Point(0, 16);
            buttonPLAYER.Size = new Size(16, 16);
            Controls.Add(buttonPLAYER);

            for (int i = 0; i < 10000; i++)
            {
                Movetractor();
            }
            buttonLOC2[0, 1] = true;
            buttonLOC2[50, 10] = true;
            buttonLOC2[49, 10] = true;
            for (int i = 0; i < height; i++)// создание текстур для лабиринта
            {
                for (int j = 0; j < width; j++)
                {
                    if (buttonLOC2[i, j] == false)
                    {
                        buttonLOC[i, j] = new Button();
                        buttonLOC[i, j].Text = "";
                        buttonLOC[i, j].Location = new Point(i * 16, j * 16);
                        buttonLOC[i, j].Size = new Size(16, 16);
                        buttonLOC[i, j].BackColor = Color.Black;
                        Controls.Add(buttonLOC[i, j]);
                    }              
                }
            }
            for (int i = 0; i < 100; i++)
            {
                int a = new Random().Next(1, 50);
                int b = new Random().Next(1, 27);
                if (buttonLOC2[a, b] == true)
                {
                    buttonBUM[i] = new Button();
                    buttonBUM[i].Text = "";
                    buttonBUM[i].Location = new Point(a * 16, b * 16);
                    buttonBUM[i].Size = new Size(16, 16);
                    buttonBUM[i].BackColor = Color.Red;
                    Controls.Add(buttonBUM[i]);
                    
                }
                else i--;
            }
            for (int i = 0; i < 30; i++) 
            {
                int a = new Random().Next(1, 50);
                int b = new Random().Next(1, 27);
                if (buttonLOC2[a, b] == true )
                {
                    buttonEnergy[i] = new Button();
                    buttonEnergy[i].Text = "";
                    buttonEnergy[i].Location = new Point(a * 16, b * 16);
                    buttonEnergy[i].Size = new Size(16, 16);
                    buttonEnergy[i].BackColor = Color.Blue;
                    Controls.Add(buttonEnergy[i]);

                }
                else i--;
            }
            for (int i = 0; i < 30; i++)
            {
                int a = new Random().Next(1, 50);
                int b = new Random().Next(1, 27);
                if (buttonLOC2[a, b] == true)
                {
                    buttonXP[i] = new Button();
                    buttonXP[i].Text = "";
                    buttonXP[i].Location = new Point(a * 16, b * 16);
                    buttonXP[i].Size = new Size(16, 16);
                    buttonXP[i].BackColor = Color.Coral;
                    Controls.Add(buttonXP[i]);

                }
                else i--;
            }
            for (int i = 0; i < 30; i++)
            {
                int a = new Random().Next(1, 50);
                int b = new Random().Next(1, 27);
                if (buttonLOC2[a, b] == true)
                {
                    buttonMedal[i] = new Button();
                    buttonMedal[i].Text = "";
                    buttonMedal[i].Location = new Point(a * 16, b * 16);
                    buttonMedal[i].Size = new Size(16, 16);
                    buttonMedal[i].BackColor = Color.Yellow;
                    Controls.Add(buttonMedal[i]);

                }
                else i--;
            }

        }
        private void Movetractor() //для постройки стен лабиринта рамдомно
        {
            if (cordX > 1  && randoms ==1 ) 
            {
                array[0] = -2;
                array[1] = 0;
                cordX += array[0];
                cordY += array[1];
            }
            if (cordX < height-3 && randoms == 2 )
            {
                array[0] =  2;
                array[1] =  0;
                cordX += array[0];
                cordY += array[1];

            }
            if (cordY > 1  && randoms == 3 )
            {    
                array[0] = 0;
                array[1] = -2;
                cordX += array[0];
                cordY += array[1];

            }
            if (cordY < width-3 && randoms == 4 )
            {
                array[0] =  0;
                array[1] =  2;
                cordX += array[0];
                cordY += array[1];
            }

            if (!buttonLOC2[cordX, cordY])
            {
                buttonLOC2[cordX, cordY] = true;
                buttonLOC2[cordX- array[0]/2, cordY- array[1] / 2] = true;
                
            }
            
            randoms = new Random().Next(1, 5);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}