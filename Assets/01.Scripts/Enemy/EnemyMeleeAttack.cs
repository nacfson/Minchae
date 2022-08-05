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

            Debug.Log("»Ñ¼Å");
            AttackFeedBack?.Invoke();
            StartCoroutine(WaitBeforeAttackCoroutine());
        }
    }
}
