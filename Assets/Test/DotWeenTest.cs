using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Gondr;

public class DotWeenTest : MonoBehaviour
{

    private string a = "Hello World!";



    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0;
            
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            Sequence seq = DOTween.Sequence();
            seq.Append(transform.DOMove(worldPos, 1f).SetEase(Ease.Linear));
            seq.Append(transform.DOScale(2, 0.5f).SetLoops(2, LoopType.Yoyo));
            seq.AppendCallback(GGM);

            
            


            
        }
    }
    public void GGM()
    {
        Debug.Log("동작 종료");
        Debug.Log(a.GGM());
    }
}
