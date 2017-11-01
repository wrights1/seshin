using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DynamoDBList : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public DynamoDBList()
        {
            InitializeComponent();

            Items = new ObservableCollection<string>
            {
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 5"
            };

            BindingContext = this;
        }

        async void Handle_ItemTapped(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private Task<List<Contact>> LoadContacts()
        {
            var context = AmazonUtils.DDBContext;
            List<ScanCondition> conditions = new List<ScanCondition>();
            var search = context.ScanAsync<Contact>(conditions);
            return search.GetNextSetAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadContacts().ContinueWith(task =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    //listView.ItemsSource = task.Result;
                    Items = task.Result;
                });
            });
        }
    }
}