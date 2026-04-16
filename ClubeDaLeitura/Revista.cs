class Revista
{

    private string Titulo;
    private string Status;
    private int NumeroDaEdicao;
    private DateTime AnoPublicacao;

    #region Construtores
    public Revista(string titulo, int numeroDaEdicao, DateTime anoPublicacao)
    {
        this.Titulo = titulo;
        this.Status = "Disponível";
        this.NumeroDaEdicao = numeroDaEdicao;
        this.AnoPublicacao = anoPublicacao;
    }

    public Revista()
    {

    }

    #endregion

    #region Getters e Setters

    public string getStatus()
    {
        return this.Status;
    }

    public void setStatus(string status)
    {
        this.Status = status;
    }
    public string getTitulo()
    {
        return this.Titulo;
    }

    public void setTitulo(string titulo)
    {
        this.Titulo = titulo;
    }

    public int getNumeroDaEdicao()
    {
        return this.NumeroDaEdicao;
    }

    public void setNumeroDaEdicao(int numeroDaEdicao)
    {
        this.NumeroDaEdicao = numeroDaEdicao;
    }

    public DateTime getAnoPublicacao()
    {
        return this.AnoPublicacao;
    }

    public void setAnoPublicacao(DateTime anoPublicacao)
    {
        this.AnoPublicacao = anoPublicacao;
    }

    #endregion

    #region Serializable

    public string Titulo_JSON { get => getTitulo(); set => setTitulo(value); }
    public string Status_JSON { get => getStatus(); set => setStatus(value); }
    public int NumeroDaEdicao_JSON { get => getNumeroDaEdicao(); set => setNumeroDaEdicao(value); }
    public DateTime AnoPublicacao_JSON { get => getAnoPublicacao(); set => setAnoPublicacao(value); }

    #endregion

    #region Métodos

    #endregion

}