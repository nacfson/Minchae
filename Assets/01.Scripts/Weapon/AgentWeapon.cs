using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    protected Weapon _weapon; // �ڱⰡ ��� �ִ� weapon
    protected WeaponRenderer _weaponRenderer;
    protected float _desireAngle; //���Ⱑ �ٶ󺸰� �ִ� ����


    [SerializeField] private int maxTotalAmmo = 2000,_totalAmmo = 200; //200/2000 �� ������
    public bool IsReloading
    {
        get
        {
            return _isReloading;
        }
    }


    protected bool _isReloading = false;
    private ReloadGaugeUI _reloadGaugeUI = null;



    protected virtual void Awake()
    {
        AssignWeapon();
        _reloadGaugeUI ??= transform.parent.Find("ReloadBar").GetComponent<ReloadGaugeUI>();
    }
    public virtual void AssignWeapon()
    {
        _weaponRenderer = GetComponentInChildren<WeaponRenderer>();
        _weapon = GetComponentInChildren<Weapon>();
    }

    public virtual void AimWeapon(Vector2 pointerPos)
    {
        Vector3 aimDirection = (Vector3)pointerPos - transform.position;
        _desireAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        //������
        AdjustWeaponRendering();
        transform.rotation = Quaternion.AngleAxis(_desireAngle, Vector3.forward);
    }

    private void AdjustWeaponRendering()
    {
        _weaponRenderer.FlipSprite(_desireAngle > 90f || _desireAngle < - 90f);
        _weaponRenderer.RenderBehindHead(_desireAngle > 0 && _desireAngle < 180f);
    }
    public virtual void Shoot()
    {
        if(_isReloading == true)
        {

            _weapon.PlayCannotSound();


            return;
        }
        _weapon.TryShooting();
    }
    public virtual void StopShooting()
    {
        _weapon.StopShooting();
    }
    public void ReloadGun()
    {
        if(_isReloading == false&& _totalAmmo > 0 && _weapon.AmmoFull == false)
        {
            _isReloading = true;
            _weapon.StopShooting();
            StartCoroutine(ReloadCoroutine());
        }
        else
        {
            _weapon.PlayCannotSound();
        }
    }
    IEnumerator ReloadCoroutine()
    {
        _reloadGaugeUI.gameObject.SetActive(true);
        float time = 0;
        while (time <= _weapon.WeaponData.reloadTime)
        {
            _reloadGaugeUI.ReloadGageNormal(time / _weapon.WeaponData.reloadTime);
            time += Time.deltaTime;
            yield return null;
        }

        //yield return new WaitForSeconds(_weapon.WeaponData.reloadTime);
        _reloadGaugeUI.gameObject.SetActive(false);

        _weapon.PlayReloadSound();

        int reloadedAmmo = Mathf.Min(_totalAmmo, _weapon.EmptyBulletCnt);
        _totalAmmo -= reloadedAmmo;
        _weapon.Ammo += reloadedAmmo;
        _isReloading = false;
    }
}
