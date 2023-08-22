using BackEndMvcCore.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BackEndProcetMVC.Context
{
    public class BackEndProjectDbContext:IdentityDbContext<AppUser>
    {
        public DbSet<Slider> sliders { get; set; }
        public DbSet<Welcome> welcomes { get; set; }
        public DbSet<Video> videos { get; set; }
        public DbSet<NoticeBoard> NoticeBoards { get; set; }
        public DbSet<Tag> tags { get; set; }
        public DbSet<CourseTag> courseTags { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<ExtraInfo> ExtraInfos { get; set; }    
        public DbSet<Event> Events { get; set; }
        public DbSet<EventTag> EventTags { get; set; }
        public DbSet<Speaker> speakers { get; set; }
        public DbSet<EventSpeaker> eventspeakers { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<AboutWelcome> AboutWelcomes { get; set; }
        public DbSet<Adress> adresses { get; set; }
        public DbSet<AdressMessage> AdressMessages { get; set; }    
        public DbSet<Blog> blogs { get; set; } 
        public DbSet<BlogTag> blogTags { get; set; }
        public DbSet<PageInfo> pageInfoos { get; set; }
        public BackEndProjectDbContext(DbContextOptions<BackEndProjectDbContext> options):base(options)
        {

        }
    }
    public class BackEnddProjectMVCCFactory : IDesignTimeDbContextFactory<BackEndProjectDbContext>
    {
        public BackEndProjectDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BackEndProjectDbContext>();
            var connectionString = "Server=DESKTOP-2S0R6OF\\SQLEXPRESS;Database=BackEnddProjectMVCC;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
            return new BackEndProjectDbContext(optionsBuilder.Options);
        }
    }
}




