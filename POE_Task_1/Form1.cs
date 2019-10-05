using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace POE_Task_1
{
    public partial class Form1 : Form
    {
        Button[,] buttons = new Button[20,20]; //button array that will be used for the grid
        
        static int UnitNum = 3;
        public int Round = 1;

        Map m = new Map(UnitNum);
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m.GenerateBattleField();
            PlaceButtons();
        }

        public void PlaceButtons() //method to place the buttons that much up the battle field fpr the uinits
        {
            GbBoxMap.Controls.Clear();

            Size btnSize = new Size(30, 30);

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Button btn = new Button();

                    btn.Size = btnSize;
                    btn.Location = new Point(i * 30, j * 30);

                    //buttons[i, j] = btn;
                    if (m.map[i, j] == "R")
                    {
                        Debug.Print("Found Rangedunit");
                        btn.Text = "->";
                        btn.Name = m.uniMap[i, j].ToString();
                        btn.Click += MyButtonCLick;

                        if (m.uniMap[i, j].factionType == faction.Hero)
                        {
                            btn.BackColor = Color.Chartreuse;
                        }
                        else
                        {
                            btn.BackColor = Color.Crimson;
                        }
                    }
                    else if (m.map[i, j] == "M")
                    {
                        Debug.Print("Found meleeunit");
                        btn.Text = "#";
                        btn.Name = m.uniMap[i, j].ToString();
                        btn.Click += MyButtonCLick;

                        if (m.uniMap[i, j].factionType == faction.Hero)
                        {
                            btn.BackColor = Color.Chartreuse;
                        }
                        else
                        {
                            btn.BackColor = Color.Crimson;
                        }
                    }
                    else
                    {
                        btn.Text = "";
                    }

                    buttons[i, j] = btn;
                }
            }

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    GbBoxMap.Controls.Add(buttons[i, j]);
                }
            }
        }

        public void MyButtonCLick(object sender, EventArgs e)
        {
            Button btn = ((Button) sender);

            foreach (Units u in m.units)
            {
                if (btn.Name == u.ToString())
                {
                    txtOutput.Text = u.ToString();
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Ticker.Enabled = true;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            Ticker.Enabled = false;
        }

        private void Ticker_Tick(object sender, EventArgs e)
        {
            GameEngine();
            lblRound.Text = "Round: " + Round;
        }

        public void GameEngine()
        {
            foreach (Units u in m.units)
            {
                u.AttRange(m.units, m.uniMap);
            }
            m.Populate();
            Round++;
            PlaceButtons();

        }

        private void lblRound_Click(object sender, EventArgs e)
        {

        }

    }
}
