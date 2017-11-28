using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItem : ContentPage
    {
        private DynamoService dynamoService;

        public NewItem()
        {
            InitializeComponent();
        }


        async void NewItem_Saved(object sender, EventArgs e)
        { 
            dynamoService = new DynamoService();

            if (username.Text == null || first.Text == null || last.Text == null)
            {
                await DisplayAlert("Missing Fields", "All fields on this screen are required", "OK");
            }
            else
            {
                User userInfo = new User
                {
                    username = username.Text,
                    firstName = first.Text,
                    lastName = last.Text
                };

                await dynamoService.Store(userInfo);

                await Navigation.PopToRootAsync();

                MessagingCenter.Send<NewItem>(this, "listRefresh");
            }
        }
    }
}

