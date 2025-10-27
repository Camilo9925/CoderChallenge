using System.Security.Cryptography;
using CoderChallenge.Application.Interfaces.Services;

namespace CoderChallenge.Application.Services;

public class ConversaoUnidadeService : IConversaoUnidadeService
{
    public float ConverterPrecisaoParaMetros(float valor, string unidade)
    {
        try
        {
            if (valor < 0)
                throw new Exception("Valor não pode ser negativo");

            var resultado = unidade?.ToLower().Trim() switch
            {
                "m" or "metro" or "metros" => valor,
                "cm" or "centimetro" or "centímetros" => valor / 100f,
                "km" or "quilometro" or "quilômetros" => valor * 1000f,
                "yd" or "yard" or "jardas" => valor * 0.9144f,
                null or "" => throw new Exception("Unidade não pode ser vazia"),
                _ => throw new Exception($"Unidade desconhecida: {unidade}")
            };

            return resultado;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Erro ao converter precisão: {ex.Message}");
            throw;
        }
    }
    public float ConverterAlturaPesParaCm(float altura, string unidade)
    {
        try
        {
            if (altura <= 0)
                throw new Exception("Altura deve ser maior que zero");

            var resultado = unidade?.ToLower().Trim() switch
            {
                "cm" or "centimetro" or "centímetros" => altura,
                "m" or "metro" or "metros" => altura * 100f,
                "ft" or "pé" or "pés" => altura * 30.48f,
                null or "" => throw new Exception("Unidade não pode ser vazia"),
                _ => throw new Exception($"Unidade desconhecida: {unidade}")
            };

            System.Console.WriteLine($"Altura convertida: {altura} {unidade} = {resultado} cm");
            return resultado;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Erro ao converter altura: {ex.Message}");
            throw;
        }
    }
    public float ConverterPesoLibrasParaGramas(float peso, string unidade)
    {
        try
        {
            if (peso <= 0)
                throw new Exception("Peso deve ser maior que zero");

            var resultado = unidade?.ToLower().Trim() switch
            {
                "g" or "grama" or "gramas" => peso,
                "kg" or "quilograma" or "quilogramas" => peso * 1000f,
                "lb" or "libra" or "libras" => peso * 453.592f,
                null or "" => throw new Exception("Unidade não pode ser vazia"),
                _ => throw new Exception($"Unidade desconhecida: {unidade}")
            };

            System.Console.WriteLine($"Peso convertido: {peso} {unidade} = {resultado} gramas");
            return resultado;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Erro ao converter peso: {ex.Message}");
            throw;
        }
    }
}