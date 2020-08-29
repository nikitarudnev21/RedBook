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
    public partial class AddView : ContentPage
    {
        public AddView()
        {
            InitializeComponent();
            Appearing += (s, e) =>
            {
                add.Clicked += async (se, ee) =>
                {
                    if (App.Database.GetItems().Where(x=>x.Name==entryName.Text || x.OldName == entryName.Text).Count()==0)
                    {
                        BookUser saveContent = new BookUser();
                        try
                        {
                            saveContent.Population = Convert.ToInt32(entryPopulation.Text);
                        }
                        catch (Exception ex) { throw ex; }
                        saveContent.Type = (string)typePicker.SelectedItem;
                        saveContent.Category = (string)categoryPicker.SelectedItem;
                        saveContent.Description = entryDescription.Text;
                        saveContent.ViewImage = entryImage.Text;
                        saveContent.Name = entryName.Text;
                        App.Database.SaveItem(saveContent);
                        await Navigation.PushAsync(new ViewList());
                    }
                    else
                    {
                        await DisplayAlert("Error", "this name is already taken", "Ok");
                    }
                };
            };
        }
    }
}