using Microsoft.EntityFrameworkCore;
using TunnelAPI.Models;

namespace TunnelAPI.Data
{
    public class TunnelApiDbContext : DbContext
    {
        public TunnelApiDbContext(DbContextOptions<TunnelApiDbContext> options) : base(options) { }

        public DbSet<StudentModel> Students { get; set; }
        public DbSet<RendezVousModel> RendezVous { get; set; }
        public object Registers { get; internal set; }
    }

}
