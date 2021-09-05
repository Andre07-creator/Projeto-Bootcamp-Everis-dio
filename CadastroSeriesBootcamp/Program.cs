using System;
using CadastroSeriesBootcamp.Models;
using CadastroSeriesBootcamp.Enums;
namespace CadastroSeriesBootcamp
{
    class Program
    {
        static SeriesRepository repositoryserie = new SeriesRepository();
        static MovieRepository repositorymovie = new MovieRepository();
        static void Main(string[] args)
        {
            string answer;
            //Loop que faz o programa voltar na escolha de filmes e series
            do
            {
                Console.WriteLine("DIO Stream a seu dispor!!!\n");
                Console.WriteLine("O que você quer ver hoje:\n");
                Console.WriteLine("[1] Series \n[2] Movies \n[3] Sair");
                int Choice = int.Parse(Console.ReadLine());

                /// Referente a opção de SERIES
                if (Choice == 1)
                {
                    string Useroption = GetUser1();
                    while (Useroption.ToUpper() != "X")
                    {
                        switch (Useroption)
                        {
                            case "1":
                                ListSeries();
                                break;
                            case "2":
                                InsertSerie();
                                break;
                            case "3":
                                UpdateSerie();
                                break;
                            case "4":
                                DeleteSerie();
                                break;
                            case "5":
                                ViewSerie();
                                break;
                            case "C":
                                Console.Clear();
                                break;

                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        Useroption = GetUser1();
                    }
                }
                /// Referente a opçao de FILMES
                else if (Choice == 2)
                {
                    string Useroption = GetUser2();
                    while (Useroption.ToUpper() != "X")
                    {
                        switch (Useroption)
                        {
                            case "1":
                                ListMovies();
                                break;
                            case "2":
                                InsertMovie();
                                break;
                            case "3":
                                UpdateMovie();
                                break;
                            case "4":
                                DeleteMovie();
                                break;
                            case "5":
                                ViewMovie();
                                break;
                            case "C":
                                Console.Clear();
                                break;

                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        Useroption = GetUser2();
                    }
                }
                //Referente a opção de SAIR
                else if(Choice == 3)
                {
                    Console.Clear();
                    break;
                }
                Console.Write("Deseja voltar ao menu inicial ?(s/n)");
                answer = Console.ReadLine();
                Console.Clear();
            } while (answer.ToUpper() == "S");
            Console.WriteLine();
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();

        }


        /// CRUD das series
        private static void DeleteSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositoryserie.Delete(indiceSerie);
        }

        private static void ViewSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositoryserie.ReturnById(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void UpdateSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int inputGenre = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string inputtitle = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int inputyear = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string inputdescription = Console.ReadLine();

            Series atualizaSerie = new Series(indiceSerie, (Genre)inputGenre,
                                              inputtitle, inputdescription, inputyear);

            repositoryserie.Update(indiceSerie, atualizaSerie);
        }

        private static void ListSeries()
        {
            Console.WriteLine("Listar séries");

            var list = repositoryserie.List();

            if (list.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in list)
            {
                var deleted = serie.retornaDeleted();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitle(), (deleted ? "*Excluído*" : ""));
            }
        }

        private static void InsertSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int inputgenre = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string inputtitle = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int inputyear = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string inputdescription = Console.ReadLine();

            Series novaSerie = new Series(id: repositoryserie.NextId(),
                                        genre: (Genre)inputgenre,
                                        title: inputtitle,
                                        year: inputyear,
                                        description: inputdescription);

            repositoryserie.Insert(novaSerie);
        }
        /// CRUD dos Filmes
        private static void ListMovies()
        {
            Console.WriteLine("Listar Filmes");

            var list = repositorymovie.List();

            if (list.Count == 0)
            {
                Console.WriteLine("Nenhuma Filme cadastrado.");
                return;
            }

            foreach (var movie in list)
            {
                var deleted = movie.retornaDeleted();

                Console.WriteLine("#ID {0}: - {1} {2}", movie.retornaId(), movie.retornaTitle(), (deleted ? "*Excluído*" : ""));
            }
        }
        private static void InsertMovie()
        {
            Console.WriteLine("Inserir novo Filme");

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int inputgenre = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Filme: ");
            string inputtitle = Console.ReadLine();

            Console.Write("Digite o Ano de lançamento do Filme: ");
            int inputyear = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Filme: ");
            string inputdescription = Console.ReadLine();

            Movie NewMovie = new Movie(id: repositoryserie.NextId(),
                                        genre: (Genre)inputgenre,
                                        title: inputtitle,
                                        year: inputyear,
                                        description: inputdescription);

            repositorymovie.Insert(NewMovie);
        }
        private static void ViewMovie()
        {
            Console.Write("Digite o id do Filme: ");
            int indicemovie = int.Parse(Console.ReadLine());

            var movie = repositorymovie.ReturnById(indicemovie);

            Console.WriteLine(movie);
        }
        private static void UpdateMovie()
        {
            Console.Write("Digite o id do Filme: ");
            int indicemovie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int inputGenre = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Filme: ");
            string inputtitle = Console.ReadLine();

            Console.Write("Digite o Ano de Lançamento do Filme: ");
            int inputyear = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Filme: ");
            string inputdescription = Console.ReadLine();

            Movie Updatemovie = new Movie(indicemovie, inputtitle, (Genre)inputGenre,
                                               inputdescription, inputyear);

            repositorymovie.Update(indicemovie, Updatemovie);
        }
        private static void DeleteMovie()
        {
            Console.Write("Digite o id do Filme: ");
            int indiceMovie = int.Parse(Console.ReadLine());

            repositorymovie.Delete(indiceMovie);
        }
        ///Cadeia de string referente a opção de SERIES
        private static string GetUser1()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string useroption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return useroption;
        }
        ///Cadeia de String referente a opção de FILMES
        private static string GetUser2()
        {

            Console.WriteLine();
            Console.WriteLine("DIO Filmes a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar Filmes");
            Console.WriteLine("2- Inserir novo Filme");
            Console.WriteLine("3- Atualizar Filme");
            Console.WriteLine("4- Excluir Filme");
            Console.WriteLine("5- Visualizar Filme");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string useroption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return useroption;
        }
    }
}
