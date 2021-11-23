using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class SearchViewPageController
    {
        ApiRepository api = new ApiRepository();

        public async Task<IEnumerable<ApiModel>> GetRecipes()
        {
            var result = await api.GetApiModels();

            return result;
        }

        public async Task<IEnumerable<ApiModel>> SearchRecipes(string search)
        {
            var result = await api.SearchApiModels(search);
            return result;
        }
    }
}