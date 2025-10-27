using CoderChallenge.Domain.Entities;
using CoderChallenge.Infrastructure.Repository.Context;
using CoderChallenge.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace CoderChallenge.Infrastructure.Repository;

public class PatoRepository : IPatoRepository
{
    private readonly AppDbContext _context;

    public PatoRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<PatoPrimordialEntity>> ObterTodosPatos()
    {
        return await _context.PatosPrimordiais
        .Include(x => x.Superpoder)
        .Include(z => z.Localizacao)
        .ThenInclude(l => l.Precisao)
        .ToListAsync();
    }
    public async Task<PatoPrimordialEntity> ObterPatoPorId(string id)
    {
        var pato = await _context.PatosPrimordiais
            .Include(h => h.Superpoder).
            Include(x => x.Localizacao).
            ThenInclude(z => z.Precisao).
            FirstOrDefaultAsync(x => x.Id == id);

        if (pato == null)
            return null!;

        return pato;
    }

    public async Task<bool> CriarPato(PatoPrimordialEntity pato)
    {
        await _context.AddAsync(pato);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> AtualizarPato(string id, PatoPrimordialEntity pato)
    {
        var patoBanco = await _context.PatosPrimordiais
            .Include(x => x.Superpoder)
            .Include(z => z.Localizacao)
                .ThenInclude(l => l.Precisao)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (patoBanco == null)
            return false;
                
        patoBanco.AlturaCm = pato.AlturaCm;
        patoBanco.UnidadeAltura = pato.UnidadeAltura;
        patoBanco.PesoG = pato.PesoG;
        patoBanco.UnidadePeso = pato.UnidadePeso;
        patoBanco.QuantidadeMutacoes = pato.QuantidadeMutacoes;
        patoBanco.StatusHibernacao = pato.StatusHibernacao;
                
        if (pato.Superpoder != null)
        {
            if (patoBanco.Superpoder == null)
                patoBanco.Superpoder = new SuperpoderEntity();

            patoBanco.Superpoder.Nome = pato.Superpoder.Nome;
            patoBanco.Superpoder.Descricao = pato.Superpoder.Descricao;
            patoBanco.Superpoder.Classificacoes = pato.Superpoder.Classificacoes;
        }
                
        if (pato.Localizacao != null)
        {
            if (patoBanco.Localizacao == null)
                patoBanco.Localizacao = new LocalizacaoEntity();

            patoBanco.Localizacao.Cidade = pato.Localizacao.Cidade;
            patoBanco.Localizacao.Pais = pato.Localizacao.Pais;
            patoBanco.Localizacao.Latitude = pato.Localizacao.Latitude;
            patoBanco.Localizacao.Longitude = pato.Localizacao.Longitude;
            patoBanco.Localizacao.PontoReferenciaConhecido = pato.Localizacao.PontoReferenciaConhecido;

            if (pato.Localizacao.Precisao != null)
            {
                if (patoBanco.Localizacao.Precisao == null)
                    patoBanco.Localizacao.Precisao = new PrecisaoEntity();

                patoBanco.Localizacao.Precisao.Valor = pato.Localizacao.Precisao.Valor;
                patoBanco.Localizacao.Precisao.UnidadeOriginal = pato.Localizacao.Precisao.UnidadeOriginal;
                patoBanco.Localizacao.Precisao.ValorEmMetros = pato.Localizacao.Precisao.ValorEmMetros;
            }
        }

        await _context.SaveChangesAsync();
        return true;
    }


    public async Task<bool> DeletarPato(string id)
    {
        var patoBanco = await _context.PatosPrimordiais
        .Include(x => x.Localizacao)
        .ThenInclude(l => l.Precisao)
        .FirstOrDefaultAsync(x => x.Id == id);

        if (patoBanco == null)
            return false;

        _context.Remove(patoBanco);
        await _context.SaveChangesAsync();

        return true;
    }
}