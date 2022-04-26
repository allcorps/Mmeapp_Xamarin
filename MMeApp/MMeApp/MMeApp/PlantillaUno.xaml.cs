using MMeApp.Data;
using MMeApp.Tabla;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MMeApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlantillaUno : ContentPage
    {
        private TBRegistros bdTBRegistros;
        public PlantillaUno(TBRegistros Plant)
        {
            bdTBRegistros = Plant;
            InitializeComponent();
            ABusto.Text = bdTBRegistros.Abusto;
            TDelantero.Text = bdTBRegistros.Tdelantero;
            CPecho.Text = bdTBRegistros.Cpecho;
            DBusto.Text = bdTBRegistros.Dbusto;
            CCintura.Text = bdTBRegistros.Ccintura;
            CCadera.Text = bdTBRegistros.Ccadera;

            if(bdTBRegistros.Oreference == null)
            {
                CatshaOrder();
            }
        }

        async public void CatshaOrder()
        {
            string res;

            do
            {
                res = await DisplayPromptAsync("Holi c:", "Ingresa la referencia o nombre del cliente","Guardar","Cancelar", initialValue: "");

                if (!string.IsNullOrWhiteSpace(res))
                {

                    if (!DependencyService.Get<ISQLite>().UserExist(res.ToString()))
                    {
                        try
                        {
                            bdTBRegistros.Oreference = res.ToString();
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                    else
                    {
                        await DisplayAlert("Alerta", "Usuario existe ingrese uno nuevo", "ok");
                        CatshaOrder();
                    }
                    
                }
                if(res == null)
                {
                    await Navigation.PopAsync();
                    break;
                }

            } while (res == "");
        }

        private async void Btn_next(object sender, EventArgs e)
        {
            
            bdTBRegistros.Abusto = ABusto.Text;
            bdTBRegistros.Tdelantero = TDelantero.Text;
            bdTBRegistros.Cpecho = CPecho.Text;
            bdTBRegistros.Dbusto = DBusto.Text;
            bdTBRegistros.Ccintura = CCintura.Text;
            bdTBRegistros.Ccadera = CCadera.Text;
            await Navigation.PushAsync(new PlantillaDos(bdTBRegistros)); 
            //se llama a la nueva plantilla dos otorgandole los registros de esta
        }
        async void Btn_cancel(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Aviso", "¿Desea cancelar?", "Continuar", "Cancelar");

            if (!response)
            {
                await Navigation.PopAsync();
            }
        }
    }
}