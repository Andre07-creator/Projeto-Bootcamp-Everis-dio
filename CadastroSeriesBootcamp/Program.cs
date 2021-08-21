using System;
using CadastroSeriesBootcamp.Models;
using CadastroSeriesBootcamp.Enums;
namespace CadastroSeriesBootcamp
{
    class Program
    {
        static SeriesRepository repositorio = new SeriesRepository();
        static void Main(string[] args)
        {
			string opcaoUsuario = ObterOpcaoUsuario();
			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
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

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

		private static void DeleteSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Delete(indiceSerie);
		}

		private static void ViewSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaById(indiceSerie);

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

			Series atualizaSerie = new Series(indiceSerie,(Genre)inputGenre,
											  inputtitle, inputdescription,inputyear);

			repositorio.Update(indiceSerie, atualizaSerie);
		}

		private static void ListSeries()
		{
			Console.WriteLine("Listar séries");

			var list = repositorio.List();

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

			Series novaSerie = new Series(id: repositorio.NextId(),
										genre: (Genre)inputgenre,
										title: inputtitle,
										year: inputyear,
										description: inputdescription);

			repositorio.Insert(novaSerie);
		}

		private static string ObterOpcaoUsuario()
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

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
	}
}
