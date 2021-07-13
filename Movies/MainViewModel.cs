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
            Items = new ObservableCollection<MovieData>(result.Search
                .Select(x => new MovieData(x.Title, x.Poster.Replace("SX300", "SX600"))));
            OnPropertyChanged("Items");
        }

        public ObservableCollection<MovieData> Items
        {
            get;
            set;
        }
    }
}
