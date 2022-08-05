using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T>
{
    private Stack<T> _pool = new Stack<T>();
}
