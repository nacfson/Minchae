using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHittable 
{

    public bool IsEnemy { get; } //프로퍼티
    public Vector3 HitPoint { get; }



    public void GetHit(int damage, GameObject damageDelaer);


}
