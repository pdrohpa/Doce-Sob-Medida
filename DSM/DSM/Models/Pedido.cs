using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM.Models
{
    public class Pedido
    {
        private double proporcao;
        private Receita receita;
        private Cliente cliente;
        private DateTime data;
        private double valorVenda;

        public Pedido(double proporcao, Receita receita)
        {
            setProporcao(proporcao);
            this.receita = receita; 
        }

        public double getProporcao()
        {
            return proporcao;
        }

        public void setProporcao(double proporcao)
        {
            if (proporcao <= 0)
                throw new ArgumentException("Proporção deve ser maior que zero");
            this.proporcao = proporcao;
        }

        public Receita getReceita()
        {
            return receita;
        }

        public Cliente getCliente()
        {
            return cliente;
        }

        public void setCliente(Cliente cliente)
        {
            this.cliente = cliente;
        }

        public DateTime getData()
        {
            return data;
        }

        public void setData(DateTime data)
        {
            this.data = data;
        }

        public double getValorVenda()
        {
            return valorVenda;
        }

        public void setValorVenda(double valor)
        {
            if (valor < 0)
                throw new ArgumentException("O valor de venda deve ser maior ou igual a zero");

            this.valorVenda = valor;
        }
    }
}
