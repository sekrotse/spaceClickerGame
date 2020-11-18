using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constant {
    // сколько процентов уровня получает игрок за убийство врага
    public const float cofLevel = 0.2f;
    // каждый указанный тут будет босс
    public const int whoIsBoss = 10;
    // рост жизней следующего врага
    public const float cofEnemy = 1.5f;
    // рост жизней босса
    public const float cofEnemyBoss = 2.5f;
    // рост урона после убийства врага
    public const int damageEnemy = 5;
    // рост урона после убийства босса
    public const int damageEnemyBoss = 10;
    // награда за врага
    public const int crystalEnemy = 50;
    // награда за босса
    public const int crystalEnemyBoss = 100;
    // рост уровня
    public const float cofUpLevel = 2f;
    // рост урона за окончание уровня
    public const int damageEndLevel = 10;
    // после какого уровня можно купить ИИ
    public const int levelII = 3;
}
