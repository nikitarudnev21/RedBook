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
    public partial class ViewContentUser : ContentPage
    {
        public ViewContentUser()
        {
            InitializeComponent();
            Appearing += (s, e) =>
            {
                string name = lblName.Text;
                string description = lblDescription.Text;
                string population = lblThickness.Text;
                string type = lblType.Text;
                string category = lblCategory.Text;
                lblName.Text = "Название вида: " + name;
                lblThickness.Text = "Популяция: " + population + " видов";
                lblType.Text = "Тип вида: " + type;
                lblCategory.Text = "Категория: " + category;
                fix.Clicked += async (se, ee) =>
                {
                    EditUser editUser = new EditUser();
                    BookUser editContent = new BookUser();
                    editContent.Name = name;
                    try
                    {
                        editContent.Population = Convert.ToInt32(population);
                    }
                    catch (Exception ex) { throw ex; }
                    editContent.Type = type;
                    editContent.Category = category;
                    editContent.Description = description;
                    if (imgView.Source is FileImageSource)
                    {
                        FileImageSource objFileImageSource = (FileImageSource)imgView.Source;
                        editContent.ViewImage = objFileImageSource.File;
                    }
                    editUser.BindingContext = editContent;
                    await Navigation.PushAsync(editUser);
                };
            };
        }
    }
}