using System.Collections.Generic;

namespace Tennis.Statemachine
{
    public class Score
    {
        private readonly int _points;

        public int Points
        {
            get { return _points; }
        }

        public Score(int points)
        {
            _points = points;
        }

        public override string ToString()
        {
            return new Dictionary<int, string>
            {
                {0, "Love"},
                {1, "Fifteen"},
                {2, "Thirty"},
                {3, "Forty"}
            }[Points];
        }

        public Score GetNext()
        {
            return new Score(Points + 1);
        }
    }
}