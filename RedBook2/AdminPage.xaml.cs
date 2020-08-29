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
    public partial class AdminPage : ContentPage
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddView());
        }

        private async void btnView_Clicked(object sender, EventArgs e)
        {
            BoolChecks.IsUserInterface = false;
            ViewList viewList = new ViewList();
            BookUser bookUser = new BookUser();
            viewList.BindingContext = bookUser;
            await Navigation.PushAsync(viewList);
        }

        private async void btnViewOffer_Clicked(object sender, EventArgs e)
        {
            OfferList offerList = new OfferList();
            await Navigation.PushAsync(offerList);
        }

        private async void btnViewRecords_Clicked(object sender, EventArgs e)
        {
            RecordList Record = new RecordList();
            OfferRecord offerRecord = new OfferRecord();
            Record.BindingContext = offerRecord;
            await Navigation.PushAsync(Record);
        }

        private async void btnExit_Clicked(object sender, EventArgs e)
        {
            bool ex = await DisplayAlert("Подтвердите действие", "Вы действительно хотите выйти из системы?", "Да", "Нет");
            if (ex)
            {
                BoolChecks.AdminLogged = false;
                await Navigation.PushAsync(new MainPage());
            }
        }

        private async void btnMainPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}