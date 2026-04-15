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