using Business;
using Models;
using Presentation.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Presentation.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        SearchViewPageController searchViewPageController = new SearchViewPageController();
        public RelayCommand SearchViewCommand { get; set; }
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand RandomRecipeCommand { get; set; }   
        public SearchViewModel SearchViewModel { get; set; }

        public MainWindowViewModel()
        {
            GetRecipes();

            SearchViewModel = new SearchViewModel();

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = null;
            });

            SearchViewCommand = new RelayCommand(o =>
            {
                CurrentView = SearchViewModel;
            });

            RandomRecipeCommand = new RelayCommand(o =>
            {
                GetRandomRecipeUrl();
            });
        }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
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

        private async void GetRecipes()
        {
            ApiList = new ObservableCollection<ApiModel>(await searchViewPageController.GetRecipes());
        }

        public void GetRandomRecipeUrl()
        {
            ApiModel apiModel = EnumerableExtension.PickRandom(ApiList);
            string url = apiModel.sourceUrl;
            System.Diagnostics.Process.Start(url);
        }
    }
}
