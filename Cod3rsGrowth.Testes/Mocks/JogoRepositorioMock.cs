using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Singletons;

namespace Cod3rsGrowth.Testes.Mocks
{
    public class JogoRepositorioMock : IJogoRepositorio
    {
        private JogoSingleton _instancia;

        public JogoRepositorioMock()
        {
            _instancia = JogoSingleton.Instancia;
        }

        public void Adicionar(Jogo jogo)
        {
            _instancia.Add(jogo);
        }

        public void Atualizar(Jogo jogoAtualizado)
        {
            var jogoDesatualizado = _instancia.Find(jogo => jogo.Id == jogoAtualizado.Id);

            var index = _instancia.IndexOf(jogoDesatualizado);

            _instancia[index] = jogoAtualizado;
        }

        public void Deletar(int id)
        {
            var jogoQueVaiSerDeletado = _instancia.Find(jogo => jogo.Id == id);

            _instancia.Remove(jogoQueVaiSerDeletado);
        }

        public Jogo ObterPorId(int id)
        {
            return _instancia.Find(x => x.Id == id);
        }

        public List<Jogo> ObterTodos(FiltroJogo? filtro = null)
        {
            var jogos = _instancia.ToList();

            if (!string.IsNullOrEmpty(filtro?.Nome))
            {
                jogos = jogos.FindAll(j => j.Nome.StartsWith(filtro.Nome, StringComparison.OrdinalIgnoreCase));
            }
            if (filtro?.Genero != null)
            {
                jogos = jogos.FindAll(j => j.Genero == filtro.Genero);
            }
            if (filtro?.Preco != null)
            {
                jogos = jogos.FindAll(j => j.Preco == filtro.Preco);
            }

            return jogos;
        }

        public bool VerificarSeTemNomeRepetido(Jogo jogo)
        {
            return !(_instancia.Exists(j => j.Nome == jogo.Nome && j.Id != jogo.Id));
        }
    }
}