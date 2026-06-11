using Naidis_TARpe24.Models.Retsept;
using System;
using System.Collections.Generic;
using System.Text;

namespace Naidis_TARpe24.Services
{
    public static class RetseptFileService
    {
        private static readonly string RetseptPath =
            Path.Combine(FileSystem.AppDataDirectory, "retseptid.txt");

        public static List<Retsept> LoeRetseptid()
        {
            var nimekiri = new List<Retsept>();

            if (!File.Exists(RetseptPath))
                return nimekiri;

            string[] read = File.ReadAllLines(RetseptPath);

            foreach (string rida in read)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(rida)) continue;

                    string[] osad = rida.Split(';');

                    if (osad.Length >= 3)
                    {
                        nimekiri.Add(new Retsept
                        {
                            Nimi = osad[0].Trim(),
                            Kategooria = osad[1].Trim(),
                            PildiLink = osad[2].Trim()
                        });
                    }
                }
                catch (Exception ex)
                {
                    
                }
            }

            return nimekiri;
        }

        public static void SalvestaRetsept(Retsept retsept)
        {
            string rida = $"{retsept.Nimi};{retsept.Kategooria};{retsept.PildiLink}";
            File.AppendAllText(RetseptPath, rida + Environment.NewLine);
        }
    }
}
