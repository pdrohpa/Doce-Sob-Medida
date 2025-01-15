using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM.Models
{
    public class IngredienteReceita
    {
        private Receita receita;
        private Ingrediente ingrediente;
        private int quantidade;

        public IngredienteReceita()
        {
            ingrediente = null;
            receita = null;
        }

        public IngredienteReceita(Receita receita, Ingrediente ingrediente)
        {
            setReceita(receita);
            setIngrediente(ingrediente);
        }

        public Receita getReceita()
        {
            return receita;
        }

        public void setReceita(Receita receita)
        {
            if (receita == null)
                throw new ArgumentException("A receita deve ser preenchida");

            this.receita = receita;
        }

        public Ingrediente getIngrediente()
        {
            return ingrediente;
        }

        public void setIngrediente(Ingrediente ingrediente)
        {
            if (ingrediente == null)
                throw new ArgumentException("O ingrediente deve ser preenchido");

            this.ingrediente = ingrediente;
        }

        public int getQuantidade()
        {
            return quantidade;
        }

        public void setQuantidade(int quantidade)
        {
            this.quantidade = quantidade;
        }
    }
}
