using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIAction : MonoBehaviour
{
    protected AIActionData _aiActionData;
    protected AIMovementData _aiMovementData;

    protected EnemyAIBrain _enemyAIBrain;

    protected virtual void Awake()
    {
        _enemyAIBrain = GetComponentInParent<EnemyAIBrain>();
        _aiActionData = GetComponentInParent<AIActionData>();
        _aiMovementData = GetComponentInParent<AIMovementData>();
    }

    public abstract void TakeAction();
}
