using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM.Models
{
    public class Ingrediente
    {
        private int codigo;
        private string nome;
        private string unidadeMedida;
        private double quantidade;
        private List<Estoque> estoques;

        public Ingrediente(string nome, string unidadeMedida)
        {
            setNome(nome);
            this.unidadeMedida = unidadeMedida;
            estoques = new List<Estoque>();
        }

        public Ingrediente(
            int codigo, 
            string nome, 
            string unidadeMedida)
        {
            this.codigo = codigo;
            setNome(nome);
            this.unidadeMedida = unidadeMedida;
            estoques = new List<Estoque>();
        }

        public int getCodigo()
        {
            return codigo;
        }

        public void setCodigo(int codigo)
        {
            this.codigo = codigo;
        }

        public string getNome()
        {
            return nome;
        }

        public void setNome(string nome)
        {
            if (nome.Length < 3)
                throw new ArgumentException("O nome deve possuir no mínimo 3 caracteres");
            this.nome = nome;   
        }

        public string getUnidadeMedida()
        {
            return unidadeMedida;
        }

        public void setUnidadeMedida(string unidadeMedida)
        {
            this.unidadeMedida = unidadeMedida;
        }

        public double getQuantidade()
        {
            double quantidadeTotal = 0;

            foreach (Estoque estoque in estoques)
            {
                string tipoAcao = estoque.getTipoAcao();
                double quantidade = estoque.getQuantidade();

                if (tipoAcao == "ENTRADA")
                    quantidadeTotal += quantidade;
                else
                    quantidadeTotal -= quantidade;
            }

            return quantidadeTotal;
        }

        public string getTextoEstoque()
        {
            string medida;
            if (unidadeMedida == "Unidades")
                medida = "unidade(s)";
            else
                medida = "quilo(s)";

            return String.Format("{0} {1}", getQuantidade().ToString("F2"), medida);
        }
        public void AddEstoque(Estoque estoque)
        {
            estoques.Add(estoque);
        }
    }
}
