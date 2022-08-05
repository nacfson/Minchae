using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFreezeFeedBack : FeedBack
{
    [SerializeField] private float _beforeFreezeDelay = 0.05f, _unFreezeDelay = 0.02f;

    [SerializeField]
    [Range(0, 1f)]
    private float _timeFreezeValue = 0.2f;


    public override void CompletePrevFeedBack()
    {
        if(TimeController.Instance != null)
        {
            TimeController.Instance?.ResetTimeScale();
        }
    }

    public override void CreateFeedBack()
    {
        TimeController.Instance?.ModifyTimeScale(_timeFreezeValue, _beforeFreezeDelay
            ,() =>
            {
                TimeController.Instance?.ModifyTimeScale(1, _unFreezeDelay)
                 ;
            });
    }
}
