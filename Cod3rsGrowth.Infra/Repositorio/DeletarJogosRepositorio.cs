using LinqToDB;

namespace Cod3rsGrowth.Infra.Repositorio
{
    public class DeletarJogosRepositorio
    {
        public static void DeletarJogosAdicionadosEmTeste(DbCod3rsGrowth bancoDeDados)
        {   
            const int numeroMaximoDeJogos = 20;
            bancoDeDados.Jogo
                .Delete(jogo => jogo.Id > numeroMaximoDeJogos);
        }
    }
}