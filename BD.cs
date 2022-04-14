using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_BD
{
    internal class BD
    {
       public static void ConnectToDatabase()
        {
            string connectionString = null;
            MySqlConnection cnn;
            connectionString = "server=localhost;database=clinique;uid=root;pwd=;";
            cnn = new MySqlConnection(connectionString);

                try
                {
                    cnn.Open();
                    if (cnn.State== System.Data.ConnectionState.Open)
                    {
                        Console.WriteLine("Le connection a la BD est fonctionnel.");
                    }
                    cnn.Close();
                }
            catch (Exception ex)
                {
                    Console.WriteLine("Impossible d'ouvrir la connection" + ex.Message);
                }
        }

       public static Animal AjouterAnimal()
        {
            string couleur;
            string proprietaire;
            Console.WriteLine("Entrez le type d'animal:");
            string type = Console.ReadLine();
            Console.WriteLine("Entrez le nom de l'animal:");
            string name = Console.ReadLine();
            Console.WriteLine("Entrez l'age de l'animal:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Entrez le poids de l'animal:");
            int poids = int.Parse(Console.ReadLine());

        }
    }
}
