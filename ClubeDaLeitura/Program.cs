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
            Console.WriteLine("5 - Gerenciar Multas");
            Console.WriteLine("6 - Gerenciar Reservas");
            Console.WriteLine("7 - Sair");
            Console.WriteLine("---------------------------------");
            Console.Write("> ");
            opcao = (int)char.GetNumericValue(Console.ReadKey(true).KeyChar);
        } while (opcao != 1 && opcao != 2 && opcao != 3 && opcao != 4 && opcao != 5 && opcao != 6 && opcao != 7);

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
            Console.WriteLine("4 - Visualizar Revistas");
            Console.WriteLine("5 - Voltar para o início");
            Console.WriteLine("---------------------------------");
            Console.Write("> ");
            opcao = (int)char.GetNumericValue(Console.ReadKey(true).KeyChar);
        } while (opcao != 1 && opcao != 2 && opcao != 3 && opcao != 4 && opcao != 5);

        return opcao;
    }
    static int ObterEscolhaMenuAmigos()
    {
        int opcao = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Gestão de Amigos");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1 - Cadastrar Amigo");
            Console.WriteLine("2 - Editar Amigo");
            Console.WriteLine("3 - Excluir Amigo");
            Console.WriteLine("4 - Visualizar Amigos");
            Console.WriteLine("5 - Voltar para o início");
            Console.WriteLine("---------------------------------");
            Console.Write("> ");
            opcao = (int)char.GetNumericValue(Console.ReadKey(true).KeyChar);
        } while (opcao != 1 && opcao != 2 && opcao != 3 && opcao != 4 && opcao != 5);

        return opcao;
    }
    static int ObterEscolhaMenuEmprestimos()
    {
        int opcao = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Gestão de Empréstimos");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1 - Cadastrar Empréstimo");
            Console.WriteLine("2 - Cadastrar Devolução");
            Console.WriteLine("3 - Visualizar Empréstimos");
            Console.WriteLine("4 - Voltar para o início");
            Console.WriteLine("---------------------------------");
            Console.Write("> ");
            opcao = (int)char.GetNumericValue(Console.ReadKey(true).KeyChar);
        } while (opcao != 1 && opcao != 2 && opcao != 3 && opcao != 4);

        return opcao;
    }
    static int ObterEscolhaMenuMultas()
    {
        int opcao = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Gestão de Multas");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1 - Visualizar Multas em Aberto");
            Console.WriteLine("2 - Quitar uma Multa");
            Console.WriteLine("3 - Visualizar Multas de um Amigo");
            Console.WriteLine("4 - Voltar para o início");
            Console.WriteLine("---------------------------------");
            Console.Write("> ");
            opcao = (int)char.GetNumericValue(Console.ReadKey(true).KeyChar);
        } while (opcao != 1 && opcao != 2 && opcao != 3 && opcao != 4);

        return opcao;
    }
    static int ObterEscolhaMenuReservas()
    {
        int opcao = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Gestão de Reservas");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1 - Criar nova Reserva");
            Console.WriteLine("2 - Cancelar uma Reserva");
            Console.WriteLine("3 - Visualizar Reservas Ativas");
            Console.WriteLine("4 - Retirar Reserva");
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

        bool verificaEmprestimos = usuario.VerificarEmprestimos();

        if (verificaEmprestimos == true)
        {
            salvarUsuario(usuario);
        }

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
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                break;
                            case 2:
                                verificaCaixas = usuario.EditarCaixa();
                                if (verificaCaixas == true)
                                {
                                    salvarUsuario(usuario);
                                }
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                break;
                            case 3:
                                verificaCaixas = usuario.ExcluirCaixa();
                                if (verificaCaixas == true)
                                {
                                    salvarUsuario(usuario);
                                }
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                break;
                            case 4:
                                usuario.MostrarCaixasCadastradas();
                                Console.WriteLine("\nPrecione ENTER para continuar");
                                Console.ReadLine();
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
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                break;
                            case 2:
                                verificaRevistas = usuario.EditarRevista();
                                if (verificaRevistas == true)
                                {
                                    salvarUsuario(usuario);
                                }
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                break;
                            case 3:
                                verificaRevistas = usuario.ExcluirRevista();
                                if (verificaRevistas == true)
                                {
                                    salvarUsuario(usuario);
                                }
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                break;
                            case 4:
                                usuario.MostrarRevistasCadastradas();
                                Console.WriteLine("\nPrecione ENTER para continuar");
                                Console.ReadLine();
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
                    #region Gestão de Amigos

                    int opcaoAmigos = 0;
                    bool verificaAmigos = false;

                    do
                    {
                        opcaoAmigos = ObterEscolhaMenuAmigos();

                        switch (opcaoAmigos)
                        {
                            case 1:
                                verificaAmigos = usuario.CadastrarAmigo();
                                if (verificaAmigos == true)
                                {
                                    salvarUsuario(usuario);
                                }
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                break;
                            case 2:
                                verificaAmigos = usuario.EditarAmigo();
                                if (verificaAmigos == true)
                                {
                                    salvarUsuario(usuario);
                                }
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                break;
                            case 3:
                                verificaAmigos = usuario.ExcluirAmigo();
                                if (verificaAmigos == true)
                                {
                                    salvarUsuario(usuario);
                                }
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                break;
                            case 4:
                                usuario.MostrarAmigosCadastrados();
                                Console.WriteLine("\nPrecione ENTER para continuar");
                                Console.ReadLine();
                                break;
                            case 5:
                                Console.WriteLine("Voltando...");
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                break;
                        }

                    } while (opcaoAmigos != 5);

                    #endregion
                    break;
                case 4:
                    #region Gestão de Emprestimos

                    int opcaoEmprestimo = 0;
                    bool verificaEmprestimo = false;

                    do
                    {
                        opcaoEmprestimo = ObterEscolhaMenuEmprestimos();

                        switch (opcaoEmprestimo)
                        {
                            case 1:
                                verificaEmprestimo = usuario.CadastrarEmprestimo();
                                if (verificaEmprestimo == true)
                                {
                                    salvarUsuario(usuario);
                                }
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                break;
                            case 2:
                                verificaEmprestimo = usuario.CadastrarDevolucao();
                                if (verificaEmprestimo == true)
                                {
                                    salvarUsuario(usuario);
                                }
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                break;
                            case 3:
                                usuario.MostrarEmprestimosCadastrados();
                                Console.WriteLine("\nPrecione ENTER para continuar");
                                Console.ReadLine();
                                break;
                            case 4:
                                Console.WriteLine("Voltando...");
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                break;
                        }

                    } while (opcaoEmprestimo != 4);

                    #endregion
                    break;
                case 5:
                    #region Gestão de Multas
                    int opcaoMulta = 0;
                    bool verificaMulta = false;

                    do
                    {
                        opcaoMulta = ObterEscolhaMenuMultas();

                        switch (opcaoMulta)
                        {
                            case 1:
                                usuario.MostrarMultasEmAberto();
                                Console.WriteLine("\nPrecione ENTER para continuar");
                                Console.ReadLine();
                                break;
                            case 2:
                                verificaMulta = usuario.QuitarUmaMulta();
                                if (verificaMulta == true)
                                {
                                    salvarUsuario(usuario);
                                }
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                break;
                            case 3:
                                usuario.MostrarMultasDeUmAmigo();
                                Console.WriteLine("\nPrecione ENTER para continuar");
                                Console.ReadLine();
                                break;
                            case 4:
                                Console.WriteLine("Voltando...");
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                break;
                        }

                    } while (opcaoMulta != 4);
                    #endregion
                    break;
                case 6:
                    #region Gestão de Reservas

                    int opcaoReserva = 0;
                    bool verificaReserva = false;

                    do
                    {
                        opcaoReserva = ObterEscolhaMenuReservas();

                        switch (opcaoReserva)
                        {
                            case 1:
                                verificaReserva = usuario.CriarReserva();
                                if (verificaReserva == true)
                                {
                                    salvarUsuario(usuario);
                                }
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                break;
                            case 2:
                                verificaReserva = usuario.CancelarReserva();
                                if (verificaReserva == true)
                                {
                                    salvarUsuario(usuario);
                                }
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                break;
                            case 3:
                                usuario.MostrarReservas();
                                Console.WriteLine("\nPrecione ENTER para continuar");
                                Console.ReadLine();
                                break;
                            case 4:
                                verificaReserva = usuario.RetirarReserva();
                                if (verificaReserva == true)
                                {
                                    salvarUsuario(usuario);
                                }
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                break;
                            case 5:
                                Console.WriteLine("Voltando...");
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                break;
                        }

                    } while (opcaoReserva != 5);

                    #endregion
                    break;
                case 7:
                    Console.WriteLine("Fechando o Programa...");
                    Thread.Sleep(3000);
                    while (Console.KeyAvailable) Console.ReadKey(true);
                    Console.Clear();
                    break;
            }
        } while (opcao != 7);

    }

}