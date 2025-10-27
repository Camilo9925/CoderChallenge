using CoderChallenge.Arguments.Arguments.Drone;
using CoderChallenge.Domain.Common;

namespace CoderChallenge.Application.Interfaces.Services;

public interface IDroneService
{
    Task<BaseApiResponse<List<OutputDrone>>> ObterTodosDrones();
    Task<BaseApiResponse<OutputDrone>> ObterDronePorId(string id);
    Task<BaseApiResponse<OutputDrone>> CriarDrone(InputDrone inputDroneCreate);
    Task<BaseApiResponse<List<OutputDrone>>> ObterDronesAtivos();
    Task<BaseApiResponse<List<OutputDrone>>> ObterDronesDestruidos();
    Task<BaseApiResponse<bool>> AtualizarDrone(string id, InputDrone inputDroneAtualizar);
    Task<BaseApiResponse<bool>> DeletarDrone(string id);
}