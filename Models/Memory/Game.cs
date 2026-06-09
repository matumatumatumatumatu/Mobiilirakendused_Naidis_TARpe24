using System;
using System.Collections.Generic;
using System.Text;

namespace Naidis_TARpe24.Models.Memory
{
    public class Game
    {
        public Player Player { get; set; }
        public List<Card> Cards { get; set; } = new();
        public Card FirstFlipped { get; set; }
        public Card SecondFlipped { get; set; }
        public DateTime StartTime { get; set; }
        public bool IsFinished { get; set; }

        public Game(Player player)
        {
            Player = player;
        }
    }
}
