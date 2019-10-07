using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace POE_Task_1
{
    class RangedUnit : Units
    {
        public int PosX // all the properties needed for the units
        {
            get { return posX; }
            set { base.posX = value; }
        }

        public int PosY
        {
            get { return posY; }
            set { base.posY = value; }
        }

        public int Health
        {
            get { return health; }
            set { base.health = value; }
        }

        public int MaxHealth
        {
            get { return maxHealth; }

        }

        public int Speed
        {
            get { return speed; }
        }

        public int Attack
        {
            get { return attack; }
        }

        public int AtkRange
        {
            get { return atkRange; }
        }

        public faction FactionType
        {
            get { return factionType; }
        }
        
        public string Symbol
        {
            get { return symbol; }
        }


        public bool IsAtk
        {
            get { return isAtk; }
        }


        List<Units> units = new List<Units>();
        private int speedCounter = 1;
        Random r = new Random();
        private Units ClosestUnit;

        public RangedUnit(int x, int y, int hp, int spd, int atk, int attRange, faction fac, string sym, bool iatk) // constructor for all the parameters
            : base(x, y, hp, spd, atk, attRange, fac, sym, iatk)
        {

        }


        public override void Move() //telling the unit which enemy unit to move towards(cloesest enemy on the battlefield)
        {
            if (ClosestUnit.posX > posX && posX < 20)
            {
                posX++;
            }
            else if (ClosestUnit.posX < posX && posX > 0)
            {
                posX--;
            }

            if (ClosestUnit.posY > posY && posY < 20)
            {
                PosY++;
            }
            else if (ClosestUnit.posY > posY && posY < 0)
            {
                posY--;
            }

        }

        public override void Combat() //telling the units to attack the closest enemy
        {
            foreach (Units u in units)
            {
                if (ClosestUnit.posX == u.posX && ClosestUnit.posY == u.posY)
                {
                    u.health = u.health - Attack;
                    isAtk = true;
                    break;

                }
            }
        }

        public override void AttRange(List<Units> uni, Units[,] uniMap) //method used to tell the unit whether to attack a unit ot to run away because of low health
        {
            units = uni;

            ClosestUnit = Position();
            int xDis, yDis;
            int distance;

            xDis = Math.Abs((PosX - ClosestUnit.posX) * (posX - ClosestUnit.posX));
            yDis = Math.Abs((PosY - ClosestUnit.posY) * (posY - ClosestUnit.posY));

            distance = (int)Math.Round(Math.Sqrt(xDis + yDis), 0);

            if (distance <= atkRange)
            {
                Combat();
            }
            else
            {
                Move();
            }
        }

        public override bool Death()
        {
            return true;
        }

        public override Units Position()
        {

            int xDis, yDis;
            double Distance;
            Units target = null;
            double temp = 1000;

            foreach (Units u in units)
            {
                if (factionType != u.factionType)
                {
                    xDis = Math.Abs((PosX - u.posX) * (posX - u.posX));
                    yDis = Math.Abs((PosY - u.posY) * (posY - u.posY));

                    Distance = Math.Round(Math.Sqrt(xDis + yDis), 0);

                    if (Distance < temp)
                    {
                        temp = Distance;
                        target = u;

                    }
                }


            }
            return target;
        }

        public override string ToString()
        {
            return "Musketeer X: " + posX
                               + " Y: " + posY
                               + "\nMaxHealth: " + maxHealth
                               + "\nHealth: " + Health
                               + "\nSpeed: " + Speed
                               + "\nAttackDamage: " + Attack
                               + "AttackRange: " + AtkRange
                               + "\nFaction: " + FactionType;
        }
    }
}
