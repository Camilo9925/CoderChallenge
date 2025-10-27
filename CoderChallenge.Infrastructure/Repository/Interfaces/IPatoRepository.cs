using CoderChallenge.Domain.Entities;

namespace CoderChallenge.Infrastructure.Repository.Interfaces;

public interface IPatoRepository
{
    Task<List<PatoPrimordialEntity>> ObterTodosPatos();
    Task<PatoPrimordialEntity> ObterPatoPorId(string id);
    Task<bool> CriarPato(PatoPrimordialEntity pato);
    Task<bool> AtualizarPato(string id, PatoPrimordialEntity pato);
    Task<bool> DeletarPato(string id);
}
