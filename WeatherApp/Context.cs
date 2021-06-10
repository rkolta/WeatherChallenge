using Microsoft.EntityFrameworkCore;
using WeatherApp.Models;

namespace WeatherApp
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<APIInteraction> APIInteractions { get; set; }
    }
}
