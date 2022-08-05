using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class TimeController : MonoBehaviour
{
    //Ŭ���� �� �ν��Ͻ�
    //Ŭ���� Ʋ, Ŭ������ �̿��� ������� ��ü
    //�л��̶�� Ŭ����

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
        //StartCoroutine�� Script �� ���� ���
    }
    IEnumerator TimeScaleCoroutine(float targetValue, float timeToWait, Action OnComplete = null)
    {
        yield return new WaitForSecondsRealtime(timeToWait); //timeScale�� ���� X
        Time.timeScale = targetValue;
        OnComplete?.Invoke();
    }
}
