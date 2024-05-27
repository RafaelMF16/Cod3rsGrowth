using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Infra.Singletons
{
    public sealed class TesteDeJogoSingleton : List<TesteDeJogo>
    {
        private TesteDeJogoSingleton() { }

        private static TesteDeJogoSingleton? _instancia;

        public static TesteDeJogoSingleton Instancia
        {
            get
            {
                lock (typeof(TesteDeJogoSingleton))
                {
                    if (_instancia == null)
                    {
                        _instancia = new TesteDeJogoSingleton();
                    }
                }
                return _instancia;
            }
        }
    }
}