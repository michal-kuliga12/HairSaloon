using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HairSaloon.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddBlogsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerLastName",
                table: "Appointments");

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicationDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Content", "EmployeeId", "Images", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { 1, "Ty też nie lubisz rozstawać się na dłużej ze swoją suszarką do włosów? Hotelowe urządzenia zwykle nie spełniają Twoich oczekiwań, a Ty chcesz mieć dobrej jakości suszarkę zawsze ze sobą? A może szukasz mini suszarki, która zmieści się w treningowej torbie? Mała suszarka do włosów będzie strzałem w dziesiątkę. Oczywiście pod warunkiem, że będzie miała spore jak na swój niewielki rozmiar możliwości! Jaka suszarka podróżna będzie najlepszym wyborem? Zobacz ranking TOP5 modeli profesjonalnych renomowanych marek. mała suszarka do włosów 5. BaByliss Pro Bambino suszarka do włosów - mała, ale o dużych możliwościach Oto suszarka do włosów mała, ale mająca naprawdę spore jak na te wymiary możliwości. To propozycja włoskiego producenta profesjonalnego sprzętu fryzjerskiego, znanego z zaawansowanych rozwiązań. Mocny silnik o mocy 1200 W jest gwarancją długotrwałego i bezawaryjnego użytkowania. Zaletą tego modelu jest też zdejmowany filtr oraz powłoka nanotytanowa, dająca świetne rezultaty szybkiego i bezpiecznego dla włosów suszenia. Do wyboru masz tu dwie temperatury i prędkości nadmuchu. W zestawie znajduje się koncentrator powietrza do wygładzania włosów oraz dyfuzor do podkreślana skrętu włosów falowanych lub kręconych. Suszarka nie składa się, ale jest na tyle kompaktowa, że bez trudu zmieścisz ją w bagażu. I polecisz gdziekolwiek, bo posiada podwójne napięcie. BaByliss Pro BAB5510E Bambino Mini suszarka do włosów 12345 4.8/5 (opinii: 6) 133,47 zł BaByliss Pro BAB5510E Bambino Mini suszarka do włosów 4. Gamma Piu Mini 7005 – mała suszarka z jonizacją Niecałe 13 cm długości ma kompaktowa suszarka do włosów włoskiej firmy Gamma Piu. Model Mini 7005 jest świetnie oceniany i chętnie wybierany jako suszarka podróżna (choć – uwaga - nie ma podwójnego napięcia), ale i podręczna. Doskonale sprawdza się też po fitnessie, siłowni, basenie itp. Nie tylko dlatego, że jest lekka i mała, ale również przez to, że jej nylonowa powłoka jest wyjątkowo odporna na zarysowania i uszkodzenia. Ogromnym plusem tej małej suszarki do włosów jest jonizacja. Tak mała suszarka z jonizacją to rzadkość. Dodatkowo turmalinowa powłoka sprawia, że włosy są dużo mniej podatne na elektryzowanie się. Mini suszarka ma po dwa ustawienia ciepła i prędkości, a w komplecie ma dyfuzor i zwężaną końcówkę koncentrującą powietrze. Ściągany filtr można wyczyścić. Dostępne kolory to: czerń, fuksja i pomarańcz. Gamma Piu MINI 7005 kompaktowa, mini suszarka do włosów, 1000W pytania o produkt: 2 12345 4.7/5 (opinii: 3) 138,99 zł Gamma Piu MINI 7005 kompaktowa, mini suszarka do włosów, 1000W 3. Gamma Piu E-T.C. Mini – lekka i poręczna suszarka o świetnych parametrach Na podium witamy model Gamma Piu. Tym razem jest to E-T.C. Mini, czyli wersja typowo podróżna, wyposażona w podwójne napięcie. Między innymi to odróżnia ją od „kuzynki” 7500, którą opisywaliśmy już w naszym rankingu. Podobnie jak ona, ma nylonową odporną powłokę, która jest idealnym rozwiązaniem dla osób dużo podróżujących, czy też trenujących na basenie, siłowni itp. Tej suszarce nie straszne żadne warunki. Nie zawiedzie Cię dzięki specjalnej technologii gwarantującej wysoką wydajność i siłę. Mimo, że waży zaledwie 200 g, potrafi szybko i skutecznie wysuszyć włosy, przy okazji wygładzając je dzięki jonizacji. Posiada dwie końcówki, umożliwia suszenie włosów z dyfuzorem i koncentratorem, a do wyboru masz klasyczną czerń i dwie wersje kolorystyczne. E-T. C. przyznajemy tytuł jednej z najlepszych małych suszarek do włosów w naszym rankingu.", "8b28c0e7-7c1b-4f88-9e80-430bdce5c68a", null, new DateOnly(1, 1, 1), "Mała suszarka do włosów – suszarka podróżna - TOP5" },
                    { 2, "Ty też nie lubisz rozstawać się na dłużej ze swoją suszarką do włosów? Hotelowe urządzenia zwykle nie spełniają Twoich oczekiwań, a Ty chcesz mieć dobrej jakości suszarkę zawsze ze sobą? A może szukasz mini suszarki, która zmieści się w treningowej torbie? Mała suszarka do włosów będzie strzałem w dziesiątkę. Oczywiście pod warunkiem, że będzie miała spore jak na swój niewielki rozmiar możliwości! Jaka suszarka podróżna będzie najlepszym wyborem? Zobacz ranking TOP5 modeli profesjonalnych renomowanych marek. mała suszarka do włosów 5. BaByliss Pro Bambino suszarka do włosów - mała, ale o dużych możliwościach Oto suszarka do włosów mała, ale mająca naprawdę spore jak na te wymiary możliwości. To propozycja włoskiego producenta profesjonalnego sprzętu fryzjerskiego, znanego z zaawansowanych rozwiązań. Mocny silnik o mocy 1200 W jest gwarancją długotrwałego i bezawaryjnego użytkowania. Zaletą tego modelu jest też zdejmowany filtr oraz powłoka nanotytanowa, dająca świetne rezultaty szybkiego i bezpiecznego dla włosów suszenia. Do wyboru masz tu dwie temperatury i prędkości nadmuchu. W zestawie znajduje się koncentrator powietrza do wygładzania włosów oraz dyfuzor do podkreślana skrętu włosów falowanych lub kręconych. Suszarka nie składa się, ale jest na tyle kompaktowa, że bez trudu zmieścisz ją w bagażu. I polecisz gdziekolwiek, bo posiada podwójne napięcie. BaByliss Pro BAB5510E Bambino Mini suszarka do włosów 12345 4.8/5 (opinii: 6) 133,47 zł BaByliss Pro BAB5510E Bambino Mini suszarka do włosów 4. Gamma Piu Mini 7005 – mała suszarka z jonizacją Niecałe 13 cm długości ma kompaktowa suszarka do włosów włoskiej firmy Gamma Piu. Model Mini 7005 jest świetnie oceniany i chętnie wybierany jako suszarka podróżna (choć – uwaga - nie ma podwójnego napięcia), ale i podręczna. Doskonale sprawdza się też po fitnessie, siłowni, basenie itp. Nie tylko dlatego, że jest lekka i mała, ale również przez to, że jej nylonowa powłoka jest wyjątkowo odporna na zarysowania i uszkodzenia. Ogromnym plusem tej małej suszarki do włosów jest jonizacja. Tak mała suszarka z jonizacją to rzadkość. Dodatkowo turmalinowa powłoka sprawia, że włosy są dużo mniej podatne na elektryzowanie się. Mini suszarka ma po dwa ustawienia ciepła i prędkości, a w komplecie ma dyfuzor i zwężaną końcówkę koncentrującą powietrze. Ściągany filtr można wyczyścić. Dostępne kolory to: czerń, fuksja i pomarańcz. Gamma Piu MINI 7005 kompaktowa, mini suszarka do włosów, 1000W pytania o produkt: 2 12345 4.7/5 (opinii: 3) 138,99 zł Gamma Piu MINI 7005 kompaktowa, mini suszarka do włosów, 1000W 3. Gamma Piu E-T.C. Mini – lekka i poręczna suszarka o świetnych parametrach Na podium witamy model Gamma Piu. Tym razem jest to E-T.C. Mini, czyli wersja typowo podróżna, wyposażona w podwójne napięcie. Między innymi to odróżnia ją od „kuzynki” 7500, którą opisywaliśmy już w naszym rankingu. Podobnie jak ona, ma nylonową odporną powłokę, która jest idealnym rozwiązaniem dla osób dużo podróżujących, czy też trenujących na basenie, siłowni itp. Tej suszarce nie straszne żadne warunki. Nie zawiedzie Cię dzięki specjalnej technologii gwarantującej wysoką wydajność i siłę. Mimo, że waży zaledwie 200 g, potrafi szybko i skutecznie wysuszyć włosy, przy okazji wygładzając je dzięki jonizacji. Posiada dwie końcówki, umożliwia suszenie włosów z dyfuzorem i koncentratorem, a do wyboru masz klasyczną czerń i dwie wersje kolorystyczne. E-T. C. przyznajemy tytuł jednej z najlepszych małych suszarek do włosów w naszym rankingu.", "8b28c0e7-7c1b-4f88-9e80-430bdce5c68a", null, new DateOnly(1, 1, 1), "Mała suszarka do włosów – suszarka podróżna - TOP5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_EmployeeId",
                table: "Blogs",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "CustomerLastName",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
