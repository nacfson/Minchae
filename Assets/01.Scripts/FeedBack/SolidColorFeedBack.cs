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
            //셰이더 그래프는 언어가 bool타입이 없기 때문에 0,1 로 true false로 구현
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
