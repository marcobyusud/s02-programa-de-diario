namespace Diario;

public class GeradorDePerguntas
{
    private List<string> _perguntas = new List<string>
    {
        "Que momento simples de hoje merece ser guardado?",
        "O que me fez sorrir hoje?",
        "Qual foi uma coisa nova que aprendi?",
        "Quem me ajudou ou tornou meu dia melhor?",
        "O que eu gostaria de fazer com mais calma amanhã?",
        "Qual foi uma pequena gentileza que fiz por alguém?",
        "Que lugar ou conversa marcou meu dia?",
        "O que consegui fazer mesmo sendo difícil?",
        "O que quero lembrar sobre hoje?",
        "Se meu dia tivesse um título, qual seria?"
    };

    private Random _aleatorio = new Random();

    public string ObterPerguntaAleatoria()
    {
        int numero = _aleatorio.Next(_perguntas.Count);
        return _perguntas[numero];
    }
}
