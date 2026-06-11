using System;
using System.Collections.Generic;
using System.Text;

namespace Naidis_TARpe24.Models.Retsept
{
    public class RetseptKategooria : List<Retsept>
    {
        public string Nimetus { get; set; }

        public RetseptKategooria(string nimetus, IEnumerable<Retsept> retseptid)
            : base(retseptid)
        {
            Nimetus = nimetus;
        }
    }
}
