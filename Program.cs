namespace Projet_BD
{
    public class Program
    {
        static void Main(string[] args)
        {
            Animal.AnimalList = BD.GetAnimalList(); //Initial data pull drom the database.
            Menu.ShowMainMenu();
        }
    }
}