using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BloodDonors
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            ToolbarItem tbi = null;
            if (Device.OS == TargetPlatform.iOS)
            {
                tbi = new ToolbarItem("+", null, () =>
                {
                    var todoItem = new TodoItem();
                    var todoPage = new RegisterForm();
                    todoPage.BindingContext = todoItem;
                    Navigation.PushAsync(todoPage);
                }, 0, 0);
            }
            if (Device.OS == TargetPlatform.Android)
            {
                tbi = new ToolbarItem("New Donor", "plus", () =>
                {
                    var todoItem = new TodoItem();
                    var todoPage = new RegisterForm();
                    todoPage.BindingContext = todoItem;
                    Navigation.PushAsync(todoPage);
                }, 0, 0);
            }
            

            ToolbarItems.Add(tbi);

            if (Device.OS == TargetPlatform.iOS)
            {
                var tbi2 = new ToolbarItem("?", null, () =>
                {
                    var todos = App.Database.GetItems();
                    var tospeak = "";
                    foreach (var t in todos)
                        tospeak += t.Name + " ";

                }, 0, 0);
                ToolbarItems.Add(tbi2);
            }

            DonorView.ItemsSource = App.Database.GetItems();
            sbSearch.TextChanged += (sender2, e2) => FilterBloodType(sbSearch.Text);

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DonorView.ItemsSource = App.Database.GetItems();

        }

        void listItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var todoItem = (TodoItem)e.SelectedItem;
            var todoPage = new RegisterForm();
            todoPage.BindingContext = todoItem;

            Navigation.PushAsync(todoPage);
        }

        private async void FilterBloodType(string filter)
        {
            DonorView.BeginRefresh();

            if (string.IsNullOrWhiteSpace(filter))
            {
                DonorView.ItemsSource = App.Database.GetItems(); ;
            }
            else
            {
                DonorView.ItemsSource = App.Database.GetItems()
                                .Where(x => x.Name.ToLower()
                                    .Contains(filter.ToLower()));
            }

            DonorView.EndRefresh();
        }
    }
}
