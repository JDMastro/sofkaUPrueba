using SofkaUPrueba.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofkaUPrueba.Core.Interfaces
{
    public interface IHistoryService
    {
        Task AddHistory(History history);
        dynamic GetHistory();
    }
}
