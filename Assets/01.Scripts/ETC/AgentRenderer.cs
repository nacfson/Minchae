using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AgentRenderer : MonoBehaviour
{

    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }


    //���� �̰� OnPointerPositionChange�� ���� 
    public void FaceDirection(Vector2 pointerInput)
    {
        Vector3 direction = (Vector3)pointerInput - transform.position; //���콺 �����͸� ���� Vector
        Vector3 result = Vector3.Cross(Vector2.up,direction); 

        _spriteRenderer.flipX = result.z > 0;
        //if(result.z > 0)
        //{
        //    _spriteRenderer.flipX = true;
        //}
        //else
        //{
        //    _spriteRenderer.flipX = false;
        //}
    }
}
