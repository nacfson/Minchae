using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : EnemyAttack
{
    public override void Attack(int damage)
    {
        if(_waitBeforeNextAttack ==false)
        {
            _enemyAIBrain.AIActionData.isAttack = true;
            float range = _enemyAIBrain.Enemy.EnemyData.attackRange;
            float distance = Vector2.Distance(_enemyAIBrain.BasePosition.position, _enemyAIBrain.Target.position);
            if(distance < range)
            {
                IHittable hit = _enemyAIBrain.Target.GetComponent<IHittable>();
                hit?.GetHit(damage, gameObject);
            }
            AttackFeedBack?.Invoke();
            StartCoroutine(WaitBeforeAttackCoroutine());
        }
    }
}
