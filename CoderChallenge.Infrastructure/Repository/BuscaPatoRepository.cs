using CoderChallenge.Domain.Entities;
using CoderChallenge.Infrastructure.Repository.Context;
using CoderChallenge.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoderChallenge.Infrastructure.Repository;

public class BuscaPatoRepository : IBuscaPatoRepository
{
    private readonly AppDbContext _context;

    public BuscaPatoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PatoPrimordialEntity> BuscarPatoAleatorio()
    {
        var todosPatos = await _context.PatosPrimordiais.ToListAsync();
        if (!todosPatos.Any())
        {
            return null!;
        }
        var random = new Random();
        var patoAleatorio = todosPatos[random.Next(todosPatos.Count)];

        return patoAleatorio;
    }

    public async Task<PatoPrimordialEntity> BuscarPatoPorId(string patoId)
    {
        var pato = await _context.PatosPrimordiais.FirstOrDefaultAsync(p => p.Id == patoId);

        if (pato == null)
            return null!;

        return pato;
    }
}
