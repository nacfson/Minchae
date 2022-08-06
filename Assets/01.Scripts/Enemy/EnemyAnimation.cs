using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : AgentAnimation
{
    protected EnemyAIBrain _enemyAIBrain;
    protected readonly int _attackHash = Animator.StringToHash("Attack");
    protected readonly int _deathBoolHash = Animator.StringToHash("IsDead");

    protected override void Awake()
    {
        base.Awake();
        _enemyAIBrain = GetComponentInParent<EnemyAIBrain>();
    }

    public void SetEndOffAttackAnimation()
    {
        //여기서 브레인을 통해서 공격상태 해제
        _enemyAIBrain.AIActionData.isAttack = false;
    }

    public void PlayAttackAnimation()
    {
        _animator.SetTrigger(_attackHash);
    }

    public override void PlayDeadAnimation()
    {
        base.PlayDeadAnimation();
        _animator.SetBool(_deathBoolHash, true);
    }

    public void EndOfDeadAnimation()
    {
        _enemyAIBrain.Enemy.Die();
    }
}
