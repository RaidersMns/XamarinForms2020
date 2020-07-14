using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Serviço.Modelo;
using App01_ConsultarCEP.Servico;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args) {

            //TODO - Validações.
            string cep = CEP.Text.Trim();

            if (IsValidCEP(cep)) {
                try { 
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if(end != null)
                    {
                    RESULTADO.Text = string.Format("Endereço: {0}, {1}, {2}, {3}, {4}", end.Cep, end.Logradouro, end.Bairro, end.Localidade, end.Uf);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "Endereço não encontrado para o CEP informado: " +cep, "OK");
                    }
                }catch(Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                }
            }

        }

        private bool IsValidCEP(string cep)
        {
            bool valido = true;
            if(cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP INVÁLIDO!  Número de caracteres incorreto", "OK");

                valido = false;
            }
            int NovoCEP = 0;
            if(!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("ERRO", "CEP INVÁLIDO!  O CEP deve ser composto apenas por números!", "OK");

                valido = false;
            }

            return valido;
        }
               
    }
}
