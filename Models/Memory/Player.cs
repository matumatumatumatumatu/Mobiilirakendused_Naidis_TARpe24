using System;
using System.Collections.Generic;
using System.Text;

namespace Naidis_TARpe24.Models.Memory
{
    public class Player
    {
        public string Name { get; set; }
        public int Moves { get; set; }
        public int MatchedPairs { get; set; }
        public TimeSpan ElapsedTime { get; set; }
        public TimeSpan BestTime { get; set; }

        public Player(string name)
        {
            Name = name;
        }
    }
}
