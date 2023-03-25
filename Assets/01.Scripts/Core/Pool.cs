using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : PoolAbleMono
{
    private Stack<T> _pool = new Stack<T>();
    private T _prefab; //�������� �������� ����
    private Transform _parent; //�θ� ����

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
            //clone �̶�� �̸��� ������ ����
            obj.gameObject.SetActive(false);
            _pool.Push(obj);
        }
    }

}

