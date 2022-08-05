using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlashLightFeedBack : FeedBack
{
    [SerializeField]
    private Light2D _lightTarget = null;
    [SerializeField]
    private float _lightOnDelay = 0.01f, _lightOffDelay = 0.01f;
    [SerializeField]
    private bool _defaultState = false;

    public override void CompletePrevFeedBack()
    {
        StopAllCoroutines(); // 모든 코루틴 종료
        //현재 Mono 에 돌고 있는 코루틴만 종료
        _lightTarget.enabled = _defaultState;
    }
    IEnumerator ToggleLightCo(float time, bool result, Action Callback = null)
    {
        yield return new WaitForSeconds(time);
        _lightTarget.enabled = result;
        Callback?.Invoke();
    }

    public override void CreateFeedBack()
    {
        StartCoroutine(ToggleLightCo(_lightOnDelay, true, () => {
            StartCoroutine(ToggleLightCo(_lightOffDelay, false)); }));
    }
}
