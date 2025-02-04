using HairSaloon.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HairSaloon.DataAccess.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
// Zamienione z DbContext, IdentityDbContext jest funkcjonalnością wymaganą do .NET identity
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Blog> Blogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // Jest potrzebne jako konfiguracja do IdentityDbContext

        modelBuilder.Entity<Service>().HasData(
            new Service { Id = 1, Name = "Strzyżenie męskie", Category = "Strzyżenie", Price = 50, DurationInMinutes = 60, Description = "" },
            new Service { Id = 2, Name = "Strzyżenie damskie", Category = "Farbowanie", Price = 50, DurationInMinutes = 90, Description = "" },
            new Service { Id = 3, Name = "Farbowanie włosów", Category = "Pakiety", Price = 50, DurationInMinutes = 30, Description = "" },
            new Service { Id = 4, Name = "Depilacja", Category = "Pielęgnacja", Price = 50, DurationInMinutes = 30, Description = "" },
            new Service { Id = 5, Name = "Strzyżenie męskie", Category = "Strzyżenie", Price = 50, DurationInMinutes = 60, Description = "" },
            new Service { Id = 6, Name = "Strzyżenie damskie", Category = "Farbowanie", Price = 50, DurationInMinutes = 90, Description = "" },
            new Service { Id = 7, Name = "Farbowanie włosów", Category = "Pakiety", Price = 50, DurationInMinutes = 30, Description = "" },
            new Service { Id = 8, Name = "Depilacja", Category = "Pielęgnacja", Price = 50, DurationInMinutes = 30, Description = "" },
            new Service { Id = 9, Name = "Depilacja", Category = "Pielęgnacja", Price = 50, DurationInMinutes = 30, Description = "" },
            new Service { Id = 10, Name = "Depilacja", Category = "Pielęgnacja", Price = 50, DurationInMinutes = 30, Description = "" },
            new Service { Id = 11, Name = "Strzyżenie męskie", Category = "Strzyżenie", Price = 50, DurationInMinutes = 60, Description = "" },
            new Service { Id = 12, Name = "Strzyżenie damskie", Category = "Farbowanie", Price = 50, DurationInMinutes = 90, Description = "" },
            new Service { Id = 13, Name = "Farbowanie włosów", Category = "Pakiety", Price = 50, DurationInMinutes = 30, Description = "" },
            new Service { Id = 14, Name = "Depilacja", Category = "Pielęgnacja", Price = 50, DurationInMinutes = 30, Description = "" },
            new Service { Id = 15, Name = "Strzyżenie męskie", Category = "Strzyżenie", Price = 50, DurationInMinutes = 60, Description = "" },
            new Service { Id = 16, Name = "Strzyżenie damskie", Category = "Farbowanie", Price = 50, DurationInMinutes = 90, Description = "" },
            new Service { Id = 17, Name = "Farbowanie włosów", Category = "Pakiety", Price = 50, DurationInMinutes = 30, Description = "" },
            new Service { Id = 18, Name = "Depilacja", Category = "Pielęgnacja", Price = 50, DurationInMinutes = 30, Description = "" },
            new Service { Id = 19, Name = "Depilacja", Category = "Pielęgnacja", Price = 50, DurationInMinutes = 30, Description = "" },
            new Service { Id = 20, Name = "Depilacja", Category = "Pielęgnacja", Price = 50, DurationInMinutes = 30, Description = "" }
            );

        modelBuilder.Entity<Blog>().HasData(
            new Blog
            {
                Id = 1,
                Title = "Mała suszarka do włosów – suszarka podróżna - TOP5",
                Content = "Ty też nie lubisz rozstawać się na dłużej ze swoją suszarką do włosów? Hotelowe urządzenia zwykle nie spełniają Twoich oczekiwań, a Ty chcesz mieć dobrej jakości suszarkę zawsze ze sobą? A może szukasz mini suszarki, która zmieści się w treningowej torbie? Mała suszarka do włosów będzie strzałem w dziesiątkę. Oczywiście pod warunkiem, że będzie miała spore jak na swój niewielki rozmiar możliwości! Jaka suszarka podróżna będzie najlepszym wyborem? Zobacz ranking TOP5 modeli profesjonalnych renomowanych marek. mała suszarka do włosów 5. BaByliss Pro Bambino suszarka do włosów - mała, ale o dużych możliwościach Oto suszarka do włosów mała, ale mająca naprawdę spore jak na te wymiary możliwości. To propozycja włoskiego producenta profesjonalnego sprzętu fryzjerskiego, znanego z zaawansowanych rozwiązań. Mocny silnik o mocy 1200 W jest gwarancją długotrwałego i bezawaryjnego użytkowania. Zaletą tego modelu jest też zdejmowany filtr oraz powłoka nanotytanowa, dająca świetne rezultaty szybkiego i bezpiecznego dla włosów suszenia. Do wyboru masz tu dwie temperatury i prędkości nadmuchu. W zestawie znajduje się koncentrator powietrza do wygładzania włosów oraz dyfuzor do podkreślana skrętu włosów falowanych lub kręconych. Suszarka nie składa się, ale jest na tyle kompaktowa, że bez trudu zmieścisz ją w bagażu. I polecisz gdziekolwiek, bo posiada podwójne napięcie. BaByliss Pro BAB5510E Bambino Mini suszarka do włosów 12345 4.8/5 (opinii: 6) 133,47 zł BaByliss Pro BAB5510E Bambino Mini suszarka do włosów 4. Gamma Piu Mini 7005 – mała suszarka z jonizacją Niecałe 13 cm długości ma kompaktowa suszarka do włosów włoskiej firmy Gamma Piu. Model Mini 7005 jest świetnie oceniany i chętnie wybierany jako suszarka podróżna (choć – uwaga - nie ma podwójnego napięcia), ale i podręczna. Doskonale sprawdza się też po fitnessie, siłowni, basenie itp. Nie tylko dlatego, że jest lekka i mała, ale również przez to, że jej nylonowa powłoka jest wyjątkowo odporna na zarysowania i uszkodzenia. Ogromnym plusem tej małej suszarki do włosów jest jonizacja. Tak mała suszarka z jonizacją to rzadkość. Dodatkowo turmalinowa powłoka sprawia, że włosy są dużo mniej podatne na elektryzowanie się. Mini suszarka ma po dwa ustawienia ciepła i prędkości, a w komplecie ma dyfuzor i zwężaną końcówkę koncentrującą powietrze. Ściągany filtr można wyczyścić. Dostępne kolory to: czerń, fuksja i pomarańcz. Gamma Piu MINI 7005 kompaktowa, mini suszarka do włosów, 1000W pytania o produkt: 2 12345 4.7/5 (opinii: 3) 138,99 zł Gamma Piu MINI 7005 kompaktowa, mini suszarka do włosów, 1000W 3. Gamma Piu E-T.C. Mini – lekka i poręczna suszarka o świetnych parametrach Na podium witamy model Gamma Piu. Tym razem jest to E-T.C. Mini, czyli wersja typowo podróżna, wyposażona w podwójne napięcie. Między innymi to odróżnia ją od „kuzynki” 7500, którą opisywaliśmy już w naszym rankingu. Podobnie jak ona, ma nylonową odporną powłokę, która jest idealnym rozwiązaniem dla osób dużo podróżujących, czy też trenujących na basenie, siłowni itp. Tej suszarce nie straszne żadne warunki. Nie zawiedzie Cię dzięki specjalnej technologii gwarantującej wysoką wydajność i siłę. Mimo, że waży zaledwie 200 g, potrafi szybko i skutecznie wysuszyć włosy, przy okazji wygładzając je dzięki jonizacji. Posiada dwie końcówki, umożliwia suszenie włosów z dyfuzorem i koncentratorem, a do wyboru masz klasyczną czerń i dwie wersje kolorystyczne. E-T. C. przyznajemy tytuł jednej z najlepszych małych suszarek do włosów w naszym rankingu.",
                EmployeeId = "8b28c0e7-7c1b-4f88-9e80-430bdce5c68a",
                PublicationDate = new DateOnly()
            },
            new Blog
            {
                Id = 2,
                Title = "Mała suszarka do włosów – suszarka podróżna - TOP5",
                Content = "Ty też nie lubisz rozstawać się na dłużej ze swoją suszarką do włosów? Hotelowe urządzenia zwykle nie spełniają Twoich oczekiwań, a Ty chcesz mieć dobrej jakości suszarkę zawsze ze sobą? A może szukasz mini suszarki, która zmieści się w treningowej torbie? Mała suszarka do włosów będzie strzałem w dziesiątkę. Oczywiście pod warunkiem, że będzie miała spore jak na swój niewielki rozmiar możliwości! Jaka suszarka podróżna będzie najlepszym wyborem? Zobacz ranking TOP5 modeli profesjonalnych renomowanych marek. mała suszarka do włosów 5. BaByliss Pro Bambino suszarka do włosów - mała, ale o dużych możliwościach Oto suszarka do włosów mała, ale mająca naprawdę spore jak na te wymiary możliwości. To propozycja włoskiego producenta profesjonalnego sprzętu fryzjerskiego, znanego z zaawansowanych rozwiązań. Mocny silnik o mocy 1200 W jest gwarancją długotrwałego i bezawaryjnego użytkowania. Zaletą tego modelu jest też zdejmowany filtr oraz powłoka nanotytanowa, dająca świetne rezultaty szybkiego i bezpiecznego dla włosów suszenia. Do wyboru masz tu dwie temperatury i prędkości nadmuchu. W zestawie znajduje się koncentrator powietrza do wygładzania włosów oraz dyfuzor do podkreślana skrętu włosów falowanych lub kręconych. Suszarka nie składa się, ale jest na tyle kompaktowa, że bez trudu zmieścisz ją w bagażu. I polecisz gdziekolwiek, bo posiada podwójne napięcie. BaByliss Pro BAB5510E Bambino Mini suszarka do włosów 12345 4.8/5 (opinii: 6) 133,47 zł BaByliss Pro BAB5510E Bambino Mini suszarka do włosów 4. Gamma Piu Mini 7005 – mała suszarka z jonizacją Niecałe 13 cm długości ma kompaktowa suszarka do włosów włoskiej firmy Gamma Piu. Model Mini 7005 jest świetnie oceniany i chętnie wybierany jako suszarka podróżna (choć – uwaga - nie ma podwójnego napięcia), ale i podręczna. Doskonale sprawdza się też po fitnessie, siłowni, basenie itp. Nie tylko dlatego, że jest lekka i mała, ale również przez to, że jej nylonowa powłoka jest wyjątkowo odporna na zarysowania i uszkodzenia. Ogromnym plusem tej małej suszarki do włosów jest jonizacja. Tak mała suszarka z jonizacją to rzadkość. Dodatkowo turmalinowa powłoka sprawia, że włosy są dużo mniej podatne na elektryzowanie się. Mini suszarka ma po dwa ustawienia ciepła i prędkości, a w komplecie ma dyfuzor i zwężaną końcówkę koncentrującą powietrze. Ściągany filtr można wyczyścić. Dostępne kolory to: czerń, fuksja i pomarańcz. Gamma Piu MINI 7005 kompaktowa, mini suszarka do włosów, 1000W pytania o produkt: 2 12345 4.7/5 (opinii: 3) 138,99 zł Gamma Piu MINI 7005 kompaktowa, mini suszarka do włosów, 1000W 3. Gamma Piu E-T.C. Mini – lekka i poręczna suszarka o świetnych parametrach Na podium witamy model Gamma Piu. Tym razem jest to E-T.C. Mini, czyli wersja typowo podróżna, wyposażona w podwójne napięcie. Między innymi to odróżnia ją od „kuzynki” 7500, którą opisywaliśmy już w naszym rankingu. Podobnie jak ona, ma nylonową odporną powłokę, która jest idealnym rozwiązaniem dla osób dużo podróżujących, czy też trenujących na basenie, siłowni itp. Tej suszarce nie straszne żadne warunki. Nie zawiedzie Cię dzięki specjalnej technologii gwarantującej wysoką wydajność i siłę. Mimo, że waży zaledwie 200 g, potrafi szybko i skutecznie wysuszyć włosy, przy okazji wygładzając je dzięki jonizacji. Posiada dwie końcówki, umożliwia suszenie włosów z dyfuzorem i koncentratorem, a do wyboru masz klasyczną czerń i dwie wersje kolorystyczne. E-T. C. przyznajemy tytuł jednej z najlepszych małych suszarek do włosów w naszym rankingu.",
                EmployeeId = "8b28c0e7-7c1b-4f88-9e80-430bdce5c68a",
                PublicationDate = new DateOnly()
            }

            );
        //modelBuilder.Entity<Appointment>().HasData(
        //    new Appointment
        //    {
        //        Id = 1,
        //        ServiceId = 6,
        //        EmployeeId = "2fdeac81-2fb0-4301-894c-3a272e22689d",
        //        CustomerPhoneNumber = 222666111,
        //        CustomerFirstName = "Michal",
        //        CustomerEmail = "test@gmail.com",
        //        Date = DateTime.Now
        //    },
        //    new Appointment
        //    {
        //        Id = 2,
        //        ServiceId = 5,
        //        EmployeeId = "b5b8c889-9472-4969-b356-40f87a64d71e",
        //        CustomerPhoneNumber = 222666111,
        //        CustomerFirstName = "Michal1",
        //        CustomerEmail = "test1@gmail.com",
        //        Date = DateTime.Now
        //    },
        //    new Appointment
        //    {
        //        Id = 3,
        //        ServiceId = 2,
        //        EmployeeId = "b5b8c889-9472-4969-b356-40f87a64d71e",
        //        CustomerPhoneNumber = 222666111,
        //        CustomerFirstName = "Michal2",
        //        CustomerEmail = "test2@gmail.com",
        //        Date = DateTime.Now
        //    });
    }
}