using System.Security.AccessControl;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata;
using System.Net.Http.Headers;
using System.Collections.Concurrent;
using System.Runtime.Serialization;
using System.Reflection.Emit;
using System.Data;
using System;

namespace Dio.Series.Classes
{
    class Program 
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                       // AtualizarSerie();
                        break;
                    case "4":
                        //ExcluirSerie();
                        break;
                    case "5":
                        //VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();

                }

                opcaoUsuario = ObterOpcaoUsuario();
                
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.ReadLine();
                        
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries:");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                ConsoleWriteLine("Nenhuma série cadastrada!");
                return;
            }
            foreach (var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1}",serie.retornaId(), serie.retornaTitulo());
                
            }
        }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova serie:");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}",i, Enum.GetName(typeof(Genero),i));
                                
            }
            Console.Write("Digite o gênero dentre as opções: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.Write("Digite um Título: ");
            string entradaTitulo = Console.ReadLine("");
            Console.Write("Digite o Ano de lançamento da série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.Write("Digite a descrição: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoRepositorio(), genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);
            
            repositorio.Insere(novaSerie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Você está na DIO.Serie!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar série");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            ConstraintCollection.WriteLine();
            return opcaoUsuario;

        }
    }
}
