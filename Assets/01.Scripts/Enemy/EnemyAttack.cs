using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EnemyAttack : MonoBehaviour
{
    protected EnemyAIBrain _enemyAIBrain;

    public UnityEvent AttackFeedBack;

    [SerializeField] protected float _attackDelay;
    public float AttackDelay
    {
        get
        {
            return _attackDelay;
        }
        set
        {
            _attackDelay = Mathf.Clamp(value, 0.1f, 10f);
        }
    }
    protected bool _waitBeforeNextAttack;
    public bool WaitBeforeNextAttack
    {
        get
        {
            return _waitBeforeNextAttack;
        }
    }

    protected virtual void Awake()
    {
        _enemyAIBrain = GetComponent<EnemyAIBrain>();

    }

    public abstract void Attack(int damage);

    protected IEnumerator WaitBeforeAttackCoroutine()
    {
        _waitBeforeNextAttack = true;
        yield return new WaitForSeconds(_attackDelay);
        _waitBeforeNextAttack = false;
    }

}
