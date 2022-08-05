using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAction : AIAction
{
    public override void TakeAction()
    {
        if (_aiActionData.isAttack == true)
        {
            _aiActionData.isAttack = false;
        }
        Vector2 direction = _enemyAIBrain.Target.position - transform.position;
        _aiMovementData.direction = direction.normalized;
        _aiMovementData.pointOfInterest = _enemyAIBrain.Target.position;
        //현재 공격중이지 않다면 이동 가능

        _enemyAIBrain.Move(direction.normalized, _enemyAIBrain.Target.position);
    }
}
