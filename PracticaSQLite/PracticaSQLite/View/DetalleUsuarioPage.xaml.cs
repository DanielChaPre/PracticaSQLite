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
	public partial class DetalleUsuarioPage : ContentPage
	{
        public SQLiteConnection conn;
        public Usuario item;
		public DetalleUsuarioPage (Usuario usuario)
		{
			InitializeComponent ();
            LlenarDatos();
            conn = DependencyService.Get<ISQLitePlatform>().GetConnection();
            conn.CreateTable<Usuario>();
            item = usuario;
		}

        public void LlenarDatos()
        {
            txtusuario.Text = item.nombreusuario;
            txtpass.Text = item.password;
        }

        private void BtnActualizar_Clicked(object sender, EventArgs e)
        {
            var usuario = new Usuario()
            {
                Id = item.Id,
                nombreusuario = txtusuario.Text,
                password = txtpass.Text
            };

            SaveItemAsync(usuario);
        }

        private void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            DeleteItemAsync(item);
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