using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class TimeController : MonoBehaviour
{
    //클래스 와 인스턴스
    //클래스 틀, 클래스를 이용해 만들어진 객체
    //학생이라는 클래스

    public static TimeController Instance;

    private void OnDestroy()
    {
        Instance = null;
    }
    private void Awake()
    {
        Instance ??= this; //after code change
    }


    public void ResetTimeScale()
    {
        StopAllCoroutines();
        Time.timeScale = 1;
    }
    public void ModifyTimeScale(float targetValue, float timeToWait, Action OnComplete= null)
    {
        StartCoroutine(TimeScaleCoroutine(targetValue, timeToWait, OnComplete));
        //StartCoroutine은 Script 쓴 곳에 상속
    }
    IEnumerator TimeScaleCoroutine(float targetValue, float timeToWait, Action OnComplete = null)
    {
        yield return new WaitForSecondsRealtime(timeToWait); //timeScale에 영향 X
        Time.timeScale = targetValue;
        OnComplete?.Invoke();
    }
}
