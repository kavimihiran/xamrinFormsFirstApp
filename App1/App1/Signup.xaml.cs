using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    public partial class Signup : ContentPage
    {

        public Signup()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.FromHex("#228B22");
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.FromHex("#228B22");
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");

            var db = new SQLiteConnection(dbpath);
            db.CreateTable<RegisterTable>();

            RegisterTable item = new RegisterTable();

            if (EntryFirstName.Text != null && EntryLastName.Text != null && EntryEmail.Text != null && EntryPassword.Text != null)
            {
                item.FirstName = EntryFirstName.Text;
                item.LastName = EntryLastName.Text;
                item.Email = EntryEmail.Text;
                item.Password = EntryPassword.Text;
                db.Insert(item);
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Congratulations ", "User Registered sucessfully", "yes", "cancel");

                    if (result)
                    {
                        await Navigation.PushAsync(new MainPage());
                    }

                }
                 );
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Failed login", "please fill all the fields", "yes", "cancel");


                }
                 );

            }
        }
    }
}