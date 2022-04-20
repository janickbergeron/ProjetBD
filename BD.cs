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
       public static Animal AjouterAnimal() //Function that returns an Animal object.
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
                while (age <= 0); //Ensure a positive number.
                Console.WriteLine("Entrez le poids de l'animal:");
                do poids = int.Parse(Console.ReadLine());
                while (poids <= 0);
            }catch (Exception ex)
            {
                Console.WriteLine("Entré invalide."); //This loop catches exceptions when user try to enter letters.
            }
            Console.WriteLine("Entrez la couleur de l'animal:(Rouge, Bleu ou Violet.)");
            do couleur = Console.ReadLine().ToLower();
            while (couleur != "rouge" && couleur != "bleu" && couleur != "violet");  //Ensure the user has entered one of the 3 colors.
            Console.WriteLine("Entrez le propriétaire de l'animal:");
            string proprietaire = Console.ReadLine();

            Animal animal = new(id, type, name, age, poids, couleur, proprietaire);
            return animal;
        }
       public static void AddAnimalToDB(Animal animal)  //Function which take an Animal as parameter to send it's data to the database.
        {
            string type = animal.Type;  //Animal attributes.
            string name = animal.Name;
            int age = animal.Age;
            int poids = animal.Poids;
            string couleur = animal.Couleur;
            string proprietaire = animal.Proprietaire;

            string query = $"INSERT INTO animal(TypeAnimal, Nom, Age, Poids, Couleur, Proprietaire) VALUES('{type}','{name}',{age},{poids},'{couleur}','{proprietaire}')"; //SQL query to write values into tables.
            string connectionString = "server=localhost;database=clinique;uid=root;pwd=;"; //Database connection info.

            MySqlConnection cnn = new MySqlConnection(connectionString); //SQLConnection object with connection info.
            cnn.Open(); //Open connection to database.
            MySqlCommand cmd = new MySqlCommand(query, cnn); //Create SQL Command.
            MySqlDataReader dataReader = cmd.ExecuteReader(); //Create a data reader and Execute the command.

            dataReader.Close(); //close Data Reader.
            cnn.Close(); //Close connection to database

            Console.WriteLine("L'animal a été ajouté a la pension.");
        }
       public static List<Animal> GetAnimalList() //Function to pull all animal data from database to then store in a List<Animal>.
        {
            string query = "SELECT * FROM animal"; //SQL query to select all data from the table.
            string connectionString = "server=localhost;database=clinique;uid=root;pwd=;"; //Database connection info.
            var list = new List<Animal>(); //Create a list to store the result

            MySqlConnection cnn = new MySqlConnection(connectionString); //SQLConnection object with connection info.
            cnn.Open(); //Open connection to database.
            MySqlCommand cmd = new MySqlCommand(query, cnn);  //Create Command
            MySqlDataReader dataReader = cmd.ExecuteReader(); //Create a data reader and Execute the command

            while (dataReader.Read())   //Read the data and store them in the list
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
                ));  //Animal Constructor.
            }
            dataReader.Close(); //close Data Reader
            cnn.Close(); //Close connection to database

            return list; //return list to be displayed
        }
       public static List<string> GetProprietaireList() //Function that returns a List of all owner's name.
       {
                string query = "SELECT Proprietaire FROM animal"; //Query to select the "proprietaire" column from the table.
                string connectionString = "server=localhost;database=clinique;uid=root;pwd=;"; //Database connection info.
                var list = new List<string>();  //Create a list to store the result.

                MySqlConnection cnn = new MySqlConnection(connectionString); //SQLConnection object with connection info.
                cnn.Open(); //Open connection to database
                MySqlCommand cmd = new MySqlCommand(query, cnn); //Create Command
                MySqlDataReader dataReader = cmd.ExecuteReader(); //Create a data reader and Execute the command

                while (dataReader.Read()) //Read the data and store them in the list
                {
                    list.Add((string)dataReader["Proprietaire"]);
                }
                dataReader.Close(); //close Data Reader
                cnn.Close(); //Close connection to database.

                return list;  //return list to be displayed
       }
       public static int GetAnimalWeight() //Function to get the sum on all animal weight.
       {            
            List<Animal> AnimalListCount = BD.GetAnimalList(); //Pulls data from Database to know if any animals are present.
            if (AnimalListCount.Count < 0)
            {
                int sum = 0; 
                string query = "SELECT Poids FROM animal"; //Query to select the "poids" column from the table.
                string connectionString = "server=localhost;database=clinique;uid=root;pwd=;"; //Database connection info.
                var list = new List<int>(); //Create a list to store the result

                MySqlConnection cnn = new MySqlConnection(connectionString); //SQLConnection object with connection info.
                cnn.Open(); //Open connection to database
                MySqlCommand cmd = new MySqlCommand(query, cnn); //Create Command
                MySqlDataReader dataReader = cmd.ExecuteReader();  //Create a data reader and Execute the command

                while (dataReader.Read())  //Read the data and store them in the list
                {
                    list.Add((int)dataReader["Poids"]);
                }
                dataReader.Close();  //close Data Reader
                cnn.Close(); //Close connection to database.

                sum = list.Sum(); //This adds up each int from the list.
                
                return sum; //return the sum of all the weight.
            }
            else
                Console.WriteLine("Aucun pensionnaire a lister.");  //Only happens if AnimalListCount.Count <= 0
            return 0;
       }
       public static List<Animal> GetAnimalColor(string color) //Function to get all animals of a given color.
        {
            string query = $"SELECT * FROM animal WHERE Couleur = '{color}'"; //Query to select all animal of a given color from the table.
            string connectionString = "server=localhost;database=clinique;uid=root;pwd=;"; //Database connection info.
            var list = new List<Animal>(); //Create a list to store the result

            MySqlConnection cnn = new MySqlConnection(connectionString); //SQLConnection object with connection info.
            cnn.Open(); //Open connection to database
            MySqlCommand cmd = new MySqlCommand(query, cnn); //Create Command
            MySqlDataReader dataReader = cmd.ExecuteReader(); //Create a data reader and Execute the command

            while (dataReader.Read()) //Read the data and store them in the list
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
                )); //Animal Constructor
            }
            dataReader.Close(); //close Data Reader
            cnn.Close(); //Close connection to database.

            return list; //return list to be displayed.
        }
       public static void RemoveAnimal(int id) //Function to remove an animal from the database.
        {
            List<Animal> AnimalListCount = BD.GetAnimalList(); //Pulls data from Database to know if any animals are present to remove.
            if (AnimalListCount.Count > 0)
            {
                string query = $"DELETE from animal WHERE ID = '{id}'"; //Query to remove an animal from the table.
                string connectionString = "server=localhost;database=clinique;uid=root;pwd=;"; //Database connection info.

                MySqlConnection cnn = new MySqlConnection(connectionString); //SQLConnection object with connection info.
                cnn.Open(); //Open connection to database
                MySqlCommand cmd = new MySqlCommand(query, cnn); //Create Command
                MySqlDataReader dataReader = cmd.ExecuteReader(); //Create a data reader and Execute the command

                dataReader.Close(); //close Data Reader
                cnn.Close(); //Close connection to database.

                Console.WriteLine($"Le pensionnaire numéro {id} à été retiré.");
                Console.ReadKey();
                Menu.ShowAllAnimal();
            }
            else
                Console.WriteLine("Aucun pensionnaire a retirer.");  //Only happens if AnimalListCount.Count <= 0
                Console.ReadKey();
        }
       public static void UpdateAnimal(int id, string name) //Function to update an animal in the database
        {
            List<Animal> AnimalListCount = BD.GetAnimalList(); //Pulls data from Database to know if any animals are present to update.
            if (AnimalListCount.Count > 0)
            {
                string query = $"UPDATE animal SET Name = '{name}' WHERE ID = '{id}'";  //Query to update then "name" column from the table.
                string connectionString = "server=localhost;database=clinique;uid=root;pwd=;"; //Database connection info.

                MySqlConnection cnn = new MySqlConnection(connectionString); //SQLConnection object with connection info.
                cnn.Open(); //Open connection to database
                MySqlCommand cmd = new MySqlCommand(query, cnn); //Create Command
                MySqlDataReader dataReader = cmd.ExecuteReader(); //Create a data reader and Execute the command
               
                dataReader.Close(); //close Data Reader
                cnn.Close(); //Close connection to database.

                Console.WriteLine($"Le nom du pensionnaire {id} à été modifié.");  
                Console.ReadKey();
                Menu.ShowAllAnimal();
            }
            else
            {
                Console.WriteLine("Aucun pensionnaire a modifier.");   //Only happens if AnimalListCount.Count <= 0
                Console.ReadKey();
            }
        }
    }
}
