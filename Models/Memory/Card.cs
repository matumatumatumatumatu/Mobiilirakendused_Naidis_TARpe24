using System;
using System.Collections.Generic;
using System.Text;

namespace Naidis_TARpe24.Models.Memory
{
    public class Card
    {
        public int Id { get; set; }
        public int PairValue { get; set; }
        public string ImageSource { get; set; }
        public bool IsFlipped { get; set; }
        public bool IsMatched { get; set; }

        public Card(int id, int pairValue, string imageSource)
        {
            Id = id;
            PairValue = pairValue;
            ImageSource = imageSource;
        }
    }
}
