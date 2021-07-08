using System;
using System.Text;

namespace ja.training.csharp._05_Umkreissuche
{
    public class UmkreissucheExampleApplication
    {
        public UmkreissucheExampleApplication(TelefonzellenRepository repository)
        {
            var address = "Heußweg 25, 20255";
            var results = repository.Load(address, 10).Result;
            foreach(var r in results)
            {
                Console.WriteLine($"z.B. die hier? {r.StreetAndNumber}, {r.ZipCode}, {r.City}??");
            }
        }
    }
}
