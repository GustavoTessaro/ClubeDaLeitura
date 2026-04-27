using System.Text.Json.Serialization;

class Usuario
{

    private string nome;
    private string senha;
    private List<Caixa> caixas;
    private List<Amigo> amigos;
    private List<Emprestimo> emprestimos;
    private List<Multa> multas;

    #region Construtores
    public Usuario()
    {
        this.nome = "Gustavo";
        this.senha = "1234";
        this.caixas = new List<Caixa>();

        this.amigos = new List<Amigo>();
        this.emprestimos = new List<Emprestimo>();
        this.multas = new List<Multa>();
    }

    #endregion

    #region Getters e Setters

    public void setMulta(List<Multa> multas)
    {
        this.multas = multas;
    }
    public List<Multa> GetMultas()
    {
        return this.multas;
    }
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

    [JsonPropertyName("nome")]
    public string Nome_JSON { get => GetNome(); set => SetNome(value); }

    [JsonPropertyName("senha")]
    public string Senha_JSON { get => GetSenha(); set => SetSenha(value); }

    [JsonPropertyName("caixas")]
    public List<Caixa> Caixas_JSON { get => GetCaixas(); set => SetCaixas(value); }

    [JsonPropertyName("amigos")]
    public List<Amigo> Amigos_JSON { get => GetAmigos(); set => SetAmigos(value); }

    [JsonPropertyName("emprestimos")]
    public List<Emprestimo> Emprestimos_JSON { get => GetEmprestimos(); set => SetEmprestimos(value); }

    [JsonPropertyName("multas")]
    public List<Multa> Multas_JSON { get => GetMultas(); set => setMulta(value); }

    #endregion

    #region Métodos Caixa

    public bool verificarCaixasCadastradas()
    {
        if (caixas.Count == 0)
        {
            Console.WriteLine("Nenhuma caixa cadastrada.");
            return false;
        }
        else
        {
            return true;
        }
    }
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
    public bool ValidarTamanhoEtiqueta(string texto)
    {
        if (string.IsNullOrEmpty(texto))
        {
            return true;
        }

        if (texto.Length > 50)
        {
            return false;
        }

        return true;
    }
    public bool CadastrarCaixa()
    {

        string Etiqueta = "";
        string Cor = "";
        int DiasDeEmprestimo = 0;
        bool verificaString = false;

        try
        {
            Console.Write("Digite a Etiqueta da Caixa: ");
            Etiqueta = Console.ReadLine() ?? "";

            if (Etiqueta == "")
            {
                Console.WriteLine("Campo VAZIO, tente novamente!");
                return false;
            }

            verificaString = ValidarTamanhoEtiqueta(Etiqueta);

            if (verificaString == false)
            {
                Console.WriteLine("Tamanho da Etiqueta ultrapassou valor máximo de caracteres (50)! Tente Novamente.");
                return false;
            }

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

        if (caixas.Count != 0)
        {
            foreach (var caixaV in caixas)
            {
                if (caixaV.GetEtiqueta().ToLower() == Etiqueta.ToLower())
                {
                    Console.WriteLine("Caixa já cadastrada com o nome " + Etiqueta + " Por favor, tente novamente!");
                    return false;
                }
            }
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
            Console.WriteLine("Nenhuma caixa cadastrada.");
            return false;
        }
        else
        {
            Console.WriteLine("Caixas cadastradas:");
            foreach (var caixa in caixas)
            {
                Console.WriteLine($"Caixa: {caixa.GetEtiquetaComCor()}, Dias de Emprestimo: {caixa.GetDiasEmprestimo()}");
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

            bool CaixaEncontrada = false;

            foreach (var caixa in caixas.ToList())
            {
                if (selecionarCaixa.ToLower() == caixa.GetEtiqueta().ToLower())
                {
                    CaixaEncontrada = true;

                    if (caixa.GetRevistas().Count == 0)
                    {
                        Console.Write("Tem certeza que deseja excluir a caixa " + caixa.GetEtiquetaComCor() + " (S/N)?");
                        char resposta = char.ToUpper(Console.ReadKey(true).KeyChar);

                        if (resposta == 'S')
                        {
                            caixas.Remove(caixa);
                            Console.WriteLine("Caixa removido com sucesso!");
                            verifica = true;
                        }
                        else
                        {
                            Console.WriteLine("Operação Cancelada...");
                            verifica = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Você não pode remover uma caixa sem antes REMOVER as revistas que estão nelas!");
                        verifica = false;
                    }
                }
            }

            if (CaixaEncontrada == false)
            {
                Console.WriteLine("Etiqueta não encontrada, tente novamente!");
                verifica = false;
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
            bool caixaEncontrada = false;

            foreach (var caixa in caixas.ToList())
            {
                if (selecionarCaixa.ToLower() == caixa.GetEtiqueta().ToLower())
                {
                    caixaEncontrada = true;
                    int opcao = EscolherEditarCaixa();

                    try
                    {
                        switch (opcao)
                        {
                            case 1:
                                string etiqueta = "";
                                bool verificaString = false;

                                Console.WriteLine("Digite um novo nome para a Etiqueta: ");
                                etiqueta = Console.ReadLine() ?? "";

                                verificaString = ValidarTamanhoEtiqueta(etiqueta);

                                if (verificaString == false)
                                {
                                    Console.WriteLine("Tamanho da Etiqueta ultrapassou valor máximo de caracteres (50)! Tente Novamente.");
                                    return false;
                                }

                                if (etiqueta != "")
                                {
                                    caixa.SetEtiqueta(etiqueta);
                                    verifica = true;
                                }
                                else
                                {
                                    Console.WriteLine("Campo VAZIO, tente novamente!");
                                    return false;
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
                                else
                                {
                                    Console.WriteLine("Dias de emprestimo deve ser maior que 0, tente novamente!");
                                    return false;
                                }
                                break;
                            case 4:
                                string etiquetaNova = "";
                                bool verificaStringNova = false;

                                Console.WriteLine("Digite um novo nome para a Etiqueta: ");
                                etiquetaNova = Console.ReadLine() ?? "";

                                verificaStringNova = ValidarTamanhoEtiqueta(etiquetaNova);

                                if (verificaStringNova == false)
                                {
                                    Console.WriteLine("Tamanho da Etiqueta ultrapassou valor máximo de caracteres (50)! Tente Novamente.");
                                    return false;
                                }

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
                                else
                                {
                                    Console.WriteLine("Campo Etiqueta VAZIA ou Dias de emprestimo menor igual a 0, tente novamente!");
                                    return false;
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
            }
            if (caixaEncontrada == false)
            {
                Console.WriteLine("Etiqueta não encontrada, tente novamente!");
                verifica = false;
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

    #region Métodos Revista
    public bool CadastrarRevista()
    {
        bool verificaLista = MostrarCaixasCadastradas();

        if (verificaLista == false)
        {
            return false;
        }

        string selecionarCaixa = "";
        bool verifica = false;

        Console.Write("Digite a Etiqueta da Caixa que deseja Cadastrar a Revista: ");
        selecionarCaixa = Console.ReadLine() ?? "";

        if (selecionarCaixa != "")
        {
            foreach (var caixa in caixas.ToList())
            {
                if (selecionarCaixa.ToLower() == caixa.GetEtiqueta().ToLower())
                {
                    verifica = caixa.CadastrarRevista();
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
    public bool MostrarRevistasCadastradas()
    {
        bool verificaLista = MostrarCaixasCadastradas();

        if (verificaLista == false)
        {
            return false;
        }

        string selecionarCaixa = "";
        bool verifica = false;

        Console.Write("Digite a Etiqueta da Caixa que deseja visualizar as Revistas: ");
        selecionarCaixa = Console.ReadLine() ?? "";

        if (selecionarCaixa != "")
        {
            foreach (var caixa in caixas.ToList())
            {
                if (selecionarCaixa.ToLower() == caixa.GetEtiqueta().ToLower())
                {
                    verifica = caixa.MostrarRevistasCadastradas();
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
    public bool EditarRevista()
    {
        bool verificaLista = MostrarCaixasCadastradas();

        if (verificaLista == false)
        {
            return false;
        }

        string selecionarCaixa = "";
        bool verifica = false;

        Console.Write("Digite a Etiqueta da Caixa que deseja Editar a Revista: ");
        selecionarCaixa = Console.ReadLine() ?? "";

        if (selecionarCaixa != "")
        {
            bool caixaEncontrada = false;

            foreach (var caixa in caixas.ToList())
            {
                if (selecionarCaixa.ToLower() == caixa.GetEtiqueta().ToLower())
                {
                    caixaEncontrada = true;
                    verifica = caixa.EditarRevista();
                }
            }
            if (caixaEncontrada == false)
            {
                Console.WriteLine("Etiqueta não encontrada, tente novamente!");
                verifica = false;
            }

            return verifica;
        }
        else
        {
            Console.WriteLine("Nome da Etiqueta Vazia, por favor tente novamente!");
            return verifica;
        }
    }
    public bool ExcluirRevista()
    {
        bool verificaLista = MostrarCaixasCadastradas();

        if (verificaLista == false)
        {
            return false;
        }

        string selecionarCaixa = "";
        bool verifica = false;

        Console.Write("Digite a Etiqueta da Caixa que deseja Excluir a Revista: ");
        selecionarCaixa = Console.ReadLine() ?? "";

        if (selecionarCaixa != "")
        {
            bool caixaEncontrada = false;

            foreach (var caixa in caixas.ToList())
            {
                if (selecionarCaixa.ToLower() == caixa.GetEtiqueta().ToLower())
                {
                    verifica = caixa.ExcluirRevista();
                }

            }

            if (caixaEncontrada == false)
            {
                Console.WriteLine("Etiqueta não encontrada, tente novamente!");
                verifica = false;
            }

            return verifica;
        }
        else
        {
            Console.WriteLine("Nome da Etiqueta Vazia, por favor tente novamente!");
            return verifica;
        }
    }
    public string MostrarTodasAsRevistasCadastradas(string amigo)
    {
        bool verificaLista = verificarCaixasCadastradas();

        if (verificaLista == false)
        {
            return "";
        }

        foreach (var caixa in caixas)
        {
            caixa.MostrarRevistasCadastradasSemMensagem();
        }

        Console.Write($"Digite o nome da revista que o amigo {amigo} fará o Empréstimo: ");
        string Revista = Console.ReadLine() ?? "";

        foreach (var emprestimo in emprestimos)
        {
            if (emprestimo.getAmigo().ToLower() == amigo.ToLower() && (emprestimo.getStatus() == "Aberto" || emprestimo.getStatus() == "Atrasado"))
            {
                Console.WriteLine($"Amigo {amigo} já tem um emprestimo cadastrado não devolvido");

                if (emprestimo.getStatus() == "Aberto")
                {
                    Console.WriteLine($"Amigo: {emprestimo.getAmigo}, Revista: {emprestimo.getRevista}, Data do Empréstimo: {emprestimo.getDataEmprestimo().ToString("dd/MM/yyyy")}, Data a ser Devolvida: {emprestimo.getDataDevolucao().ToString("dd/MM/yyyy")}, Status: {emprestimo.getStatus()}");
                }
                else
                {
                    if (emprestimo.getStatus() == "Atrasado")
                    {
                        Console.WriteLine($"Amigo: {emprestimo.getAmigo}, Revista: {emprestimo.getRevista}, Data do Empréstimo: {emprestimo.getDataEmprestimo().ToString("dd/MM/yyyy")}, Data que deveria ser Devolvida: {emprestimo.getDataDevolucao().ToString("dd/MM/yyyy")}, Dias em Atraso: {emprestimo.DiasEmAtraso()}, Status: {emprestimo.getStatus()}");
                    }
                }

                return "";
            }
        }

        return Revista;

    }

    #endregion

    #region Métodos Amigo

    public bool VerificarAmigos(string nome)
    {
        bool verifica = false;

        foreach (var amigo in amigos)
        {
            if (amigo.getNome().ToLower() == nome.ToLower())
            {
                verifica = true;
            }
        }
        return verifica;
    }

    public bool VerificarTelefoneExistente(string telefone)
    {
        bool verifica = false;

        foreach (var amigo in amigos)
        {
            if (amigo.getTelefone() == telefone)
            {
                verifica = true;
            }
        }
        return verifica;
    }
    public string VerificarTelefone(string telefone)
    {
        string apenasNumeros = System.Text.RegularExpressions.Regex.Replace(telefone ?? "", @"[^\d]", "");

        int tamanho = apenasNumeros.Length;

        if (tamanho == 10)
        {
            return long.Parse(apenasNumeros).ToString(@"(00) 0000-0000");
        }
        else if (tamanho == 11)
        {
            return long.Parse(apenasNumeros).ToString(@"(00) 0 0000-0000");
        }
        else
        {
            Console.WriteLine("Número de Telefone inválido (formato validado: 10-11 dígitos), tente novamente!");
            return "";
        }
    }
    public bool ValidarTamanhoNome(string texto)
    {
        if (string.IsNullOrEmpty(texto))
        {
            return false;
        }

        int tamanho = texto.Length;

        if (tamanho >= 3 && tamanho <= 100)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool MostrarAmigosCadastrados()
    {
        if (amigos.Count == 0)
        {
            Console.WriteLine("Nenhum amigo cadastrado.");
            return false;
        }
        else
        {
            Console.WriteLine("Amigos cadastrados:");
            foreach (var amigo in amigos)
            {
                Console.WriteLine($"Nome: {amigo.getNome()}, Nome do Responsável: {amigo.getNomeResponsavel()}, Telefone: {amigo.getTelefone()}");
            }
            return true;
        }
    }
    public bool ExcluirAmigo()
    {
        bool verificaLista = MostrarAmigosCadastrados();

        if (verificaLista == false)
        {
            return false;
        }

        string selecionarAmigo = "";
        bool verifica = false;

        Console.Write("Digite o nome do Amigo que deseja Excluir: ");
        selecionarAmigo = Console.ReadLine() ?? "";

        if (selecionarAmigo != "")
        {
            bool amigoEncontrado = false;

            foreach (var amigo in amigos.ToList())
            {
                if (selecionarAmigo.ToLower() == amigo.getNome().ToLower())
                {
                    amigoEncontrado = true;
                    bool verificaListaEmprestimo = false;

                    foreach (var emprestimo in emprestimos)
                    {
                        if (emprestimo.getAmigo().ToLower() == amigo.getNome().ToLower() && emprestimo.getStatus().ToLower() != "Concluído")
                        {
                            verificaListaEmprestimo = true;
                        }
                    }

                    if (verificaListaEmprestimo == false)
                    {
                        Console.Write("Tem certeza que deseja excluir o amigo " + amigo.getNome() + " (S/N)?");
                        char resposta = char.ToUpper(Console.ReadKey(true).KeyChar);

                        if (resposta == 'S')
                        {
                            amigos.Remove(amigo);
                            Console.WriteLine("Amigo removido com sucesso!");
                            verifica = true;
                        }
                        else
                        {
                            Console.WriteLine("Operação Cancelada...");
                            verifica = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Você não pode remover um Amigo sem antes REMOVER os empréstimos dele!");
                        verifica = false;
                    }
                }
            }

            if (amigoEncontrado == false)
            {
                Console.WriteLine("Amigo não encontrado, tente novamente!");
                verifica = false;
            }

            return verifica;
        }
        else
        {
            Console.WriteLine("Nome da Etiqueta Vazia, por favor tente novamente!");
            return verifica;
        }
    }
    public bool CadastrarAmigo()
    {
        string Nome = "";
        string NomeResponsavel = "";
        string Telefone = "";
        bool verificaNome = false;

        try
        {
            Console.Write("Digite o nome do Amigo: ");
            Nome = Console.ReadLine() ?? "";

            verificaNome = ValidarTamanhoNome(Nome);

            if (verificaNome == false)
            {
                Console.WriteLine("Tamanho do Nome do Amigo deve conter entre 3 à 100 caracteres! Tente Novamente.");
                return false;
            }

            verificaNome = VerificarAmigos(Nome);

            if (verificaNome == true)
            {
                Console.WriteLine("Amigo com o mesmo nome já Cadastrado! Tente Novamente.");
                return false;
            }

            Console.Write("Digite o nome do Responsavel do Amigo: ");
            NomeResponsavel = Console.ReadLine() ?? "";

            verificaNome = ValidarTamanhoNome(NomeResponsavel);

            if (verificaNome == false)
            {
                Console.WriteLine("Tamanho do Nome do Responsável deve conter entre 3 à 100 caracteres! Tente Novamente.");
                return false;
            }

            Console.Write("Digite o número de telefone do Amigo: ");
            Telefone = Console.ReadLine() ?? "";

            Telefone = VerificarTelefone(Telefone);

            bool verificaTelefoneExistente = false;

            verificaTelefoneExistente = VerificarTelefoneExistente(Telefone);

            if (verificaTelefoneExistente == true)
            {
                Console.WriteLine("Número de Telefone já cadastrado em outro Amigo, tente novamente!");
                return false;
            }

        }
        catch (System.Exception)
        {
            Console.WriteLine("Erro, verifique se os parêmetros foram passados corretamente!");
            return false;
        }

        if (amigos.Count != 0)
        {
            foreach (var amigoV in amigos)
            {
                if (amigoV.getNome().ToLower() == Nome.ToLower())
                {
                    Console.WriteLine("Amigo já cadastrado com o nome " + Nome + " Por favor, tente novamente!");
                    return false;
                }
            }
        }

        if (Nome != "" && NomeResponsavel != "" && Telefone != "")
        {
            Amigo amigo = new Amigo(Nome, NomeResponsavel, Telefone);

            amigos.Add(amigo);
            Console.WriteLine("Amigo cadastrado com sucesso!");

            return true;
        }
        else
        {
            Console.WriteLine("Nome dos campos Vazia, por favor tente novamente!");
            return false;
        }
    }
    public int EscolherEditarAmigo()
    {

        int opcao = 0;

        do
        {
            Console.WriteLine("Digite uma Opção para Editar: ");
            Console.WriteLine("1 - Editar Nome");
            Console.WriteLine("2 - Editar Nome Responsável");
            Console.WriteLine("3 - Editar Telefone");
            Console.WriteLine("4 - Editar Tudo");
            Console.WriteLine("5 - Voltar");
            opcao = (int)char.GetNumericValue(Console.ReadKey(true).KeyChar);
        } while (opcao != 1 && opcao != 2 && opcao != 3 && opcao != 4 && opcao != 5);

        return opcao;
    }
    public bool EditarAmigo()
    {
        bool verificaLista = MostrarAmigosCadastrados();

        if (verificaLista == false)
        {
            return false;
        }

        string selecionarAmigo = "";
        bool verifica = false;

        Console.Write("Digite o nome do amigo que deseja Editar: ");
        selecionarAmigo = Console.ReadLine() ?? "";

        if (selecionarAmigo != "")
        {
            bool amigoEncontrado = false;

            foreach (var amigo in amigos.ToList())
            {
                if (selecionarAmigo.ToLower() == amigo.getNome().ToLower())
                {
                    amigoEncontrado = true;
                    int opcao = EscolherEditarAmigo();

                    try
                    {
                        switch (opcao)
                        {
                            case 1:
                                string nome = "";
                                bool verificaNome = false;

                                Console.WriteLine("Digite um novo nome para o Amigo: ");
                                nome = Console.ReadLine() ?? "";

                                verificaNome = ValidarTamanhoNome(nome);

                                if (verificaNome == false)
                                {
                                    Console.WriteLine("Tamanho do Nome do Amigo deve conter entre 3 à 100 caracteres! Tente Novamente.");
                                    return false;
                                }

                                verificaNome = VerificarAmigos(nome);

                                if (verificaNome == true)
                                {
                                    Console.WriteLine("Amigo com o mesmo nome já Cadastrado! Tente Novamente.");
                                    return false;
                                }

                                if (nome != "")
                                {
                                    amigo.setNome(nome);

                                    if (emprestimos.Count != 0)
                                    {
                                        foreach (var emprestimo in emprestimos)
                                        {
                                            if (emprestimo.getAmigo().ToLower() == amigo.getNome().ToLower())
                                            {
                                                emprestimo.setAmigo(amigo.getNome());
                                            }
                                        }
                                    }

                                    verifica = true;
                                }
                                else
                                {
                                    Console.WriteLine("Nome do Amigo Vazia, por favor tente novamente!");
                                    verifica = false;
                                }
                                break;
                            case 2:
                                string NomeResponsavel = "";
                                bool verificaNomeNovo = false;

                                Console.WriteLine("Digite um novo nome do responsável para o Amigo: ");
                                NomeResponsavel = Console.ReadLine() ?? "";

                                verificaNomeNovo = ValidarTamanhoNome(NomeResponsavel);

                                if (verificaNomeNovo == false)
                                {
                                    Console.WriteLine("Tamanho do Nome do Responsável deve conter entre 3 à 100 caracteres! Tente Novamente.");
                                    return false;
                                }

                                if (NomeResponsavel != "")
                                {
                                    amigo.setNomeResponsavel(NomeResponsavel);

                                    verifica = true;
                                }
                                else
                                {
                                    Console.WriteLine("Nome do Amigo Vazia, por favor tente novamente!");
                                    verifica = false;
                                }
                                break;
                            case 3:
                                Console.Write("Digite o novo número de telefone do amigo: ");
                                string Telefone = Console.ReadLine();

                                Telefone = VerificarTelefone(Telefone);

                                if (Telefone != "")
                                {

                                    bool verificaTelefoneExistente = false;

                                    verificaTelefoneExistente = VerificarTelefoneExistente(Telefone);

                                    if (verificaTelefoneExistente == true)
                                    {
                                        Console.WriteLine("Número de Telefone já cadastrado em outro Amigo, tente novamente!");
                                        return false;
                                    }

                                    amigo.setTelefone(Telefone);

                                    verifica = false;
                                }
                                else
                                {
                                    Console.WriteLine("Telefone do Amigo Vazia, por favor tente novamente!");
                                    verifica = false;
                                }

                                break;
                            case 4:
                                string nomeNovo = "";
                                bool validacaoNome = false;

                                Console.WriteLine("Digite um novo nome para o Amigo: ");
                                nomeNovo = Console.ReadLine() ?? "";

                                validacaoNome = ValidarTamanhoNome(nomeNovo);

                                if (validacaoNome == false)
                                {
                                    Console.WriteLine("Tamanho do Nome do Amigo deve conter entre 3 à 100 caracteres! Tente Novamente.");
                                    return false;
                                }

                                validacaoNome = VerificarAmigos(nomeNovo);

                                if (validacaoNome == true)
                                {
                                    Console.WriteLine("Amigo com o mesmo nome já Cadastrado! Tente Novamente.");
                                    return false;
                                }

                                string NomeResponsavelNovo = "";
                                Console.WriteLine("Digite um novo nome do responsavel para o Amigo: ");
                                NomeResponsavelNovo = Console.ReadLine() ?? "";

                                validacaoNome = ValidarTamanhoNome(NomeResponsavelNovo);

                                if (validacaoNome == false)
                                {
                                    Console.WriteLine("Tamanho do Nome do Responsável deve conter entre 3 à 100 caracteres! Tente Novamente.");
                                    return false;
                                }

                                Console.Write("Digite o novo número de telefone do amigo: ");
                                string TelefoneNovo = Console.ReadLine() ?? "";

                                TelefoneNovo = VerificarTelefone(TelefoneNovo);

                                if (nomeNovo != "" && NomeResponsavelNovo != "" && TelefoneNovo != "")
                                {

                                    bool verificaTelefoneExistenteNovo = false;

                                    verificaTelefoneExistenteNovo = VerificarTelefoneExistente(TelefoneNovo);

                                    if (verificaTelefoneExistenteNovo == true)
                                    {
                                        Console.WriteLine("Número de Telefone já cadastrado em outro Amigo, tente novamente!");
                                        return false;
                                    }

                                    amigo.setNome(nomeNovo);
                                    amigo.setNomeResponsavel(NomeResponsavelNovo);
                                    amigo.setTelefone(TelefoneNovo);

                                    if (emprestimos.Count != 0)
                                    {
                                        foreach (var emprestimo in emprestimos)
                                        {
                                            if (emprestimo.getAmigo().ToLower() == amigo.getNome().ToLower())
                                            {
                                                emprestimo.setAmigo(amigo.getNome());
                                            }
                                        }
                                    }

                                    verifica = true;
                                }
                                else
                                {
                                    Console.WriteLine("Parâmetros Vazia, por favor tente novamente!");
                                    verifica = false;
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
            }

            if (amigoEncontrado == false)
            {
                Console.WriteLine("Amigo não encontrado, tente novamente!");
                verifica = false;
            }

            return verifica;
        }
        else
        {
            Console.WriteLine("Nome do Amigo Vazia, por favor tente novamente!");
            return verifica;
        }
    }

    #endregion

    #region Métodos Emprestimo
    public bool VerificarEmprestimos()
    {
        if (emprestimos.Count == 0)
        {
            return false;
        }
        else
        {
            bool verificaAtraso = false;

            foreach (var emprestimo in emprestimos)
            {
                // Se o status não for "Concluído" e a data de hoje for maior que a data de devolução
                if (emprestimo.getStatus() != "Concluído" && emprestimo.getStatus() != "Atrasado" && DateTime.Now > emprestimo.getDataDevolucao())
                {
                    emprestimo.setStatus("Atrasado");

                    if (verificaAtraso == false)
                    {
                        Console.WriteLine("Atenção: Existem NOVOS empréstimos atrasados!");
                    }

                    Console.WriteLine($"Amigo: {emprestimo.getAmigo()}, Revista: {emprestimo.getRevista()}, Data do Empréstimo: {emprestimo.getDataEmprestimo().ToString("dd/MM/yyyy")}, Data que deveria ser Devolvida: {emprestimo.getDataDevolucao().ToString("dd/MM/yyyy")}, Dias em Atraso: {emprestimo.DiasEmAtraso()}, Status: {emprestimo.getStatus()}");

                    string NomeAmigo = emprestimo.getAmigo();
                    string NomeRevista = emprestimo.getRevista();

                    if (multas.Count != 0)
                    {
                        bool verificaMulta = false;

                        foreach (var multa in multas)
                        {
                            if (multa.getstatus() != "Quitada" && multa.getNomeAmigo() == NomeAmigo && multa.getnomeRevista() == NomeRevista)
                            {
                                float valorMulta = 2 * emprestimo.DiasEmAtrasoInt();
                                multa.setvalorMulta(valorMulta);

                                verificaMulta = true;
                            }
                        }

                        if (verificaMulta == false)
                        {
                            float valorMulta = 2 * emprestimo.DiasEmAtrasoInt();

                            Multa multa = new Multa(NomeAmigo, NomeRevista, valorMulta);

                            multas.Add(multa);
                        }
                    }
                    else
                    {
                        float valorMulta = 2 * emprestimo.DiasEmAtrasoInt();

                        Multa multa = new Multa(NomeAmigo, NomeRevista, valorMulta);

                        multas.Add(multa);
                    }

                    verificaAtraso = true;
                }
                else
                {
                    if (emprestimo.getStatus() != "Concluído" && DateTime.Now > emprestimo.getDataDevolucao())
                    {
                        string NomeAmigo = emprestimo.getAmigo();
                        string NomeRevista = emprestimo.getRevista();

                        if (multas.Count != 0)
                        {
                            bool verificaMulta = false;

                            foreach (var multa in multas)
                            {
                                if (multa.getstatus() != "Quitada" && multa.getNomeAmigo() == NomeAmigo && multa.getnomeRevista() == NomeRevista)
                                {
                                    float valorMulta = 2 * emprestimo.DiasEmAtrasoInt();
                                    multa.setvalorMulta(valorMulta);

                                    verificaMulta = true;
                                }
                            }

                            if (verificaMulta == false)
                            {
                                float valorMulta = 2 * emprestimo.DiasEmAtrasoInt();

                                Multa multa = new Multa(NomeAmigo, NomeRevista, valorMulta);

                                multas.Add(multa);
                            }

                            verificaAtraso = true;
                        }
                        else
                        {
                            float valorMulta = 2 * emprestimo.DiasEmAtrasoInt();

                            Multa multa = new Multa(NomeAmigo, NomeRevista, valorMulta);

                            multas.Add(multa);

                            verificaAtraso = true;
                        }
                    }
                }
            }

            if (verificaAtraso == true)
            {
                return true;
            }
            return false;
        }
    }
    public bool CadastrarEmprestimo()
    {
        string Amigo = "";
        string Revista = "";
        int DiasEmprestimo = 0;

        bool verificaAmigo = false;
        bool verificaRevista = false;

        try
        {
            verificaAmigo = MostrarAmigosCadastrados();

            if (verificaAmigo == true)
            {
                Console.Write("Digite o nome do Amigo que fará o Empréstimo: ");
                Amigo = Console.ReadLine() ?? "";

                if (Amigo != "")
                {
                    bool amigoAchado = false;

                    foreach (var amigo in amigos)
                    {
                        if (amigo.getNome().ToLower() == Amigo.ToLower())
                        {
                            amigoAchado = true;

                            Revista = MostrarTodasAsRevistasCadastradas(amigo.getNome());

                            if (Revista != "")
                            {
                                int verificarDiasEmprestimos = 0;

                                foreach (var caixa in caixas)
                                {
                                    verificarDiasEmprestimos = caixa.verificaRevista(Revista);

                                    if (verificarDiasEmprestimos > 0)
                                    {
                                        DiasEmprestimo = verificarDiasEmprestimos;
                                    }
                                }

                            }
                            else
                            {
                                Console.WriteLine("Revista não Encontrada, tente novamente!");
                                return false;
                            }

                        }
                    }

                    if (amigoAchado == false)
                    {
                        Console.WriteLine("Amigo não Encontrado, tente novamente!");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Amigo não Encontrado, tente novamente!");
                    return false;
                }

            }
        }
        catch (System.Exception)
        {
            Console.WriteLine("Erro, verifique se os parêmetros foram passados corretamente!");
            return false;
        }

        if (Amigo != "" && Revista != "" && DiasEmprestimo > 0)
        {
            Emprestimo emprestimo = new Emprestimo(Amigo, Revista, DiasEmprestimo);

            emprestimos.Add(emprestimo);
            Console.WriteLine("Emprestimo cadastrado com sucesso!");

            return true;
        }
        else
        {
            Console.WriteLine("Nome dos campos Vazia ou Revista Indisponível, por favor tente novamente!");
            return false;
        }
    }
    public bool CadastrarDevolucao()
    {
        string amigo = "";

        Console.Write("Digite o nome do amigo que devolveu a revista: ");
        amigo = Console.ReadLine() ?? "";

        if (amigo != "")
        {
            foreach (var emprestimo in emprestimos)
            {
                if (emprestimo.getAmigo().ToLower() == amigo.ToLower())
                {
                    emprestimo.setStatus("Concluído");
                    emprestimo.setDataDevolucao(DateTime.MinValue);
                    emprestimo.setDataDevolvido(DateTime.Now);

                    foreach (var caixa in caixas)
                    {
                        caixa.DevolverRevista(emprestimo.getRevista());
                    }

                    return true;
                }
            }

            Console.WriteLine("Amigo não encontrado, por favor tente novamente!");
            return false;
        }
        else
        {
            Console.WriteLine("Nome do Amigo Vazia, tente Novamente!");
            return false;
        }

    }
    public bool MostrarEmprestimosCadastrados()
    {
        if (emprestimos.Count == 0)
        {
            Console.WriteLine("Nenhum empréstimo cadastrado.");
            return false;
        }
        else
        {
            Console.WriteLine("Empréstimos cadastrados:");
            foreach (var emprestimo in emprestimos)
            {
                if (emprestimo.getStatus() == "Concluído")
                {
                    Console.WriteLine($"Amigo: {emprestimo.getAmigo()}, Revista: {emprestimo.getRevista()}, Data do Empréstimo: {emprestimo.getDataEmprestimo().ToString("dd/MM/yyyy")}, Data Devolvida: {emprestimo.getDataDevolvido().ToString("dd/MM/yyyy")}, Status: {emprestimo.getStatus()}");
                }
                else
                {
                    if (emprestimo.getStatus() == "Aberto")
                    {
                        Console.WriteLine($"Amigo: {emprestimo.getAmigo()}, Revista: {emprestimo.getRevista()}, Data do Empréstimo: {emprestimo.getDataEmprestimo().ToString("dd/MM/yyyy")}, Data a ser Devolvida: {emprestimo.getDataDevolucao().ToString("dd/MM/yyyy")}, Status: {emprestimo.getStatus()}");
                    }
                    else
                    {
                        if (emprestimo.getStatus() == "Atrasado")
                        {
                            Console.WriteLine($"Amigo: {emprestimo.getAmigo()}, Revista: {emprestimo.getRevista()}, Data do Empréstimo: {emprestimo.getDataEmprestimo().ToString("dd/MM/yyyy")}, Data que deveria ser Devolvida: {emprestimo.getDataDevolucao().ToString("dd/MM/yyyy")}, Dias em Atraso: {emprestimo.DiasEmAtraso()}, Status: {emprestimo.getStatus()}");
                        }
                    }
                }
            }
            return true;
        }
    }

    #endregion

}