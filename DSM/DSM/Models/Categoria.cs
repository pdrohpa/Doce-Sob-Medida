
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM.Models
{
    public class Categoria
    {
        private int codigo;
        private string descricao;

        public Categoria(string descricao)
        {
           setDescricao(descricao);
        }

        public Categoria(int codigo, string descricao)
        {
            this.codigo = codigo;
            setDescricao(descricao);
        }

        public int getCodigo()
        {
            return codigo;
        }

        public string getDescricao()
        {
            return descricao;
        }

        public void setDescricao(string descricao)
        {
            if (descricao.Length < 3)
                throw new ArgumentException("A descrição deve possui no mínimo 3 caracteres");

            this.descricao = descricao;
        }
    }
}
