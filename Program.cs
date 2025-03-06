
namespace Library
{
    class Program
    {
        static void Main()
        {
            User user=new User();
            Login login=new Login();

            while(true)
            {
                Console.WriteLine("\n1. Register");
                Console.WriteLine("\n2. Login");
                Console.WriteLine("\n3. Sign Out");
                Console.Write("\nChoice: ");
                string choice=Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        user.Register();
                        break;
                    case "2":
                        login.SignIn();
                        break;
                    case "3":
                        Console.WriteLine("Program is finished!");
                        return;
                    default:
                        Console.WriteLine("Incorrect choice!");
                        break;
                }
            }
        }
    }
}















