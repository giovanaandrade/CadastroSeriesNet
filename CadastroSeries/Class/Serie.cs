using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroSeries.Class
{
    public class Serie : EntidadeBase
    {
        public Genero Genero { get; private set; }
        public string Titulo { get; private set; }
        public string Sinopse { get; private set; }
        public int Ano { get; private set; }
        public string Diretor { get; private set; }
        public bool Excluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string sinopse, int ano, string diretor)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Sinopse = sinopse;
            Ano = ano;
            Diretor = diretor;
            Excluido = false;
        }

        public override string ToString()
        {
            return  "ID: " + Id + Environment.NewLine 
                    +"Título: " + Titulo + Environment.NewLine
                    + "Gênero: " + Genero + Environment.NewLine
                    + "Sinopse: " + Sinopse + Environment.NewLine
                    + "Ano: " + Ano + Environment.NewLine
                    + "Diretor: " + Diretor + Environment.NewLine
                    + "Excluído: " + Excluido;
        }

        public string RetornaTitutlo()
        {
            return Titulo;
        }

        public int RetornaId()
        {
            return Id;
        }

        public void Excluir()
        {
            Excluido = true;
        }
    }
}
