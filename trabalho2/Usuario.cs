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
        private string _cep;
        private string _rua;
        private string _Bairro;
        private string _Numero_casa;



        public Usuario(int prontuario,
                string CPF,
                string senha)
        {
           _prontuario= prontuario;
            _cpf = CPF;
            _senha = senha;
        }
        public Usuario(int prontuario, string Rua, string Bairro, string Numero, string cep)
        {
            _prontuario = prontuario;
            _cep = cep;
            _rua = Rua;
            _Bairro = Bairro;
            _Numero_casa = Numero;

        }
        public Usuario( string Rua, string Bairro, string Numero, string cep)
        {
            _cep = cep;
            _rua = Rua;
            _Bairro = Bairro;
            _Numero_casa = Numero;

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
        public string rua
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("PREENCHA O CAMPO rua ");

                _rua = value;
            }
            get { return _rua; }

        }
        public string Bairro
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("PREENCHA O CAMPO Bairro ");

                _Bairro = value;
            }
            get { return _Bairro; }

        }
        public string Numero
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("PREENCHA O CAMPO Numero da casa ");

                _Numero_casa = value;
            }
            get { return _Numero_casa; }

        }
        public string cep
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("PREENCHA O CAMPO CEP ");

                _cep = value;
            }
            get { return _cep; }

        }

    }
}
