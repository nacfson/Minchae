using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LamdaTest : MonoBehaviour
{
    Action<int, int> b;
    Func<int, int> c; //�������� ���̴� �Ķ���Ͱ� ���� Ÿ��
    void Start()    
    {
        b = (int a, int b) => Debug.Log(a + b);
    }
}
