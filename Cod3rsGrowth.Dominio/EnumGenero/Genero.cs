using System.ComponentModel;

namespace Cod3rsGrowth.Dominio.EnumGenero
{
    public enum Genero
    {
        [Description("Não definido")]
        NAODEFINIDO,

        [Description("FPS")]
        FPS,

        [Description("Battle Royale")]
        BATTLEROYALE,

        [Description("Moba")]
        MOBA,

        [Description("RPG")]
        RPG,

        [Description("MMORPG")]
        MMORPG,

        [Description("FPA")]
        FPA,

        [Description("RTS")]
        RTS,

        [Description("PVP")]
        PVP,

        [Description("Simulador")]
        SIMULADOR,

        [Description("Sobrevivência")]
        SOBREVIVENCIA,

        [Description("TPS")]
        TPS,

        [Description("Mundo Aberto")]
        MUNDOABERTO,

        [Description("Luta")]
        LUTA,

        [Description("Corrida")]
        CORRIDA,

        [Description("Terror")]
        TERROR,

        [Description("RogueLike")]
        ROGUELIKE,

        [Description("Aventura")]
        AVENTURA
    }
}