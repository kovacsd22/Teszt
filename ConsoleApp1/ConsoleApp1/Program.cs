using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static List<Feladvany> lista = new List<Feladvany>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("feladvanyok.txt");
            while (!sr.EndOfStream)
            {
                lista.Add(new Feladvany(sr.ReadLine()));
            }
            sr.Close();
            Console.WriteLine($"3. feladat: Beolvasva {lista.Count} feladvany");

            int meret;
            do
            {
                Console.Write( "4. feladat: kérem a feladvány méretét [4...9]: ");
                meret = int.Parse( Console.ReadLine());
            }
            while (!int.TryParse(Console.ReadLine(), out meret) || meret < 4 || meret > 9);


            List<Feladvany> XElemuFeladavanyok = new List<Feladvany>();
            foreach (var l in lista)
            {
                if (l.Meret == meret)
                {
                    XElemuFeladavanyok.Add(l);
                }
            }

            Console.WriteLine($"{meret}x{XElemuFeladavanyok.Count} méretű feladványból {meret* XElemuFeladavanyok.Count} darab van tárolva.");

            Random rnd = new Random();
            int index = rnd.Next(XElemuFeladavanyok.Count);
            var kivalasztottFeladvany = XElemuFeladavanyok[index];

            Console.WriteLine("5. feladat: A kiválasztott feladvány: ");
            Console.WriteLine(kivalasztottFeladvany.Kezdo);

            double db = 0;
            foreach (char szamjegy in kivalasztottFeladvany.Kezdo)
            {
                if (szamjegy != '0')
                {
                    db++;
                }
            }
            Console.WriteLine($"6. feladat: A feladvány kitöltöttsége: {100*db/kivalasztottFeladvany.Kezdo.Length}");

            Console.WriteLine("7. feladat: A feladvány kirajzolva:");
            kivalasztottFeladvany.Kirajzol();

            string fajlNev = string.Format($"sudoku{meret}.txt");
            StreamWriter sw = new StreamWriter(fajlNev);
            foreach (var k in XElemuFeladavanyok)
            {
                sw.WriteLine(k.Kezdo);
            }
            sw.Close();

            Console.WriteLine($"8. feladat: {fajlNev} állomány {XElemuFeladavanyok.Count} darab feladvánnyal létrehozva");



        }
    }
}
