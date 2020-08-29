using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace RedBook2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Edit : ContentPage
    {
        public Edit()
        {
            InitializeComponent();
            Appearing += (s, e) =>
            {

                BookUser saveContent = new BookUser();
                saveContent.OldName = entryName.Text;
              /*  OfferModifications offer = new OfferModifications();
                offer.OldName = lblName.Text;*/
                saveContent.BookId = App.Database.GetItems().Where(x => x.Name == entryName.Text).First().BookId;
                fix.Clicked += async (se, ee) => {
                    if (entryPopulation.Text.All(c => char.IsNumber(c)) && entryDescription.Text.Length != 0
                    && entryName.Text.Length != 0 && entryPopulation.Text.Length != 0)
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
                           App.Database.SaveItem(saveContent);
                            /*    offer.Name = entryName.Text;
                                offer.Population = Convert.ToInt32(entryPopulation.Text);
                                offer.Category = (string)categoryPicker.SelectedItem;
                                offer.Type = (string)typePicker.SelectedItem;
                                offer.Description = entryDescription.Text;
                                offer.ViewImage = viewImg.Source.ToString();
                                App.Database.SaveModification(offer);*/
                            await Navigation.PushAsync(new ViewList());
                    }
                    else
                    {
                        await DisplayAlert("Error", "Please fill the fields correctly", "Ok");
                    }
                };
               /* viewImg.Clicked += async (se, ee) => {

                    await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Photos);
                    await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Photos);
                    await CrossPermissions.Current.RequestPermissionsAsync(Permission.Photos);
                    await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
                    await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Storage);
                    await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);
                    await CrossMedia.Current.Initialize();

                    if (!CrossMedia.Current.IsPickPhotoSupported)
                    {
                        await DisplayAlert("Не поддерживается", "Ваш девайс не поддерживает данный функционал", "Ок");
                    }
                    else
                    {
                        var mediaOptions = new PickMediaOptions()
                        {
                            PhotoSize = PhotoSize.Medium
                        };
                        var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);
                        if (viewImg == null)
                        {
                            await DisplayAlert("Error", "Could not get the image, please try again.", "Ok");
                            return;
                        }
                        viewImg.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());
                    }
                };*/
            };
        }
    }
}