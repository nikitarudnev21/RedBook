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
    public partial class AddRecord : ContentPage
    {
        public AddRecord()
        {
            InitializeComponent();
            Appearing += (s, e) =>
            {
                add.Clicked += async (se, ee) =>
                {
                        OfferRecord saveContent = new OfferRecord();
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
                        App.Database.SaveOffer(saveContent);
                        await Navigation.PushAsync(new ViewList());
                };
            };
        }
    }
}