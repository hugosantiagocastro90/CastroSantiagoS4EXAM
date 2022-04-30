using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CastroSantiagoS4EXAM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        double totalAPagar = 0;
        double montoInicial = 0;
        double cuotaMensual = 0;
        public Registro(string usuario)
        {
            InitializeComponent();
            lblUsuario.Text = usuario;
        }

        private void btnCalcular_Clicked(object sender, EventArgs e)
        {

            try
            {
                montoInicial = Convert.ToDouble(txtMontoInicial.Text);
                if (montoInicial < 1 || montoInicial > 3000 )
                {
                    DisplayAlert("Error", "Monto debe ser de 1 a 3000", "Continuar");

                }
                else
                {
                    cuotaMensual = ((3000 - montoInicial) / 5) + (((3000 - montoInicial) / 5) * 5)/100;
                    txtPagoMensual.Text = cuotaMensual.ToString();
                    totalAPagar = (cuotaMensual * 5);
                }

            }
            catch (Exception)
            {
                DisplayAlert("Error", "Monto debe ser numerico", "Continuar");

            }

        }

        private async void btnEnviar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Resumen(lblUsuario.Text, txtNombre.Text, totalAPagar));

        }
    }
}