using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
        }

        private async Task GetMovieData()
        {
            var result = await _networkService.GetAsync<ListOfMovies>(ApiConstants.GetMoviesUri(SearchTerm));
            Items = new ObservableCollection<MovieData>(result.Search
                .Select(x => new MovieData(x.Title, x.Poster.Replace("SX300", "SX600"))));
            OnPropertyChanged("Items");
        }

        public ObservableCollection<MovieData> Items
        {
            get;
            set;
        }

        public string SearchTerm { get; set; }
        public ICommand PerformSearchCommand { get => new Command(async () => await GetMovieData()); }

    }
}
