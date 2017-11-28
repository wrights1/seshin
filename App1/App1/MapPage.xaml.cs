using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DocumentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Newtonsoft.Json;

namespace App1
{
    public partial class MapPage : ContentPage
    {
        public List<Document> preItems; // GET THIS WORKING ASYNCHRONOUSLY
        private DynamoService _dynamoService;

    public MapPage()
        {
            InitializeComponent();


            var map = new Map(MapSpan.FromCenterAndRadius(
                new Position(40.070836, -82.524082),
                Distance.FromMiles(0.5)))
            {
                IsShowingUser = true,
                VerticalOptions = LayoutOptions.FillAndExpand
            };


            _dynamoService = new DynamoService();
            preItems = _dynamoService.GetAll<Event>();
            //Debug.WriteLine("GOT ALL YEEEEEEEEEEEEEEEEEEEEEEEEET");

            List<float> _latlist = new List<float>();
            List<float> _longlist = new List<float>();
            List<string> _titles = new List<string>();
            List<string> _hosts = new List<string>();

            for (int i = 0; i < preItems.Count; i++)
            {
                var dict = preItems[i].ToAttributeMap();
                string json = preItems[i].ToJson();
                var jsonObj = JsonConvert.DeserializeObject<Event>(json);
               
                _latlist.Add(jsonObj.latitude);
                _longlist.Add(jsonObj.longitude);
                _titles.Add(jsonObj.title);
                _hosts.Add(jsonObj.hostname);
                //Debug.WriteLine("ADDED EVENT YOOOOOOOOOOOOOOOO");
            }

            for (int i = 0; i < _latlist.Count; i++)
            {
                var position1 = new Position(_latlist[i], _longlist[i]);
                var pin = new Pin
                {
                    Type = PinType.Place,
                    Position = position1,
                    Label = _titles[i],
                    Address = _hosts[i],
                };

                pin.Id = "pin" + i;
                map.Pins.Add(pin);
                pin.Clicked += async (sender, e) =>
                {
                    var p = sender as Pin;
                    Debug.WriteLine(p.Address);
                    /* okay so
                     * 
                     * we need to query the database for this specific event to get all the information,
                     * because the pin is only storing hostname, lat, long, and title
                     * 
                     * nothing else is known about the event because nothing else can be saved
                     * from the inital GetAll, unless we make our own Pin class (screw that)
                     * 
                     * so we need to search for the event 
                     * 
                     */
                    var eventPage = new EventInfo();
                    eventPage.BindingContext = sender;
                    await Navigation.PushAsync(eventPage);
                };

            }



            Content = map;
        }
    }
}
