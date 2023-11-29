using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalho2
{
    public class Usuario
    {

        private int _prontuario;
        private string _cpf;
        private string _senha;


        public Usuario(int prontuario,
                string CPF,
                string senha)
        {
           _prontuario= prontuario;
            _cpf = CPF;
            _senha = senha;
        }
        public Usuario(string CPF, string senha)
        {
            Cpf = CPF;
            Senha = senha;
        }

        public int prontuario
        {
            set { _prontuario = value; }
            get { return _prontuario; }

        }
        public string Cpf
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("PREENCHA O CAMPO CPF");

                _cpf = value;
            }
            get { return _cpf; }

        }
        public string Senha
        {
            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("PREENCHA O CAMPO Senha"); 

                _senha = value; }
            get { return _senha; }

        }

    }
}
