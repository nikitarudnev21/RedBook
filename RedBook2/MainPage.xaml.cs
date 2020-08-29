using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RedBook2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnOffer_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddRecord());
        }

        private async void btnView_Clicked(object sender, EventArgs e)
        {
            BoolChecks.IsUserInterface = true;
            ViewList viewList = new ViewList();
            BookUser bookUser = new BookUser();
            viewList.BindingContext = bookUser;
            await Navigation.PushAsync(viewList);
        }

        private async void btnLog_Clicked(object sender, EventArgs e)
        {
            if (BoolChecks.AdminLogged)
            {
                await Navigation.PushAsync(new AdminPage());
            }
            else
            {
                AdminLogin adminList = new AdminLogin();
                BookAdmin bookAdmin = new BookAdmin();
                adminList.BindingContext = bookAdmin;
                await Navigation.PushAsync(adminList);
            }
        }

        private async void btnExit_Clicked(object sender, EventArgs e)
        {
            bool ex = await DisplayAlert("Подтвердите действие", "Вы действительно хотите выйти?", "Да", "Нет");
            if (ex)
            {
                Environment.Exit(0);
            }
        }
    }
}
