using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SofkaUPrueba.Infrastructure.Persistence.Migrations
{
    public partial class firts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Difficulty = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Score = table.Column<int>(type: "int", nullable: false),
                    CategoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Iscorrect = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    QuestionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Difficulty", "Name" },
                values: new object[,]
                {
                    { 1, "1", "FACIL" },
                    { 2, "2", "INTERMEDIO" },
                    { 3, "3", "MEDIO" },
                    { 4, "4", "PROFESIONAL" },
                    { 5, "5", "EXPERTO" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CategoriesId", "Name", "Score" },
                values: new object[,]
                {
                    { 1, 1, "¿Qué tipo de animal es la ballena?", 2 },
                    { 2, 1, "¿Qué cantidad de huesos hay en el cuerpo humano?", 2 },
                    { 3, 1, "¿Cuáles son los cinco tipos de sabores primarios?", 2 },
                    { 4, 1, "¿Cuál es el lugar más frío de la tierra?", 2 },
                    { 5, 1, "¿Cómo se llama la Reina del Reino Unido?", 2 },
                    { 6, 2, "¿Dónde originaron los juegos olímpicos?", 3 },
                    { 7, 2, "¿Cuándo acabó la II Guerra Mundial?", 3 },
                    { 8, 2, "¿Quién es el autor de el Quijote?", 3 },
                    { 9, 2, "¿Quién pintó “la última cena”?", 3 },
                    { 10, 2, "¿Quién es el padre del psicoanálisis?", 3 },
                    { 11, 3, "¿Quién es el famoso Rey de Rock en los Estados Unidos?", 4 },
                    { 12, 3, "¿Qué es la cartografía?", 4 },
                    { 13, 3, "¿Dónde se encuentra la famosa Torre Eiffel?", 4 },
                    { 14, 3, "¿Cuál es tercer planeta en el sistema solar?", 4 },
                    { 15, 3, "¿Qué país tiene forma de bota?", 4 },
                    { 16, 4, "¿Cuántas patas tiene la araña?", 5 },
                    { 17, 4, "¿Cómo se llama el animal más rápido del mundo?", 5 },
                    { 18, 4, "¿Cómo se llama la estación espacial rusa?", 5 },
                    { 19, 4, "¿Cuál es el único mamífero capaz de volar?", 5 },
                    { 20, 4, "¿Cuál es la nacionalidad de Pablo Neruda?", 5 },
                    { 21, 5, "¿Quién traicionó a Jesús?", 6 },
                    { 22, 5, "¿En qué país se usó la primera bomba atómica en combate?", 6 },
                    { 23, 5, "¿Cuál es el animal que tiene mayor facilidad para repetir las frases y palabras que escucha?", 6 },
                    { 24, 5, "¿Cuántos corazones tienen los pulpos?", 6 },
                    { 25, 5, "¿De qué país es originario el café?", 6 }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "Iscorrect", "Name", "QuestionsId" },
                values: new object[,]
                {
                    { 1, true, "mamífero", 1 },
                    { 2, false, "anfibios", 1 },
                    { 3, false, "reptiles", 1 },
                    { 4, false, "cefalópodos", 1 },
                    { 5, false, "300", 2 },
                    { 6, false, "150", 2 },
                    { 7, false, "200", 2 },
                    { 8, true, "206", 2 },
                    { 9, false, "ácido, salado, frutoso, verdura y tierroso", 3 },
                    { 10, true, "dulce, amargo, ácido, salado y umami", 3 },
                    { 11, false, "venenoso, frutoso, dulce, baboso y umami", 3 },
                    { 12, false, "amargo, salado, aceitoso, tierroso y empalagoso", 3 },
                    { 13, false, "España", 4 },
                    { 14, false, "Canada", 4 },
                    { 15, true, "antártida", 4 },
                    { 16, false, "Rusia", 4 },
                    { 17, false, "Diana", 5 },
                    { 18, false, "Maria isabel V", 5 },
                    { 19, false, "Tereza de calcuta", 5 },
                    { 20, true, "Isabel II", 5 },
                    { 21, false, "Mongolia", 6 },
                    { 22, false, "Roma", 6 },
                    { 23, true, "Grecia", 6 },
                    { 24, false, "Italia", 6 },
                    { 25, false, "1920", 7 },
                    { 26, true, "1945", 7 },
                    { 27, false, "1900", 7 },
                    { 28, false, "1917", 7 },
                    { 29, true, "Miguel de Cervantes", 8 },
                    { 30, false, "Gabriel garcia marquez", 8 },
                    { 31, false, "J. K. Rowling", 8 },
                    { 32, false, "Edgar Allan Poe", 8 },
                    { 33, false, "Vincent van Gogh", 9 },
                    { 34, false, "Frida Kahlo", 9 },
                    { 35, true, "Leonardo da Vinci", 9 },
                    { 36, false, "Fernando Botero", 9 },
                    { 37, false, "Carl Jung", 10 },
                    { 38, false, "Alfred Adler", 10 },
                    { 39, false, "Charcot", 10 },
                    { 40, true, "Sigmund Freud", 10 },
                    { 41, true, "Elvis Presley", 11 },
                    { 42, false, "Jimi hendrix", 11 },
                    { 43, false, "Carlos santana", 11 },
                    { 44, false, "Jerry Lee Lewis", 11 },
                    { 45, false, "Es la ciencia que estudia los mares", 12 },
                    { 46, true, "Es la ciencia que estudia los mapas", 12 },
                    { 47, false, "Es la ciencia que estudia los animales", 12 },
                    { 48, false, "Es la ciencia que estudia la tierra", 12 },
                    { 49, false, "China", 13 },
                    { 50, false, "Noruega", 13 },
                    { 51, false, "Italia", 13 },
                    { 52, true, "París", 13 },
                    { 53, true, "La Tierra", 14 },
                    { 54, false, "Venus", 14 },
                    { 55, false, "Jupiter", 14 },
                    { 56, false, "Mercurio", 14 },
                    { 57, false, "España", 15 },
                    { 58, false, "Francia", 15 },
                    { 59, false, "Ecuador", 15 },
                    { 60, true, "Italia", 15 },
                    { 61, false, "6 patas", 16 },
                    { 62, false, "10 patas", 16 },
                    { 63, true, "8 patas", 16 },
                    { 64, false, "4 patas", 16 },
                    { 65, false, "Tigre", 17 },
                    { 66, true, "Guepardo", 17 },
                    { 67, false, "Tortuga", 17 },
                    { 68, false, "Leon", 17 },
                    { 69, true, "Mir", 18 },
                    { 70, false, "NASA", 18 },
                    { 71, false, "FBI", 18 },
                    { 72, false, "CTI", 18 },
                    { 73, false, "El gato", 19 },
                    { 74, false, "El avestruz", 19 },
                    { 75, false, "Los Pingüinos", 19 },
                    { 76, true, "El murciélago", 19 },
                    { 77, true, "Chile", 20 },
                    { 78, false, "Argentina", 20 },
                    { 79, false, "Paraguay", 20 },
                    { 80, false, "Uruguay", 20 },
                    { 81, false, "Judas tadeo", 21 },
                    { 82, true, "Judas iscariote", 21 },
                    { 83, false, "San pedro", 21 },
                    { 84, false, "Francisco", 21 },
                    { 85, false, "Rusia", 22 },
                    { 86, false, "China", 22 },
                    { 87, true, "Japón", 22 },
                    { 88, false, "Ucrania", 22 },
                    { 89, false, "Azulejo", 23 },
                    { 90, false, "Maria mulata", 23 },
                    { 91, false, "Loros", 23 },
                    { 92, true, "Cuervo", 23 },
                    { 93, false, "1 corazones", 24 },
                    { 94, true, "3 corazones", 24 },
                    { 95, false, "4 corazones", 24 },
                    { 96, false, "2 corazones", 24 },
                    { 97, false, "Venezuela", 25 },
                    { 98, false, "Colombia", 25 },
                    { 99, true, "Etiopía", 25 },
                    { 100, false, "España", 25 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionsId",
                table: "Options",
                column: "QuestionsId");

            migrationBuilder.CreateIndex(
                name: "Idx_username_players",
                table: "Players",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CategoriesId",
                table: "Questions",
                column: "CategoriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
