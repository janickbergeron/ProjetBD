namespace Projet_BD
{
    public class Program
    {
        static void Main(string[] args)
        {
            //BD.ConnectToDatabase();


            Animal chien = new(1,"chien","fido",5,10,"bleu","pierre");
            Animal chat = new(2, "chat", "mitaine", 2, 5, "brun", "gilles");
            Animal.AnimalList.Add(chien);
            Animal.AnimalList.Add(chat);

            Menu.ShowAllAnimal();
        }
    }
}