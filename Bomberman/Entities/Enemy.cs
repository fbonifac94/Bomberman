using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Bomberman.Entities
{
    class Enemy : EnemyEntity
    {
        private static Enemy enemy;

        public Enemy(Rectangle rectangle) : base(rectangle) { }

        public static Enemy getInstance(bool requireNewInstance = false)
        {
            if (enemy == null || requireNewInstance)
            {
                Enemy.enemy = new Enemy(new Rectangle(375, 220, 40, 35));
            }
            return Enemy.enemy;
        }
    }
}
