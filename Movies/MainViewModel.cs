using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Movies
{
    public class MainViewModel : BindableObject
    {
        public MainViewModel()
        {
            OnPropertyChanged("Items");
        }

        public ObservableCollection<string> Items => new ObservableCollection<string>
        {
            "Apocalypse Now",
            "Full Metal Jacket",
            "Battle of the River Plate"
        };
    }
}
