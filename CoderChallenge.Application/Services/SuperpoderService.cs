using CoderChallenge.Application.Interfaces.Services;
using CoderChallenge.Domain.Entities;

namespace CoderChallenge.Application.Services;

public class SuperpoderService : ISuperpoderService
{
    public SuperpoderEntity GerarSuperpoderAleatorio()
    {
        try
        {
            var todosSuperPoderes = ObterTodosSuperPoderes();

            if (!todosSuperPoderes.Any())
            {
                return null!;
            }

            var random = new Random();
            var superpoderAleatorio = todosSuperPoderes[random.Next(todosSuperPoderes.Count)];

            return superpoderAleatorio;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao gerar superpoder aleatório: {ex.Message}");
            throw;
        }
    }

    public List<SuperpoderEntity> ObterTodosSuperPoderes()
    {
        try
        {
            var superpoderes = new List<SuperpoderEntity>
        {
            new SuperpoderEntity
            {
                Id = "sp-001",
                Nome = "Laser Ocular",
                Descricao = "Lança feixes de laser pelos olhos com precisão cirúrgica",
                Classificacoes = new List<string> { "bélico", "raro", "alto risco de incêndio" }
            },
            new SuperpoderEntity
            {
                Id = "sp-002",
                Nome = "Tempestade Elétrica",
                Descricao = "Gera descargas elétricas em área ao redor",
                Classificacoes = new List<string> { "bélico", "raro", "alto risco de curto-circuito" }
            },
            new SuperpoderEntity
            {
                Id = "sp-003",
                Nome = "Manipulação de Água",
                Descricao = "Controla e manipula água em qualquer forma",
                Classificacoes = new List<string> { "elemental", "muito raro", "risco de afogamento" }
            },
            new SuperpoderEntity
            {
                Id = "sp-004",
                Nome = "Voo Supersônico",
                Descricao = "Voa em velocidades supersônicas deixando rastro de fogo",
                Classificacoes = new List<string> { "bélico", "raro", "risco de colisão" }
            },
            new SuperpoderEntity
            {
                Id = "sp-005",
                Nome = "Invisibilidade Temporal",
                Descricao = "Desaparece do espaço-tempo por curtos períodos",
                Classificacoes = new List<string> { "raro", "muito raro", "lendário" }
            },
            new SuperpoderEntity
            {
                Id = "sp-006",
                Nome = "Regeneração Acelerada",
                Descricao = "Regenera qualquer ferimento em segundos",
                Classificacoes = new List<string> { "defensivo", "raro", "praticamente indestrutível" }
            },
            new SuperpoderEntity
            {
                Id = "sp-007",
                Nome = "Grito Sônico",
                Descricao = "Emite um grito que causa dano em área e destrói estruturas",
                Classificacoes = new List<string> { "bélico", "raro", "alto risco de surdez" }
            },
            new SuperpoderEntity
            {
                Id = "sp-008",
                Nome = "Controle de Gravidade",
                Descricao = "Manipula campos gravitacionais ao seu redor",
                Classificacoes = new List<string> { "elemental", "muito raro", "risco de implosão" }
            },
            new SuperpoderEntity
            {
                Id = "sp-009",
                Nome = "Telecinese",
                Descricao = "Move objetos com o poder da mente",
                Classificacoes = new List<string> { "psíquico", "raro", "risco de aneurisma" }
            },
            new SuperpoderEntity
            {
                Id = "sp-010",
                Nome = "Combustão Espontânea",
                Descricao = "Ignição espontânea de qualquer material próximo",
                Classificacoes = new List<string> { "bélico", "muito raro", "risco de incêndio descontrolado" }
            }
        };

            return superpoderes;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
