using System.Windows;

namespace Lab_2_2.Models
{
    public class Circle : DistanceCalculator
    {
        private float _radius;

        public float Radius
        {
            get => _radius;
            set => _radius = value > 0 ? value : _radius;
        }

        public Circle(float radius = 10f)
        {
            _radius = radius;
        }

        public bool Contains(Point shot)
        {
            return CalculateDistance(shot, new Point(_radius, _radius)) < _radius;
        }
    }
}