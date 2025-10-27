using CoderChallenge.Domain.Entities;

namespace CoderChallenge.Infrastructure.Repository.Interfaces;

public interface IBuscaPatoRepository
{
    Task<PatoPrimordialEntity> BuscarPatoAleatorio();
    Task<PatoPrimordialEntity> BuscarPatoPorId(string patoId);
}
