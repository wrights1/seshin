using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {

        static string bomb = new Random().Next(1, 4).ToString();

        static int scores = 0;

        //static string text = MyEntry.text;

        public MainPage()
        {
            InitializeComponent();
        }

        async void ButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button.Text == bomb) // death
            {
                await DisplayAlert("Bomb Exploded!", "Game Over", "Retry?");
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
