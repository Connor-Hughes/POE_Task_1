using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace POE_Task_1
{
    class Map
    {
        public string[,] map = new string[20, 20];
        public  List<Button> buttons = new List<Button>();
        Random Rd = new Random();

        public List<Units> units = new List<Units>();
        public List<Units> rangedUnit = new List<Units>();
        public List<Units> melleUnit = new List<Units>();
        public  Units[,] uniMap = new Units[20,20];

        int UnitNum;

        public Map(int UnitN = 0)
        {
            UnitNum = UnitN;
        }

        public  void GenerateBattleField() // placing the units down and setting all the units stats
        {
            for (int i = 0; i < UnitNum; i++)
            {
                if (Rd.Next(0, 2) == 0)
                {
                    RangedUnit Musketeer = new RangedUnit(0, 0, 40, 1, 5, 3, faction.Hero, "->", false);
                    rangedUnit.Add(Musketeer);
                    Debug.Print("Make ranged");
                }
                else
                {
                    MelleUnit Pekka = new MelleUnit(0, 0, 60, 1, 10, 1, faction.Hero, "#", false);
                    melleUnit.Add(Pekka);
                }
            }
            for (int i = 0; i < UnitNum; i++)
            {
                if (Rd.Next(0, 2) == 0)
                {
                    RangedUnit Musketeer = new RangedUnit(0, 0, 30, 1, 4, 3, faction.Villain, "->", false);
                    rangedUnit.Add(Musketeer);
                }
                else
                {
                    MelleUnit Pekka = new MelleUnit(0, 0, 40, 1, 6, 1, faction.Villain, "#", false);
                    melleUnit.Add(Pekka);
                }
            }

            foreach (Units u in rangedUnit)
            {
                for (int i = 0; i < rangedUnit.Count; i++)
                {
                    int xPos = Rd.Next(0, 20);
                    int yPos = Rd.Next(0, 20);

                    while (xPos == rangedUnit[i].posX && yPos == rangedUnit[i].posY && xPos == melleUnit[i].posX && yPos == melleUnit[i].posY)
                    {
                         xPos = Rd.Next(0, 20);
                         yPos = Rd.Next(0, 20);
                    }

                    u.posX = xPos;
                    u.posY = yPos;
                    uniMap[u.posY, u.posX] = (Units) u;
                }
                units.Add(u);
            }

            foreach (Units u in melleUnit)
            {
                for (int i = 0; i < melleUnit.Count; i++)
                {
                    int xPos = Rd.Next(0, 20);
                    int yPos = Rd.Next(0, 20);

                    while (xPos == melleUnit[i].posX && yPos == melleUnit[i].posY && xPos == rangedUnit[i].posX && yPos == rangedUnit[i].posY)
                    {
                        xPos = Rd.Next(0, 20);
                        yPos = Rd.Next(0, 20);
                    }

                    u.posX = xPos;
                    u.posY = yPos;
                    uniMap[u.posY, u.posX] = (Units)u;
                }
                units.Add(u);
            }

            Populate();
        }

        public void Populate() //filling the block map with units
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    map[i, j] = "";
                }
            }

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    uniMap[i, j] = null;
                }
            }

            foreach (Units u in units)
            {
                uniMap[u.posY, u.posX] = u;
            }

            foreach (Units u in rangedUnit)
            {
                Debug.Print("Place Ranged");
                map[u.posY, u.posX] = "R";
            }
            foreach (Units u in melleUnit)
            {
                map[u.posY, u.posX] = "M";
            }



        }

        private void UpdatePosition()
        {

        }


    }
}
