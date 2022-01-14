using Infra.Data.Minimal.Models;
using Infra.Data.Minimal.Repository.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infra.Data.Minimal.Contexts
{
    public class AppDbContext: DbContext
    {
        public DbSet<Tarefas> Leads { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source = tarefas.db");
            }
        }

        public static async Task VerificaDBExiste(IServiceProvider services, ILogger logger, string connectionString)
        {
            logger.LogInformation("Verifica se o banco de dados existe e esteja na string de conexão :" +
                " '{connectionString}'", connectionString);

            using var db = services.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
            await db.Database.MigrateAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TarefasMap());

            base.OnModelCreating(builder);
        }
    }
}