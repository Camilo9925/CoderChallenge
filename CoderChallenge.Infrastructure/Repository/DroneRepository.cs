using CoderChallenge.Domain.Entities;
using CoderChallenge.Infrastructure.Repository.Context;
using CoderChallenge.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoderChallenge.Infrastructure.Repository;

public class DroneRepository(AppDbContext _context) : IDroneRepository
{
    public async Task<List<DroneEntity>> ObterTodosDrones()
    {
        return await _context.Drones
            .Include(d => d.Localizacao)
            .ThenInclude(l => l.Precisao)
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<DroneEntity> ObterDronePorId(string id)
    {
        var drone = await _context.Drones
        .Include(d => d.Localizacao)
        .ThenInclude(l => l.Precisao)
        .FirstOrDefaultAsync(d => d.Id == id);

        if (drone == null)
            return null!;

        return drone;
    }
    public async Task<List<DroneEntity>> ObterTodosDronesAtivos()
    {
        return await _context.Drones
        .Include(d => d.Localizacao)
        .ThenInclude(x => x.Precisao)
        .Where(x => x.Ativo == true)
        .ToListAsync();;
    }
    public async Task<List<DroneEntity>> ObterTodosDronesDestruidos()
    {
        return await _context.Drones
        .Include(d => d.Localizacao)
        .ThenInclude(x => x.Precisao)
        .Where(x => x.Ativo == false)
        .ToListAsync();;
    }
    public async Task<bool> CriarDrone(DroneEntity droneEntity)
    {
        await _context.Drones.AddAsync(droneEntity);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> AtualizarDrone(string id, DroneEntity drone)
    {
        var droneBanco = await _context.Drones
            .Include(x => x.Localizacao)
                .ThenInclude(l => l.Precisao)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (droneBanco == null)
            return false;
        
        droneBanco.NumeroSerie = drone.NumeroSerie;
        droneBanco.Marca = drone.Marca;
        droneBanco.Fabricante = drone.Fabricante;
        droneBanco.PaisOrigem = drone.PaisOrigem;
        droneBanco.Ativo = drone.Ativo;
        
        if (drone.Localizacao != null)
        {
            if (droneBanco.Localizacao == null)
                droneBanco.Localizacao = new LocalizacaoEntity();

            droneBanco.Localizacao.Cidade = drone.Localizacao.Cidade;
            droneBanco.Localizacao.Pais = drone.Localizacao.Pais;
            droneBanco.Localizacao.Latitude = drone.Localizacao.Latitude;
            droneBanco.Localizacao.Longitude = drone.Localizacao.Longitude;
            droneBanco.Localizacao.PontoReferenciaConhecido = drone.Localizacao.PontoReferenciaConhecido;

            if (drone.Localizacao.Precisao != null)
            {
                if (droneBanco.Localizacao.Precisao == null)
                    droneBanco.Localizacao.Precisao = new PrecisaoEntity();

                droneBanco.Localizacao.Precisao.Valor = drone.Localizacao.Precisao.Valor;
                droneBanco.Localizacao.Precisao.UnidadeOriginal = drone.Localizacao.Precisao.UnidadeOriginal;
                droneBanco.Localizacao.Precisao.ValorEmMetros = drone.Localizacao.Precisao.ValorEmMetros;
            }
        }

        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeletarDrone(string id)
    {
        var droneBanco = await _context.Drones
        .Include(x => x.Localizacao)
        .ThenInclude(l => l.Precisao)
        .FirstOrDefaultAsync(x => x.Id == id);

        if (droneBanco == null)
            return false;

        _context.Remove(droneBanco);
        await _context.SaveChangesAsync();

        return true;
    }
}