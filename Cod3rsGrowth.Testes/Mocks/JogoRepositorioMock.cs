using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Singletons;
using FluentValidation;

namespace Cod3rsGrowth.Testes.Mocks
{
    public class JogoRepositorioMock : IJogoRepositorio
    {
        private JogoSingleton _instancia;
        private readonly IValidator<Jogo> _jogoValidador;

        public JogoRepositorioMock(IValidator<Jogo> validator)
        {
            _jogoValidador = validator;

            _instancia = JogoSingleton.Instancia;
        }

        public void Adicionar(Jogo jogo)
        {
            _jogoValidador.ValidateAndThrow(jogo);

            _instancia.Add(jogo);
        }

        public void Atualizar(Jogo jogoAtualizado)
        {
            _jogoValidador.ValidateAndThrow(jogoAtualizado);

            var jogoDesatualizado = _instancia.Find(jogo => jogo.Id == jogoAtualizado.Id)
                ?? throw new Exception($"Erro ao obter jogo com id {jogoAtualizado.Id}");

            var index = _instancia.IndexOf(jogoDesatualizado);

            _instancia[index] = jogoAtualizado;
        }

        public void Deletar(int id)
        {
            var jogoQueVaiSerDeletado = _instancia.Find(jogo => jogo.Id == id)
                ?? throw new Exception($"Erro ao obter jogo com id {id}");

            _instancia.Remove(jogoQueVaiSerDeletado);
        }

        public Jogo ObterPorId(int id)
        {
            var obterJogo = _instancia.Find(x => x.Id == id)
                ?? throw new Exception($"Erro ao obter jogo com id {id}");

            return obterJogo;
        }

        public List<Jogo> ObterTodos()
        {
            return _instancia;
        }
    }
}