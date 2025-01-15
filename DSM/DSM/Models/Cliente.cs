using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM.Models
{
    public class Cliente
    {
        private int codigo;
        private string nome;
        private string telefone;

        public Cliente() {  }

        public Cliente(string nome, string telefone)
        {
            setNome(nome);
            setTelefone(telefone);
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
                throw new ArgumentException("Nome deve ter no mínimo 3 caracteres");

            this.nome = nome;
        }

        public string getTelefone()
        {
            return telefone;
        }

        public void setTelefone(string telefone)
        {
            if (telefone.Length < 10)
                throw new ArgumentException("O telefone deve possuir DDD e o número");

            this.telefone = telefone;
        }
    }
}
