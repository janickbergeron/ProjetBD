using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_BD
{
    internal class Animal
    {
        private int _id;
        private string _type;
        private string _name;
        private int _age;
        private int _poids;
        private string _couleur;
        private string _proprietaire;

        public int Id { get { return _id; } set { _id = value; } }
        public string Type { get { return _type; } set { _type = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public int Age { get { return _age; } set { _age = value; } }
        public int Poids { get { return _poids; } set { _poids = value; } }
        public string Couleur { get { return _couleur; } set { _couleur = value; } }
        public string Proprietaire { get { return _proprietaire; } set { _proprietaire = value; } }

        public static List<Animal> AnimalList = new List<Animal>();

        public Animal(int id, string type, string name, int age, int poids, string couleur, string proprietaire)
        {
            _id = id;
            _type = type;
            _name = name;   
            _age = age;
            _poids = poids;
            _couleur = couleur;
            _proprietaire = proprietaire;
        }
        
        public static List<Animal> GetAnimalList()
        {
            string query = "SELECT * FROM animal";

            //Create a list to store the result
            var list = new List<Animal>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);  //  connection???
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list.Add(new Animal
                    {
                           Id = int.Parse(dataReader["ID"]),
                           Type = dataReader["Type"].ToString(),
                           Name = dataReader["Name"].ToString(),
                           Age = int.Parse(dataReader["Age"]),
                           Poids = int.Parse(dataReader["Poids"]),
                           Couleur = dataReader["Couleur"].ToString(),
                           Proprietaire = dataReader["Proprietaire"].ToString()
                    });                        
                }
       
                //Console.ReadLine();

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
               return list;
            }
            else
            {
                return list;
            }
            
        }
    }
}
