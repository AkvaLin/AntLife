namespace Practic
{
    public enum BasicModifiers
    {
        usual,         // health: 1, protection: 0, damage: 1
        senior,        // health: 2, protection: 1, damage: 2
        advanced,      // health: 6, protection: 2, damage: 4
        elite,         // health: 8, protection: 4, damage: 3
        legendary      // health: 10, protection: 6, damage: 4
    }

    public enum SpecialWorkersModifiers
    {
        forgetful,      // может забыть взять ресурс из кучи
        sprinter,       // не может быть атакован первым
        experienced     // может брать любой тип ресурса
    }

    public enum SpecialWarriorsModifiers
    {
        anomalistic,    // атакует своих вместо врагов
        havy,           // принимает все атаки на себя, здоровье и защита увеличены в двое
        vindictive      // убивает своего убийцу, даже если он неуязвим
    }

    public enum Types
    {
        queen,
        worker,
        warrior,
        special
    }

    public enum QueensStats
    {
        green,         //
        red,           //
        black          //
    }
}