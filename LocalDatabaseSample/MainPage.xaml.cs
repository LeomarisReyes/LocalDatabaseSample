using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalDatabaseSample.Models;
using Xamarin.Forms;

namespace LocalDatabaseSample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ContactListView.ItemsSource = await App.Database.GetPeopleAsync();
        }



        async void OnButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Name.Text) && !string.IsNullOrWhiteSpace(LastName.Text) && !string.IsNullOrWhiteSpace(Telephone.Text))
            {
                await App.Database.SavePersonAsync(new Contact
                {
                    Name      = Name.Text,
                    LastName  = LastName.Text,
                    Telephone = Telephone.Text
                });

                Name.Text = LastName.Text = Telephone.Text = string.Empty;
                ContactListView.ItemsSource = await App.Database.GetPeopleAsync();
            }
        }
    }
}
