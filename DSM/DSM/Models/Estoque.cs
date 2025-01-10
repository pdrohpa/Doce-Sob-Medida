using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM.Models
{
    public class Estoque
    {
        private int codigo;
        private DateTime data;
        private string tipoAcao;
        private double quantidade;
        private Ingrediente ingrediente;

        public Estoque(int codigo, DateTime data, string tipoAcao, double quantidade, Ingrediente ingrediente)
        {
            this.data = data;
            setTipoAcao(tipoAcao);
            setQuantidade(quantidade);
            setIngrediente(ingrediente);
        }

        public Estoque(DateTime data, string tipoAcao, double quantidade, Ingrediente ingrediente)
        {
            this.data = data;
            setTipoAcao(tipoAcao);
            setQuantidade(quantidade);
            setIngrediente(ingrediente);
        }

        public int getCodigo()
        {
            return codigo;
        }

        public DateTime getData()
        {
            return data;
        }

        public string getTipoAcao()
        {
            return tipoAcao;
        }

        public void setTipoAcao(string tipoAcao)
        {
            tipoAcao = tipoAcao.ToUpper();
            if (tipoAcao != "ENTRADA" && tipoAcao != "SAIDA")
            {
                throw new ArgumentException("Tipo de ação inválida");
            }

            this.tipoAcao = tipoAcao;
        }

        public double getQuantidade()
        {
            return quantidade;
        }

        public void setQuantidade(double quantidade)
        {
            if (quantidade < 0)
            {
                throw new ArgumentException("Quantidade deve ser maior ou igual a zero");
            }

            this.quantidade = quantidade;
        }

        public bool permitirOperacao()
        {
            double quantidadeEstoque = ingrediente.getQuantidade();
            if (tipoAcao == "SAIDA" && quantidade > quantidadeEstoque)
            {
                return false;
            }

            return true;

        }

        public Ingrediente getIngrediente()
        {
            return ingrediente;
        }

        public void setIngrediente(Ingrediente ingrediente)
        {
            if (ingrediente == null)
            {
                throw new ArgumentException("Você deve informar um ingrediente");
            }

            this.ingrediente = ingrediente;
        }
    }
}
