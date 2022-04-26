using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MMeApp.Data;

namespace MMeApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            DependencyService.Get<ISQLite>().GetSQLiteConnectionWithCreateDatabase();
        }

        private async void Btn_search(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Cosultar());
            
        }

        private async void Btn_template(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlantillaUno(new Tabla.TBRegistros()));
        }
    }
}
