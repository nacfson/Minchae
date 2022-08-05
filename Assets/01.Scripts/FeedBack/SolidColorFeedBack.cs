using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidColorFeedBack : FeedBack
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private float _flashTime = 0.1f;

    public override void CompletePrevFeedBack()
    {
        StopAllCoroutines();
        _spriteRenderer.material.SetInt("_MakeHit", 0);
    }

    public override void CreateFeedBack()
    {
        if (_spriteRenderer.material.HasProperty("_MakeHit"))
        {
            //���̴� �׷����� �� boolŸ���� ���� ������ 0,1 �� true false�� ����
            _spriteRenderer.material.SetInt("_MakeHit", 1);
            StartCoroutine(WaitBeforeChangingBack());

        }
    }
    IEnumerator WaitBeforeChangingBack()
    {
        yield return new WaitForSeconds(_flashTime);
        _spriteRenderer.material.SetInt("_MakeHit", 0);
    }



}
