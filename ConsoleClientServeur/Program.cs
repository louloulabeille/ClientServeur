using ClientServeur;
using System;

namespace ConsoleClientServeur
{
    class Program
    {
        static void Main(string[] args)
        {
            //Serveur s = new Serveur();
            Serveur c = new Serveur(8580);
        }
    }
}
