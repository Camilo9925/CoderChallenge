using CoderChallenge.Arguments.Arguments.BuscaPato;
using CoderChallenge.Domain.Common;

namespace CoderChallenge.Application.Interfaces.Services;

public interface IBuscaPatoService
{
    Task<BaseApiResponse<OutputBuscaPato>> ExecutarBuscaPatoAsync(string droneId, string patoIdEspecifico = null!);
}
