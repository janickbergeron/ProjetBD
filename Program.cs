namespace Projet_BD
{
    public class Program
    {
        static void Main(string[] args)
        {
            //BD.ConnectToDatabase();
            //Animal.AnimalList = Animal.GetAnimalList();

            Animal chien = new(0,"chien","fido",5,10,"bleu","pierre");
            Animal chat = new(1,"chat", "mitaine", 2, 5, "brun", "gilles");
            Animal.AnimalList.Add(chien);
            Animal.AnimalList.Add(chat);

            //Menu.ShowAllProprio();
            //Menu.ShowAllAnimal();
            Menu.ShowMainMenu();
        }
    }
}