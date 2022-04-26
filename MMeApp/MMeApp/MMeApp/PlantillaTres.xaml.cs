using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMeApp.Tabla;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MMeApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlantillaTres : ContentPage
    {
        private TBRegistros bdTBRegistros;
        public PlantillaTres(TBRegistros PDos)
        {
            bdTBRegistros = PDos;
            InitializeComponent();
            AEspalda.Text = bdTBRegistros.Aespalda;
            TEspalda.Text = bdTBRegistros.Tespalda;
            LBrazo.Text = bdTBRegistros.Lbrazo;
            LCadera.Text = bdTBRegistros.Lcadera;
            LRodilla.Text = bdTBRegistros.Lrodilla;

        }

        private async void Btn_next(object sender, EventArgs e)
        {
            bdTBRegistros.Aespalda = AEspalda.Text;
            bdTBRegistros.Tespalda = TEspalda.Text;
            bdTBRegistros.Lbrazo = LBrazo.Text;
            bdTBRegistros.Lcadera = LCadera.Text;
            bdTBRegistros.Lrodilla = LRodilla.Text;
            await Navigation.PushAsync(new PlantillaFinal(bdTBRegistros));
        }
        async void Btn_back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}