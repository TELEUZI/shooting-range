using System.Collections.Generic;
using System.Windows;
using Lab_2_2.Exceptions;

namespace Lab_2_2.Models
{
    public class ShotService
    {
        private readonly Circle _circle;
        private readonly int _shotAmount;

        public ShotService(int shotAmount = 3)
        {
            _shotAmount = shotAmount;
            History = new List<(Point, bool)>();
            _circle = new Circle();
        }

        public List<(Point, bool)> History { get; }


        /// <exception cref="TooMuchShotsException">User did too much shots.</exception>
        public bool MakeShot(Point shot)
        {
            if (History.Count >= _shotAmount)
            {
                throw new TooManyShotsException();
            }

            var isDead = IsTarget(shot);
            History.Add((shot, isDead));
            return isDead;
        }


        public void Restart()
        {
            History.Clear();
        }

        private bool IsTarget(Point shot)
        {
            return IsUnderLine(shot) && _circle.Contains(shot);
        }

        private static bool IsUnderLine(Point shot)
        {
            return shot.X < 0 && shot.X <= shot.Y || shot.X > 0 && shot.X >= shot.Y;
        }
    }
}