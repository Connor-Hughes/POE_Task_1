using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POE_Task_1
{
    enum  faction //factions for both the Melee and the Ranged unit
    {
        Hero, 
        Villain
    }

    abstract class Units 
    {
        public int posX;

        public int posY;

        public int health;

        public int maxHealth;

        public int speed;

        public int attack;

        public int atkRange;

        public faction factionType;

        public string symbol;

        public bool isAtk;


        public abstract void Move();

        public abstract void Combat();

        public abstract void AttRange(List<Units> uni, Units[,] uniMap);

        public abstract bool Death();

        public abstract Units Position();

        public abstract string ToString();

        public Units(int x, int y, int hp, int spd, int atk, int attRange, faction fac, string sym, bool iatk )
        {
            posX = x;
            posY = y;
            health = hp;
            speed = spd;
            attack = atk;
            atkRange = attRange;
            factionType = fac;
            symbol = sym;
            isAtk = iatk;

        }


    }
}
