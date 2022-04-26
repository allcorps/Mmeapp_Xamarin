using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMeApp.Tabla;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MMeApp.Data;

namespace MMeApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlantillaDos : ContentPage
    {
        private TBRegistros bdTBRegistros; // hice la variable
        public PlantillaDos(TBRegistros PUno) 
        {
            bdTBRegistros = PUno; // le di el valor que recibe a la variable
            InitializeComponent();
            AHombro.Text = bdTBRegistros.Ahombro;
            CCuello.Text = bdTBRegistros.Ccuello;
            CBrazo.Text = bdTBRegistros.Cbrazo;
            CPuno.Text = bdTBRegistros.Cpuno;
            LTiro.Text = bdTBRegistros.Ctiro;
            Lfp.Text = bdTBRegistros.Lfp;
        }

        private async void Btn_next(object sender, EventArgs e)
        {
            
            // termine de llenar lo que faltaba
            bdTBRegistros.Ahombro = AHombro.Text;
            bdTBRegistros.Ccuello = CCuello.Text;
            bdTBRegistros.Cbrazo = CBrazo.Text;
            bdTBRegistros.Cpuno = CPuno.Text;
            bdTBRegistros.Ctiro = LTiro.Text;
            bdTBRegistros.Lfp = Lfp.Text;
            await Navigation.PushAsync(new PlantillaTres(bdTBRegistros)); 
        }
        async void Btn_back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}