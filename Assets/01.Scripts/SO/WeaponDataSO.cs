using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="SO/WEAPON/WeaponData")]
public class WeaponDataSO : ScriptableObject
{
    public BulletDataSO bulletDataSO;

    [Range(0, 999)] public int ammoCapacity = 100; // źâ ũ��

    public bool automaticFire; //������ ��� 
    [Range(0.1f, 2f)] public float weaponDelay = 0.1f; //������� �ð�
    [Range(0, 10f)] public float spreadAngle = 5f; //ź�� ������ ����

    [SerializeField] private bool _multiBulletShot = false; //�ѹ� Ŭ���� ������ �߻�
    [SerializeField] private int _bulletCount = 1;

    [Range(0.1f, 2f)] public float reloadTime = 0.1f; //������ �ð� 

    public AudioClip shootClip;
    public AudioClip outOfAmmoClip;
    public AudioClip reloadClip;

    public int GetBulletCountToSpawn()
    {
        return _multiBulletShot ? _bulletCount : 1;
    }
}
