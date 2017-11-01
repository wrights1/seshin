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
    public partial class MasterDetailPage1Detail: ContentPage
    {
        static string bomb = new Random().Next(1, 4).ToString();

        static int scores = 0;

        public MasterDetailPage1Detail()
        {
            InitializeComponent();
        }

        async void ButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button.Text == bomb) // death
            {
                await DisplayAlert("u suck", "Game Over", "Retry?");
                bomb = new Random().Next(1, 4).ToString();
                scores = 0;
            }
            else
            { 
                scores += 1;
                bomb = new Random().Next(1, 4).ToString();
                await DisplayAlert("Success", " Score: " + scores, "Continue");
            }

        }
    }
}