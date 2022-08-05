using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITransition : MonoBehaviour
{
    public List<AIDecision> decisions;

    public AIState positiveState; // 모든 조건이 참일 경우 여기로
    public AIState negativeState;
}
