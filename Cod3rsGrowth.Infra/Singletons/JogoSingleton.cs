using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Infra.Singletons
{
    public class JogoSingleton : List<Jogo>
    {
        public JogoSingleton() { }

        private static JogoSingleton? _instancia;
        private static Object _singletonLock = new Object();

        public static JogoSingleton Instancia
        {
            get
            {
                lock (_singletonLock)
                {
                    if (_instancia == null) 
                        _instancia = new JogoSingleton();
                }
                return _instancia;
            }
        }
    }
}