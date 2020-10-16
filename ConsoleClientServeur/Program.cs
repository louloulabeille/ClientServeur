using ClientServeur;
using System;
using System.Diagnostics;
using Utilitaires;

namespace ConsoleClientServeur
{
    class Program
    {
        static void Main(string[] args)
        {
            //Serveur s = new Serveur();
            Serveur c = new Serveur(8580);
            /*string s = Console.ReadLine();
            if ( s == "s")
            {
                c.Arret();
                Debug.WriteLine("sortie du programme");
            }*/
            GameIOData gIOData = new GameIOData(0, 1);
            c.Donnee = gIOData;
        }
    }
}
