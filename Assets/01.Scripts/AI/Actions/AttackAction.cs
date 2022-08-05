using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : AIAction
{


    public override void TakeAction()
    {
        _aiMovementData.direction = Vector2.zero;
        if(_aiActionData.isAttack == false)
        {
            _enemyAIBrain.Attack();
            _aiMovementData.pointOfInterest = _enemyAIBrain.Target.position;
        }
        _enemyAIBrain.Move(_aiMovementData.direction, _aiMovementData.pointOfInterest);
    }


}
