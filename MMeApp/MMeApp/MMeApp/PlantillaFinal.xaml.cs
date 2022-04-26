using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMeApp.Data;
using MMeApp.Tabla;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using Plugin.Media.Abstractions;


namespace MMeApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlantillaFinal : ContentPage
    {
        private TBRegistros bdTBRegistros;
        public PlantillaFinal(TBRegistros Pfinal)
        {
            DependencyService.Get<ISQLite>().GetSQLiteConnectionWithCreateDatabase();
            bdTBRegistros = Pfinal; 
            InitializeComponent();
            COrder.Text = bdTBRegistros.Oreference;
            XTra.Text = bdTBRegistros.Extra;
            image1.Source = bdTBRegistros.UbicacionImagen1;
            /*
            image2.Source = bdTBRegistros.UbicacionImagen2;
            image3.Source = bdTBRegistros.UbicacionImagen3;
            */

        }

        async void Btn_back(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        async void Btn_save(object sender, EventArgs e)
        {
            bdTBRegistros.Oreference = COrder.Text;
            bdTBRegistros.Extra = XTra.Text;

            bool response = await DisplayAlert("Finalizar", "¿Desea guardar el registro?", "Guardar", "Cancelar");

            if (response)
            {
                if (!DependencyService.Get<ISQLite>().UserExist(bdTBRegistros.Oreference.ToString()))
                {
                    bool res = DependencyService.Get<ISQLite>().SaveRegister(bdTBRegistros);

                    if (res)
                    {
                        await DisplayAlert("MENSAJE", "SE GUARDO CORRECTAMENTE EN EL DISPOSITIVO", "OK");
                        await Navigation.PopToRootAsync();
                    }
                }
                else
                {
                    bool res2 = DependencyService.Get<ISQLite>().UpdateRegister(bdTBRegistros);

                    if (res2)
                    {
                        await DisplayAlert("MENSAJE", "SE ACTUALIZO CORRECTAMENTE EN EL DISPOSITIVO", "OK");
                        await Navigation.PushAsync(new Cosultar());
                    }

                }
            }
            else
            {
                await Navigation.PopToRootAsync();
            }
        }

        private async void Btn_SaveImg1(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Error", "No se soporta el cargar fotos", "ok");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
            });

            if (file == null)
            {
                return;
            }
            bdTBRegistros.UbicacionImagen1 = file.Path;
            file.Dispose();
            image1.Source = bdTBRegistros.UbicacionImagen1;

        }
/*
        private async void Btn_SaveImg2(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Error", "No se soporta el cargar fotos", "ok");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
            });

            if (file == null)
            {
                return;
            }
            bdTBRegistros.UbicacionImagen2 = file.Path;
            file.Dispose();
            image2.Source = bdTBRegistros.UbicacionImagen2;
        }
        private async void Btn_SaveImg3(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Error", "No se soporta el cargar fotos", "ok");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
            });

            if (file == null)
            {
                return;
            }
            bdTBRegistros.UbicacionImagen3 = file.Path;
            file.Dispose();
            image3.Source = bdTBRegistros.UbicacionImagen3;
         */
    }
}