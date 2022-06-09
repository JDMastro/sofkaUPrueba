using Microsoft.EntityFrameworkCore;
using SofkaUPrueba.Core.Entities;
using SofkaUPrueba.Infrastructure.Persistence.Configurations;
using System.Reflection;

namespace SofkaUPrueba.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) { }

        public DbSet<Players> Players { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Options> Options { get; set; }
        public DbSet<Questions> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.ApplyConfiguration(new PlayersConfiguration());

            //SEED DATA CATEGORIES
            builder.Entity<Categories>().HasData(
                new Categories { Id = 1, Name = "FACIL", Difficulty = "1" },
                new Categories { Id = 2, Name = "INTERMEDIO", Difficulty = "2" },
                new Categories { Id = 3, Name = "MEDIO", Difficulty = "3" },
                new Categories { Id = 4, Name = "PROFESIONAL", Difficulty = "4" },
                new Categories { Id = 5, Name = "EXPERTO", Difficulty = "5" }
                );

            //SEED DATA QUESTIONS
            builder.Entity<Questions>().HasData(
                new Questions { Id = 1, Name = "¿Qué tipo de animal es la ballena?", CategoriesId = 1, Score = 2 },
                new Questions { Id = 2, Name = "¿Qué cantidad de huesos hay en el cuerpo humano?", CategoriesId = 1, Score = 2 },
                new Questions { Id = 3, Name = "¿Cuáles son los cinco tipos de sabores primarios?", CategoriesId = 1, Score = 2 },
                new Questions { Id = 4, Name = "¿Cuál es el lugar más frío de la tierra?", CategoriesId = 1, Score = 2 },
                new Questions { Id = 5, Name = "¿Cómo se llama la Reina del Reino Unido?", CategoriesId = 1, Score = 2 },
                new Questions { Id = 6, Name = "¿Dónde originaron los juegos olímpicos?", CategoriesId = 2, Score = 3 },
                new Questions { Id = 7, Name = "¿Cuándo acabó la II Guerra Mundial?", CategoriesId = 2, Score = 3 },
                new Questions { Id = 8, Name = "¿Quién es el autor de el Quijote?", CategoriesId = 2, Score = 3 },
                new Questions { Id = 9, Name = "¿Quién pintó “la última cena”?", CategoriesId = 2, Score = 3 },
                new Questions { Id = 10, Name = "¿Quién es el padre del psicoanálisis?", CategoriesId = 2, Score = 3 },
                new Questions { Id = 11, Name = "¿Quién es el famoso Rey de Rock en los Estados Unidos?", CategoriesId = 3, Score = 4 },
                new Questions { Id = 12, Name = "¿Qué es la cartografía?", CategoriesId = 3, Score = 4 },
                new Questions { Id = 13, Name = "¿Dónde se encuentra la famosa Torre Eiffel?", CategoriesId = 3, Score = 4 },
                new Questions { Id = 14, Name = "¿Cuál es tercer planeta en el sistema solar?", CategoriesId = 3, Score = 4 },
                new Questions { Id = 15, Name = "¿Qué país tiene forma de bota?", CategoriesId = 3, Score = 4 },
                new Questions { Id = 16, Name = "¿Cuántas patas tiene la araña?", CategoriesId = 4, Score = 5 },
                new Questions { Id = 17, Name = "¿Cómo se llama el animal más rápido del mundo?", CategoriesId = 4, Score = 5 },
                new Questions { Id = 18, Name = "¿Cómo se llama la estación espacial rusa?", CategoriesId = 4, Score = 5 },
                new Questions { Id = 19, Name = "¿Cuál es el único mamífero capaz de volar?", CategoriesId = 4, Score = 5 },
                new Questions { Id = 20, Name = "¿Cuál es la nacionalidad de Pablo Neruda?", CategoriesId = 4, Score = 5 },
                new Questions { Id = 21, Name = "¿Quién traicionó a Jesús?", CategoriesId = 5, Score = 6 },
                new Questions { Id = 22, Name = "¿En qué país se usó la primera bomba atómica en combate?", CategoriesId = 5, Score = 6 },
                new Questions { Id = 23, Name = "¿Cuál es el animal que tiene mayor facilidad para repetir las frases y palabras que escucha?", CategoriesId = 5, Score = 6 },
                new Questions { Id = 24, Name = "¿Cuántos corazones tienen los pulpos?", CategoriesId = 5, Score = 6 },
                new Questions { Id = 25, Name = "¿De qué país es originario el café?", CategoriesId = 5, Score = 6 }
                );


            //SEED DATA OPTIONS
            builder.Entity<Options>().HasData(
                //OPCIONES DE PREGUNTA 1
                new Options { Id = 1, Name = "mamífero", Iscorrect = true, QuestionsId = 1 },
                new Options { Id = 2, Name = "anfibios", Iscorrect = false, QuestionsId = 1 },
                new Options { Id = 3, Name = "reptiles", Iscorrect = false, QuestionsId = 1 },
                new Options { Id = 4, Name = "cefalópodos", Iscorrect = false, QuestionsId = 1 },

                //OPCIONES DE PREGUNTA 2
                new Options { Id = 5, Name = "300", Iscorrect = false, QuestionsId = 2 },
                new Options { Id = 6, Name = "150", Iscorrect = false, QuestionsId = 2 },
                new Options { Id = 7, Name = "200", Iscorrect = false, QuestionsId = 2 },
                new Options { Id = 8, Name = "206", Iscorrect = true, QuestionsId = 2 },

                //OPCIONES DE PREGUNTA 3
                new Options { Id = 9, Name = "ácido, salado, frutoso, verdura y tierroso", Iscorrect = false, QuestionsId = 3 },
                new Options { Id = 10, Name = "dulce, amargo, ácido, salado y umami", Iscorrect = true, QuestionsId = 3 },
                new Options { Id = 11, Name = "venenoso, frutoso, dulce, baboso y umami", Iscorrect = false, QuestionsId = 3 },
                new Options { Id = 12, Name = "amargo, salado, aceitoso, tierroso y empalagoso", Iscorrect = false, QuestionsId = 3 },

                //OPCIONES DE PREGUNTA 4
                new Options { Id = 13, Name = "España", Iscorrect = false, QuestionsId = 4 },
                new Options { Id = 14, Name = "Canada", Iscorrect = false, QuestionsId = 4 },
                new Options { Id = 15, Name = "antártida", Iscorrect = true, QuestionsId = 4 },
                new Options { Id = 16, Name = "Rusia", Iscorrect = false, QuestionsId = 4 },

                //OPCIONES DE PREGUNTA 5
                new Options { Id = 17, Name = "Diana", Iscorrect = false, QuestionsId = 5 },
                new Options { Id = 18, Name = "Maria isabel V", Iscorrect = false, QuestionsId = 5 },
                new Options { Id = 19, Name = "Tereza de calcuta", Iscorrect = false, QuestionsId = 5 },
                new Options { Id = 20, Name = "Isabel II", Iscorrect = true, QuestionsId = 5 },

                //OPCIONES DE PREGUNTA 6
                new Options { Id = 21, Name = "Mongolia", Iscorrect = false, QuestionsId = 6 },
                new Options { Id = 22, Name = "Roma", Iscorrect = false, QuestionsId = 6 },
                new Options { Id = 23, Name = "Grecia", Iscorrect = true, QuestionsId = 6 },
                new Options { Id = 24, Name = "Italia", Iscorrect = false, QuestionsId = 6 },

                //OPCIONES DE PREGUNTA 7
                new Options { Id = 25, Name = "1920", Iscorrect = false, QuestionsId = 7 },
                new Options { Id = 26, Name = "1945", Iscorrect = true, QuestionsId = 7 },
                new Options { Id = 27, Name = "1900", Iscorrect = false, QuestionsId = 7 },
                new Options { Id = 28, Name = "1917", Iscorrect = false, QuestionsId = 7 },

                //OPCIONES DE PREGUNTA 8
                new Options { Id = 29, Name = "Miguel de Cervantes", Iscorrect = true, QuestionsId = 8 },
                new Options { Id = 30, Name = "Gabriel garcia marquez", Iscorrect = false, QuestionsId = 8 },
                new Options { Id = 31, Name = "J. K. Rowling", Iscorrect = false, QuestionsId = 8 },
                new Options { Id = 32, Name = "Edgar Allan Poe", Iscorrect = false, QuestionsId = 8 },

                //OPCIONES DE PREGUNTA 9
                new Options { Id = 33, Name = "Vincent van Gogh", Iscorrect = false, QuestionsId = 9 },
                new Options { Id = 34, Name = "Frida Kahlo", Iscorrect = false, QuestionsId = 9 },
                new Options { Id = 35, Name = "Leonardo da Vinci", Iscorrect = true, QuestionsId = 9 },
                new Options { Id = 36, Name = "Fernando Botero", Iscorrect = false, QuestionsId = 9 },

                //OPCIONES DE PREGUNTA 10
                new Options { Id = 37, Name = "Carl Jung", Iscorrect = false, QuestionsId = 10 },
                new Options { Id = 38, Name = "Alfred Adler", Iscorrect = false, QuestionsId = 10 },
                new Options { Id = 39, Name = "Charcot", Iscorrect = false, QuestionsId = 10 },
                new Options { Id = 40, Name = "Sigmund Freud", Iscorrect = true, QuestionsId = 10 },

                //OPCIONES DE PREGUNTA 11
                new Options { Id = 41, Name = "Elvis Presley", Iscorrect = true, QuestionsId = 11 },
                new Options { Id = 42, Name = "Jimi hendrix", Iscorrect = false, QuestionsId = 11 },
                new Options { Id = 43, Name = "Carlos santana", Iscorrect = false, QuestionsId = 11 },
                new Options { Id = 44, Name = "Jerry Lee Lewis", Iscorrect = false, QuestionsId = 11 },

                //OPCIONES DE PREGUNTA 12
                new Options { Id = 45, Name = "Es la ciencia que estudia los mares", Iscorrect = false, QuestionsId = 12 },
                new Options { Id = 46, Name = "Es la ciencia que estudia los mapas", Iscorrect = true, QuestionsId = 12 },
                new Options { Id = 47, Name = "Es la ciencia que estudia los animales", Iscorrect = false, QuestionsId = 12 },
                new Options { Id = 48, Name = "Es la ciencia que estudia la tierra", Iscorrect = false, QuestionsId = 12 },

                //OPCIONES DE PREGUNTA 13
                new Options { Id = 49, Name = "China", Iscorrect = false, QuestionsId = 13 },
                new Options { Id = 50, Name = "Noruega", Iscorrect = false, QuestionsId = 13 },
                new Options { Id = 51, Name = "Italia", Iscorrect = false, QuestionsId = 13 },
                new Options { Id = 52, Name = "París", Iscorrect = true, QuestionsId = 13 },

                //OPCIONES DE PREGUNTA 14
                new Options { Id = 53, Name = "La Tierra", Iscorrect = true, QuestionsId = 14 },
                new Options { Id = 54, Name = "Venus", Iscorrect = false, QuestionsId = 14 },
                new Options { Id = 55, Name = "Jupiter", Iscorrect = false, QuestionsId = 14 },
                new Options { Id = 56, Name = "Mercurio", Iscorrect = false, QuestionsId = 14 },

                //OPCIONES DE PREGUNTA 15
                new Options { Id = 57, Name = "España", Iscorrect = false, QuestionsId = 15 },
                new Options { Id = 58, Name = "Francia", Iscorrect = false, QuestionsId = 15 },
                new Options { Id = 59, Name = "Ecuador", Iscorrect = false, QuestionsId = 15 },
                new Options { Id = 60, Name = "Italia", Iscorrect = true, QuestionsId = 15 },

                //OPCIONES DE PREGUNTA 16
                new Options { Id = 61, Name = "6 patas", Iscorrect = false, QuestionsId = 16 },
                new Options { Id = 62, Name = "10 patas", Iscorrect = false, QuestionsId = 16 },
                new Options { Id = 63, Name = "8 patas", Iscorrect = true, QuestionsId = 16 },
                new Options { Id = 64, Name = "4 patas", Iscorrect = false, QuestionsId = 16 },

                //OPCIONES DE PREGUNTA 17
                new Options { Id = 65, Name = "Tigre", Iscorrect = false, QuestionsId = 17 },
                new Options { Id = 66, Name = "Guepardo", Iscorrect = true, QuestionsId = 17 },
                new Options { Id = 67, Name = "Tortuga", Iscorrect = false, QuestionsId = 17 },
                new Options { Id = 68, Name = "Leon", Iscorrect = false, QuestionsId = 17 },

                //OPCIONES DE PREGUNTA 18
                new Options { Id = 69, Name = "Mir", Iscorrect = true, QuestionsId = 18 },
                new Options { Id = 70, Name = "NASA", Iscorrect = false, QuestionsId = 18 },
                new Options { Id = 71, Name = "FBI", Iscorrect = false, QuestionsId = 18 },
                new Options { Id = 72, Name = "CTI", Iscorrect = false, QuestionsId = 18 },

                //OPCIONES DE PREGUNTA 19
                new Options { Id = 73, Name = "El gato", Iscorrect = false, QuestionsId = 19 },
                new Options { Id = 74, Name = "El avestruz", Iscorrect = false, QuestionsId = 19 },
                new Options { Id = 75, Name = "Los Pingüinos", Iscorrect = false, QuestionsId = 19 },
                new Options { Id = 76, Name = "El murciélago", Iscorrect = true, QuestionsId = 19 },

                //OPCIONES DE PREGUNTA 20
                new Options { Id = 77, Name = "Chile", Iscorrect = true, QuestionsId = 20 },
                new Options { Id = 78, Name = "Argentina", Iscorrect = false, QuestionsId = 20 },
                new Options { Id = 79, Name = "Paraguay", Iscorrect = false, QuestionsId = 20 },
                new Options { Id = 80, Name = "Uruguay", Iscorrect = false, QuestionsId = 20 },

                //OPCIONES DE PREGUNTA 21
                new Options { Id = 81, Name = "Judas tadeo", Iscorrect = false, QuestionsId = 21 },
                new Options { Id = 82, Name = "Judas iscariote", Iscorrect = true, QuestionsId = 21 },
                new Options { Id = 83, Name = "San pedro", Iscorrect = false, QuestionsId = 21 },
                new Options { Id = 84, Name = "Francisco", Iscorrect = false, QuestionsId = 21 },

                //OPCIONES DE PREGUNTA 22
                new Options { Id = 85, Name = "Rusia", Iscorrect = false, QuestionsId = 22 },
                new Options { Id = 86, Name = "China", Iscorrect = false, QuestionsId = 22 },
                new Options { Id = 87, Name = "Japón", Iscorrect = true, QuestionsId = 22 },
                new Options { Id = 88, Name = "Ucrania", Iscorrect = false, QuestionsId = 22 },

                //OPCIONES DE PREGUNTA 23
                new Options { Id = 89, Name = "Azulejo", Iscorrect = false, QuestionsId = 23 },
                new Options { Id = 90, Name = "Maria mulata", Iscorrect = false, QuestionsId = 23 },
                new Options { Id = 91, Name = "Loros", Iscorrect = false, QuestionsId = 23 },
                new Options { Id = 92, Name = "Cuervo", Iscorrect = true, QuestionsId = 23 },

                //OPCIONES DE PREGUNTA 24
                new Options { Id = 93, Name = "1 corazones", Iscorrect = false, QuestionsId = 24 },
                new Options { Id = 94, Name = "3 corazones", Iscorrect = true, QuestionsId = 24 },
                new Options { Id = 95, Name = "4 corazones", Iscorrect = false, QuestionsId = 24 },
                new Options { Id = 96, Name = "2 corazones", Iscorrect = false, QuestionsId = 24 },

                //OPCIONES DE PREGUNTA 25
                new Options { Id = 97, Name = "Venezuela", Iscorrect = false, QuestionsId = 25 },
                new Options { Id = 98, Name = "Colombia", Iscorrect = false, QuestionsId = 25 },
                new Options { Id = 99, Name = "Etiopía", Iscorrect = true, QuestionsId = 25 },
                new Options { Id = 100, Name = "España", Iscorrect = false, QuestionsId = 25 }
                );



            base.OnModelCreating(builder);
        }
    }
}
