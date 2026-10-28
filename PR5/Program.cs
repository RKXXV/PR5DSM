using HashPasswords;
using PR5.Model;
using System;

namespace PR5
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Введите имя пользователя: ");
            string name = Console.ReadLine();
            Console.Write("Введите фамилию пользователя: ");
            string surname = Console.ReadLine();
            Console.Write("Введите логин пользователя: ");
            string login = Console.ReadLine();
            Console.Write("Введите пароль пользователя: ");
            string password = Console.ReadLine();
            Console.Write("Укажите ClientId: ");
            int clientId = Convert.ToInt32(Console.ReadLine());

            string hash = Hash.HashPasswords(password);
            Console.WriteLine($"Хэшированный пароль пользователя: {hash}");

            using (SoftForgeDBEntities model = new SoftForgeDBEntities())
            {
                User user = new User() 
                { 
                    Name = name, 
                    Surname = surname, 
                    Login = login, 
                    Password = hash, 
                    ClientId = clientId 
                };

                model.User.Add(user);
                model.SaveChanges();
            }

            Console.WriteLine("Учётная запись добавлена");
        }
    }
}
