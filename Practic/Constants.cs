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

    public enum SpecialsModifiers
    {
        hardworking,    // может брать рессурсы
        lazy,           // не может брать рессурсы
        usual,          // может быть атакован
        invulnerable,   // неуязвимый
        peaceful,       // не может аттаковать
        agressive,      // может аттаковать
        experienced,    // может брать любой тип ресурса
        sprinter,       // после смерти все равно доносит ресрсы
        legend          // отменяет все модификаторы своих и вражеских воинов
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
        // популяция: рабочих=12, воинов=9, особенных=1;
        // Королева <Анна>(здоровье=17, защита=5, урон=18), цикл роста личинок 2-5 дней, может создать 2-3 королев;
        // - <продвинутый> РАБОЧИЙ 'веточка или веточка' за раз.
        // - <продвинутый забывчивый> РАБОЧИЙ 'росинка или веточка' за раз
        // - <легендарный> ВОИН
        // - <обычный аномальный> ВОИН
        // Особенное насекомое <трудолюбивый неуязвимый мирный опытный - Бабочка>(здоровье=19, защита=6):
        // может брать ресурсы (3 ресурса: листик); не может быть атакован войнами; может брать любой тип ресурса.
        red,  
        // популяция: рабочих=19, воинов=8, особенных=1;
        // Королева <Рогнеда>(здоровье=22, защита=5, урон=28), цикл роста личинок 2-3 дней, может создать 2-4 королев;
        // - <старший> РАБОЧИЙ 'росинка или росинка' за раз.
        // - <элитный опытный> РАБОЧИЙ 'веточка и камушек'
        // - <элитный> ВОИН
        // - <продвинутый толстый> ВОИН
        // Особенное насекомое <трудолюбивый обычный мирный марафонец - Толстоножка>(здоровье=28, защита=5):
        // может брать ресурсы (2 ресурса: любой); может быть атакован войнами; после смерти все равно доставляет ресурс в колонию.
        black 
        // популяция: рабочих=14, воинов=6, особенных=1;
        // Королева <Виктория>(здоровье=19, защита=7, урон=20), цикл роста личинок 3-3 дней, может создать 2-5 королев;
        // - <продвинутый> РАБОЧИЙ 'росинка или камушек' за раз.
        // - <старший спринтер> РАБОЧИЙ 'листик или камушек' за раз
        // - <продвинутый> ВОИН
        // - <старший мстительный> ВОИН
        // Особенное насекомое <ленивый обычный агрессивный легенда - Медведка>(здоровье=19, защита=7, урон=9):
        // не может брать ресурсы; может быть атакован войнами; атакует врагов(1 цель за раз и наносит 3 укуса);
        // отменяет все модификаторы своих и вражеских воинов.
    }

    public enum Resources
    {
        branch,
        leaf,
        dewDrop,
        stone
    }
}