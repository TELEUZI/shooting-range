using System.Windows;

namespace Lab_2_2.Models
{
    public class DistanceCalculator
    {
        protected double CalculateDistance(Point point, Point secondPoint)
        {
            return Point.Subtract(point, secondPoint).Length;
        }
    }
}