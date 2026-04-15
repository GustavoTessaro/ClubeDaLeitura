class Usuario
{

    private string nome;
    private string senha;
    private List<Caixa> caixas;

    private List<Amigo> amigos;
    private List<Emprestimo> emprestimos;

    #region Construtores
    public Usuario()
    {
        this.nome = "Gustavo";
        this.senha = "1234";
        this.caixas = new List<Caixa>();

        this.amigos = new List<Amigo>();
        this.emprestimos = new List<Emprestimo>();
    }

    #endregion

    #region Getters e Setters

    public string GetNome()
    {
        return this.nome;
    }

    public void SetNome(string nome)
    {
        this.nome = nome;
    }

    public string GetSenha()
    {
        return this.senha;
    }

    public void SetSenha(string senha)
    {
        this.senha = senha;
    }

    public List<Caixa> GetCaixas()
    {
        return this.caixas;
    }

    public void SetCaixas(List<Caixa> caixas)
    {
        this.caixas = caixas;
    }

    public List<Amigo> GetAmigos()
    {
        return this.amigos;
    }

    public void SetAmigos(List<Amigo> amigos)
    {
        this.amigos = amigos;
    }

    public List<Emprestimo> GetEmprestimos()
    {
        return this.emprestimos;
    }

    public void SetEmprestimos(List<Emprestimo> emprestimos)
    {
        this.emprestimos = emprestimos;
    }

    #endregion

    #region Serializable

    public string Nome_JSON { get => GetNome(); set => SetNome(value); }
    public string Senha_JSON { get => GetSenha(); set => SetSenha(value); }
    public List<Caixa> Caixas_JSON { get => GetCaixas(); set => SetCaixas(value); }
    public List<Amigo> Amigos_JSON { get => GetAmigos(); set => SetAmigos(value); }
    public List<Emprestimo> Emprestimos_JSON { get => GetEmprestimos(); set => SetEmprestimos(value); }

    #endregion

    #region Métodos Caixa

    public string EscolherCor(string nome)
    {

        int opcao = 0;

        do
        {
            Console.Clear();
            Console.WriteLine($"Escolha uma opção de cor para a caixa {nome}: ");
            Console.WriteLine("1 - Branco   2 - Cinza");
            Console.WriteLine("3 - Vermelho 4 - Azul");
            Console.WriteLine("5 - Verde    6 - Amarelo");
            Console.WriteLine("7 - Ciano    8 - Magenta/Roxo-claro");
            opcao = (int)char.GetNumericValue(Console.ReadKey(true).KeyChar);

        } while (opcao != 1 && opcao != 2 && opcao != 3 && opcao != 4 && opcao != 5 && opcao != 6 && opcao != 7 && opcao != 8);

        if (opcao == 1)
        {
            return "white";
        }
        else if (opcao == 2)
        {
            return "gray";
        }
        else if (opcao == 3)
        {
            return "red";
        }
        else if (opcao == 4)
        {
            return "blue";
        }
        else if (opcao == 5)
        {
            return "green";
        }
        else if (opcao == 6)
        {
            return "yellow";
        }
        else if (opcao == 7)
        {
            return "cyan";
        }
        else if (opcao == 8)
        {
            return "magenta";
        }

        return "white";

    }
    public int EscolherEditarCaixa()
    {

        int opcao = 0;

        do
        {
            Console.WriteLine("Digite uma Opção para Editar: ");
            Console.WriteLine("1 - Editar Etiqueta");
            Console.WriteLine("2 - Editar Cor");
            Console.WriteLine("3 - Editar Dias de Emprestimo");
            Console.WriteLine("4 - Editar Tudo");
            Console.WriteLine("5 - Voltar");
            opcao = (int)char.GetNumericValue(Console.ReadKey(true).KeyChar);
        } while (opcao != 1 && opcao != 2 && opcao != 3 && opcao != 4 && opcao != 5);

        return opcao;
    }
    public bool CadastrarCaixa()
    {

        string Etiqueta = "";
        string Cor = "";
        int DiasDeEmprestimo = 0;

        try
        {
            Console.Write("Digite a Etiqueta da Caixa: ");
            Etiqueta = Console.ReadLine();
            Cor = EscolherCor(Etiqueta);
            Console.Clear();
            Console.Write("Digite o número de dias de emprestimo: ");
            DiasDeEmprestimo = int.Parse(Console.ReadLine());
        }
        catch (System.Exception)
        {
            Console.WriteLine("Erro, verifique se os parêmetros foram passados corretamente!");
            return false;
        }

        Caixa caixa = new Caixa(Etiqueta, Cor, DiasDeEmprestimo);

        caixas.Add(caixa);
        Console.WriteLine("Caixa cadastrada com sucesso!");

        return true;

    }
    public bool MostrarCaixasCadastradas()
    {
        if (caixas.Count == 0)
        {
            Console.WriteLine("Nenhum equipamento cadastrado.");
            return false;
        }
        else
        {
            Console.WriteLine("Caixas cadastradas:");
            foreach (var caixa in caixas)
            {
                Console.WriteLine($"Caixa: {caixa.GetEtiquetaComCor}, Dias de Emprestimo: {caixa.GetDiasEmprestimo}");
            }
            return true;
        }
    }

    public bool ExcluirCaixa()
    {
        bool verificaLista = MostrarCaixasCadastradas();

        if (verificaLista == false)
        {
            return false;
        }

        string selecionarCaixa = "";
        bool verifica = false;

        Console.Write("Digite a Etiqueta da Caixa que deseja Excluir: ");
        selecionarCaixa = Console.ReadLine() ?? "";

        if (selecionarCaixa != "")
        {
            foreach (var caixa in caixas.ToList())
            {
                if (selecionarCaixa.ToLower() == caixa.GetEtiqueta().ToLower())
                {
                    if (caixa.GetRevistas().Count == 0)
                    {
                        Console.Write("Tem certeza que deseja excluir a caixa " + caixa.GetEtiquetaComCor + " (S/N)?");
                        char resposta = char.ToUpper(Console.ReadKey(true).KeyChar);

                        if (resposta == 'S')
                        {
                            caixas.Remove(caixa);
                            Console.WriteLine("Caixa removido com sucesso!");
                            Thread.Sleep(3000);
                            while (Console.KeyAvailable) Console.ReadKey(true);
                            Console.Clear();
                            verifica = true;
                        }
                        else
                        {
                            Console.WriteLine("Operação Cancelada...");
                            Thread.Sleep(3000);
                            while (Console.KeyAvailable) Console.ReadKey(true);
                            Console.Clear();
                            verifica = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Você não pode remover uma caixa sem antes REMOVER as revistas que estão nelas!");
                        Thread.Sleep(3000);
                        while (Console.KeyAvailable) Console.ReadKey(true);
                        Console.Clear();
                        verifica = false;
                    }
                }
                else
                {
                    Console.WriteLine("Etiqueta não encontrada, tente novamente!");
                    verifica = false;
                }
            }
            return verifica;
        }
        else
        {
            Console.WriteLine("Nome da Etiqueta Vazia, por favor tente novamente!");
            return verifica;
        }
    }
    public bool EditarCaixa()
    {
        bool verificaLista = MostrarCaixasCadastradas();

        if (verificaLista == false)
        {
            return false;
        }

        string selecionarCaixa = "";
        bool verifica = false;

        Console.Write("Digite a Etiqueta da Caixa que deseja Editar: ");
        selecionarCaixa = Console.ReadLine() ?? "";

        if (selecionarCaixa != "")
        {
            foreach (var caixa in caixas.ToList())
            {
                if (selecionarCaixa.ToLower() == caixa.GetEtiqueta().ToLower())
                {
                    int opcao = EscolherEditarCaixa();

                    try
                    {
                        switch (opcao)
                        {
                            case 1:
                                string etiqueta = "";
                                Console.WriteLine("Digite um novo nome para a Etiqueta: ");
                                etiqueta = Console.ReadLine() ?? "";
                                if (etiqueta != "")
                                {
                                    caixa.SetEtiqueta(etiqueta);
                                    verifica = true;
                                }
                                break;
                            case 2:
                                string cor = EscolherCor(caixa.GetEtiquetaComCor());
                                caixa.SetCor(cor);
                                verifica = true;
                                break;
                            case 3:
                                Console.Write("Digite o novo número de dias de emprestimo: ");
                                int diasDeEmprestimo = int.Parse(Console.ReadLine());
                                if (diasDeEmprestimo > 0)
                                {
                                    caixa.SetDiasEmprestimo(diasDeEmprestimo);
                                    verifica = true;
                                }
                                break;
                            case 4:
                                string etiquetaNova = "";
                                Console.WriteLine("Digite um novo nome para a Etiqueta: ");
                                etiquetaNova = Console.ReadLine() ?? "";
                                string corNova = EscolherCor(caixa.GetEtiquetaComCor());
                                Console.Write("Digite o novo número de dias de emprestimo: ");
                                int diasDeEmprestimoNovo = int.Parse(Console.ReadLine());

                                if (etiquetaNova != "" && diasDeEmprestimoNovo > 0)
                                {
                                    caixa.SetEtiqueta(etiquetaNova);
                                    caixa.SetCor(corNova);
                                    caixa.SetDiasEmprestimo(diasDeEmprestimoNovo);
                                    verifica = true;
                                }
                                break;
                            case 5:
                                Console.WriteLine("Voltando...");
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                verifica = false;
                                break;
                        }
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Erro, verifique se os parêmetros foram passados corretamente!");
                        verifica = false;
                    }
                }
                else
                {
                    Console.WriteLine("Etiqueta não encontrada, tente novamente!");
                    verifica = false;
                }
            }
            return verifica;
        }
        else
        {
            Console.WriteLine("Nome da Etiqueta Vazia, por favor tente novamente!");
            return verifica;
        }
    }

    #endregion

}