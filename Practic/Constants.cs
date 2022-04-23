namespace Practic
{
    public enum BasicModifiers
    {
        usual,         // health: 1, protection: 0, damage: 1, resources: 1, attackTargets: 1, bites: 1
        senior,        // health: 2, protection: 1, damage: 2, resources: 1, attackTargets: 1, bites: 1
        advanced,      // health: 6, protection: 2, damage: 4, resources: 2, attackTargets: 2, bites: 1
        elite,         // health: 8, protection: 4, damage: 3, resources: 2, attackTargets: 2, bites: 2
        legendary      // health: 10, protection: 6, damage: 4, resources: 3, attackTargets: 3, bites: 1
    }

    public enum SpecialWorkersModifiers
    {
        forgetful,      // может забыть взять ресурс из кучи +
        sprinter,       // не может быть атакован первым +
        experienced     // может брать любой тип ресурса +
    }

    public enum SpecialWarriorsModifiers
    {
        anomalistic,    // атакует своих вместо врагов +
        heavy,          // принимает все атаки на себя, здоровье и защита увеличены в двое +
        vindictive      // убивает своего убийцу, даже если он неуязвим +
    }

    public enum SpecialsModifiers
    {
        hardworking,    // может брать рессурсы +
        lazy,           // не может брать рессурсы +
        usual,          // может быть атакован +
        invulnerable,   // неуязвимый +
        peaceful,       // не может аттаковать +
        agressive,      // может аттаковать +
        experienced,    // может брать любой тип ресурса +
        sprinter,       // после смерти все равно доносит ресурсы +
        legend          // отменяет все модификаторы своих и вражеских воинов +
    }

    public enum Types
    {
        queen,
        worker,
        warrior,
        special,
    }

    public enum ColonyColors
    {
        green,
        red,
        black
    }

    public enum Resources
    {
        branch,
        leaf,
        dewDrop,
        stone
    }
}