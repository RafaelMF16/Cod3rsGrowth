using Cod3rsGrowth.Dominio.Entidades;
using System.Collections.Generic;

namespace Cod3rsGrowth.Infra.Singletons
{
    public class JogoSingleton : List<Jogo>
    {
        public JogoSingleton() { }

        private static JogoSingleton? _instancia;

        public static JogoSingleton Instancia
        {
            get
            {
                lock (typeof(JogoSingleton))
                {
                    if (_instancia == null)
                    {
                        _instancia = new JogoSingleton ();
                    }
                }
                return _instancia;
            }
        }
    }
}