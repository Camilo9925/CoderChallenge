using CoderChallenge.Domain.Entities;

namespace CoderChallenge.Infrastructure.Repository.Interfaces;

public interface IDroneRepository
{
    Task<List<DroneEntity>> ObterTodosDrones();
    Task<DroneEntity> ObterDronePorId(string id);
    Task<List<DroneEntity>> ObterTodosDronesAtivos();
    Task<List<DroneEntity>> ObterTodosDronesDestruidos();
    Task<bool> CriarDrone(DroneEntity droneEntity);
    Task<bool> AtualizarDrone(string id, DroneEntity drone);
    Task<bool> DeletarDrone(string id);
}