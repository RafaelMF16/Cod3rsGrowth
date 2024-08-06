using System;
using System.ComponentModel;
using System.Reflection;

namespace Cod3rsGrowth.Servico.Servicos
{
    public static class ServicoGenero
    {
        public static string ObterDescricaoEnum(Enum enumerador)
        {
            const int posicaoInicial = 0;
            const int arrayVazio = 0;

            var campo = enumerador.GetType().GetField(enumerador.ToString())
                ?? throw new Exception($"Erro ao obter {typeof(FieldInfo)}");

            DescriptionAttribute[] atributos =
                (DescriptionAttribute[])campo.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            return atributos.Length > arrayVazio ? atributos[posicaoInicial].Description : enumerador.ToString();
        }
    }
}