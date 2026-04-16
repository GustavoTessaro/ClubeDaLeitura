class Emprestimo
{

    private string amigo;
    private string revista;
    private string status;
    private DateTime dataEmprestimo;
    private DateTime dataDevolucao;
    private DateTime dataDevolvido;

    #region COnstrutores

    public Emprestimo(string Amigo, string Revista, int DiasEmprestimo)
    {
        this.amigo = Amigo;
        this.revista = Revista;
        this.status = "Aberto";
        this.dataEmprestimo = DateTime.Now;
        this.dataDevolucao = CalcularDataDevolucao(DiasEmprestimo);
        this.dataDevolvido = DateTime.MinValue;
    }

    public Emprestimo()
    {

    }

    #endregion

    #region Getters e Setters

    public string getAmigo()
    {
        return this.amigo;
    }

    public void setAmigo(string Amigo)
    {
        this.amigo = Amigo;
    }

    public string getRevista()
    {
        return this.revista;
    }

    public void setRevista(string Revista)
    {
        this.revista = Revista;
    }

    public string getStatus()
    {
        return this.status;
    }

    public void setStatus(string Status)
    {
        this.status = Status;
    }

    public DateTime getDataEmprestimo()
    {
        return this.dataEmprestimo;
    }

    public void setDataEmprestimo(DateTime DataEmprestimo)
    {
        this.dataEmprestimo = DataEmprestimo;
    }

    public DateTime getDataDevolucao()
    {
        return this.dataDevolucao;
    }

    public void setDataDevolucao(DateTime DataDevolucao)
    {
        this.dataDevolucao = DataDevolucao;
    }

    public DateTime getDataDevolvido()
    {
        return this.dataDevolvido;
    }

    public void setDataDevolvido(DateTime DataDevolvido)
    {
        this.dataDevolvido = DataDevolvido;
    }

    #endregion

    #region Serializable

    public string Amigo_JSON { get => getAmigo(); set => setAmigo(value); }
    public string Revista_JSON { get => getRevista(); set => setRevista(value); }
    public string Status_JSON { get => getStatus(); set => setStatus(value); }
    public DateTime DataEmprestimo_JSON { get => getDataEmprestimo(); set => setDataEmprestimo(value); }
    public DateTime DataDevolucao_JSON { get => getDataDevolucao(); set => setDataDevolucao(value); }
    public DateTime DataDevolvido_JSON { get => getDataDevolvido(); set => setDataDevolvido(value); }

    #endregion

    #region Métodos

    public DateTime CalcularDataDevolucao(int DiasEmprestimo)
    {
        return this.dataEmprestimo.AddDays(DiasEmprestimo);
    }
    public string DiasEmAtraso()
    {
        TimeSpan diferenca = DateTime.Now - this.dataDevolucao;

        int dias = diferenca.Days > 0 ? diferenca.Days : 0;

        return dias.ToString();
    }

    #endregion

}