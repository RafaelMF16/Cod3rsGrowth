using System.ComponentModel;

namespace Cod3rsGrowth.Dominio.EnumGenero
{
    public enum Genero
    {
        [Description("Padrão caso enum não seja definido")]
        NAODEFINIDO,

        [Description("Jogo de tiro em primeira pessoa")]
        FPS,

        [Description("Jogo de competição eliminatória entre jogadores em um cenário de sobrevivência")]
        BATTLEROYALE,

        [Description("Jogo de batalha em equipes dentro de arenas")]
        MOBA,

        [Description("Jogo de interpretação de personagens")]
        RPG,

        [Description("Jogo de interpretação de personagens aonde o jogador tem liberdade para explorar um mundo virtual aberto")]
        MMORPG,

        [Description("Jogo de aventura em primeira pessoa")]
        FPA,

        [Description("Jogo de estratégia em tempo real")]
        RTS,

        [Description("Jogo aonde jogadores se enfrentam em batalhas reais em um mundo virtual")]
        PVP,

        [Description("Jogo aonde uma experiência real é simulada em um mundo virtual")]
        SIMULADOR,

        [Description("Jogo que coloca jogadores em situações extremas aonde o objetivo é sobreviver")]
        SOBREVIVENCIA,

        [Description("Jogo de tiro em terceira pessoa")]
        TPS,

        [Description("Jogo que permite ao jogador explorar um mundo virtual aberto")]
        MUNDOABERTO,

        [Description("Jogo de luta")]
        LUTA
    }
}