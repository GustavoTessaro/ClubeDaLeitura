using System.Dynamic;
using System.Xml.Schema;

class Caixa
{

    private string Etiqueta;
    private string Cor;
    private int DiasEmprestimo;

    private List<Revista> revistas;

    #region Construtores
    public Caixa(string etiqueta, string cor, int diasEmprestimo)
    {
        this.Etiqueta = etiqueta;
        this.Cor = cor;
        this.DiasEmprestimo = diasEmprestimo;
        this.revistas = new List<Revista>();
    }

    public Caixa()
    {

    }

    #endregion

    #region Getters e Setters

    public List<Revista> GetRevistas()
    {
        return this.revistas;
    }

    public void SetRevistas(List<Revista> revistas)
    {
        this.revistas = revistas;
    }
    public string GetEtiqueta()
    {
        return this.Etiqueta;
    }

    public void SetEtiqueta(string etiqueta)
    {
        this.Etiqueta = etiqueta;
    }

    public string GetCor()
    {
        return this.Cor;
    }

    public void SetCor(string cor)
    {
        this.Cor = cor;
    }

    public int GetDiasEmprestimo()
    {
        return this.DiasEmprestimo;
    }

    public void SetDiasEmprestimo(int diasEmprestimo)
    {
        this.DiasEmprestimo = diasEmprestimo;
    }

    #endregion

    #region Serializable

    public string Etiqueta_JSON { get => GetEtiqueta(); set => SetEtiqueta(value); }
    public string Cor_JSON { get => GetCor(); set => SetCor(value); }
    public int DiasEmprestimo_JSON { get => GetDiasEmprestimo(); set => SetDiasEmprestimo(value); }
    public List<Revista> Revistas_JSON { get => GetRevistas(); set => SetRevistas(value); }

    #endregion

    #region Métodos

    public bool CadastrarRevista()
    {
        string Titulo = "";
        int NumeroDaEdicao = 0;
        DateTime AnoPublicacao;

        try
        {
            Console.Write("Digite o Título da Revista: ");
            Titulo = Console.ReadLine();
            Console.Write($"\nDigite o número da Edição da revista {Titulo}: ");
            NumeroDaEdicao = int.Parse(Console.ReadLine());
            Console.Write($"\nDigite a data de publicação da revista {Titulo} (dd/MM/yyyy): ");
            AnoPublicacao = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        }
        catch (System.Exception)
        {
            Console.WriteLine("Erro, verifique se os parêmetros foram passados corretamente!");
            return false;
        }

        if (revistas.Count != 0)
        {
            foreach (var revistaV in revistas)
            {
                if (revistaV.getTitulo().ToLower() == Titulo.ToLower())
                {
                    Console.WriteLine("Caixa já cadastrada com o nome " + Titulo + " Por favor, tente novamente!");
                    return false;
                }
            }
        }

        Revista revista = new Revista(Titulo, NumeroDaEdicao, AnoPublicacao);

        revistas.Add(revista);
        Console.WriteLine("Revista cadastrada com sucesso!");

        return true;
    }

    public int verificaRevista(string nome)
    {
        foreach (var revista in revistas)
        {
            if (revista.getTitulo().ToLower() == nome.ToLower() && revista.getStatus().ToLower() == "Disponível")
            {
                revista.setStatus("Indisponível");
                return this.DiasEmprestimo;
            }
        }
        return 0;
    }

    public void DevolverRevista(string nome)
    {
        foreach (var revista in revistas)
        {
            if (revista.getTitulo().ToLower() == nome.ToLower() && revista.getStatus().ToLower() == "Indisponível")
            {
                revista.setStatus("Disponível");
            }
        }
    }
    public void MostrarRevistasCadastradasSemMensagem()
    {
        if (revistas.Count != 0)
        {
            foreach (var revista in revistas)
            {
                Console.WriteLine($"Título: {revista.getTitulo}, Número da Edição: {revista.getNumeroDaEdicao}, Data da Publicação: {revista.getAnoPublicacao().ToString("dd/MM/yyyy")}, Status: {revista.getStatus()}");
            }
        }
    }
    public bool MostrarRevistasCadastradas()
    {
        if (revistas.Count == 0)
        {
            Console.WriteLine("Nenhuma revista cadastrada.");
            return false;
        }
        else
        {
            Console.WriteLine("Caixas cadastradas:");
            foreach (var revista in revistas)
            {
                Console.WriteLine($"Título: {revista.getTitulo}, Número da Edição: {revista.getNumeroDaEdicao}, Data da Publicação: {revista.getAnoPublicacao().ToString("dd/MM/yyyy")}, Status: {revista.getStatus()}");
            }
            return true;
        }
    }
    public bool ExcluirRevista()
    {
        bool verificaLista = MostrarRevistasCadastradas();

        if (verificaLista == false)
        {
            return false;
        }

        string selecionarRevista = "";
        bool verifica = false;

        Console.Write("Digite o Título da Revista que deseja Excluir: ");
        selecionarRevista = Console.ReadLine() ?? "";

        if (selecionarRevista != "")
        {
            foreach (var revista in revistas.ToList())
            {
                if (selecionarRevista.ToLower() == revista.getTitulo().ToLower())
                {
                    Console.Write("Tem certeza que deseja excluir a revista " + revista.getTitulo + " (S/N)?");
                    char resposta = char.ToUpper(Console.ReadKey(true).KeyChar);

                    if (resposta == 'S')
                    {
                        revistas.Remove(revista);
                        Console.WriteLine("Revista removida com sucesso!");
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
                    Console.WriteLine("Revista não encontrada, tente novamente!");
                    verifica = false;
                }
            }
            return verifica;
        }
        else
        {
            Console.WriteLine("Nome da Revista Vazia, por favor tente novamente!");
            return verifica;
        }
    }
    public int EscolherEditarRevista()
    {
        int opcao = 0;

        do
        {
            Console.WriteLine("Digite uma Opção para Editar: ");
            Console.WriteLine("1 - Editar Título");
            Console.WriteLine("2 - Editar Número da Edição");
            Console.WriteLine("3 - Editar Ano da Publicação");
            Console.WriteLine("4 - Editar Tudo");
            Console.WriteLine("5 - Voltar");
            opcao = (int)char.GetNumericValue(Console.ReadKey(true).KeyChar);
        } while (opcao != 1 && opcao != 2 && opcao != 3 && opcao != 4 && opcao != 5);

        return opcao;
    }
    public bool EditarRevista()
    {
        bool verificaLista = MostrarRevistasCadastradas();

        if (verificaLista == false)
        {
            return false;
        }

        string selecionarRevista = "";
        bool verifica = false;

        Console.Write("Digite o nome Revista que deseja Editar: ");
        selecionarRevista = Console.ReadLine() ?? "";

        if (selecionarRevista != "")
        {
            foreach (var revista in revistas.ToList())
            {
                if (selecionarRevista.ToLower() == revista.getTitulo().ToLower())
                {
                    int opcao = EscolherEditarRevista();

                    try
                    {
                        switch (opcao)
                        {
                            case 1:
                                string Titulo = "";
                                Console.WriteLine("Digite um novo título para a Revista: ");
                                Titulo = Console.ReadLine() ?? "";
                                if (Titulo != "")
                                {
                                    revista.setTitulo(Titulo);
                                    verifica = true;
                                }
                                break;
                            case 2:
                                int NumeroDaEdicao = 0;
                                Console.WriteLine("Digite um novo número da Edição para a Revista: ");
                                NumeroDaEdicao = int.Parse(Console.ReadLine());
                                revista.setNumeroDaEdicao(NumeroDaEdicao);
                                verifica = true;
                                break;
                            case 3:
                                DateTime AnoPublicacao;
                                Console.Write("Digite a nova data de publicação da revista (dd/MM/yyyy): ");
                                AnoPublicacao = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                                revista.setAnoPublicacao(AnoPublicacao);
                                break;
                            case 4:
                                string TituloNovo = "";
                                int NumeroDaEdicaoNovo = 0;
                                DateTime AnoPublicacaoNovo;

                                Console.WriteLine("Digite um novo título para a Revista: ");
                                TituloNovo = Console.ReadLine() ?? "";

                                Console.WriteLine("Digite um novo número da Edição para a Revista: ");
                                NumeroDaEdicaoNovo = int.Parse(Console.ReadLine());

                                Console.Write("Digite a nova data de publicação da revista (dd/MM/yyyy): ");
                                AnoPublicacaoNovo = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                                if (TituloNovo != "")
                                {
                                    revista.setTitulo(TituloNovo);
                                    revista.setNumeroDaEdicao(NumeroDaEdicaoNovo);
                                    revista.setAnoPublicacao(AnoPublicacaoNovo);
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
                    Console.WriteLine("Revista não encontrada, tente novamente!");
                    verifica = false;
                }
            }
            return verifica;
        }
        else
        {
            Console.WriteLine("Nome da Revista Vazia, por favor tente novamente!");
            return verifica;
        }
    }
    public string GetEtiquetaComCor()
    {
        // Mapeia a string que você salvou no SetCor para o código ANSI
        string codigo = this.Cor.ToLower() switch
        {
            "white" => "\u001b[37m",
            "gray" => "\u001b[90m",
            "red" => "\u001b[31m",
            "blue" => "\u001b[34m",
            "green" => "\u001b[32m",
            "yellow" => "\u001b[33m",
            "cyan" => "\u001b[36m",
            "magenta" => "\u001b[35m",
            _ => "\u001b[0m" // Padrão
        };

        return $"{codigo}{this.Etiqueta}\u001b[0m";
    }


    #endregion

}