using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : PoolAbleMono
{

    public ResourcesDataSO _resourceDataSO;
    private AudioSource _audioSource;
    private Collider2D _collider;
    private SpriteRenderer _spritedRenderer;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _resourceDataSO.useSound;
        _collider = GetComponent<Collider2D>();
        _spritedRenderer = GetComponent<SpriteRenderer>();

    }
    public void PickUpResource()
    {
        StartCoroutine(DestroyCoroutine());
    }
    IEnumerator DestroyCoroutine()
    {
        _collider.enabled = false;
        _spritedRenderer.enabled = false;
        _audioSource.Play();
        yield return new WaitForSeconds(_audioSource.clip.length + 0.3f);
        PoolManager.Instance.Push(this);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        transform.DOKill();
    }

    public override void Init()
    {
        _spritedRenderer.enabled = true;
        _collider.enabled = false;
    }
}
