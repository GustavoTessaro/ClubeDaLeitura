using System.Text.Json;

class Program
{
    static string nomeArquivo = "usuario.json";
    static void salvarUsuario(Usuario usuario)
    {
        string jsonString = JsonSerializer.Serialize(usuario, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("usuario.json", jsonString);
    }
    static Usuario lerUsuario()
    {
        if (File.Exists("usuario.json"))
        {
            string jsonString = File.ReadAllText("usuario.json");
            return JsonSerializer.Deserialize<Usuario>(jsonString) ?? new Usuario();
        }
        return new Usuario();
    }
    static int ObterEscolhaMenuPrincipal()
    {
        int opcao = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Clube da Leitura");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1 - Gerenciar Caixas de Revistas");
            Console.WriteLine("2 - Gerenciar Revistas");
            Console.WriteLine("3 - Gerenciar Amigos");
            Console.WriteLine("4 - Gerenciar Empréstimos");
            Console.WriteLine("S - Sair");
            Console.WriteLine("---------------------------------");
            Console.Write("> ");
            opcao = (int)char.GetNumericValue(Console.ReadKey(true).KeyChar);
        } while (opcao != 1 && opcao != 2 && opcao != 3 && opcao != 4 && opcao != 5);

        return opcao;
    }
    static int ObterEscolhaMenuCaixas()
    {
        int opcao = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Gestão de Caixas");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1 - Cadastrar caixa");
            Console.WriteLine("2 - Editar caixa");
            Console.WriteLine("3 - Excluir caixa");
            Console.WriteLine("4 - Visualizar caixas");
            Console.WriteLine("5 - Voltar para o início");
            Console.WriteLine("---------------------------------");
            Console.Write("> ");
            opcao = (int)char.GetNumericValue(Console.ReadKey(true).KeyChar);
        } while (opcao != 1 && opcao != 2 && opcao != 3 && opcao != 4 && opcao != 5);

        return opcao;
    }
    static int ObterEscolhaMenuRevistas()
    {
        int opcao = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Gestão de Revistas");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1 - Cadastrar Revista");
            Console.WriteLine("2 - Editar Revista");
            Console.WriteLine("3 - Excluir Revista");
            Console.WriteLine("4 - Visualizar Revista");
            Console.WriteLine("5 - Voltar para o início");
            Console.WriteLine("---------------------------------");
            Console.Write("> ");
            opcao = (int)char.GetNumericValue(Console.ReadKey(true).KeyChar);
        } while (opcao != 1 && opcao != 2 && opcao != 3 && opcao != 4 && opcao != 5);

        return opcao;
    }
    static void Main(string[] args)
    {
        Usuario usuario = lerUsuario();

        string nome = "";
        string senha = "";

        do
        {
            Console.Write("Digite o nome do Usuario: ");
            nome = Console.ReadLine() ?? "";
            Console.Write("\nDigite a senha do Usuario: ");
            senha = Console.ReadLine() ?? "";
        } while (usuario.GetNome() != nome && usuario.GetSenha() != senha);

        int opcao = 0;

        do
        {
            opcao = ObterEscolhaMenuPrincipal();

            switch (opcao)
            {
                case 1:
                    #region Gestão de Caixas

                    int opcaoCaixas = 0;
                    bool verificaCaixas = false;

                    do
                    {
                        opcaoCaixas = ObterEscolhaMenuCaixas();

                        switch (opcaoCaixas)
                        {
                            case 1:
                                verificaCaixas = usuario.CadastrarCaixa();
                                if (verificaCaixas == true)
                                {
                                    salvarUsuario(usuario);
                                }
                                break;
                            case 2:
                                verificaCaixas = usuario.EditarCaixa();
                                if (verificaCaixas == true)
                                {
                                    salvarUsuario(usuario);
                                }
                                break;
                            case 3:
                                verificaCaixas = usuario.ExcluirCaixa();
                                if (verificaCaixas == true)
                                {
                                    salvarUsuario(usuario);
                                }
                                break;
                            case 4:
                                usuario.MostrarCaixasCadastradas();
                                break;
                            case 5:
                                Console.WriteLine("Voltando...");
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                break;
                        }

                    } while (opcaoCaixas != 5);

                    #endregion
                    break;
                case 2:
                    #region Gestão de Revistas

                    int opcaoRevistas = 0;
                    bool verificaRevistas = false;

                    do
                    {
                        opcaoRevistas = ObterEscolhaMenuRevistas();

                        switch (opcaoRevistas)
                        {
                            case 1:
                                verificaRevistas = usuario.CadastrarRevista();
                                if (verificaRevistas == true)
                                {
                                    salvarUsuario(usuario);
                                }
                                break;
                            case 2:
                                verificaRevistas = usuario.EditarRevista();
                                if (verificaRevistas == true)
                                {
                                    salvarUsuario(usuario);
                                }
                                break;
                            case 3:
                                verificaRevistas = usuario.ExcluirCaixa();
                                if (verificaRevistas == true)
                                {
                                    salvarUsuario(usuario);
                                }
                                break;
                            case 4:
                                usuario.MostrarCaixasCadastradas();
                                break;
                            case 5:
                                Console.WriteLine("Voltando...");
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                break;
                        }

                    } while (opcaoRevistas != 5);

                    #endregion
                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:
                    Console.WriteLine("Fechando o Programa...");
                    Thread.Sleep(3000);
                    while (Console.KeyAvailable) Console.ReadKey(true);
                    Console.Clear();
                    break;
            }
        } while (opcao != 5);

    }

}