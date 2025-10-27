using CoderChallenge.Arguments.Arguments.Pato;
using CoderChallenge.Domain.Entities;

namespace CoderChallenge.Application.Interfaces;

public interface IPatoValidator
{
    void ValidarPatoExistente(PatoPrimordialEntity pato);
    void ValidarInputPato(InputPatoPrimordial input);
}
