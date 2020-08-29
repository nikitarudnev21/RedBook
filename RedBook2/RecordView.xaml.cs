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
    public partial class RecordView : ContentPage
    {
        public RecordView()
        {
            InitializeComponent();
            Appearing += (s, e) =>
            {

                add.Clicked += async (se, ee) =>
                {
                    if (App.Database.GetItems().Where(x => x.Name == lblName.Text || x.OldName == lblName.Text).Count() == 0)
                    { 
                        BookUser saveContent = new BookUser();
                        try
                        {
                            if (lblThickness.Text.Length!=0)
                            {
                                saveContent.Population = Convert.ToInt32(lblThickness.Text);
                            }
                        }
                        catch (Exception ex) { throw ex; }
                        saveContent.Type = lblType.Text;
                        saveContent.Category = lblCategory.Text;
                        saveContent.Description = lblDescription.Text;
                        if (imgView.Source is FileImageSource)
                        {
                            FileImageSource objFileImageSource = (FileImageSource)imgView.Source;
                            saveContent.ViewImage = objFileImageSource.File;
                        }
                        saveContent.Name = lblName.Text;
                        App.Database.SaveItem(saveContent);
                        await Navigation.PushAsync(new ViewList());
                    }
                    else
                    {
                        await DisplayAlert("Error", "this name is already taken", "Ok");
                    }
                };
                delete.Clicked += async (se, ee) =>
                {
                    App.Database.DeleteOffer(App.Database.GetOffers().Where(x => x.Name == lblName.Text).First().OfferId);
                    await Navigation.PushAsync(new RecordList());
                };
            };
        }
    }
}