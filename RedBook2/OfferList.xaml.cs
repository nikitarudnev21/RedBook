using RedBook2.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RedBook2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OfferList : ContentPage
    {
        public OfferList()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            list.ItemsSource = App.Database.GetModifications();
            base.OnAppearing();
        }

        private async void list_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            OfferModifications offerModification = (OfferModifications)e.SelectedItem;
            OfferView offerView = new OfferView();
            offerView.BindingContext = offerModification;
            await Navigation.PushAsync(offerView);
        }
    }
}