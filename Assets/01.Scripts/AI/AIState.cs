using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour
{
    private EnemyAIBrain _enemyAIBrain = null;
    [SerializeField] private List<AIAction> _actions = null;
    [SerializeField]
    private List<AITransition> _transition = null;

    private void Awake()
    {
        _enemyAIBrain = transform.parent.parent.GetComponent<EnemyAIBrain>();

    }
    public void UpdateState()
    {
        foreach(AIAction a in _actions)
        {
            a.TakeAction();
        }

        foreach(AITransition tr in _transition)
        {
            bool result = false;
            foreach(AIDecision d in tr.decisions)
            {
                result = d.MakeADecision();
                if (result == false) break;
            }
            if(result == true)
            {
                if(tr.positiveState != null)
                {
                    _enemyAIBrain.ChangeState(tr.positiveState);
                    //enemybrain 에게 통보
                    return;
                }
            }
            else
            {
                if (tr.negativeState != null)
                {
                    _enemyAIBrain.ChangeState(tr.negativeState);
                    //enemybrain 에게 통보
                    return;
                }
            }
        }
    }
}
