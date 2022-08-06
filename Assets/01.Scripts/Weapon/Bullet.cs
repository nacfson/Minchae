using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolAbleMono
{
    protected Rigidbody2D _rigidBody;
    protected SpriteRenderer _spriteRenderer;
    protected Animator _animator;
    protected float _timeToLive;

    protected int _enemyLayer;
    protected int _obstacleLayer;

    protected bool _isDead = false; //총알 한개가 여러명에게 동시에 맞았을 떄 한명에게만 적용
    [SerializeField] protected BulletDataSO bulletDataSO;
    public BulletDataSO BulletDataSO
    {
        get
        {
            return bulletDataSO;
        }
        set
        {
            bulletDataSO = value;
        }
    }


    protected bool _isEnemy;
    public bool IsEnemy
    {
        get => _isEnemy;
        set => _isEnemy = value;
    }

    private void Awake()
    {
        _obstacleLayer = LayerMask.NameToLayer("Obstacle"); //장애물 레이어의 번호를 알아옴
        _rigidBody = GetComponent<Rigidbody2D>();
        _enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    public override void Init()
    {
        _timeToLive = 0;
        _isDead = false;
    }

    public void SetPositionAndRotation(Vector3 pos, Quaternion rot)
    {
        transform.SetPositionAndRotation(pos, rot);
    }

    private void FixedUpdate()
    {
        _timeToLive += Time.fixedDeltaTime;
     
        _rigidBody.MovePosition(transform.position + BulletDataSO.bulletSpeed * transform.right * Time.fixedDeltaTime);
        if(_timeToLive >= BulletDataSO.lifeTime)
        {
            _isDead = true;
            PoolManager.Instance.Push(this);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isDead == true) return;

        IHittable hittable = collision.GetComponent<IHittable>();

        if(hittable != null && hittable.IsEnemy == IsEnemy)
        {
            return;
        }
        
        hittable?.GetHit(bulletDataSO.damage, gameObject);


        if(collision.gameObject.layer == _obstacleLayer)
        {
            HitObstacle(collision);
        }
        if(collision.gameObject.layer == _enemyLayer)
        {
            HitEnemy(collision);
        }
        _isDead = true;
        PoolManager.Instance.Push(this);
    }

    private void HitEnemy(Collider2D col)
    {
        Vector2 randomOffset = Random.insideUnitCircle * 0.5f;
        Impact impact = PoolManager.Instance.Pop(bulletDataSO.impactEnemyPrefab.name).GetComponent<Impact>();
        Quaternion rot = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360f)));
        impact.SetPositionAndRotation(col.transform.position + (Vector3)randomOffset , rot);
        impact.SetScaleAndTime(Vector3.one * 0.7f, 0.2f);
    }

    private void HitObstacle(Collider2D col)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 10f);
        if(hit.collider != null)
        {
            Impact impact = PoolManager.Instance.Pop(bulletDataSO.impactObstaclePrefab.name) as Impact;
            Quaternion rot = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360f)));
            impact.SetPositionAndRotation(hit.point + (Vector2)transform.right * 0.5f, rot);
            impact.SetScaleAndTime(Vector3.one, 0.2f);
        }

    }


}
