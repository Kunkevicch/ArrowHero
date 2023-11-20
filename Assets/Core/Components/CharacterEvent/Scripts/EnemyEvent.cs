using System;

namespace ArrowHero.Core
{
    public class EnemyEvent : CharacterEvent
    {
        public static event Action<Enemy> enemyDied;

        public void CallEnemyDied(Enemy enemy)
        {
            enemyDied?.Invoke(enemy);
        }
    }
}
