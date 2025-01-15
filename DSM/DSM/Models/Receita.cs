using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM.Models
{
    public class Receita
    {
        private int codigo;
        private string nome;
        private string descricao;
        private double precoCusto;
        private Categoria categoria;
        private List<IngredienteReceita> ingredientes;

        public Receita() { }

        public Receita(int codigo, string nome, string descricao, double precoCusto, Categoria categoria)
        {
            this.codigo = codigo;
            setNome(nome);
            this.descricao = descricao;
            setPrecoCusto(precoCusto);
            setCategoria(categoria);
            ingredientes = new List<IngredienteReceita>();
        }

        public Receita(string nome, string descricao, double precoCusto, Categoria categoria)
        {
            setNome(nome);
            this.descricao = descricao;
            setPrecoCusto(precoCusto);
            setCategoria(categoria);
            ingredientes = new List<IngredienteReceita>();
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
                throw new ArgumentException("O nome deve ter no mínimo 3 caracteres");
            this.nome = nome;
        }

        public string getDescricao()
        {
            return descricao;
        }

        public double getPrecoCusto()
        {
            return precoCusto;
        }

        public void setPrecoCusto(double precoCusto)
        {
            if (precoCusto <= 0)
            {
                throw new ArgumentException("O preço deve ser maior que 0");
            }

            this.precoCusto = precoCusto;   
        }

        public Categoria getCategoria()
        {
            return categoria;
        }

        public void setCategoria(Categoria categoria)
        {
            if (categoria == null)
            {
                throw new ArgumentException("A categoria deve ser preenchida");
            }

            this.categoria = categoria;
        }

        public void AddIngrediente(IngredienteReceita ingrediente)
        {
            ingredientes.Add(ingrediente);
        }

        public List<IngredienteReceita> getIngredientes()
        {
            return ingredientes;
        }
    }
}
