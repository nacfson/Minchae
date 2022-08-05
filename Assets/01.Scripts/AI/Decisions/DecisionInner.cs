using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionInner : AIDecision
{ 
    [SerializeField]

    [Range(0.1f,30f)]
    private float _distance = 5f;
    public float Distance
    {
        get
        {
            return _distance;
        }
        set
        {
            _distance = Mathf.Clamp(value, 0.1f, 30f);
        }
    }

    public override bool MakeADecision()
    {
        float calc = Vector3.Distance(_enemyAIBrain.Target.position,_enemyAIBrain.BasePosition.position);

        if(calc < _distance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if(UnityEditor.Selection.activeObject == gameObject)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _distance);
            Gizmos.color = Color.white;
        }
    }

#endif
}
