using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BloodDonors
{
    public partial class RegisterForm : ContentPage
    {
        public RegisterForm()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
        }

        void submitClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            App.Database.SaveItem(todoItem);
            this.Navigation.PopAsync();
        }

    }
}
