using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YodleTest
{
    public class Particle
    {
        public double Position { get; set; }
        public Direction Direction { get; set; }

        public void Move(double speed)
        {
            switch (Direction)
            {
                case Direction.Left:
                    Position -= speed;
                    break;
                case Direction.Right:
                    Position += speed;
                    break;
                default:
                    break;
            }
        }

        public int KeyPosition
        {
            get
            {
                var floor = (int)Math.Floor(Position);
                return Math.Abs(Position - floor) > 0.5 ? floor + 1 : floor;
            }
        }
    }
}
