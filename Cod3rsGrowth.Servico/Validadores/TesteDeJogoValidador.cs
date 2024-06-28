using Cod3rsGrowth.Dominio.Entidades;
using FluentValidation;
using System;

namespace Cod3rsGrowth.Servico.Validadores
{
    public class TesteDeJogoValidador : AbstractValidator<TesteDeJogo>
    {
        public TesteDeJogoValidador()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(testeDeJogo => testeDeJogo.NomeResponsavelDoTeste)
                .NotEmpty()
                .WithMessage("O campo Nome do responsável do teste é obrigatório")
                .MaximumLength(50)
                .WithMessage("Nome do responsável do teste dever ter 50 caracteres ou menos");

            RuleFor(testeDeJogo => testeDeJogo.Descricao)
                .MaximumLength(250)
                .WithMessage("A descrição deve ter 250 caracteres ou menos");

            RuleFor(testeDeJogo => testeDeJogo.Nota)
                .NotEmpty()
                .WithMessage("O campo nota é obrigatório")
                .Must((jogo, nota) => validaNota(jogo.Nota))
                .WithMessage("Nota deve estar entre 0 e 10");

            RuleFor(testeDeJogo => testeDeJogo.Aprovado)
                .NotNull()
                .WithMessage("O campo aprovado é obrigatório");

            RuleFor(testeDeJogo => testeDeJogo.DataRealizacaoTeste)
                .NotEmpty()
                .WithMessage("O campo data de realização do teste é obrigatório")
                .Must(x => x == DateTime.Today)
                .WithMessage("Data de realização do teste deve ser a data atual");

            RuleFor(testeDeJogo => testeDeJogo.IdJogo)
                .NotEmpty()
                .WithMessage("O campo JogoId é obrigatório");
        }

        private static bool validaNota(decimal nota)
        {
            var menorNota = 0;
            var maiorNota = 10;
            
            return nota >= menorNota && nota <= maiorNota;
        }
    }
}