using CoderChallenge.Application.Interfaces;
using CoderChallenge.Application.Interfaces.Services;
using CoderChallenge.Application.Mappers;
using CoderChallenge.Arguments.Arguments.Drone;
using CoderChallenge.Domain.Common;
using CoderChallenge.Infrastructure.Repository.Interfaces;

namespace CoderChallenge.Application.Services;

public class DroneService : IDroneService
{
    private readonly IDroneRepository _repository;
    private readonly IDroneValidator _validador;   
    public DroneService(IDroneRepository repository, IDroneValidator validador)
    {
        _repository = repository;
        _validador = validador;
    }
    public async Task<BaseApiResponse<List<OutputDrone>>> ObterTodosDrones()
    {
        try
        {
            var drones = await _repository.ObterTodosDrones();
            if (drones == null || !drones.Any())
                return BaseApiResponse<List<OutputDrone>>.Ok(new List<OutputDrone>(), "Nenhum drone encontrado");

            var outputs = drones.Select(DroneMapper.DroneEntityToOutputDrone).ToList();

            return BaseApiResponse<List<OutputDrone>>.Ok(outputs, $"{outputs.Count} drones encontrados");
        }
        catch (Exception ex)
        {
            return BaseApiResponse<List<OutputDrone>>.Erro("Erro ao obter todos os drones", new List<string> { ex.Message });
        }
    }
    public async Task<BaseApiResponse<OutputDrone>> ObterDronePorId(string id)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(id))
                return BaseApiResponse<OutputDrone>.Erro("ID do drone não pode ser vazio");

            var drone = await _repository.ObterDronePorId(id);

            if (drone is null)
                return BaseApiResponse<OutputDrone>.Erro("Drone não encontrado");

            _validador.ValidarDroneExistente(drone);

            var output = DroneMapper.DroneEntityToOutputDrone(drone);

            return BaseApiResponse<OutputDrone>.Ok(output, "Drone obtido com sucesso");
        }
        catch (Exception ex)
        {
            return BaseApiResponse<OutputDrone>.Erro("Erro ao obter drone por id", new List<string> { ex.Message });
        }
    }
    public async Task<BaseApiResponse<List<OutputDrone>>> ObterDronesAtivos()
    {
        try
        {
            var drones = await _repository.ObterTodosDronesAtivos();
            if (drones is null || !drones.Any())
                return BaseApiResponse<List<OutputDrone>>.Ok([], "Nenhum drone ativo encontrado");

            var outputs = drones.Select(DroneMapper.DroneEntityToOutputDrone).ToList();

            return BaseApiResponse<List<OutputDrone>>.Ok(outputs, $"{outputs.Count} drones ativos encontrados");
        }
        catch(Exception ex)
        {
            return BaseApiResponse<List<OutputDrone>>.Erro("Erro ao obter drones ativos", new List<string> { ex.Message });
        }
    }
    public async Task<BaseApiResponse<List<OutputDrone>>> ObterDronesDestruidos()
    {
        try
        {
            var drones = await _repository.ObterTodosDronesDestruidos();
            if(drones is null || !drones.Any())
                return BaseApiResponse<List<OutputDrone>>.Ok([], "Nenhum drone destruído encontrado");

            var outputs = drones.Select(DroneMapper.DroneEntityToOutputDrone).ToList();

            return BaseApiResponse<List<OutputDrone>>.Ok(outputs, $"{outputs.Count} drones destruídos encontrados");
        }
        catch(Exception ex)
        {
            return BaseApiResponse<List<OutputDrone>>.Erro("Erro ao obter drones destruidos", new List<string> { ex.Message });
        }
    }
    public async Task<BaseApiResponse<OutputDrone>> CriarDrone(InputDrone inputDroneCreate)
    {
        try
        {
            _validador.ValidarInputDrone(inputDroneCreate);

            var entity = DroneMapper.InputDroneToEntity(inputDroneCreate);
            var criado = await _repository.CriarDrone(entity);

            if (!criado)
                return BaseApiResponse<OutputDrone>.Erro("Falha ao criar drone no banco de dados");

            var output = DroneMapper.DroneEntityToOutputDrone(entity);
            return BaseApiResponse<OutputDrone>.Ok(output, "Drone criado com sucesso");
        }
        catch (Exception ex)
        {
            return BaseApiResponse<OutputDrone>.Erro("Erro ao criar drone", new List<string> { ex.Message });
        }
    }
    public async Task<BaseApiResponse<bool>> AtualizarDrone(string id, InputDrone inputDrone)
    {
        try
        {           
            _validador.ValidarInputDrone(inputDrone);

            var entity = DroneMapper.InputDroneToEntity(inputDrone);
            var atualizado = await _repository.AtualizarDrone(id, entity);

            if (!atualizado)
                return BaseApiResponse<bool>.Erro("Falha ao atualizar drone");

            return BaseApiResponse<bool>.Ok(true, "Drone atualizado com sucesso");
        }
        catch (Exception ex)
        {
            return BaseApiResponse<bool>.Erro("Erro ao atualizar drone", new List<string> { ex.Message });
        }
    }
    public async Task<BaseApiResponse<bool>> DeletarDrone(string id)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(id))
                return BaseApiResponse<bool>.Erro("ID do drone não pode ser vazio");

            var deletado = await _repository.DeletarDrone(id);
            if (!deletado)
                return BaseApiResponse<bool>.Erro("Erro ao deletar drone");

            return BaseApiResponse<bool>.Ok(true, "Drone deletado com sucesso");
        }
        catch(Exception ex)
        {
            return BaseApiResponse<bool>.Erro("Erro ao deletar drone", new List<string> { ex.Message });
        }
    }
}