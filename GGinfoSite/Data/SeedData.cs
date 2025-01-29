using System.Runtime.Intrinsics.X86;
using System;
using GGinfoSite.Models;
using GGinfoSite.Data;
using Microsoft.AspNetCore.Identity;

public class SeedData
{
    public static void Seed(ApplicationDbContext context, IServiceProvider provider)
    {
        if (!context.BlogPost.Any())
        {
            var userManager = provider.GetRequiredService<UserManager<AppUser>>();

            AppUser reidDuke = userManager.FindByNameAsync("ReidDuke").Result;
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
                Poster = reidDuke,
                PostRating = 5,
                PostTime = DateTime.Parse("11/1/2024")
            };
            context.BlogPost.Add(blogPost);

            AppUser samBlack = userManager.FindByNameAsync("SamBlack").Result;
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
                Poster = samBlack,
                PostRating = 4,
                PostTime = DateTime.Parse("11/5/2024")
            };
            context.BlogPost.Add(blogPost);

            AppUser gabeGucker = userManager.FindByNameAsync("GabeGucker").Result;
            blogPost = new BlogPost
            {
                PostTitle = "Test 3rd Post(Title)",
                PostText = "Test 3rd Post(Body)",
                Poster = gabeGucker,
                PostRating = 4,
                PostTime = DateTime.Parse("1/14/2025")
            };
            context.BlogPost.Add(blogPost);

            context.SaveChanges();
        }
    }
}