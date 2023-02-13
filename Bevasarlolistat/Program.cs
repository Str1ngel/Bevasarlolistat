using System.ComponentModel;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Bevasarlolistat
{
    internal class Program
    {
        public static List<Bevasarlolista> list = new();
        public static List<Bevasarlolista> listCheep = new();
        public static List<int> indexList = new();
        static void Main(string[] args)
        {
            Reading("../../../data/bevasarlolista.txt");
            Writer("../../../data/fizetendo.txt");
            Feladat6();
            Feladat8();
            Feladat9();
            Feladat10();
            Feladat12();
            Feladat13();
            Feladat14();
        }

        private static void Feladat14()
        {
            bool have = false;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].mennyiseg > 10)
                {
                    have = true;
                    indexList.Add(i);
                }
            }

            string resoult = "";

            for (int i = 0; i < indexList.Count; i++)
            {
                if (i == 0)
                    resoult += list[indexList[i]].termekneve;

                else
                    resoult += ", " + list[indexList[i]].termekneve;
            }

            Console.WriteLine("\n10. Feladat:\n\t" +
                ((have) 
                ? $"{resoult}" 
                : "Nincs ilyen termék!"));
        }

        private static void Feladat13()
        {
            int index = 0;

            for (int i = 0; i < list.Count; i++)
                if (list[i].egysegar < list[index].egysegar)
                    index = i;

            Console.WriteLine("\n13. Feladat:\n" +
                $"\tA legolcsóbb termék: {list[index].termekneve}, {list[index].egysegar} Ft");
        }

        private static void Feladat12()
        {
            foreach (var i in list)
                if (i.egysegar < 500)
                    listCheep.Add(i);

            Console.WriteLine("\n12. Feladat:\n" +
                $"\t{listCheep.Count} db 500Ft-nál olcsóbb termék van a bevásárlólistában.");
        }

        private static void Writer(string dataLocation)
        {
            FileStream fs = new(dataLocation, FileMode.Create);
            StreamWriter sw = new(fs);

            double sum = 0;
            
            foreach (var i in list)
            {
                sum += Summary(i.mennyiseg, i.egysegar);
                sw.WriteLine($"{i.termekneve};{Summary(i.mennyiseg, i.egysegar)}");
            }

            sw.Write($"Végösszeg: {sum}");

            sw.Close();
            fs.Close();
        }

        private static void Feladat10()
        {
            int index = 0;

            for (int i = 1; i < list.Count; i++)
                if (list[i].egysegar > list[index].egysegar)
                    index = i;

            Console.WriteLine("\n10. Feladat: \n\n" +
                $"\tLegdrágább termék: {list[index].termekneve}, ára: {list[index].egysegar} Ft");
        }

        private static void Feladat9()
        {
            int count = 0;

            foreach (var i in list)
                count += i.mennyiseg;

            Console.WriteLine("\n9. Feladat: \n\n" +
                $"\tÖsszesen {count} db terméket");
        }

        private static void Feladat8()
        {
            double sum = 0;

            foreach (var i in list)
                sum += Summary(i.mennyiseg, i.egysegar);

            Console.WriteLine("\n8. Feladat: \n\n" +
                $"\tVégösszeg: {sum} Ft");
        }

        private static void Feladat6()
        {
            Console.WriteLine("\n6. Feladat:\n\n" +
                $"\t{list.Count} féle terméket kell megvásárlnia!");
        }

        private static double Summary(int mennyiseg, double egysegar)
            => mennyiseg * egysegar;

        private static void Reading(string dataLocation)
        {
            FileStream fs = new(dataLocation, FileMode.Open);
            StreamReader sr = new(fs);

            while (!sr.EndOfStream)
                list.Add(new(sr.ReadLine()));

            sr.Close();
            fs.Close();
        }
    }
}