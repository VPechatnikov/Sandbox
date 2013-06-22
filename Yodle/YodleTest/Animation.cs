using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YodleTest
{
    public class Animation
    {
        const string OccupiedPosition = "X";
        const string EmptyPosition = ".";

        public string[] Animate(double speed, string init)
        {
            var animation = new List<string>();
            int tubeLength = init.Length;
            List<Particle> particles = InitParticles(init);
            string currentState = GetStringRepresentation(particles, tubeLength);
            animation.Add(currentState);
            do
            {
                particles.ForEach(p=>p.Move(speed));
                currentState = GetStringRepresentation(particles, tubeLength);
                animation.Add(currentState);
            }
            while (currentState.Contains(OccupiedPosition));

            return animation.ToArray();
        }

        private string GetStringRepresentation(List<Particle> particles, int tubeLength)
        {
            var state = new String('.',tubeLength).ToCharArray();
            foreach (var particle in particles)
            {
                int keyPosition = particle.KeyPosition;
                if (particle.Position <= tubeLength - 1 && particle.Position >= 0)
                    state[keyPosition] = 'X';
            }
            return string.Join("", state);
        }

        private List<Particle> InitParticles(string init)
        {
            var particles = new List<Particle>();
            for (var position = 0; position < init.Length; position++)
            {
                switch (init[position])
                {
                    case 'L':
                        particles.Add(new Particle{Position=position, Direction = YodleTest.Direction.Left});
                        break;
                    case 'R':
                        particles.Add(new Particle{Position=position, Direction = YodleTest.Direction.Right});
                        break;
                    case '.':
                        break;
                    default:
                        throw new InvalidOperationException("Encountered invalid initial state, only 'L', 'R', and '.' are valid position states");
                }
            }
            return particles;
        }
    }
}
