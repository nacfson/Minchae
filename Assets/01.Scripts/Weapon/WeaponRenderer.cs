using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponRenderer : MonoBehaviour
{
    [SerializeField]
    protected int _playerSortingOrder = 0;

    protected SpriteRenderer _spritedRenderer;

    private void Awake()
    {
        _spritedRenderer = GetComponent<SpriteRenderer>();
    }

    public void FlipSprite(bool value)
    {
        Vector3 localScale = Vector3.one;
        if(value == true)
        {
            localScale.y = -1;
        }
        transform.localScale = localScale;
    }

    public void RenderBehindHead(bool value)
    {
        if(value == true)
        {
            _spritedRenderer.sortingOrder = _playerSortingOrder - 1;
        }
        else
        {
            _spritedRenderer.sortingOrder = _playerSortingOrder + 1;
        }
    }



}
