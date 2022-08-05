using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : PoolAbleMono
{
    private Stack<T> _pool = new Stack<T>();
    private T _prefab; //오리지날 프리팹을 저장
    private Transform _parent; //부모 저장

    public Pool(T prefab, Transform parent, int count = 10)
    {
        _prefab = prefab;
        _parent = parent;

        Make(prefab, parent, count);

    }

    public void Push(T obj)
    {
        obj.gameObject.SetActive(false);
        _pool.Push(obj);
    }

    public T Pop()
    {
        T obj = null;
        if(_pool.Count <= 0)
        {
            Make(_prefab,_parent,1);
        }
        else
        {
            obj = _pool.Pop();
            obj.gameObject.SetActive(true);
        }
        return obj;
    }
    public void Make(T prefab, Transform parent,int count)
    {
        for (int i = 0; i < count; i++)
        {
            T obj = GameObject.Instantiate(prefab, parent);
            obj.gameObject.name = obj.gameObject.name.Replace("(Clone)", "");
            //clone 이라는 이름을 공백을 제거
            obj.gameObject.SetActive(false);
            _pool.Push(obj);
        }
    }

}

