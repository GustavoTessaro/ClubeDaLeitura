using System.Text.Json.Serialization;
class Multa
{
    private string nomeAmigo;
    private float valorMulta;
    private string nomeRevista;
    private string status;

    #region Construtores

    public Multa(string Amigo, string Revista, float valorMulta)
    {
        this.nomeAmigo = Amigo;
        this.valorMulta = valorMulta;
        this.nomeRevista = Revista;
        this.status = "Pendente";
    }

    public Multa()
    {

    }

    #endregion

    #region Getters e Setters

    public string getNomeAmigo()
    {
        return this.nomeAmigo;
    }

    public void setNomeAmigo(string nome)
    {
        this.nomeAmigo = nome;
    }

    public float getvalorMulta()
    {
        return this.valorMulta;
    }

    public void setvalorMulta(float valor)
    {
        this.valorMulta = valor;
    }

    public string getnomeRevista()
    {
        return this.nomeRevista;
    }

    public void setnomeRevista(string revista)
    {
        this.nomeRevista = revista;
    }

    public string getstatus()
    {
        return this.status;
    }

    public void setStatus(string status)
    {
        this.status = status;
    }

    #endregion

    #region Serializable

    [JsonPropertyName("nomeAmigo")]
    public string NomeAmigo_JSON { get => getNomeAmigo(); set => setNomeAmigo(value); }

    [JsonPropertyName("valorMulta")]
    public float ValorMulta_JSON { get => getvalorMulta(); set => setvalorMulta(value); }

    [JsonPropertyName("nomeRevista")]
    public string NomeRevista_JSON { get => getnomeRevista(); set => setnomeRevista(value); }

    [JsonPropertyName("status")]
    public string Status_JSON { get => getstatus(); set => setStatus(value); }

    #endregion

}