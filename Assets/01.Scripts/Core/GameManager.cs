using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    [SerializeField]
    private Transform _player;


    public Transform Player { get => _player; }
    private void Awake()
    {

        if(Instance != null)
        {
            Debug.LogError("Multiple GameManager is running");
        }
        Instance = this;

        PoolManager.Instance = new PoolManager(transform);
        //풀링 매니저에 풀링할 것을 만들어주는 작업
    }
}
