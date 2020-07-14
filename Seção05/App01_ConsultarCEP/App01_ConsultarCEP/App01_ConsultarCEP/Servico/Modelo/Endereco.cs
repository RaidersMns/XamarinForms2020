﻿using System;
using System.Collections.Generic;
using System.Text;

namespace App01_ConsultarCEP.Serviço.Modelo
{
    public class Endereco
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Unidade { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }     
    }
}
