using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DocumentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersList : ContentPage
    {
        //public ObservableCollection<User> Items { get; set; }
        public List<Document> preItems { get; set; } // GET THIS WORKING ASYNCHRONOUSLY
        public ObservableCollection<string> Items { get; set; }
        private DynamoService _dynamoService;

        public UsersList()
        {
            InitializeComponent();

            _dynamoService = new DynamoService();
            Items = PopulateList(_dynamoService);
            BindingContext = this;


            //will repopulate list on addition of new item
            MessagingCenter.Subscribe<NewItem>(this, "listRefresh", (sender) => {
                Debug.WriteLine("REFRESH PLS");
                //UsersList yeet = new UsersList();
                Items = PopulateList(_dynamoService);
                BindingContext = this;
            });

        }

        public ObservableCollection<string> PopulateList(DynamoService ds)
        {

            preItems = ds.GetAll<User>();
            //List<Document> docList = preItems.Result;
            ObservableCollection<string> names = new ObservableCollection<string>();
            for (int i = 0; i < preItems.Count; i++)
            {
                string json = preItems[i].ToJson();
                dynamic jsonObj = JsonConvert.DeserializeObject(json);
                string un = jsonObj.username;
                names.Add(un);
                //Debug.WriteLine(docList[i].ToJson());
            }
            return names;
        }

        async void Handle_ItemTapped(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            await DisplayAlert("Item Tapped", e.SelectedItem.ToString(), "OK");
            Debug.WriteLine(e.SelectedItem.ToString());

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItem());
        }

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public Command RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;

                    await Navigation.PushAsync(new UsersList());

                    IsRefreshing = false;
                });
            }
        }
    }

}