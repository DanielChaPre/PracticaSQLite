using PracticaSQLite.View;
using PracticaSQLite.Views.Forms;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PracticaSQLite
{
    public partial class App : Application
    {
        public App()
        {
            XF.Material.Forms.Material.Init(this);
            InitializeComponent();
            
            //MainPage = new MainPage();
            //MainPage = new EjemploPage();
            MainPage = new SimpleLoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
