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
    public partial class ViewList : ContentPage
    {
        public ViewList()
        {
            InitializeComponent();
            //  Appearing += (s, e) => {  };
        }
        protected override void OnAppearing()
        {
            list.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }
        private async void List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            BookUser selectedView = (BookUser)e.SelectedItem;
            if (BoolChecks.IsUserInterface)
            {
                ViewContentUser viewContentUser = new ViewContentUser();
                viewContentUser.BindingContext = selectedView;
                await Navigation.PushAsync(viewContentUser);
            }
            else
            {
                ViewContent viewContent = new ViewContent();
                viewContent.BindingContext = selectedView;
                await Navigation.PushAsync(viewContent);
            }
        }
    }
}