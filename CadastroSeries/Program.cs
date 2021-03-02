using CadastroSeries.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroSeries
{
    class Program
    {
        static SerieRepositorio serieRepositorio = new SerieRepositorio();
        public static void Main(string[] args)
        {


            while (true)
            {
                Console.WriteLine("================== Cadastro de Séries ============================");
                Console.WriteLine("Selecione uma opção");
                Console.WriteLine("1-Inserir | 2-Atualizar | 3-Excluir | 4-Listar | 5-Visualizar série");

                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Inserir();
                        break;
                    case 2:
                        Atualizar();
                        break;
                    case 3:
                        Excluir();
                        break;
                    case 4:
                        Listar();
                        break;
                    case 5:
                        Visualizar();
                        break;
                    default:
                        break;
                }
            }
        }



        public static Serie CadastrarSerie(int id)
        {
            var generos = Enum.GetValues(typeof(Genero));
         
            Console.WriteLine("Gêneros: ");
            foreach (int i in generos)
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            
            Console.WriteLine("Digite o gênero da série:");
            int genero = int.Parse(Console.ReadLine());

            if (genero >= generos.Length || genero < 0)
            {
                throw new IndexOutOfRangeException("Gênero inválido");
            } 

            Console.WriteLine("Digite o título da série:");
            var titulo = Console.ReadLine();

            Console.WriteLine("Digite a sinopse da série: ");
            var sinopse = Console.ReadLine();

            Console.WriteLine("Digite a ano da série: ");
            var ano = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o diretor da série: ");
            var diretor = Console.ReadLine();

            int idSerie;

            if (id == -1)
            {
               idSerie = serieRepositorio.ProximoId();
            } else
            {
                idSerie = id;
            }

            Serie serie = new Serie(idSerie, (Genero)genero, titulo, sinopse, ano, diretor);

            return serie;
        }

        public static void Inserir()
        {
            Serie serie = CadastrarSerie(-1);

            serieRepositorio.Insere(serie);

            Console.WriteLine("Série cadastrada");
        }
        public static void Atualizar()
        {
            Console.WriteLine("Digite o id da série: ");
            var id = int.Parse(Console.ReadLine());

            Serie serie = CadastrarSerie(id);

           

            if (serieRepositorio.Atualiza(id, serie))
            {
                Console.WriteLine("Série atualizada");

            }
            else
            {
                Console.WriteLine("Id inexistente");

            }

        }

        public static void Excluir()
        {
            Console.WriteLine("Digite o id da série: ");
            var id = int.Parse(Console.ReadLine());

            

            if(serieRepositorio.Exclui(id))
            {
                Console.WriteLine("Série excluída");
                
            } else
            {
                Console.WriteLine("Id inexistente");

            }
        }

        public static void Listar()
        {
            List<Serie> listaSerie = new List<Serie>();

            listaSerie = serieRepositorio.Lista();

            if (listaSerie.Count == 0)
            {
                Console.WriteLine("Lista vazia, cadastre uma série");
            }
            else
            {

                listaSerie.ForEach(serie => 
                    Console.WriteLine("{0} - {1}", serie.RetornaId(), serie.RetornaTitutlo()));
            }


        }

        public static void Visualizar()
        {
            Console.WriteLine("Digite o id da série que você quer visualizar: ");
            var id = int.Parse(Console.ReadLine());

            try
            {
                Serie serie = serieRepositorio.RetornaPorId(id);
                Console.WriteLine(serie);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
           

   

        }

    }
}
