using System;

namespace DIO.Bank
{
    public class Conta
    {
        private  TipoConta TipoConta {get; set;}
        private double Saldo {get; set;}
        private double Credito {get; set;}
        private string nome {get; set;}

        //CONSTRUTOR
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.nome = nome;
        }

        //MÉTODOS
        public bool Sacar(double valorSaque)
        {
            //Validação de saldo suficiente
            if(this.Saldo - valorSaque < (this.Credito *-1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;
            Console.WriteLine("Saldo atual da conta de {0} é {1}",this.nome,this.Saldo);
            return true;
        }

        public bool Depositar(double valorDepositado)
        {
            this.Saldo += valorDepositado;
            Console.WriteLine("Saldo atual  da conta de {0} é {1}",this.nome,this.Saldo);
            return true;
        }

        public bool Transferir(double valorTransferido, Conta contaDestino)
        {
            if(this.Sacar(valorTransferido)){
                contaDestino.Depositar(valorTransferido);
            }
            return true;
        }

        //SOBRESCRITA TOSTRING
        public override string ToString()
        {
            string retorno ="";
            retorno += "TipoConta" + this.TipoConta + " | ";
            retorno += "Nome " + this.nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito  " + this.Credito;
            return retorno;
        }
    }
}