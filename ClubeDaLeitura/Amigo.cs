using System.Text.Json.Serialization;
class Amigo
{

    private string nome;
    private string nomeResponsavel;
    private string telefone;

    #region Construtores

    public Amigo(string Nome, string NomeResponsavel, string Telefone)
    {
        this.nome = Nome;
        this.nomeResponsavel = NomeResponsavel;
        this.telefone = Telefone;
    }

    public Amigo()
    {

    }

    #endregion

    #region Getters e Setters

    public string getNome()
    {
        return this.nome;
    }

    public void setNome(string Nome)
    {
        this.nome = Nome;
    }

    public string getNomeResponsavel()
    {
        return this.nomeResponsavel;
    }

    public void setNomeResponsavel(string NomeResponsavel)
    {
        this.nomeResponsavel = NomeResponsavel;
    }

    public string getTelefone()
    {
        return this.telefone;
    }

    public void setTelefone(string Telefone)
    {
        this.telefone = Telefone;
    }

    #endregion

    #region Serializable

    [JsonPropertyName("nome")]
    public string Nome_JSON { get => getNome(); set => setNome(value); }

    [JsonPropertyName("nomeResponsavel")]
    public string NomeResponsavel_JSON { get => getNomeResponsavel(); set => setNomeResponsavel(value); }

    [JsonPropertyName("telefone")]
    public string Telefone_JSON { get => getTelefone(); set => setTelefone(value); }

    #endregion

}