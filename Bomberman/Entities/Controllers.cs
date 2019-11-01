using Microsoft.Xna.Framework.Input;

namespace Bomberman.Entities
{
    class Controllers
    {
        private Keys UP;

        private Keys DOWN;

        private Keys LEFT;

        private Keys RIGHT;

        private Keys ACTION;

        public Controllers(Keys up, Keys down, Keys left, Keys right, Keys action) {
            this.UP = up;
            this.DOWN = down;
            this.LEFT = left;
            this.RIGHT = right;
            this.ACTION = action;
        }

        public Keys getUp()
        {
            return this.UP;
        }

        public Keys getDown()
        {
            return this.DOWN;
        }

        public Keys getLeft()
        {
            return this.LEFT;
        }

        public Keys getRight()
        {
            return this.RIGHT;
        }

        public Keys getAction()
        {
            return this.ACTION;
        }

    }
}
