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

        string menuString =  "╔═══════════════════════════════════════════════════════════════════════════════╗ \n" +
                             "║  ID  |   Type    |     Nom     |  Age  |  Poids  |  Couleur  |   Propriétaire ║ \n";
            foreach (Animal animal in Animal.AnimalList)
            {
                menuString += String.Format("║  {0,-3} |  {1,-8} |  {2,-10} |   {3,-3} |   {4,-5} |   {5,-6}  |      {6,-10}║\n",animal.Id,animal.Type,animal.Name,animal.Age,animal.Poids,animal.Couleur,animal.Proprietaire);
            }
            menuString += "╚═══════════════════════════════════════════════════════════════════════════════╝";

            Console.WriteLine(menuString);
        }
        public static void ShowMainMenu()
        {
            string menuString = "╔═════════════════════════════════════════════╗ \n" +
                                "║               Menu Principal                ║ \n" +
                                "║                                             ║ \n" +
                                "║    1 - Ajouter Animal                       ║ \n" +
                                "║    2 - Liste des Animaux en Pension         ║ \n" +
                                "║    3 - Liste de proprietaire                ║ \n" +
                                "║    4 - Total d'animaux en pension           ║ \n" +
                                "║    5 - Poids total des animaux en pension   ║ \n" +
                                "║    6 - Liste des animaux d'une même couleur ║ \n" +
                                "║    7 - Retirer Animal                       ║ \n" +
                                "║    8 - Modifier Animal                      ║ \n" +
                                "║                                             ║ \n" +
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
            while (input != "1" && input != "2" && input != "3" && input != "4" && input != "5" && input != "6" && input != "7" && input != "8" && input != "9")
            switch (input)
            {
                case "1":

                    break;
                case "2":

                    break;
                case "3":

                    break;
                case "4":

                    break;
                case "5":

                    break;
                case "6":

                    break;
                case "7":

                    break;
                case "8":

                    break;
                case "9":

                    break;
            }
        }
    }
}
