using Infra.Data.Minimal.Contexts;
using Infra.Data.Minimal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Minimal.Repository.Contracts
{
    public interface ITarefasRepository : IGenericRepository<AppDbContext, Tarefas>
    {
    }
}
