using CoderChallenge.Arguments.Arguments.BuscaPato;
using CoderChallenge.Domain.Entities;

namespace CoderChallenge.Application.Interfaces.Services;

public interface ISimuladorProvocacaoService
{
    Task<OutputResultadoProvocacaoPato> SimularProvocacaoAsync(PatoPrimordialEntity pato, DroneEntity drone);
    SuperpoderEntity GerarSuperpoderAleatorio();
}
