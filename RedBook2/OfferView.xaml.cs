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
    public partial class OfferView : ContentPage
    {
        public OfferView()
        {
            InitializeComponent();
            Appearing += (s, e) =>
            {
                addModification.Clicked += async (se, ee) =>
                {
                    if (App.Database.GetItems().Where(x=>x.OldName==lblName.Text || x.Name== lblName.Text).Count()==0)
                    {
                        BookUser saveContent = new BookUser();
                        foreach (var modification in App.Database.GetModifications())
                        {
                            if (App.Database.GetItems().Where(x => x.Name == modification.OldName || x.OldName == modification.OldName).Count() != 0)
                            {
                                saveContent.BookId = App.Database.GetItems().Where(x => x.Name == modification.OldName || x.OldName == modification.OldName).First().BookId;
                            }
                        }
                        try
                        {
                            saveContent.Population = Convert.ToInt32(lblThickness.Text);
                        }
                        catch (Exception ex) { throw ex; }
                        saveContent.Type = lblType.Text;
                        saveContent.Category = lblCategory.Text;
                        saveContent.Description = lblDescription.Text;
                        saveContent.ViewImage = imgView.Source.ToString();
                        saveContent.Name = lblName.Text;
                        App.Database.SaveItem(saveContent);
                        await Navigation.PushAsync(new ViewList());
                    }
                    else
                    {
                        await DisplayAlert("Error", "This name is already taken", "Ok");
                    }

                };
                delete.Clicked += async (se, ee) =>
                {
                    App.Database.DeleteModification(App.Database.GetModifications().Where(x=>x.Name==lblName.Text).First().ModificationId);
                    await Navigation.PushAsync(new OfferList());
                };
            };
        }
    }
}