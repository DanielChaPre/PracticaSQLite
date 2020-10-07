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
        List<Usuario> listaUsuarios = new List<Usuario>();
        public List<Usuario> ListUsuarios { get { return listaUsuarios; } }
        public Pantalla2View ()
		{
			InitializeComponent ();
            conn = DependencyService.Get<ISQLitePlatform>().GetConnection();
            conn.CreateTable<Usuario>();

            listaUsuarios = GetItemsAsync();
        }

        public List<Usuario> GetItemsAsync()
        {
            return conn.Table<Usuario>().ToList();
        }
    }
}