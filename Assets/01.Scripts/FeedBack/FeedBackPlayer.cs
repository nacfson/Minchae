using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedBackPlayer : MonoBehaviour
{
    [SerializeField]
    private List<FeedBack> _feedbackToPlay = null;
    public void PlayFeedBack()
    {
        FinishFeedBack(); //들어가기전 이전 피드백 종료
        foreach (FeedBack f in _feedbackToPlay)
        {
            f.CreateFeedBack();
        }
    }
    public void FinishFeedBack()
    {
        foreach(FeedBack f in _feedbackToPlay)
        {
            f.CompletePrevFeedBack();
        }
    }
}
