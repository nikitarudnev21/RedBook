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
    public partial class AdminLogin : ContentPage
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            entryLog.Text = "";
            entryPass.Text = "";
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            BookAdmin admin = new BookAdmin();
            if (entryLog.Text == admin.Login && entryPass.Text == admin.Password)
            {
                BoolChecks.AdminLogged = true;
                await Navigation.PushAsync(new AdminPage());
            }
            else
            {
                await DisplayAlert("Error", "Incorrect login or password", "OK");
            }
        }
    }
}