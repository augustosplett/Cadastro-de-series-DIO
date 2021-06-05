using System;


namespace Teste
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
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        public static void VisualizarSerie()
        {
            Console.Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.Write(serie);
            Console.WriteLine();
        }
        private static void AtualizarSerie()
        {
            Console.Write("Digite o Id da Série:");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            ColetarDadosEGravar(indiceSerie, 2);
            
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série Cadastrada");
                return;
            }

            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                if(!excluido)
                {
                    Console.WriteLine("#ID {0}: -{1}", serie.retornaID(), serie.retornaTitulo());
                }
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("#ID {0}: -{1}", i, Enum.GetName(typeof(Genero), i));
            }
            int identificador = repositorio.ProximoId();
            ColetarDadosEGravar(identificador, 1);
        }

        private static void ColetarDadosEGravar(int id, int tipo)
        {
            Console.WriteLine("Digite o gênero entre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série:");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início da série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie serie = new Serie(id: id,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano:entradaAno,
                                    descricao: entradaDescricao);

            if(tipo == 1)
            {
                repositorio.Insere(serie);
            }else if(tipo == 2)
            {
                repositorio.Atualiza(id, serie);
            }
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Cadastro de Séries");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir Nova Série");
            Console.WriteLine("3 - Atualizar Série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
