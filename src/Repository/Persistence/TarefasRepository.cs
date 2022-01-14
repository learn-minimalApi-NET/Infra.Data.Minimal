using Infra.Data.Minimal.Contexts;
using Infra.Data.Minimal.Models;
using Infra.Data.Minimal.Repository.Contracts;
using Infra.Data.Minimal.Repository.Generics;

namespace Infra.Data.Minimal.Repository.Persistence
{
    public class TarefasRepository : GenericRepository<AppDbContext, Tarefas>, ITarefasRepository
    {
    }
}
