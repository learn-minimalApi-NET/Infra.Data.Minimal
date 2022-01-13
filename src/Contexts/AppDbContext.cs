using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infra.Data.Minimal.Contexts
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public static async Task VerificaDBExiste(IServiceProvider services, ILogger logger, string connectionString)
        {
            logger.LogInformation("Verifica se o banco de dados existe e esteja na string de conexão :" +
                " '{connectionString}'", connectionString);

            using var db = services.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
            await db.Database.MigrateAsync();
        }
    }
}