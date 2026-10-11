using System;
using System.Collections.Generic;
using System.Text;

namespace FutoversenyCLI
{
    internal class Runner
    {
        public Runner(string l)
        {
            var r = l.Split(";");
            StartNumber = int.Parse(r[0]);
            Name = r[1];
            Gender = r[2];
            BirthYear = int.Parse(r[3]);
            Club = new Club()
            {
                ClubID = int.Parse((string)r[4]),
                ClubName = r[5],
            };
            Distance = new Distance()
            {
                DistanceID = int.Parse(r[6]),
                DistanceName = r[7],
                Meters = int.Parse(r[8])
            };
            Time = r[9];
            City = r[10];
        }

        public int StartNumber { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int BirthYear { get; set; }
        public Club Club { get; set; }
        public Distance Distance { get; set; }
        public string Time { get; set; }
        public string City { get; set; }

        public string Pace()
        {
            int? sec = TimeInSeconds();
            if (sec == null) return "-";
            int p = sec.Value * 1000 / Distance.Meters;    // egész osztás → lefelé kerekít
            return $"{p / 60}:{p % 60:00} /km";
        }

        public int? TimeInSeconds()
        {
            
            if (Time != "DNF")
            {
                var r = Time.Split(':');
                return int.Parse(r[0]) * 3600 + int.Parse(r[1]) * 60 + int.Parse(r[2]);
            }
            else
            {
              return 0;
            }
        }
        public override string ToString()
        {
                return $"\tStart number: {StartNumber}\n" +
           $"\tName: {Name}\n" +
           $"\tGender: {Gender}\n" +
           $"\tBirth year: {BirthYear}\n" +
           $"\tClub: {Club.ClubName}\n" +
           $"\tDistance: {Distance.DistanceName} ({Distance.Meters} m)\n" +
           $"\tCity: {City}\n" +
           $"\tTime: {Time}\n" +
           $"\tPace: {Pace()}\n";

        }
    }
}
