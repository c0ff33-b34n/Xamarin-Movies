using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Movies
{
    public class MainViewModel : BindableObject
    {
        private INetworkService _networkService;
        public MainViewModel(INetworkService networkService)
        {
            _networkService = networkService;
            OnPropertyChanged("Items");
            GetMovieData();
        }

        private async void GetMovieData()
        {
            var result = await _networkService.GetAsync<RootObject>(Constants.GetMoviesUri("avengers"));
            Items = new ObservableCollection<string>(result.Search.Select(x => x.Title));
            OnPropertyChanged("Items");
        }

        public ObservableCollection<string> Items
        {
            get;
            set;
        }
    }
}
