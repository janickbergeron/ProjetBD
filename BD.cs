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
            int age = 0;
            int poids = 0;
            string couleur;

            int id = Animal.AnimalList.Count + 1;
            Console.WriteLine("Entrez le type d'animal:");
            string type = Console.ReadLine();
            Console.WriteLine("Entrez le nom de l'animal:");
            string name = Console.ReadLine();
            Console.WriteLine("Entrez l'age de l'animal:");
            try{
                do age = int.Parse(Console.ReadLine());
                while (age <= 0);
                Console.WriteLine("Entrez le poids de l'animal:");
                do poids = int.Parse(Console.ReadLine());
                while (poids <= 0);
            }catch (Exception ex)
            {
                Console.WriteLine("Entré invalide.");
            }
            Console.WriteLine("Entrez la couleur de l'animal:(Rouge, Bleu ou Violet.)");
            do couleur = Console.ReadLine().ToLower();
            while (couleur != "rouge" && couleur != "bleu" && couleur != "violet");
            Console.WriteLine("Entrez le propriétaire de l'animal:");
            string proprietaire = Console.ReadLine();


            Animal animal = new(id, type, name, age, poids, couleur, proprietaire);
            return animal;
        }
       public static void AddAnimalToDB(Animal animal)
        {
            string type = animal.Type;
            string name = animal.Name;
            int age = animal.Age;
            int poids = animal.Poids;
            string couleur = animal.Couleur;
            string proprietaire = animal.Proprietaire;

            string query = $"INSERT INTO animal(TypeAnimal, Nom, Age, Poids, Couleur, Proprietaire) VALUES('{type}','{name}',{age},{poids},'{couleur}','{proprietaire}')";
            string connectionString = "server=localhost;database=clinique;uid=root;pwd=;";
            MySqlConnection cnn = new MySqlConnection(connectionString);

            cnn.Open();
            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, cnn);

            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();
            //close Data Reader
            dataReader.Close();
            cnn.Close();
        }
       public static List<Animal> GetAnimalList()
        {
            string query = "SELECT * FROM animal";
            string connectionString = "server=localhost;database=clinique;uid=root;pwd=;";
            MySqlConnection cnn = new MySqlConnection(connectionString);

            //Create a list to store the result
            var list = new List<Animal>();
            cnn.Open();
            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, cnn);

            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            //Read the data and store them in the list
            while (dataReader.Read())
            {
                list.Add(new Animal
                (
                       (int)dataReader["ID"],
                       (string)dataReader["TypeAnimal"],
                       (string)dataReader["Nom"],
                       (int)dataReader["Age"],
                       (int)dataReader["Poids"],
                       (string)dataReader["Couleur"],
                       (string)dataReader["Proprietaire"]
                ));
            }

            //close Data Reader
            dataReader.Close();
            cnn.Close();

            //return list to be displayed
            return list;


        }
       public static List<string> GetProprietaireList()
       {

                string query = "SELECT Proprietaire FROM animal";
                string connectionString = "server=localhost;database=clinique;uid=root;pwd=;";
                MySqlConnection cnn = new MySqlConnection(connectionString);

                //Create a list to store the result
                var list = new List<string>();
                cnn.Open();
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, cnn);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list.Add((string)dataReader["Proprietaire"]);
                }

                //close Data Reader
                dataReader.Close();
                cnn.Close();

                //return list to be displayed
                return list;

            
       }
       public static int GetAnimalWeight()
       {            
            List<Animal> AnimalList = BD.GetAnimalList();
            if (AnimalList.Count < 0)
            {
                    int sum = 0;
                string query = "SELECT Poids FROM animal";
                string connectionString = "server=localhost;database=clinique;uid=root;pwd=;";
                MySqlConnection cnn = new MySqlConnection(connectionString);

                //Create a list to store the result
                var list = new List<int>();
                cnn.Open();
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, cnn);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list.Add((int)dataReader["Poids"]);
                }

                //close Data Reader
                dataReader.Close();
                cnn.Close();

                sum = list.Sum();
                //return list to be displayed
                return sum;
            }
            else
                Console.WriteLine("Aucun pensionnaire a lister.");
            return 0;
       }
       public static List<Animal> GetAnimalColor(string color)
        {
            string query = $"SELECT * FROM animal WHERE Couleur = '{color}'";
            string connectionString = "server=localhost;database=clinique;uid=root;pwd=;";
            MySqlConnection cnn = new MySqlConnection(connectionString);

            //Create a list to store the result
            var list = new List<Animal>();
            cnn.Open();
            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, cnn);

            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            //Read the data and store them in the list
            while (dataReader.Read())
            {
                list.Add(new Animal
                (
                       (int)dataReader["ID"],
                       (string)dataReader["TypeAnimal"],
                       (string)dataReader["Nom"],
                       (int)dataReader["Age"],
                       (int)dataReader["Poids"],
                       (string)dataReader["Couleur"],
                       (string)dataReader["Proprietaire"]
                ));
            }

            //close Data Reader
            dataReader.Close();
            cnn.Close();

            //return list to be displayed
            return list;


        }
        public static void RemoveAnimal(int id)
        {
            List<Animal> AnimalList = BD.GetAnimalList();
            if (AnimalList.Count > 0)
            {
                string query = $"DELETE from animal WHERE ID = '{id}'";
                string connectionString = "server=localhost;database=clinique;uid=root;pwd=;";
                MySqlConnection cnn = new MySqlConnection(connectionString);
                cnn.Open();
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, cnn);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Close();
                cnn.Close();
                Console.WriteLine($"Le pensionnaire numéro {id} à été retiré.");
                Console.ReadKey();
                Menu.ShowAllAnimal();
            }
            else
                Console.WriteLine("Aucun pensionnaire a retirer.");
                Console.ReadKey();
        }
        public static void UpdateAnimal(int id, string name)
        {
            List<Animal> AnimalList = BD.GetAnimalList();
            if (AnimalList.Count > 0)
            {
                string query = $"UPDATE animal SET Name = '{name}' WHERE ID = '{id}'";
                string connectionString = "server=localhost;database=clinique;uid=root;pwd=;";
                MySqlConnection cnn = new MySqlConnection(connectionString);

                cnn.Open();
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, cnn);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Close();
                cnn.Close();
                Console.WriteLine($"Le nom du pensionnaire {id} à été modifié.");
                Console.ReadKey();
                Menu.ShowAllAnimal();
            }
            else
            {
                Console.WriteLine("Aucun pensionnaire a modifier.");
                Console.ReadKey();
            }
        }

    }
}
