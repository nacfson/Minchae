using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHittable 
{

    public bool IsEnemy { get; } //������Ƽ
    public Vector3 HitPoint { get; }



    public void GetHit(int damage, GameObject damageDelaer);


}
