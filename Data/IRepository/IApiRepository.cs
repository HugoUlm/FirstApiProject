using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IApiRepository
    {
        Task<IEnumerable<ApiModel>> GetApiModels();
        Task<IEnumerable<ApiModel>> SearchApiModels(string search);
    }
}
