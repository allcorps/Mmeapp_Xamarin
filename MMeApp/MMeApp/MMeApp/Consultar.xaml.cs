using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MMeApp.Tabla;
using MMeApp.Data;

namespace MMeApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cosultar : ContentPage
    {
        public Cosultar()
        {
            DependencyService.Get<ISQLite>().GetSQLiteConnectionWithCreateDatabase();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            AccidenteList();
        }

        private void AccidenteList()
        {
            Lista_Registros.ItemsSource = null;
            Lista_Registros.ItemsSource = DependencyService.Get<ISQLite>().ListaRegistros();
        }


        async void Btn_back(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        async void Eliminar_Clicked(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("MENSAJE", "DESEA ELIMINAR EL REGISTRO?", "Ok", "Cancel");
            if (res)
            {
                var menu = sender as MenuItem;
                TBRegistros detalles = menu.CommandParameter as TBRegistros;
                DependencyService.Get<ISQLite>().DeleteRegister(detalles.Id_orden);
                await DisplayAlert("MENSAJE", "Registro ELIMINADO CORRECTAMENTE", "OK");
                await Navigation.PushAsync(new Cosultar());
            }
        }



        async private void Ver_Clicked(object sender, EventArgs e)
        {
            var menu = sender as MenuItem;
            TBRegistros detalles = menu.CommandParameter as TBRegistros;
            await Navigation.PushAsync(new PlantillaUno(detalles));
        }

        private void Lista_Registros_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}