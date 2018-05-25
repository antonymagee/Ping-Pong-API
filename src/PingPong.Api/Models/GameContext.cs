using Microsoft.EntityFrameworkCore;

namespace Anow.PingPong.Api.Models

{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options)
            : base(options)
            {
            }

        public DbSet<GameObject> Game { get; set;}
    }
}
