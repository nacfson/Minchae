using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class FeedBack : MonoBehaviour
{
    public abstract void CreateFeedBack(); //현재 피드백 실행
    public abstract void CompletePrevFeedBack(); //이전 피드백 종료

    protected virtual void OnDestroy()
    {
        CompletePrevFeedBack();
    }

    protected virtual void OnDisable()
    {
        CompletePrevFeedBack();
    }
}
