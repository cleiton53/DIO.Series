using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
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
                      AtualizarSerie();
                      break;
                  case "4":
                      ExcluirSerie();
                      break;
                  case "5":
                      VisualizarSerie();
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

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repository.List();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repository.NextId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repository.Insert(novaSerie);                            
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            int entradaGenero, entradaAno;
            string entradaTitulo, entradaDescricao;

            InserirDados(out entradaGenero, out entradaTitulo, out entradaAno, out entradaDescricao);

            Serie atualizaSerie = new Serie(id: indiceSerie,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);

            repository.Update(indiceSerie, atualizaSerie);
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repository.Delete(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repository.FindById(indiceSerie);

            Console.WriteLine(serie);
        }
        private static void InserirDados(out int entradaGenero, out string entradaTitulo, out int entradaAno, out string entradaDescricao)
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            entradaGenero = int.Parse(Console.ReadLine());
            Console.Write("Digite o titulo da série: ");
            entradaTitulo = Console.ReadLine();
            Console.Write("Digite o ano de inicio da série: ");
            entradaAno = int.Parse(Console.ReadLine());
            Console.Write("Digite a descrição da série: ");
            entradaDescricao = Console.ReadLine();
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
