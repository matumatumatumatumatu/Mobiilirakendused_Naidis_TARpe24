using System;
using System.Collections.Generic;
using System.Text;

namespace Naidis_TARpe24.Models.Memory
{
    public class Player
    {
       public string Name { get; set; }
        public DateTime GameStarted { get; set; }
        public DateTime GameEnded { get; set; }
        public DateTime GameTime { get; set; }
        public DateTime BestTime { get; set; }

    }
}
