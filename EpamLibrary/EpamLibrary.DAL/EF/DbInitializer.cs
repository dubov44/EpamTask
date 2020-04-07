using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using EpamLibrary.DAL.Identity;
using Microsoft.AspNet.Identity;
using System;
using EpamLibrary.DAL.Entities;

namespace EpamLibrary.DAL.EF
{
    public class DbInitializer : CreateDatabaseIfNotExists<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(context));

            var role1 = new ApplicationRole { Name = "admin" };
            var role2 = new ApplicationRole { Name = "librarian" };
            var role3 = new ApplicationRole { Name = "user" };
            var role4 = new ApplicationRole { Name = "banned" };
            var role5 = new ApplicationRole { Name = "deleted" };

            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);
            roleManager.Create(role4);
            roleManager.Create(role5);

            var admin = new ApplicationUser { Email = "ttrianon8@gmail.com", UserName = "ttrianon8@gmail.com" };
            string password = "TU9Uefr3";
            var result = userManager.Create(admin, password);
            var adminProfile = new ClientProfile() { ApplicationUser = admin, Email = admin.Email, Name = admin.UserName };

            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, role1.Name);
                context.ClientProfiles.Add(adminProfile);
            }

            var user = new ApplicationUser { Email = "ttrianon12@gmail.com", UserName = "ttrianon12@gmail.com" };
            password = "QwErTy12345";
            result = userManager.Create(user, password);
            var userProfile = new ClientProfile() { ApplicationUser = admin, Email = admin.Email, Name = admin.UserName };

            if (result.Succeeded)
            {
                userManager.AddToRole(user.Id, role3.Name);
                context.ClientProfiles.Add(userProfile);
            }

            var genre1 = new Genre() { Name = "action" };
            var genre2 = new Genre() { Name = "adventure" };
            var genre3 = new Genre() { Name = "comedy" };
            var genre4 = new Genre() { Name = "drama" };
            var genre5 = new Genre() { Name = "romance" };
            var genre6 = new Genre() { Name = "fantasy" };
            var genre7 = new Genre() { Name = "martial arts" };
            var genre8 = new Genre() { Name = "tragedy" };
            var genre9 = new Genre() { Name = "supernatural" };
            var genre10 = new Genre() { Name = "mystery" };
            var genre11 = new Genre() { Name = "psychological" };
            var genre12 = new Genre() { Name = "sci fi" };

            var author1 = new Author() { Name = "decaspell" };
            var author2 = new Author() { Name = "miro" };
            var author3 = new Author() { Name = "mad snail" };
            var author4 = new Author() { Name = "chaos" };
            var author5 = new Author() { Name = "one" };
            var author6 = new Author() { Name = "tabata yuuki" };

            var publisher1 = new Publisher() { Name = "manganelo" };
            var publisher2 = new Publisher() { Name = "mangakakalot" };
            var publisher3 = new Publisher() { Name = "mangarock" };
            var publisher4 = new Publisher() { Name = "readmanga" };

            var book1 = new Book() 
            { 
                Name = "Tales Of Demons And Gods", 
                PublicationDate = new DateTime(1999, 6, 14), 
                Quantity = 4, 
                Discription = "Nie Li, one of the strongest Demon Spiritist in his past life standing at the pinnacle of the martial world , however he lost his life during the battle with Sage Emperor and the six deity ranked beast, his soul was then reborn back in time back to when he is still 13. Although he’s the weakest in his class with the lowest talent at only Red soul realm, with the aid of the vast knowledge which he accumulated in his previous life, he trained faster then anyone. Trying to protect the city which in the coming future was being assaulted by beast and ended up being destroyed as well as protecting his lover, friends and family who died by the beast assault. and to destroy the Sacred family whom abandon their duty and betrayed the city in his past life.",
                ImagePath = "/Content/images/tales-of-demons-and-gods.jpg"
            };
            var book2 = new Book() 
            { 
                Name = "Solo Leveling", 
                PublicationDate = new DateTime(1959, 5, 27), 
                Quantity = 0, 
                Discription = "10 years ago, after “the Gate” that connected the real world with the monster world opened, some of the ordinary, everyday people received the power to hunt monsters within the Gate. They are known as Hunters. However, not all Hunters are powerful. My name is Sung Jin-Woo, an E-rank Hunter. I'm someone who has to risk his life in the lowliest of dungeons, the World's Weakest. Having no skills whatsoever to display, I barely earned the required money by fighting in low-leveled dungeons… at least until I found a hidden dungeon with the hardest difficulty within the D-rank dungeons! In the end, as I was accepting death, I suddenly received a strange power, a quest log that only I could see, a secret to leveling up that only I know about! If I trained in accordance with my quests and hunted monsters, my level would rise. Changing from the weakest Hunter to the strongest S-rank Hunter!",
                ImagePath = "/Content/images/solo-leveling.jpg"
            };
            var book3 = new Book() 
            { 
                Name = "Star Martial God Technique", 
                PublicationDate = new DateTime(2007, 12, 05), 
                Quantity = 3, 
                Discription = "In the whole world there lays twelve paths to climb Tower of God, and in legends these twelve pathways leads toward legendary road of immortality. However these paths in the Tower of God, are far too long, without end. In ancient times there once were many types of martial arts, sadly the world underwent terrible changes, and only three were left: Flame, Dragon and Star Martial Arts. Generations of experts of those three martial arts are searching for the road of immortality. A Star Martial Arts practitioner on his journey of lifetime, plans to become the Highest God.",
                ImagePath = "/Content/images/star-martial-god-technique.jpg"
            };
            var book4 = new Book()
            {
                Name = "Versatile Mage",
                PublicationDate = new DateTime(2008, 12, 25),
                Quantity = 8,
                Discription = "He awoke, and the world was changed. The familiar high school now teaches magic, encouraging students to become the greatest magicians they can be. Beyond the city limits, wandering magical beasts prey on humans. An advanced scientific world changed into one with advanced magic. Yet, what has not changed was the same teacher who looks upon him with disdain, the same students who look upon him with contempt, the same father who struggles at the bottom rung of society, and the same innocent step sister who cannot walk. However, Mo Fan discovered that while everyone else can only use one major element, he himself can use all magic!",
                ImagePath = "/Content/images/versatile-mage.jpg"
            };
            var book5 = new Book()
            {
                Name = "Onepunch-Man",
                PublicationDate = new DateTime(2010, 4, 20),
                Quantity = 25,
                Discription = "One punch-Man imitates the life of an average hero who wins all of his fights with only one punch! This is why he is called Onepunch man Manga. This story takes place in the fictional Z-City. The world is full of mysterious beings, villains and monsters that cause destruction and havoc. An association of heroes has been established to protect the citizens from all harms and enemies. People with superhuman ability can register themselves with the association that protects citizens. There, they will be required to take a series of tests to determine their ability and what class they are. Class S being the highest and class C being the lowest.",
                ImagePath = "/Content/images/onepunch-man.jpg"
            };
            var book6 = new Book()
            {
                Name = "A Returner's Magic Should Be Special",
                PublicationDate = new DateTime(1997, 3, 07),
                Quantity = 6,
                Discription = "The Shadow Labyrinth - the most catastrophic existence humanity has faced in history. Desir Arman is one of the six remaining survivors of mankind within it. The six attempt to clear the final level of the labyrinth but ultimately fail, and the world comes to an end. However - when Desir thought he would meet his demise, what is revealed before him is the world... thirteen years ago?! Desir is returned to the past, back to the time when he enrolled at the nation's finest magic academy - Havrion. He is reunited with his precious friends, and is prepared to change the past to save the world and his loved ones...! Three years remaining before the emergence of the Shadow World! Change the past and gather powerful comrades to save mankind!",
                ImagePath = "/Content/images/a-returners-magic-should-be-special.jpg"
            };
            var book7 = new Book()
            {
                Name = "Black Clover",
                PublicationDate = new DateTime(2017, 12, 05),
                Quantity = 11,
                Discription = "From MangaHelpers: Aster and Yuno were abandoned together at the same church, and have been inseparable since. As children, they promised that they would compete against each other to see who would become the next sorcerous emperor. However, as they grew up, some differences between them became plain. Yuno was a genius with magic, with amazing power and control, while Aster could not use magic at all, and tried to make up for his lack by training physically. When they received their grimoires at age 15, Yuno got a spectacular book with a four-leaf-clover (most people receive a three-leaf-clover), while Aster received nothing at all. However, when Yuno was threatened, the truth about Aster's power was revealed-- he received a five-leaf-clover grimoire, a 'black clover' book of anti-magic. Now the two friends are heading out in the world, both seeking the same goal!",
                ImagePath = "/Content/images/black-clover.jpg"
            };
            var book8 = new Book()
            {
                Name = "I Am The Sorcerer King",
                PublicationDate = new DateTime(2016, 2, 23),
                Quantity = 43,
                Discription = "10 years ago, the monster horde from the rift formed from space and time started attacking the mankind. At the same time, people have started to awaken the power and began hunting the monsters for fame and money Lee SungHoon, in need of money because of his mother’s sickness, takes a dangerous job to help hunt those monsters four times a month by acting as a bait for the hunters But one day, he is heavily injured by a monster and remembers his past life as a sorcerer king ‘Huh? Did I just die?» ‘Wait, I was a Sorcerer King Kratraus in my previous life?’ With his past memories, SungHoon’s overpowered magic show begins.",
                ImagePath = "/Content/images/i-am-the-sorcerer-king.jpg"
            };
            var book9 = new Book()
            {
                Name = "Soul Land",
                PublicationDate = new DateTime(1998, 7, 19),
                Quantity = 7,
                Discription = "Tang Sect, the most famous martial arts sect of all. By stealing its most secret teachings to fulfill his dreams, Tang San committed an unforgivable crime. With his ambition attained, he hands his legacy to the sect and throws himself from the fearsome “Hell’s Peak.” But he could have never imagined that this would take him to another world, one without martial arts and grudges. A land where only the mystical souls of battle lay. The continent of Douro. How will Tang San survive in this unknown environment? With a new road to follow, a new legend begins…",
                ImagePath = "/Content/images/soul-land.jpg"
            };

            book1.Authors.Add(author1);
            book2.Authors.Add(author2);
            book3.Authors.Add(author3);
            book3.Authors.Add(author4);
            book4.Authors.Add(author5);
            book4.Authors.Add(author6);
            book4.Authors.Add(author2);
            book5.Authors.Add(author3);
            book5.Authors.Add(author2);
            book6.Authors.Add(author5);
            book7.Authors.Add(author1);
            book7.Authors.Add(author2);
            book7.Authors.Add(author6);
            book8.Authors.Add(author1);
            book8.Authors.Add(author4);
            book9.Authors.Add(author1);

            book1.Genres.Add(genre1);
            book1.Genres.Add(genre2);
            book1.Genres.Add(genre3);
            book1.Genres.Add(genre6);
            book2.Genres.Add(genre7);
            book2.Genres.Add(genre2);
            book2.Genres.Add(genre3);
            book2.Genres.Add(genre8);
            book2.Genres.Add(genre9);
            book3.Genres.Add(genre10);
            book3.Genres.Add(genre12);
            book3.Genres.Add(genre3);
            book3.Genres.Add(genre4);
            book3.Genres.Add(genre5);
            book3.Genres.Add(genre6);
            book4.Genres.Add(genre7);
            book4.Genres.Add(genre1);
            book4.Genres.Add(genre2);
            book4.Genres.Add(genre8);
            book4.Genres.Add(genre9);
            book5.Genres.Add(genre2);
            book5.Genres.Add(genre9);
            book5.Genres.Add(genre11);
            book6.Genres.Add(genre12);
            book6.Genres.Add(genre3);
            book6.Genres.Add(genre5);
            book6.Genres.Add(genre6);
            book7.Genres.Add(genre8);
            book7.Genres.Add(genre6);
            book7.Genres.Add(genre7);
            book8.Genres.Add(genre1);
            book8.Genres.Add(genre8);
            book8.Genres.Add(genre3);
            book9.Genres.Add(genre4);
            book9.Genres.Add(genre8);
            book9.Genres.Add(genre1);
            book9.Genres.Add(genre12);
            book9.Genres.Add(genre11);
            book9.Genres.Add(genre3);
            book9.Genres.Add(genre9);

            book1.Publisher = publisher1;
            book2.Publisher = publisher2;
            book3.Publisher = publisher2;
            book4.Publisher = publisher3;
            book5.Publisher = publisher3;
            book6.Publisher = publisher3;
            book7.Publisher = publisher4;
            book8.Publisher = publisher4;
            book9.Publisher = publisher1;

            context.Genres.Add(genre1);
            context.Genres.Add(genre2);
            context.Genres.Add(genre3);
            context.Genres.Add(genre4);
            context.Genres.Add(genre5);
            context.Genres.Add(genre6);
            context.Genres.Add(genre7);
            context.Genres.Add(genre8);
            context.Genres.Add(genre9);
            context.Genres.Add(genre10);
            context.Genres.Add(genre11);
            context.Genres.Add(genre12);
            context.Authors.Add(author1);
            context.Authors.Add(author2);
            context.Authors.Add(author3);
            context.Authors.Add(author4);
            context.Authors.Add(author5);
            context.Authors.Add(author6);
            context.Books.Add(book1);
            context.Books.Add(book2);
            context.Books.Add(book3);
            context.Books.Add(book4);
            context.Books.Add(book5);
            context.Books.Add(book6);
            context.Books.Add(book7);
            context.Books.Add(book8);
            context.Books.Add(book9);
            context.Publishers.Add(publisher1);
            context.Publishers.Add(publisher2);
            context.Publishers.Add(publisher3);
            context.Publishers.Add(publisher4);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
