using CoderChallenge.Arguments.Arguments.Pato;
using CoderChallenge.Domain.Common;

namespace CoderChallenge.Application.Interfaces.Services;

public interface IPatoService
{
    Task<BaseApiResponse<List<OutputPatoPrimordial>>> ObterTodosPatos();
    Task<BaseApiResponse<OutputPatoPrimordial>> ObterPatoPorId(string id);
    Task<BaseApiResponse<OutputPatoPrimordial>> CriarPato(InputPatoPrimordial inputPatoPrimordialCreate);
    Task<BaseApiResponse<bool>> AtualizarPato(string id, InputPatoPrimordial pato);
    Task<BaseApiResponse<bool>> DeletarPato(string id);
}