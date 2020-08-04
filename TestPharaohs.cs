using System.Collections.Generic;

namespace TestPharaohs
{
    public enum Dynasty
    {
        First,
        Second,
        Third,
        Fourth,
        Fifth
    }
    public class Pharaoh
    {
        public string Name { get; set; }
        public int StartOfReign { get; set; } // BC
        public int EndOfReign { get; set; } // BC
        public Dynasty Dynasty { get; set; }

        public List<Pharaoh> GetPharaohsToQuery()
        {
            return new List<Pharaoh> {
                new Pharaoh {
                    Name = "Sekhemkhet",
                    StartOfReign = 2649,
                    EndOfReign = 2643,
                    Dynasty = Dynasty.Third
                },
                new Pharaoh {
                    Name = "Huni",
                    StartOfReign = 2637,
                    EndOfReign = 2613,
                    Dynasty = Dynasty.Third
                },
                new Pharaoh {
                    Name = "Khufu",
                    StartOfReign = 2589,
                    EndOfReign = 2566,
                    Dynasty = Dynasty.Fourth
                },
                new Pharaoh {
                    Name = "Userkaf",
                    StartOfReign = 2498,
                    EndOfReign = 2491,
                    Dynasty = Dynasty.Fifth
                },
                new Pharaoh {
                    Name = "Menkauhor Kaiu",
                    StartOfReign = 2422,
                    EndOfReign = 2414,
                    Dynasty = Dynasty.Fifth
                },
                new Pharaoh {
                    Name = "Unas",
                    StartOfReign = 2375,
                    EndOfReign = 2345,
                    Dynasty = Dynasty.Fifth
                }
            };
        }
    }
}