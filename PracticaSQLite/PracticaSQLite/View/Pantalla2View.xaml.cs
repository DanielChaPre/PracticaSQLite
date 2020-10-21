using PracticaSQLite.Modelo;
using PracticaSQLite.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PracticaSQLite.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Pantalla2View : ContentPage
    {
        public SQLiteConnection conn;
        private static bool banderaClick;
        List<Usuario> listaUsuarios = new List<Usuario>();
        public List<Usuario> ListUsuarios { get { return listaUsuarios; } }
        public Pantalla2View ()
		{
			InitializeComponent ();
            conn = DependencyService.Get<ISQLitePlatform>().GetConnection();
            conn.CreateTable<Usuario>();

            listaUsuarios = GetItemsAsync();
            UsuariosView.ItemSelected += UsuariosView_ItemSelected;
          
        }

        private async void UsuariosView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                UsuariosView.SelectedItem = null;
                if (banderaClick)
                {
                    var item = e.SelectedItem as Usuario;
                    if (item != null)
                    {
                        banderaClick = false;
                        await Navigation.PushAsync(new DetalleUsuarioPage(item));

                    }

                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Info", "Error:" + ex.Message, "Aceptar");
            }
        }

        public List<Usuario> GetItemsAsync()
        {
            return conn.Table<Usuario>().ToList();
        }
    }
}