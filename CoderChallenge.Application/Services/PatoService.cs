using CoderChallenge.Application.Interfaces;
using CoderChallenge.Application.Interfaces.Services;
using CoderChallenge.Application.Mappers;
using CoderChallenge.Arguments.Arguments.Pato;
using CoderChallenge.Domain.Common;
using CoderChallenge.Infrastructure.Repository.Interfaces;

namespace CoderChallenge.Application.Services;

public class PatoService : IPatoService
{
    private readonly IPatoRepository _repository;
    private readonly IPatoValidator _validator;
    private readonly IConversaoUnidadeService _conversaoUnidadeService;

    public PatoService(IPatoRepository repository, IPatoValidator validator, IConversaoUnidadeService conversaoUnidadeService)
    {
        _repository = repository;
        _validator = validator;
        _conversaoUnidadeService = conversaoUnidadeService;
    }

    public async Task<BaseApiResponse<List<OutputPatoPrimordial>>> ObterTodosPatos()
    {
        try
        {
            var patos = await _repository.ObterTodosPatos();

            if (patos is null || !patos.Any())
                return BaseApiResponse<List<OutputPatoPrimordial>>.Ok(new List<OutputPatoPrimordial>(), "Nenhum pato encontrado");

            foreach (var pato in patos)
                _validator.ValidarPatoExistente(pato);

            var outputs = patos
                .Select(PatoPrimordialMapper.PatoPrimordialEntityToOutput)
                .ToList();

            return BaseApiResponse<List<OutputPatoPrimordial>>.Ok(outputs, "Patos obtidos com sucesso");
        }
        catch(Exception ex)
        {
            return BaseApiResponse<List<OutputPatoPrimordial>>.Erro("Erro ao obter todos os patos", new List<string> { ex.Message });
        }
    }
    public async Task<BaseApiResponse<OutputPatoPrimordial>> ObterPatoPorId(string id)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(id))
                return BaseApiResponse<OutputPatoPrimordial>.Erro("ID do pato não pode ser vazio");

            var pato = await _repository.ObterPatoPorId(id);
            _validator.ValidarPatoExistente(pato);

            var output = PatoPrimordialMapper.PatoPrimordialEntityToOutput(pato);
            return BaseApiResponse<OutputPatoPrimordial>.Ok(output, "Pato obtido com sucesso");
        }
        catch (Exception ex)
        {
            return BaseApiResponse<OutputPatoPrimordial>.Erro("Erro ao obter pato por id", new List<string> { ex.Message });
        }
    }
    public async Task<BaseApiResponse<OutputPatoPrimordial>> CriarPato(InputPatoPrimordial input)
    {
        try
        {
            _validator.ValidarInputPato(input);

            var entity = PatoPrimordialMapper.PatoPrimordialInputToEntity(input, _conversaoUnidadeService);
            await _repository.CriarPato(entity);

            var output = PatoPrimordialMapper.PatoPrimordialEntityToOutput(entity);
            return BaseApiResponse<OutputPatoPrimordial>.Ok(output, "Pato criado com sucesso");

        } catch (Exception ex)
        {
            return BaseApiResponse<OutputPatoPrimordial>.Erro("Erro ao criar pato", new List<string> { ex.Message });
        }

    }
    public async Task<BaseApiResponse<bool>> AtualizarPato(string id, InputPatoPrimordial input)
    {
        try
        {
            _validator.ValidarInputPato(input);

            var atualizado = await _repository.AtualizarPato(id, PatoPrimordialMapper.PatoPrimordialInputToEntity(input, _conversaoUnidadeService));

            return atualizado ? BaseApiResponse<bool>.Ok(true, "Pato atualizado com sucesso") : BaseApiResponse<bool>.Erro("Falha ao atualizar pato");

        }
        catch (Exception ex) 
        {
            return BaseApiResponse<bool>.Erro("Erro ao atualizar drone", new List<string> { ex.Message });
        }
    }
    public async Task<BaseApiResponse<bool>> DeletarPato(string id)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(id))
                return BaseApiResponse<bool>.Erro("ID do pato não pode ser vazio");

            var resultado = await _repository.DeletarPato(id);

            if (!resultado)
                return BaseApiResponse<bool>.Erro("Pato não encontrado ou falha ao deletar");

            return BaseApiResponse<bool>.Ok(true, "Pato deletado com sucesso");
        }
        catch (Exception ex)
        {
            return BaseApiResponse<bool>.Erro("Erro ao deletar pato", new List<string> { ex.Message });
        }
    }
}