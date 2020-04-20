using System;

namespace UsingEntityFrameworkCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create VideoGameCRUD object
            VideoGameCRUD videoGameCRUD = new VideoGameCRUD();

            // Add some video games.
            videoGameCRUD.CreateVideoGame(new VideoGame
            {
                Id = 1,
                Title = "Street Fighter IV",
                Platform = "PS4"
            });
            videoGameCRUD.CreateVideoGame(new VideoGame
            {
                Id = 2,
                Title = "God of War",
                Platform = "PS4"
            });
            VideoGame videoGame = new VideoGame
            {
                Id = 3,
                Title = "Pro Evolution Soccer 2017",
                Platform = "PS4"
            };
            videoGameCRUD.CreateVideoGame(videoGame);

            // Fetch All Video Game
            foreach (VideoGame vg in videoGameCRUD.ReadAll())
            {
                Console.WriteLine($"{vg.Id} - {vg.Title} - {vg.Platform}");
            }
            Console.WriteLine("Press Enter key to continue...");
            Console.ReadLine();

            //Update Game
            videoGame.Title = "Pro Evolution Soccer 2020";
            if (videoGameCRUD.Update(videoGame))
            {
                Console.WriteLine("Update Video Game Complete!");
            }else{
                Console.WriteLine("Update Video Game Not Complete!");
            }

            //Show All Video Game
            foreach (VideoGame vg in videoGameCRUD.ReadAll())
            {
                Console.WriteLine($"{vg.Id} - {vg.Title} - {vg.Platform}");
            }
        }
    }
}
