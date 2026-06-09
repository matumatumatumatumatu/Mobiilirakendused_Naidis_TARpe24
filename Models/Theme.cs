using System;
using System.Collections.Generic;
using System.Text;

namespace Naidis_TARpe24.Models.Memory
{
    public class Theme
    {
        public string Name { get; set; }
        public Color BackgroundColor { get; set; }
        public Color TextColor { get; set; }
        public Color AccentColor { get; set; }
        public Color CardBorderColor { get; set; }

        public Theme(string name, Color background, Color text, Color accent, Color cardBorder)
        {
            Name = name;
            BackgroundColor = background;
            TextColor = text;
            AccentColor = accent;
            CardBorderColor = cardBorder;
        }

        public void Apply(ContentPage page)
        {
            page.BackgroundColor = BackgroundColor;
        }

        public static Theme Dark => new Theme(
            "Tume",
            Color.FromArgb("#0D0D0D"),
            Color.FromArgb("#E0E0E0"),
            Color.FromArgb("#4A90D9"),
            Color.FromArgb("#4A90D9")
        );

        public static Theme Light => new Theme(
            "Hele",
            Color.FromArgb("#F5F5F5"),
            Color.FromArgb("#1A1A1A"),
            Color.FromArgb("#007AFF"),
            Color.FromArgb("#CCCCCC")
        );

        public static Theme Fire => new Theme(
            "Tuline",
            Color.FromArgb("#1A0500"),
            Color.FromArgb("#FFD580"),
            Color.FromArgb("#FF4500"),
            Color.FromArgb("#FF4500")
        );

        public static List<Theme> AllThemes => new List<Theme> { Dark, Light, Fire };
    }
}
