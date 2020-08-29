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
    public partial class RecordList : ContentPage
    {
        public RecordList()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            list.ItemsSource = App.Database.GetOffers();
            base.OnAppearing();
        }
        private async void List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            OfferRecord selectedRecord = (OfferRecord)e.SelectedItem;
            RecordView record = new RecordView();
            record.BindingContext = selectedRecord;
            await Navigation.PushAsync(record);
        }
    }
}