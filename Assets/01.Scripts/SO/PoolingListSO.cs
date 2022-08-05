using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class PoolingPair
{
    public PoolAbleMono prefab;
    public int poolCount;
}



[CreateAssetMenu(menuName ="SO/System/PoolingList")]
public class PoolingListSO : ScriptableObject
{
    public List<PoolingPair> list;
}
