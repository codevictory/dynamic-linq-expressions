using System.Collections.Generic;

namespace Model
{
    public class Emperor
    {
        public string Name { get; set; }
        public int StartOfReign { get; set; } // AD
        public int EndOfReign { get; set; } // AD
        public Dynasty Dynasty { get; set; }

        public static List<Emperor> GetEmperorsList()
        {
            return new List<Emperor> {
                new Emperor {
                    Name = "Tiberius",
                    StartOfReign = 14,
                    EndOfReign = 16,
                    Dynasty = Dynasty.JulioClaudian
                },
                new Emperor {
                    Name = "Claudius",
                    StartOfReign = 41,
                    EndOfReign = 54,
                    Dynasty = Dynasty.JulioClaudian
                },
                new Emperor {
                    Name = "Nero",
                    StartOfReign = 54,
                    EndOfReign = 68,
                    Dynasty = Dynasty.JulioClaudian
                },
                new Emperor {
                    Name = "Vespasian",
                    StartOfReign = 69,
                    EndOfReign = 79,
                    Dynasty = Dynasty.Flavian
                },
                new Emperor {
                    Name = "Titus",
                    StartOfReign = 79,
                    EndOfReign = 81,
                    Dynasty = Dynasty.Flavian
                },
                new Emperor {
                    Name = "Trajan",
                    StartOfReign = 98,
                    EndOfReign = 117,
                    Dynasty = Dynasty.NervaAntonine
                },
                new Emperor {
                    Name = "Hadrian",
                    StartOfReign = 117,
                    EndOfReign = 138,
                    Dynasty = Dynasty.NervaAntonine
                },
                new Emperor {
                    Name = "Marcus Aurelius",
                    StartOfReign = 161,
                    EndOfReign = 180,
                    Dynasty = Dynasty.NervaAntonine
                },
                new Emperor {
                    Name = "Septimus Severus",
                    StartOfReign = 193,
                    EndOfReign = 211,
                    Dynasty = Dynasty.Severan
                },
                new Emperor {
                    Name = "Gordian III",
                    StartOfReign = 238,
                    EndOfReign = 244,
                    Dynasty = Dynasty.Gordian
                },
                new Emperor {
                    Name = "Constantine I",
                    StartOfReign = 306,
                    EndOfReign = 337,
                    Dynasty = Dynasty.Constantinian
                },
                new Emperor {
                    Name = "Valentinian II",
                    StartOfReign = 375,
                    EndOfReign = 392,
                    Dynasty = Dynasty.Valentinian
                },
                new Emperor {
                    Name = "Honorius",
                    StartOfReign = 395,
                    EndOfReign = 423,
                    Dynasty = Dynasty.Theodosian
                }
            };
        }
    }
}