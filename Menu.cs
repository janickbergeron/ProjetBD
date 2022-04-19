using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_BD
{
    internal class Menu
    {
        public static void ShowAllAnimal()
        {
            List<Animal> AnimalList = BD.GetAnimalList();
            Console.Clear();
        string menuString =  "╔═══════════════════════════════════════════════════════════════════════════════╗ \n" +
                             "║  ID  |   Type    |     Nom     |  Age  |  Poids  |  Couleur  |   Propriétaire ║ \n";
            foreach (Animal animal in AnimalList)
            {
                menuString += String.Format("║  {0,-3} |  {1,-8} |  {2,-10} |   {3,-3} |   {4,-5} |   {5,-6}  |      {6,-10}║\n",animal.Id,animal.Type,animal.Name,animal.Age,animal.Poids,animal.Couleur,animal.Proprietaire);
            }
            menuString += "╚═══════════════════════════════════════════════════════════════════════════════╝";

            Console.WriteLine(menuString);
        }
        public static void ShowAllProprio()
        {
            List<string> ProprioList = BD.GetProprietaireList();
            Console.Clear();        
            string menuString = "╔═══════════════════╗ \n" +
                                "║   Propriétaire    ║ \n" +
                                "╠═══════════════════╣ \n";
            foreach (string proprio in ProprioList)
            {
                menuString += String.Format("║     {0,-10}    ║\n", proprio);
            }
            menuString +=       "╚═══════════════════╝";

            Console.WriteLine(menuString);
        }
        public static void ShowAnimalTotal()
        {
            List<Animal> AnimalList = BD.GetAnimalList();
            Console.Clear();
            string menuString = "╔════════════════════════════╗ \n" +
                                "║   Total nombre d'animaux   ║ \n" +
                                "╠════════════════════════════╣ \n";
            
            
                menuString += String.Format("║              {0,-5}         ║\n", AnimalList.Count);
            
            menuString += "╚════════════════════════════╝";

            Console.WriteLine(menuString);
        }
        public static void ShowAnimalPoidsTotal()
        {
            int sum = BD.GetAnimalWeight();
            Console.Clear();
            string menuString = "╔═════════════════════════╗ \n" +
                                "║   Total poids animaux   ║ \n" +
                                "╠═════════════════════════╣ \n";


            menuString += String.Format("║            {0,-5}        ║\n", sum);

            menuString += "╚═════════════════════════╝";

            Console.WriteLine(menuString);
        }
        public static void ShowAllAnimalColor()
        {
            List<Animal> AnimalList = BD.GetAnimalList();
            if (AnimalList.Count > 0)
            {
                string couleur = null;
                Console.WriteLine("Veuillez choisir une couleur: (Rouge, Bleu ou Violet.)");
                do couleur = Console.ReadLine().ToLower();
                while (couleur != "rouge" && couleur != "bleu" && couleur != "violet");
                AnimalList = BD.GetAnimalColor(couleur);
                Console.Clear();
                string menuString = "╔═══════════════════════════════════════════════════════════════════════════════╗ \n" +
                                 "║  ID  |   Type    |     Nom     |  Age  |  Poids  |  Couleur  |   Propriétaire ║ \n";
                foreach (Animal animal in AnimalList)
                {
                    menuString += String.Format("║  {0,-3} |  {1,-8} |  {2,-10} |   {3,-3} |   {4,-5} |   {5,-6}  |      {6,-10}║\n", animal.Id, animal.Type, animal.Name, animal.Age, animal.Poids, animal.Couleur, animal.Proprietaire);
                }
                menuString += "╚═══════════════════════════════════════════════════════════════════════════════╝";

                Console.WriteLine(menuString);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Aucun pensionnaire présentement.");
                Console.ReadKey();
            }
        }
        public static int SelectAnimal()
        {
            List<Animal> AnimalList = BD.GetAnimalList();
            if (AnimalList.Count > 0)
            {
                    int id = 0;
                ShowAllAnimal();
                Console.WriteLine("Veuillez entrer l'ID de l'animal.");
                try { id = int.Parse(Console.ReadLine()); }
                catch (Exception ex)
                {
                    Console.WriteLine("Entré incorrecte.");
                }
                return id;
            }
            else
            {
                return 0;
            }
        }
        public static string SelectNewName()
        {
            List<Animal> AnimalList = BD.GetAnimalList();
            if (AnimalList.Count > 0)
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
        public static void ShowMainMenu()
        {
            Console.Clear();
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
            Console.WriteLine(menuString);
            InputMainMenu();
        }
        public static void InputMainMenu()
        {
            Console.WriteLine("Veuillez faire un choix:");
            string input;
            do input = Console.ReadLine();
            while (input != "1" && input != "2" && input != "3" && input != "4" && input != "5" && input != "6" && input != "7" && input != "8" && input != "9");
            switch (input)
            {
                case "1":
                    BD.AddAnimalToDB(BD.AjouterAnimal());
                    Console.WriteLine("L'animal a été ajouté a la pension.");
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
