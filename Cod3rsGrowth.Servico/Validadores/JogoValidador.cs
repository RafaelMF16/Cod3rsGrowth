using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.EnumGenero;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Validadores
{
    public class JogoValidador : AbstractValidator<Jogo>
    {
        public JogoValidador()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(jogo => jogo.Id)
                .NotEmpty()
                .WithMessage("O campo id é obrigatório");

            RuleFor(jogo => jogo.Nome)
                .NotEmpty()
                .WithMessage("O campo nome é obrigatório")
                .MaximumLength(100)
                .WithMessage("Nome dever ter 100 caracteres ou menos");

            RuleFor(jogo => jogo.Genero)
                .IsInEnum()
                .WithMessage("O Gênero não é válido")
                .Must((jogo, genero) => validaEnum(jogo.Genero))
                .WithMessage("O Gênero não é válido");

            RuleFor(jogo => jogo.Preco)
                .PrecisionScale(6, 2, true)
                .WithMessage("Preco deve ter 4 digitos e duas casas decimais");
        }

        private static bool validaEnum(Genero genero)
        {
            if (genero == Genero.NAODEFINIDO)
            {
                return false;
            }
            return true;
        }
    }
}