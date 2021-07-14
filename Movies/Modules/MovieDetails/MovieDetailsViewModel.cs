using Movies.Common.Base;
using Movies.Common.Database;
using Movies.Common.Models;
using Movies.Common.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private IRepository<FullMovieInformation> _movieInformationRepository;

        private MovieData _movieData;

        public MovieDetailsViewModel(INavigationService navigationService,
                                     INetworkService networkService,
                                     IRepository<FullMovieInformation> repo)
        {
            _navigationService = navigationService;
            _networkService = networkService;
            _movieInformationRepository = repo;
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
            var dbinfo = (await _movieInformationRepository.GetAllAsync()).FirstOrDefault(x => x.imdbID == MovieInformation.imdbID);

            if (dbinfo != null)
            {
                MovieInformation.Id = dbinfo.Id;
                IsFavorite = dbinfo.IsFavorite;
            }
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
            MovieInformation.IsFavorite = IsFavorite;
            await _movieInformationRepository.SaveAsync(MovieInformation);
        }

    }
}
