using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItem : ContentPage
    {
        public NewItem()
        {
            InitializeComponent();
        }

        async void NewItem_Saved(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new MasterDetailPage1Detail());
            //Detail = new NavigationPage(new HighScores());
            await Navigation.PopToRootAsync();
        }
    }
}