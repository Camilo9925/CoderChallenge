using CoderChallenge.Domain.Entities;

namespace CoderChallenge.Application.Interfaces.Services;

public interface ISuperpoderService
{
    SuperpoderEntity GerarSuperpoderAleatorio();
    List<SuperpoderEntity> ObterTodosSuperPoderes();
}
