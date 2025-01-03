using System;

namespace DesafioJAP.Services
{
    public class ContratoAluguerValidator
    {
        public static bool ValidarDataInicio(DateTime dataInicio)
        {
            return dataInicio >= DateTime.Now.Date;
        }

        public static bool ValidarDataFim(DateTime dataFim, DateTime dataInicio)
        {
            return dataFim > dataInicio;
        }
    }
}
