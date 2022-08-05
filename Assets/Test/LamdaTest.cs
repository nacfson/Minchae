using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LamdaTest : MonoBehaviour
{
    Action<int, int> b;
    Func<int, int> c; //마지막에 쓰이는 파라미터가 리턴 타입
    void Start()    
    {
        b = (int a, int b) => Debug.Log(a + b);
    }
}
