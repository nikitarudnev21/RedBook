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
    public partial class EditUser : ContentPage
    {
        public EditUser()
        {
            InitializeComponent();
            Appearing += (s, e) =>
            {
                OfferModifications saveContent = new OfferModifications();
                saveContent.OldName = entryName.Text;
          //      DisplayAlert("asdas", saveContent.OldDescription + App.Database.GetItems().Where(x=>x.Description==saveContent.OldDescription).First().BookId, "sa");
              //  saveContent.OldDescription = entryDescription.Text;
                
           //     saveContent.BookId = App.Database.GetItems().Where(x => x.Name == entryName.Text).First().BookId;
                /*  var cnt = App.Database.GetItems().Where(x => x.Name == entryName.Text).Count();
                  DisplayAlert("", cnt.ToString() + entryName.Text, "Cancel");*/
                fix.Clicked += async (se, ee) =>
                {
                    if (entryPopulation.Text.All(c => char.IsNumber(c)))
                    {
                            saveContent.Name = entryName.Text;
                            saveContent.Population = Convert.ToInt32(entryPopulation.Text);
                            saveContent.Category = (string)categoryPicker.SelectedItem;
                            saveContent.Type = (string)typePicker.SelectedItem;
                            saveContent.Description = entryDescription.Text;
                            if (viewImg.Source is FileImageSource)
                            {
                                FileImageSource objFileImageSource = (FileImageSource)viewImg.Source;
                                saveContent.ViewImage = objFileImageSource.File;
                            }
                            App.Database.SaveModification(saveContent);
                            await Navigation.PushAsync(new ViewList());
                    }
                    else
                    {
                        await DisplayAlert("Error", "Please fill the fields correctly", "Ok");
                    }
                };
            };
        }
    }
}