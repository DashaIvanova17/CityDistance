using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Program
{
    // Пример базы данных городов с координатами
    static Dictionary<string, (double latitude, double longitude)> cities = new Dictionary<string, (double, double)>
    {
            { "Москва", (55.7558, 37.6173) },
            { "Санкт-Петербург", (59.9343, 30.3351) },
            { "Казань", (55.8304, 49.0661) },
            { "Новосибирск", (55.0084, 82.9357) },
            { "Екатеринбург", (56.8389, 60.6057) },
            { "Нижний Новгород", (56.2965, 44.002) },
            { "Челябинск", (55.1644, 61.4368) },
            { "Омск", (54.9893, 73.3682) },
            { "Самара", (53.1952, 50.1069) },
            { "Ростов-на-Дону", (47.2357, 39.7015) },
            { "Уфа", (54.7348, 55.9575) },
            { "Красноярск", (56.0153, 92.8932) },
            { "Пермь", (58.0103, 56.2344) },
            { "Воронеж", (51.6593, 39.1966) },
            { "Волгоград", (48.7080, 44.5133) },
            { "Краснодар", (45.0402, 38.9760) },
            { "Саратов", (51.5339, 46.0347) },
            { "Тюмень", (57.1535, 65.5423) },
            { "Тольятти", (53.5078, 49.4204) },
            { "Ижевск", (56.8389, 53.2765) },
            { "Барнаул", (53.3474, 83.7784) },
            { "Иркутск", (52.2830, 104.3050) },
            { "Ульяновск", (54.3142, 48.4032) },
            { "Тверь", (56.8587, 35.9176) },
            { "Магнитогорск", (53.4077, 58.9793) },
            { "Калуга", (54.5138, 36.2604) },
            { "Киров", (58.6035, 49.6680) },
            { "Сочи", (43.6028, 39.7342) },
            { "Чита", (52.0317, 113.5009) },
            { "Ставрополь", (45.0428, 41.9734) },
            { "Белгород", (50.5975, 36.5852) },
            { "Астрахань", (46.3479, 48.0336) },
            { "Улан-Удэ", (51.8333, 107.5841) },
            { "Тамбов", (52.7213, 41.4524) },
            { "Владимир", (56.1296, 40.4061) },
            { "Мурманск", (68.9792, 33.0746) },
            { "Якутск", (62.0360, 129.733) },
            { "Хабаровск", (48.4726, 135.0578) },
            { "Ярославль", (57.6261, 39.8845) },
            { "Оренбург", (51.7682, 55.0969) },
            { "Новокузнецк", (53.7596, 87.1216) },
            { "Кемерово", (55.3516, 86.0874) },
            { "Абакан", (53.7156, 91.4295) },
            { "Азов", (47.1161, 39.4166) },
            { "Александров", (56.3993, 38.7116) },
            { "Калининград", (54.1161, 20.7116) },
            { "Великий Новгород", (58.5298, 31.2765) },
            { "Воскресенск", (55.3232, 38.6525) },
            { "Грозный", (43.3134, 45.6924) },
            { "Железногорск", (52.3323, 93.5344) },
            { "Жуковский", (43.3134, 45.69) },
            { "Жигулёвск", (53.4334, 49.4747) },
            { "Заречный", (55.6543, 38.1236) },
            { "Заринск", (43.3144, 45.6955) },
            { "Ессентуки", (44.0454, 42.8657) },
                
    };

    static void Main(string[] args)
    {
         bool exit = false;

 while (!exit)
 {
     string city1 = GetCity("Введите название первого города: ");
     string city2 = GetCity("Введите название второго города: ");

     (double lat1, double lon1) = cities[city1];
     (double lat2, double lon2) = cities[city2];

     Console.WriteLine("Выберите метод расчета расстояния:");
     Console.WriteLine("1. По прямой");
     Console.WriteLine("2. В объезд");
     string choice = Console.ReadLine();

     double distance = 0;

     if (choice == "1")
     {
         distance = CalculateDistance(lat1, lon1, lat2, lon2);
         Console.WriteLine($"Расстояние по прямой между {city1} и {city2}: {distance:F2} км");
     }
     else if (choice == "2")
     {
         // Здесь можно реализовать алгоритм для расчета расстояния по дороге
         // Для простоты будем использовать заглушку
         distance = CalculateRoadDistance(city1, city2);
         Console.WriteLine($"Расстояние в объезд между {city1} и {city2}: примерно {distance} км ");
     }
     else
     {
         Console.WriteLine("Некорректный выбор метода.");
     }

     Console.WriteLine("Хотите продолжить расчет? (Да/Нет)");
     string continueChoice = Console.ReadLine();

     if (continueChoice.ToLower() != "да")
     {
         exit = true;
     }
        }
    }

    static string GetCity(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string city = Console.ReadLine();
            if (cities.ContainsKey(city))
            {
                return city;
            }
            else
            {
                Console.WriteLine("Город не найден в базе данных. Пожалуйста, попробуйте снова.");
            }
        }
    }

    static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
    {
        // Формула для расчета расстояния по прямой (Haversine)
        const double R = 6371; // Радиус Земли в км
        double dLat = ToRadians(lat2 - lat1);
        double dLon = ToRadians(lon2 - lon1);
        double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                   Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                   Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        return R * c;
    }

    static double CalculateRoadDistance(string city1, string city2)
    {

        return new Random().Next(200, 1000);
    }

    static double ToRadians(double angle)
    {
        return angle * Math.PI / 180.0;

    }

}
