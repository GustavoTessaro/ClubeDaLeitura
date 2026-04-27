using System.Text.Json.Serialization;
class Reserva
{
    private string nomeAmigo;
    private string nomeRevista;
    private DateTime dataReserva;
    private string status;

    #region Construtores

    public Reserva(string nomeAmigo, string nomeRevista)
    {
        this.nomeAmigo = nomeAmigo;
        this.nomeRevista = nomeRevista;
        this.dataReserva = DateTime.Now;
        this.status = "Ativa";
    }
    public Reserva()
    {
    }

    #endregion

    #region Getters e Setters
    public string getNomeAmigo()
    {
        return this.nomeAmigo;
    }
    public string getNomeRevista()
    {
        return this.nomeRevista;
    }
    public DateTime getDataReserva()
    {
        return this.dataReserva;
    }
    public string getStatus()
    {
        return this.status;
    }
    public void setStatus(string status)
    {
        this.status = status;
    }
    public void SetDataReserva(DateTime data)
    {
        this.dataReserva = data;
    }
    public void setNomeAmigo(string nomeAmigo)
    {
        this.nomeAmigo = nomeAmigo;
    }
    public void setNomeRevista(string nomeRevista)
    {
        this.nomeRevista = nomeRevista;
    }

    #endregion

    #region Serializable

    [JsonPropertyName("nomeAmigo")]
    public string Nome_JSON { get => getNomeAmigo(); set => setNomeAmigo(value); }

    [JsonPropertyName("nomeRevista")]
    public string Nome_Revista_JSON { get => getNomeRevista(); set => setNomeRevista(value); }

    [JsonPropertyName("dataReserva")]
    public DateTime Data_Reserva_JSON { get => getDataReserva(); set => SetDataReserva(value); }

    [JsonPropertyName("status")]
    public string Status_JSON { get => getStatus(); set => setStatus(value); }

    #endregion

    #region Métodos

    #endregion

}