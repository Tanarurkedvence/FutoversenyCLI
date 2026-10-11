namespace FutoversenyCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Runner> runners = new List<Runner>();

            using(StreamReader o = new StreamReader("../../../forras/futok.txt"))
            {
                o.ReadLine();
                while (!o.EndOfStream)
                {
                    string line = o.ReadLine();
                    runners.Add(new Runner(line));
                }
            }
            Console.WriteLine("5. feladat");
            Console.WriteLine($"\tA versenyzők száma: {runners.Count()} ");
            int szamlalo = 0;
            foreach (var r in runners)
            {
                if(r.Time == "DNF")
                {
                    szamlalo++;
                }
            }
            Console.WriteLine($"\tFeladta a versenyt (DNF): {szamlalo} fő");

            var gyoztes = runners
                .Where(x => x.Distance.DistanceName == "Maraton" && x.Time != "DNF")
                .OrderBy(x => x.TimeInSeconds())
                .First();


            Console.WriteLine("\tA maraton győztese:");
            Console.WriteLine(gyoztes.ToString().Replace("\t", "\t\t"));

            var f7 = runners.Where(x => x.Distance.Meters == 10000).OrderBy(x => x.Distance.DistanceID);

            int nemcelbaerok = f7.Count(x => x.Time == "DNF");
            Console.WriteLine($"10 km: {f7.Count()} indulóból {f7.Count() - nemcelbaerok} ért célba, legjobb idő: {f7.Min(x => x.Time)}");

            var f8 = runners.Where(x => x.Distance.DistanceName == "Félmaraton").OrderBy(x => x.Distance.DistanceID);
            int fingocskák = f8.Count(x => x.Time == "DNF");
            Console.WriteLine($"Félmaraton: {f8.Count()} indulóból {f8.Count() - fingocskák} ért célba, legjobb idő: {f8.Min(x => x.Time)}");

            var f9 = runners.Where(x => x.Distance.DistanceName == "Maraton").OrderBy(x => x.Distance.DistanceID);
            int benak = f9.Count(x => x.Time == "DNF");
            Console.WriteLine($"Maraton: {f9.Count()} indulóból {f9.Count() - benak} ért célba, legjobb idő: {f9.Min(x => x.Time)}");
            Console.WriteLine();
            Console.WriteLine("8. feladat: Fájlba írás");

            var asd = runners.Where(x => x.Distance.DistanceName == "Félmaraton" && x.BirthYear >= 2003 && x.Gender == "N" && x.Time != "DNF").OrderBy(x => x.Time);
            int counter = 1;
            using(StreamWriter i = new StreamWriter("../../../forras/u23_noi_felmaraton.txt"))
            {
                foreach(var x in asd)
                {
                    i.WriteLine($"{counter++};{x.Name};{x.Time}");
                }
            }
        }
    }
}
