using System.Collections.Generic;
using System.Linq;

namespace UsingEntityFrameworkCore
{
    public class VideoGameCRUD
    {
        public VideoGameCRUD()
        {
            using (var context = new VideoGameDbContext())
            {
                // The line below clears and resets the databse.
                context.Database.EnsureDeleted();
                // Create the database if it does not exist
                context.Database.EnsureCreated();
            }
        }
        public int CreateVideoGame(VideoGame videoGame)
        {
            using (var context = new VideoGameDbContext())
            {
                context.VideoGames.Add(videoGame);
                return context.SaveChanges();
            }
        }
        public List<VideoGame> ReadAll()
        {
            using (var context = new VideoGameDbContext())
            {
                var all = from v in context.VideoGames select v;
                return all.ToList();
            }
        }
        public bool Update(VideoGame videoGame)
        {
            using (var context = new VideoGameDbContext())
            {
                VideoGame vg = (from v in context.VideoGames
                                where v.Id == videoGame.Id
                                select v).SingleOrDefault();
                int saveStatus = 0;
                if (vg != null)
                {
                    vg.Title = videoGame.Title;
                    vg.Platform = videoGame.Platform;
                    saveStatus = context.SaveChanges();
                }
                return saveStatus > 0;
            }
        }
        public bool DeleteAllVideoGame()
        {
            using (var context = new VideoGameDbContext())
            {
                context.Database.EnsureDeleted();
                return true;
            }
        }
    }
}