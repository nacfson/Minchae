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
        //���� ���������� �ʴٸ� �̵� ����

        _enemyAIBrain.Move(direction.normalized, _enemyAIBrain.Target.position);
    }
}
