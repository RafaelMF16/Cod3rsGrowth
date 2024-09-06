using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.EnumGenero;
using Cod3rsGrowth.Infra.Interfaces;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Validadores
{
    public class JogoValidador : AbstractValidator<Jogo>
    {
        private readonly IJogoRepositorio _jogoRepositorio;
        public JogoValidador(IJogoRepositorio jogoRepositorio)
        {
            _jogoRepositorio = jogoRepositorio;

            ClassLevelCascadeMode = CascadeMode.Continue;

            RuleFor(jogo => jogo.Nome)
                .NotEmpty()
                .WithMessage("O campo nome é obrigatório.")
                .MaximumLength(100)
                .WithMessage("Nome dever ter 100 caracteres ou menos.");

            RuleFor(jogo => jogo)
                .Must(jogo => _jogoRepositorio.VerificarSeTemNomeRepetido(jogo))
                .WithMessage("Já existe um jogo com esse nome cadastrado.");

            RuleFor(jogo => jogo.Genero)
                .IsInEnum()
                .WithMessage("O Gênero não é válido.")
                .Must((jogo, genero) => validaEnum(jogo.Genero))
                .WithMessage("O Gênero não é válido.");

            RuleFor(jogo => jogo.Preco)
                .PrecisionScale(6, 2, true)
                .WithMessage("O preço máximo é R$999,99.");
        }

        private bool validaEnum(Genero genero)
        {
            return !(genero == Genero.NAODEFINIDO);
        }
    }
}