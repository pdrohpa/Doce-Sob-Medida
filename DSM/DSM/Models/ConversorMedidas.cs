using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM.Models
{
    public class ConversorMedidas
    {
        public ConversorMedidas() { }

        public double converterParaQuilos(double quantidade, string unidadeMedida)
        {
            if (unidadeMedida == "Mililitros" || unidadeMedida == "Gramas")
                return quantidade / 1000;
            else if (unidadeMedida == "Xícaras")
                return (quantidade * 240) / 1000;
            else if (unidadeMedida == "Colheres de Chá")
                return (quantidade * 5) / 1000;
            else if (unidadeMedida == "Colheres de Sopa")
                return (quantidade * 15) / 1000;

            return quantidade;
        }

        public double converterParaUnidadeMedida(double pesoEmQuilos, string unidadeMedida)
        {
            if (unidadeMedida == "Mililitros" || unidadeMedida == "Gramas")
                return pesoEmQuilos * 1000;
            else if (unidadeMedida == "Xícaras")
                return (pesoEmQuilos * 1000) / 240;
            else if (unidadeMedida == "Colheres de Chá")
                return (pesoEmQuilos * 1000) / 5;
            else if (unidadeMedida == "Colheres de Sopa")
                return (pesoEmQuilos * 1000) / 15;

            return pesoEmQuilos;
        }
    }
}
