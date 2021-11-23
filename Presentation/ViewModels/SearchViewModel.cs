using Business;
using Models;
using Presentation.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class SearchViewModel : ObservableObject
    {
        SearchViewPageController searchViewPageController = new SearchViewPageController();

        public SearchViewModel()
        {
            GetRecipes();
        }

        private string _searchText;

        public string SearchText
        {
            get { return _searchText; }
            set 
            { 
                _searchText = value;
                OnPropertyChanged();
                Search(SearchText);
            }
        }

        private ObservableCollection<ApiModel> _apiList;

        public ObservableCollection<ApiModel> ApiList
        {
            get { return _apiList; }
            set 
            { 
                _apiList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<ApiModel> _apiListSearch;

        public ObservableCollection<ApiModel> ApiListSearch
        {
            get { return _apiListSearch; }
            set
            {
                _apiListSearch = value;
                OnPropertyChanged();
            }
        }

        private async void GetRecipes()
        {
            ApiList = new ObservableCollection<ApiModel>(await searchViewPageController.GetRecipes());
        }

        private async void Search(string text)
        {
            ApiListSearch = new ObservableCollection<ApiModel>(await searchViewPageController.SearchRecipes(text));
            ApiList = ApiListSearch;

            if (string.IsNullOrEmpty(text))
            {
                GetRecipes();
            }
        }
    }
}
