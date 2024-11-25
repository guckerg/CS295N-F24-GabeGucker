using System.Runtime.Intrinsics.X86;
using System;
using GGinfoSite.Models;
using GGinfoSite.Data;

public class SeedData
{
    public static void Seed(ApplicationDbContext context)
    {
        if (!context.BlogPost.Any())  // this is to prevent adding duplicate data
        {
            // Create User objects
            AppUser blogPoster = new AppUser { Name = "Gabe Gucker" };
            AppUser blogPoster2 = new AppUser { Name = "Gabe Gucker" };
            // Queue up user objects to be saved to the DB
            context.AppUsers.Add(blogPoster);
            context.AppUsers.Add(blogPoster2);
            context.SaveChanges();  // Saving adds UserId to User objects

            BlogPost blogPost = new BlogPost
            {
                PostTitle = "The Effects of Caffine on the Human Body.",
                PostText = "Caffeine, a natural stimulant found in coffee, " +
                "tea, and various other beverages, primarily affects the " +
                "central nervous system. It blocks adenosine receptors in " +
                "the brain, which prevents the onset of drowsiness, helping " +
                "you feel more awake and alert. This can enhance concentration, " +
                "improve mood, and boost physical performance. However, caffeine " +
                "can also lead to increased heart rate, elevated blood pressure, " +
                "and stimulate the release of adrenaline, which might cause jitteriness " +
                "or anxiety in some individuals. It’s important to consume it in " +
                "moderation, as excessive intake can lead to dependence, disrupted sleep, " +
                "and other negative side effects. Each person's tolerance to caffeine " +
                "can vary, so finding the right balance is key to enjoying its benefits " +
                "while minimizing potential downsides. For both new and seasoned coffee " +
                "lovers, understanding caffeine's effects can help you make informed " +
                "decisions about your consumption and enjoy this beloved stimulant responsibly!",
                Poster = blogPoster,
                PostRating = 5,
                PostTime = DateTime.Parse("11/1/2020")
            };
            context.BlogPost.Add(blogPost);  // queues up a review to be added to the DB

            blogPost = new BlogPost
            {
                PostTitle = "Does Dark Roast Have More or Less Caffine Than Other Roasts?",
                PostText = "Contrary to popular belief, the caffeine content in coffee does " +
                "not significantly vary between dark and light roasts. The roasting process " +
                "itself has only a minor effect on caffeine levels. While dark roasts have a " +
                "bolder, richer flavor, they don't necessarily contain more caffeine than their " +
                "lighter counterparts. In fact, light roasts can sometimes have slightly more " +
                "caffeine by volume, because they are denser than dark roasts. However, the " +
                "difference is usually minimal and depends more on the specific coffee bean " +
                "variety and brewing method than the roast level itself. So, whether you prefer " +
                "the intense flavor of a dark roast or the subtle nuances of a light roast, " +
                "you can enjoy your coffee knowing that the caffeine content will be quite " +
                "similar. Cheers to discovering your perfect cup!",
                Poster = blogPoster2,
                PostRating = 4,
                PostTime = DateTime.Parse("11/2/2020")
            };
            context.BlogPost.Add(blogPost);
            context.SaveChanges(); // stores all the reviews in the DB
        }
    }
}