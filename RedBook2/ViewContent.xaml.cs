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
    public partial class ViewContent : ContentPage
    {
        public ViewContent()
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
                    Edit edit = new Edit();
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
                    editContent.ViewImage = imgView.Source.ToString();
                    edit.BindingContext = editContent;
                    await Navigation.PushAsync(edit);
                };
                delete.Clicked += async (se, ee) => {
                    Deleted deleted = new Deleted();
                    deleted.deletedID = App.Database.GetItems().Where(x => x.Description == description).First().BookId;
                    if (App.Database.GetDeletedItems().Where(x=>x.Description==description).Count()!=0)
                    {
                        deleted.Description = description + ".";
                    }
                    else
                    {
                        deleted.Description = description;
                    }
                    if (App.Database.GetDeletedItems().Where(x => x.Name == name).Count() != 0)
                    {
                        deleted.Name = name + ".";
                    }
                    else
                    {
                        deleted.Name = name;
                    }
                    App.database.SaveDeleted(deleted);
                    App.Database.DeleteItem(App.Database.GetItems().Where(x=>x.Description==description && x.Name == name).First().BookId);
                    await Navigation.PushAsync(new ViewList());
                };
            };
        }
    }
}