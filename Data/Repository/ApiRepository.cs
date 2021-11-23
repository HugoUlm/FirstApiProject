using Data.IRepository;
using Models;
using Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ApiRepository : IApiRepository
    {
        public async Task<IEnumerable<ApiModel>> GetApiModels()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage apiResponse = await client.GetAsync("Get your API-Key from spoonacular.com");

                string jsonResponse = await apiResponse.Content.ReadAsStringAsync();

                RecipeModel recipeModel = JsonConvert.DeserializeObject<RecipeModel>(jsonResponse);

                return recipeModel.results.Select(x => new ApiModel()
                {
                    title = x.title,
                    sourceUrl = x.sourceUrl,
                    servings = x.servings,
                    readyInMinutes = x.readyInMinutes,
                });
            }
        }

        public async Task<IEnumerable<ApiModel>> SearchApiModels(string search)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage apiResponse = await client.GetAsync("Get your API-Key from spoonacular.com");

                string jsonResponse = await apiResponse.Content.ReadAsStringAsync();

                RecipeModel recipeModel = JsonConvert.DeserializeObject<RecipeModel>(jsonResponse);

                return recipeModel.results.Where(x => x.title.ToLower().Contains(search)).Select(x => new ApiModel()
                {
                    title = x.title,
                    sourceUrl = x.sourceUrl,
                    servings = x.servings,
                    readyInMinutes = x.readyInMinutes,
                });
            }
        }
    }
}
