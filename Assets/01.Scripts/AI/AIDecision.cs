using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIDecision : MonoBehaviour
{
    protected AIActionData _aiActionData;
    protected AIMovementData _aiMovementData;

    protected EnemyAIBrain _enemyAIBrain;

    protected virtual void Awake()
    {
        _enemyAIBrain = transform.parent.parent.parent.GetComponent<EnemyAIBrain>();
        _aiActionData = _enemyAIBrain.transform.Find("AI").GetComponent<AIActionData>();
        _aiMovementData = _enemyAIBrain.transform.Find("AI").GetComponent<AIMovementData>();
    }

    public abstract bool MakeADecision();
}
