using System.Text.Json;

namespace Diario;

public class Program
{
    // Fiz algo a mais: o diário salva o humor e usa JSON para guardar os registros.
    public static void Main()
    {
        Diario diario = new();
        GeradorDePerguntas geradorDePerguntas = new();

        bool continuar = true;
        while (continuar)
        {
            ExibirMenu();
            string opcao = Console.ReadLine() ?? "";

            switch (opcao)
            {
                case "1":
                    CriarRegistro(diario, geradorDePerguntas);
                    break;
                case "2":
                    diario.ExibirTodos();
                    break;
                case "3":
                    SalvarDiario(diario);
                    break;
                case "4":
                    CarregarDiario(diario);
                    break;
                case "5":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }

        Console.WriteLine("Até a próxima!");
    }

    private static void ExibirMenu()
    {
        Console.WriteLine();
        Console.WriteLine("---------------- MEU DIÁRIO ----------------");
        Console.WriteLine("1. Escrever um registro");
        Console.WriteLine("2. Exibir os registros");
        Console.WriteLine("3. Salvar o diário");
        Console.WriteLine("4. Carregar um diário");
        Console.WriteLine("5. Sair");
        Console.Write("Escolha uma opção: ");
    }

    private static void CriarRegistro(Diario diario, GeradorDePerguntas geradorDePerguntas)
    {
        string pergunta = geradorDePerguntas.ObterPerguntaAleatoria();
        Console.WriteLine();
        Console.WriteLine($"Pergunta: {pergunta}");
        Console.Write("Resposta: ");
        string resposta = Console.ReadLine() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(resposta))
        {
            Console.WriteLine("A resposta não pode ficar vazia.");
            return;
        }

        string humor = PerguntarHumor();
        string data = DateTime.Now.ToShortDateString();
        diario.AdicionarRegistro(new Registro(data, pergunta, resposta, humor));
        Console.WriteLine("Registro adicionado!");
    }

    private static string PerguntarHumor()
    {
        Console.WriteLine();
        Console.WriteLine("Como você está hoje? (opcional)");
        Console.WriteLine("1. Cansado(a)  2. Triste  3. Neutro  4. Bem  5. Muito bem");
        Console.Write("Escolha ou pressione Enter para pular: ");
        string escolha = Console.ReadLine() ?? "";

        switch (escolha)
        {
            case "1": return "Cansado(a)";
            case "2": return "Triste";
            case "3": return "Neutro";
            case "4": return "Bem";
            case "5": return "Muito bem";
            default: return "Não registrado";
        }
    }

    private static void SalvarDiario(Diario diario)
    {
        Console.Write("Nome do arquivo para salvar: ");
        string arquivo = Console.ReadLine() ?? "";

        if (arquivo == "")
        {
            Console.WriteLine("Digite um nome de arquivo.");
            return;
        }

        try
        {
            diario.SalvarNoArquivo(arquivo);
            Console.WriteLine("Diário salvo!");
        }
        catch (IOException erro)
        {
            Console.WriteLine($"Não foi possível salvar: {erro.Message}");
        }
        catch (UnauthorizedAccessException erro)
        {
            Console.WriteLine($"Sem permissão para salvar: {erro.Message}");
        }
        catch (ArgumentException erro)
        {
            Console.WriteLine($"Nome de arquivo inválido: {erro.Message}");
        }
    }

    private static void CarregarDiario(Diario diario)
    {
        Console.Write("Nome do arquivo para carregar: ");
        string arquivo = Console.ReadLine() ?? "";

        if (arquivo == "")
        {
            Console.WriteLine("Digite um nome de arquivo.");
            return;
        }

        try
        {
            diario.CarregarDoArquivo(arquivo);
            Console.WriteLine("Diário carregado!");
        }
        catch (JsonException erro)
        {
            Console.WriteLine($"Esse arquivo não parece ser um diário: {erro.Message}");
        }
        catch (IOException erro)
        {
            Console.WriteLine($"Não foi possível abrir o arquivo: {erro.Message}");
        }
        catch (UnauthorizedAccessException erro)
        {
            Console.WriteLine($"Sem permissão para abrir: {erro.Message}");
        }
        catch (ArgumentException erro)
        {
            Console.WriteLine($"Nome de arquivo inválido: {erro.Message}");
        }
    }
}
