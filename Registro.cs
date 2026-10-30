namespace Diario;

public class Registro
{
    public string Data { get; set; }
    public string TextoPergunta { get; set; }
    public string TextoResposta { get; set; }
    public string Humor { get; set; }

    public Registro(string data, string textoPergunta, string textoResposta, string humor = "Não registrado")
    {
        Data = data;
        TextoPergunta = textoPergunta;
        TextoResposta = textoResposta;
        Humor = humor;
    }

    public void Exibir()
    {
        Console.WriteLine($"Data: {Data}");
        Console.WriteLine($"Como eu estava: {Humor}");
        Console.WriteLine($"Pergunta: {TextoPergunta}");
        Console.WriteLine($"Resposta: {TextoResposta}");
        Console.WriteLine();
    }
}
