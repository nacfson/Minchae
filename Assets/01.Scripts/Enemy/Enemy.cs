using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : PoolAbleMono, IHittable, IAgent
{
    [SerializeField]
    protected EnemyDataSO _enemyData;
    public EnemyDataSO EnemyData { get => _enemyData; }

    public bool IsEnemy => true;

    public Vector3 HitPoint { get; private set; }
    [field : SerializeField]
    public int Health { get; private set; }

    [field: SerializeField]
    public UnityEvent OnDie { get; set; }
    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }


    protected bool _isDead = false;
    [SerializeField]
    protected bool _isActive = false; //?????? ????? ??????? ?????? ????????.
    protected EnemyAIBrain _brain;
    protected EnemyAttack _attack;
    protected CapsuleCollider2D _bodyCollider;
    protected SpriteRenderer _spriteRenderer;

    protected virtual void Awake()
    {
        _brain = GetComponent<EnemyAIBrain>();
        _attack = GetComponent<EnemyAttack>();
        _bodyCollider = GetComponent<CapsuleCollider2D>();
        _spriteRenderer = transform.Find("VisualSprite").GetComponent<SpriteRenderer>();
        SetEnemyData();



    }
    public override void Init()
    {
        _bodyCollider.enabled = false;
        _brain.enabled = false;
        _isActive = false;
        if (_spriteRenderer.material.HasProperty("_Dissolve"))
        {
            _spriteRenderer.material.SetFloat("_Dissolve", 0);
        }
    }
    private void Start()
    {
        Spawn();
    }
    public void Spawn()
    {
        Sequence sequence = DOTween.Sequence();
        Tween dissolve = DOTween.To(
            () => _spriteRenderer.material.GetFloat("_Dissolve"),
            x => _spriteRenderer.material.SetFloat("_Dissolve", x),
            1f,
            1f);
        sequence.Append(dissolve);
        sequence.AppendCallback(() => ActiveObject());
    }

    public void ActiveObject()
    {
        _brain.enabled = true;
        _isActive = true;
        _bodyCollider.enabled = true;
        Health = _enemyData.maxHealth;

    }
    private void SetEnemyData()
    {
        _attack.AttackDelay = _enemyData.attackDelay; //?????????? ????

        transform.Find("AI/IdleState/TranChase")
            .GetComponent<DecisionInner>().Distance = _enemyData.chaseRange;
        transform.Find("AI/ChaseState/TranIdle")
            .GetComponent<DecisionInner>().Distance = _enemyData.chaseRange;

        transform.Find("AI/ChaseState/TranAttack")
            .GetComponent<DecisionInner>().Distance = _enemyData.attackRange;
        transform.Find("AI/AttackState/TranChase")
            .GetComponent<DecisionOuter>().Distance = _enemyData.attackRange;

        Health = _enemyData.maxHealth;
    }

    public virtual void PerformAttack()
    {
        if(_isDead == false && _isActive == true)
        {
            _attack.Attack(_enemyData.damage);
        }
    }

    public void GetHit(int damage, GameObject damageDealer)
    {
        if (_isDead == true) return;


        Health -= damage;
        HitPoint = damageDealer.transform.position;

        OnGetHit?.Invoke();
        if(Health <= 0)
        {
            DeadProcess();
        }
    }


    private void DeadProcess()
    {
        Health = 0;
        _isDead = true;
        OnDie?.Invoke();
    }

    public void Die()
    {
        Destroy(gameObject);
    }


}
