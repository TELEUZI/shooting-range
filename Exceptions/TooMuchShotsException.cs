using System;

namespace Lab_2_2.Exceptions
{
    public class TooManyShotsException: Exception
    {
        public TooManyShotsException(): base("You've tried to make more shots than available.")
        {
        }

        public TooManyShotsException(string message)
            : base(message)
        {
        }

        public TooManyShotsException(string message, Exception inner)
            : base($"{message}", inner)
        {
        }
    }
}