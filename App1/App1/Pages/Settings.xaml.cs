using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public Settings()
        {
            InitializeComponent();

            Items = new ObservableCollection<string>
            {
                "Account",
                "My Events",
                "Display",
                "Profile",
                "Privacy"
            };

            BindingContext = this;
        }

        async void Handle_ItemTapped(object sender, SelectedItemChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.SelectedItem);

            if (e.SelectedItem == null)
                return;

            await DisplayAlert("stop", "what are you doing", "sorry");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}