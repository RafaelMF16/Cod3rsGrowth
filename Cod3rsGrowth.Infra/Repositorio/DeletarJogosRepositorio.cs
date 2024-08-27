using LinqToDB;

namespace Cod3rsGrowth.Infra.Repositorio
{
    public class DeletarJogosRepositorio
    {
        public static void DeletarJogosAdicionadosEmTeste(DbCod3rsGrowth bancoDeDados)
        {   
            const string nomeDoJogoQueVaiSerDeletado = "FarCry 5";
            bancoDeDados.Jogo
                .Delete(jogo => jogo.Nome == nomeDoJogoQueVaiSerDeletado);
        }
    }
}