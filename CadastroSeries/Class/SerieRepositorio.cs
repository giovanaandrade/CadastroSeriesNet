using CadastroSeries.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroSeries.Class
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        public bool Atualiza(int id, Serie serie)
        {

            if (id > listaSerie.Count)
            {
                return false;
            }
            else
            {
                listaSerie[id] = serie;
                return true;
            }
        }

        public bool Exclui(int id)
        {
            if (id > listaSerie.Count)
            {
                return false;
            }
            else
            {
                listaSerie[id].Excluir();
                return true;
            }
        }

        public void Insere(Serie serie)
        {
            listaSerie.Add(serie);
        }

        public List<Serie> Lista()
        {
            return listaSerie;    
         
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            if(id > listaSerie.Count)
            {
                throw new Exception();
            }

           return listaSerie[id];
        }
    }
}
