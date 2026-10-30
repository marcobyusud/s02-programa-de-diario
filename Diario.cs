using System.Text.Json;

namespace Diario;

public class Diario
{
    private readonly List<Registro> _registros = new();

    public void AdicionarRegistro(Registro novoRegistro)
    {
        _registros.Add(novoRegistro);
    }

    public void ExibirTodos()
    {
        if (_registros.Count == 0)
        {
            Console.WriteLine("Seu diário ainda não tem registros.");
            return;
        }

        foreach (Registro registro in _registros)
        {
            registro.Exibir();
        }
    }

    public void SalvarNoArquivo(string arquivo)
    {
        string conteudo = JsonSerializer.Serialize(_registros, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(arquivo, conteudo);
    }

    public void CarregarDoArquivo(string arquivo)
    {
        string conteudo = File.ReadAllText(arquivo);
        List<Registro>? registrosCarregados =
            JsonSerializer.Deserialize<List<Registro>>(conteudo);

        if (registrosCarregados is null)
        {
            throw new JsonException("O arquivo não contém uma lista de registros válida.");
        }

        _registros.Clear();
        _registros.AddRange(registrosCarregados);
    }
}
