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
    public class UsuariosViewModel : BaseViewModel
    {
        public SQLiteConnection conn;
        private Usuario usuario;

        public UsuariosViewModel()
        {
            conn = DependencyService.Get<ISQLitePlatform>().GetConnection();
            conn.CreateTable<Usuario>();
            RegistroCommand = new Command(() => Registrar());
            ActualizarCommand = new Command(() => Actualizar());
            EliminarCommand = new Command(() => Eliminar());
        }

        public Usuario Usuario {
            get => usuario;
            set { usuario = value; OnPropertyChanged(); }
        }

        public ICommand RegistroCommand { private set; get; }
        public ICommand ActualizarCommand { private set; get; }
        public ICommand EliminarCommand { private set; get; }

        void Registrar()
        {
            var confirmacion = SaveItemAsync(usuario);

            Application.Current.MainPage = new NavigationPage(new Pantalla2View());
        }

        void Actualizar()
        {
            SaveItemAsync(Usuario);
        }

        void Eliminar()
        {
            DeleteItemAsync(Usuario);
        }

        public int SaveItemAsync(Usuario item)
        {
            if (item.Id != 0)
            {
                return conn.Update(item);
            }
            else
            {
                return conn.Insert(item);
            }
        }

        public int DeleteItemAsync(Usuario item)
        {
            return conn.Delete(item);
        }


    }
}
