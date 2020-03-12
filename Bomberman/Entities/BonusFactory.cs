using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.Entities
{
    class BonusFactory
    {
        private static BonusFactory bonusFactory;

        TimeSpan tiempo;

        int proximoTiempo = 10;

        private  Random random = new Random();

        private Random randomImg = new Random();

        private Random randomPosc = new Random();

        private Dictionary<int, Tuple<int, int>> startPointBonus = new Dictionary<int, Tuple<int, int>>
        {
            {1, new Tuple<int, int>(200,65) } ,
            {2, new Tuple<int, int>(370,65) } ,
            {3, new Tuple<int, int>(540,65) } ,
            {4, new Tuple<int, int>(200,140) } ,
            {5, new Tuple<int, int>(140,140) } ,
            {6, new Tuple<int, int>(370,140) } ,
            {7, new Tuple<int, int>(660,140) } ,
            {8, new Tuple<int, int>(90, 180) } ,
            {9, new Tuple<int, int>(90,340) } ,
            {10, new Tuple<int, int>(90,380) } ,
            {11, new Tuple<int, int>(140,380) } ,
            {12, new Tuple<int, int>(260,380) } ,
            {13, new Tuple<int, int>(550,380) } ,
            {14, new Tuple<int, int>(490,380) } ,
            {15, new Tuple<int, int>(320,340) } ,
            {16, new Tuple<int, int>(320,300) } ,
            {17, new Tuple<int, int>(320,260) } ,
            {18, new Tuple<int, int>(370,300) } ,
            {19, new Tuple<int, int>(370,220) } ,
            {20, new Tuple<int, int>(430,220) } ,
            {21, new Tuple<int, int>(430,260) } ,
            {22, new Tuple<int, int>(430,180) } ,
            {23, new Tuple<int, int>(145,220) } ,
            {24, new Tuple<int, int>(200,220) } ,
            {25, new Tuple<int, int>(200,260) } ,
            {26, new Tuple<int, int>(610,220) } ,
            {27, new Tuple<int, int>(550,220) } ,
            {28, new Tuple<int, int>(550,300) } 
        };

        private BonusFactory() { }

        public static BonusFactory getInstance()
        {
            if (bonusFactory == null)
            {
                bonusFactory = new BonusFactory();
            }
            return bonusFactory;
        }

        public void generateBonus(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.Subtract(tiempo).Seconds
                    > proximoTiempo
                    && Background.getInstance().bonus.Count < 3)
            {
                proximoTiempo = random.Next(10, 20);
                tiempo = gameTime.TotalGameTime;
                Bonus bonusObj;
                do
                {
                    Tuple<int, int> xy = startPointBonus[randomPosc.Next(1, 28)];
                    bonusObj = new Bonus(randomImg.Next(1, 3).ToString(), xy.Item1, xy.Item2);
                } while (intersectBonusPosc(bonusObj.getCurrentPosition()));
                Background.getInstance().bonus.Add(bonusObj);
            }
        }

        public bool intersectBonusPosc(Rectangle bonus)
        {
            return Background.getInstance().bonus.Count(elem => elem.intersect(bonus)) > 0;
        }
    }
}
