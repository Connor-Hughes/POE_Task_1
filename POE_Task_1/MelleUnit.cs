using System;
using System.Collections.Generic;

namespace POE_Task_1
{
    class MelleUnit : Units
    {
        public int PosX  // all the properties needed for the units
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

        public MelleUnit(int x, int y, int hp, int spd, int atk, int attRange, faction fac, string sym, bool iatk)
            : base(x, y, hp, spd, atk, attRange, fac, sym, iatk)
        {

        }

        public override void Move() //showing the units which other units to attack and at what point to try run away
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

        public override void Combat() //telling the units to  attack the closest enemy
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

        public override void AttRange(List<Units> uni, Units[,] uniMap) // telling the units to  attack the closest enemy
        {
            units = uni;

            ClosestUnit = Position();
            int xDis, yDis;
            int distance;

            xDis = Math.Abs((PosX - ClosestUnit.posX) * (posX - ClosestUnit.posX));
            yDis = Math.Abs((PosY - ClosestUnit.posY) * (posY - ClosestUnit.posY));

            distance = (int) Math.Round(Math.Sqrt(xDis + yDis), 0);

            if (distance <= atkRange)
            {
                Combat();   
            }
            else
            {
                Move();
            }
        }

        public override bool Death() // telling the units to die once health has reached 0
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

        public override string ToString()  //
        {
            return "Pekka X: " + posX
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



