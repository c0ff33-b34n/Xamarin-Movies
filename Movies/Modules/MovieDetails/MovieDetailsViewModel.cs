using Movies.Common.Base;
using Movies.Common.Models;
using Movies.Common.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Movies.Modules.MovieDetails
{
    public class MovieDetailsViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private INetworkService _networkService;

        private MovieData _movieData;

        public MovieDetailsViewModel(INavigationService navigationService, INetworkService networkService)
        {
            _navigationService = navigationService;
            _networkService = networkService;
        }

        public MovieData MovieData
        {
            get => _movieData;
            set => SetProperty(ref _movieData, value);
        }

        private bool _isFavorite;
        public bool IsFavorite
        {
            get => _isFavorite;
            set => SetProperty(ref _isFavorite, value);
        }

        private FullMovieInformation _movieInformation;
        public FullMovieInformation MovieInformation
        {
            get => _movieInformation;
            set => SetProperty(ref _movieInformation, value);
        }


        public override async Task InitializeAsync(object parameter)
        {
            MovieData = (MovieData)parameter;
            MovieInformation = await _networkService.GetAsync<FullMovieInformation>(ApiConstants.GetMovieById(MovieData.ImdbID));
        }

        public ICommand GoBackCommand => new Command(async () => await GoBack());
        public ICommand FavoriteCommand => new Command(async () => await SetMovieFavorite());

        private async Task GoBack()
        {
            await _navigationService.PopAsync();
        }

        private async Task SetMovieFavorite()
        {
            IsFavorite = !IsFavorite;
        }

    }
}
