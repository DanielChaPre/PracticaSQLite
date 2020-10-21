using PracticaSQLite.Modelo;
using PracticaSQLite.Services;
using PracticaSQLite.View;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PracticaSQLite.ViewModel
{
    public class LoginViewModel: BaseViewModel
    {
        public SQLiteConnection conn;
        private string usuario;
        private string password;

        public LoginViewModel()
        {
            conn = DependencyService.Get<ISQLitePlatform>().GetConnection();
            conn.CreateTable<Usuario>();
            LogearCommand = new Command(() => Logear());
        }

        public string Usuario {
            get => usuario;
            set => usuario = value;
        }

        public string Password {
            get => password;
            set => password = value;
        }

        public ICommand LogearCommand { private set; get; }

        void Logear()
        {
            var user = GetItemsQuery(Usuario, Password);
            if (!string.IsNullOrEmpty(user[0].nombreusuario))
            {
                // Application.Current.MainPage.Navigation.PushAsync(new Pantalla2View());
                Application.Current.MainPage = new NavigationPage(new Pantalla2View());
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("alerta", "El usuario no fue encontrado", "Ok");
            }
        }

        public List<Usuario> GetItemsQuery(string user, string pass)
        {
            return conn.Query<Usuario>("SELECT * FROM Usuario WHERE nombreusuario = ? and password = ?", new string[2] { user, pass });
        }
    }
}
