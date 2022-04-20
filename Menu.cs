using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_BD
{
    internal class Menu
    {
        public static void ShowAllAnimal() //Function to display all animals.
        {
            List<Animal> AnimalList = BD.GetAnimalList(); //Pulls data from Database stored in a list to display.
            Console.Clear();
                       string menuString =  "╔═══════════════════════════════════════════════════════════════════════════════╗ \n" +
                                            "║  ID  |   Type    |     Nom     |  Age  |  Poids  |  Couleur  |   Propriétaire ║ \n";
            foreach (Animal animal in AnimalList) //Create a new formated line for each animal in AnimalList.
            {1                                                                                                                    //  0          1           2           3           4            5                6
                menuString += String.Format("║  {0,-3} |  {1,-8} |  {2,-10} |   {3,-3} |   {4,-5} |   {5,-6}  |      {6,-10}║\n" ,animal.Id,animal.Type,animal.Name,animal.Age,animal.Poids,animal.Couleur,animal.Proprietaire); //String.Format is used within the string's "" represented with {X,Y}.
            }                                                                                                                                                                                                                    //X represents the attribute after the string. Y represent the number of character reserved for this attribute.                                            
                              menuString += "╚═══════════════════════════════════════════════════════════════════════════════╝";                                                                                                 //Everything in between each pairs of bracket is also included in the final string.

            Console.WriteLine(menuString); //Display complete menuString.
        }
        public static void ShowAllProprio() //Function to display all animals owner.
        {
            List<string> ProprioList = BD.GetProprietaireList(); //Pulls data from Database stored in a list to display.
            Console.Clear();        
                        string menuString = "╔═══════════════════╗ \n" +
                                            "║   Propriétaire    ║ \n" +
                                            "╠═══════════════════╣ \n";
            foreach (string proprio in ProprioList) //Create a new formated line for each onwer in ProprioList
            {
                menuString += String.Format("║     {0,-10}    ║\n", proprio);
            }
                        menuString +=       "╚═══════════════════╝";

            Console.WriteLine(menuString); //Display complete menuString.
        }
        public static void ShowAnimalTotal() //Function to display the current animals total.
        {
            List<Animal> AnimalList = BD.GetAnimalList(); //Pulls data from Database stored in a list to display.
            Console.Clear();
                        string menuString = "╔════════════════════════════╗ \n" +
                                            "║   Total nombre d'animaux   ║ \n" +
                                            "╠════════════════════════════╣ \n";
                menuString += String.Format("║              {0,-5}         ║\n", AnimalList.Count);
                              menuString += "╚════════════════════════════╝";
             
            Console.WriteLine(menuString); //Display complete menuString.
        }
        public static void ShowAnimalPoidsTotal() //Function to show total weight of animals.
        {
            int sum = BD.GetAnimalWeight(); //Pulls data from Database to get the total weight.
            Console.Clear();
                    string menuString = "╔═════════════════════════╗ \n" +
                                        "║   Total poids animaux   ║ \n" +
                                        "╠═════════════════════════╣ \n";
            menuString += String.Format("║            {0,-5}        ║\n", sum);
                          menuString += "╚═════════════════════════╝";

            Console.WriteLine(menuString); //Display complete menuString.
        }
        public static void ShowAllAnimalColor() //Function to display all animal with the same color.
        {
            List<Animal> AnimalListCount = BD.GetAnimalList(); //Pulls data from Database to know if any animals are present to display.
            if (AnimalListCount.Count > 0)
            {
                string couleur = null;
                Console.WriteLine("Veuillez choisir une couleur: (Rouge, Bleu ou Violet.)");
                do couleur = Console.ReadLine().ToLower();
                while (couleur != "rouge" && couleur != "bleu" && couleur != "violet"); //Ensure user input is one of the 3 colors.

                List<Animal> AnimalList = BD.GetAnimalColor(couleur); //Pulls data from Database stored in a list to display.
                Console.Clear();
                            string menuString = "╔═══════════════════════════════════════════════════════════════════════════════╗ \n" +
                                                "║  ID  |   Type    |     Nom     |  Age  |  Poids  |  Couleur  |   Propriétaire ║ \n";
                foreach (Animal animal in AnimalList) //Create a new formated line for each animal in AnimalList.
                {
                    menuString += String.Format("║  {0,-3} |  {1,-8} |  {2,-10} |   {3,-3} |   {4,-5} |   {5,-6}  |      {6,-10}║\n", animal.Id, animal.Type, animal.Name, animal.Age, animal.Poids, animal.Couleur, animal.Proprietaire); //See Formated String comments in ShowAllAnimal(),
                }
                                  menuString += "╚═══════════════════════════════════════════════════════════════════════════════╝";

                Console.WriteLine(menuString); //Display complete menuString.
            }
            else
            {
                Console.WriteLine("Aucun pensionnaire présentement.");  //Only happens if AnimalListCount.Count <= 0
                Console.ReadKey();
            }
        }
        public static int SelectAnimal() //Function that returns the ID integer of a selected animal.
        {
            List<Animal> AnimalListCount = BD.GetAnimalList(); //Pulls data from Database to know if any animals are present to select.
            if (AnimalListCount.Count > 0)
            {
                    int id = 0;
                ShowAllAnimal();  //Display a list of animals for user's to choose and record input.
                Console.WriteLine("Veuillez entrer l'ID de l'animal.");
                try { id = int.Parse(Console.ReadLine()); }
                catch (Exception ex)
                {
                    Console.WriteLine("Entré incorrecte.");   //Happens if user try to enter any non-integer characters.
                }
                return id;
            }
            else
            {
                return 0;
            }
        }
        public static string SelectNewName()  //Function that returns a string from the user's input.
        {
            List<Animal> AnimalListCount = BD.GetAnimalList(); //Pulls data from Database to know if any animals are present to update.
            if (AnimalListCount.Count > 0)
            {
                string name = null;
                Console.WriteLine("Veuillez entrer le nouveau nom de l'animal.");
                name = Console.ReadLine();
                return name;
            }
            else
            {
                return null;
            }
        }
        public static void ShowMainMenu() //Function that display the main menu.
        {
            Console.Clear();   //Starts with a Clear to make sure you don't end up with duplicate menu.
            string menuString = "╔═════════════════════════════════════════════╗ \n" +
                                "║               Menu Principal                ║ \n" +
                                "╠═════════════════════════════════════════════╣ \n" +
                                "║    1 - Ajouter Animal                       ║ \n" +
                                "║    2 - Liste des Animaux en Pension         ║ \n" +
                                "║    3 - Liste de proprietaire                ║ \n" +
                                "║    4 - Total d'animaux en pension           ║ \n" +
                                "║    5 - Poids total des animaux en pension   ║ \n" +
                                "║    6 - Liste des animaux d'une même couleur ║ \n" +
                                "║    7 - Retirer Animal                       ║ \n" +
                                "║    8 - Modifier Animal                      ║ \n" +
                                "║    9 - Quitter                              ║ \n" +
                                "╚═════════════════════════════════════════════╝";
            Console.Clear();
            Console.WriteLine(menuString); //Display complete menuString.
            InputMainMenu();
        }
        public static void InputMainMenu() //Function to align the user's choice from main menu.
        {
            Console.WriteLine("Veuillez faire un choix:");
            string input;
            do input = Console.ReadLine();
            while (input != "1" && input != "2" && input != "3" && input != "4" && input != "5" && input != "6" && input != "7" && input != "8" && input != "9"); //Ensure the user's input is (1-9)
            switch (input)
            {
                case "1":
                    BD.AddAnimalToDB(BD.AjouterAnimal());
                    Console.ReadKey();
                    ShowMainMenu();
                    break;
                case "2":
                    ShowAllAnimal();
                    Console.ReadKey();
                    ShowMainMenu();
                    break;
                case "3":
                    ShowAllProprio();
                    Console.ReadKey();
                    ShowMainMenu();
                    break;
                case "4":
                    ShowAnimalTotal();
                    Console.ReadKey();
                    ShowMainMenu();
                    break;
                case "5":
                    ShowAnimalPoidsTotal();
                    Console.ReadKey();
                    ShowMainMenu();
                    break;
                case "6":
                    ShowAllAnimalColor();
                    Console.ReadKey();
                    ShowMainMenu();
                    break;
                case "7":
                    BD.RemoveAnimal(SelectAnimal());
                    ShowMainMenu();
                    break;
                case "8":
                    BD.UpdateAnimal(SelectAnimal(), SelectNewName());
                    ShowMainMenu();
                    break;
                case "9":

                    break;
            }
        }
    }
}
