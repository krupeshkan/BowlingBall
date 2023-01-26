using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public class Game
    {
        private readonly List<Frame> _frames = new List<Frame>();
        public void Roll(int pins)
        {
            //if (GameFinished())
            //    throw new GameOverException();

            Add(Frame.Create(pins, 0));
        }

        private void Add(Frame frame)
        {
            _frames.Add(frame);
        }

        public int GetScore()
        {
            Add(new Open(0, 0));
            Add(new Open(0, 0));

            for (int i = 0; i < 10; i++)
                _frames[i].AddBonus(_frames[i + 1], _frames[i + 2]);

            int _totalScore = 0;
            _frames.ForEach(frame => _totalScore += frame.Score());
            return _totalScore;
        }

        public void RollFinalFrame(int firstRoll, int secondRoll, int thirdRoll)
        {
            Add(Frame.Create(firstRoll, secondRoll, thirdRoll));
        }

        private bool GameFinished()
        {
            return _frames.Count.Equals(10);
        }

        public void RollStrike()
        {
            Roll(10);
        }
    }
}
