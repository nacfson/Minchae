using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    [SerializeField]
    private Transform _player;
    [SerializeField]
    private PoolingListSO _poolingListSO;

    [SerializeField] private Texture2D _cursorTexture;




    [SerializeField] private float _criticalRate = 0.7f, _criticalMinDmg =1.5f,_criticalMaxDmg=2.5f;
    public bool isCritical => Random.value < _criticalRate; //0~1 까지의 난수 

    public int GetCriticalDamage(int dmg)
    {
        float ratio = Random.Range(_criticalMinDmg, _criticalMaxDmg);
        dmg = Mathf.CeilToInt(ratio * (float)dmg);
    }

    public Transform Player { get => _player; }
    private void Awake()
    {

        if(Instance != null)
        {
            Debug.LogError("Multiple GameManager is running");
        }
        Instance = this;

        PoolManager.Instance = new PoolManager(transform);
        CreatePool();
        SetCursorIcon();
        //풀링 매니저에 풀링할 것을 만들어주는 작업
    }
    private void CreatePool()
    {
        foreach(PoolingPair pp in _poolingListSO.list)
        {
            PoolManager.Instance.CreatePool(pp.prefab, pp.poolCount);
        }
    }
    private void SetCursorIcon()
    {
        Cursor.SetCursor(_cursorTexture, new Vector2(_cursorTexture.width/2f, _cursorTexture.height/2f),CursorMode.Auto);
    }
}
