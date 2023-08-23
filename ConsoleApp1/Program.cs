using ConsoleApp1.Examples;

namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {
        using ( ApplicationContext db = new ApplicationContext() )
        {
            // создаем два объекта User
            User tom = new User { Name = "Tom", Age = 33 };
            User alice = new User { Name = "Alice", Age = 26 };

            // добавляем их в бд
            db.Users.Add( tom );
           
            db.Users.Add( alice );
            db.SaveChanges();

            Console.WriteLine( "Объекты успешно сохранены" );

            // получаем объекты из бд и выводим на консоль
            List<User> users = db.Users.Where(x => x.Age > 30).ToList();
            Console.WriteLine( "Список объектов:" );
            foreach ( User u in users )
            {
                Console.WriteLine( $"{u.Id}.{u.Name} - {u.Age}" );
            }
        }
    }
}