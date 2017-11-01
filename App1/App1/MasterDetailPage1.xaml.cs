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
    public partial class MasterDetailPage1 : MasterDetailPage
    {
        public MasterDetailPage1()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        { 
            var item = e.SelectedItem as MasterDetailPage1MenuItem;
            if (item == null)
                return;

            if (item.Id == 0)
            {
                Detail = new NavigationPage(new MasterDetailPage1Detail());
            }

            if ( item.Id == 1)
            { 
                Detail = new NavigationPage(new HighScores());
            }

            if (item.Id == 2)
            {
                Detail = new NavigationPage(new Settings());
            }

            if (item.Id == 3)
            {
                Detail = new NavigationPage(new About());
            }

            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}