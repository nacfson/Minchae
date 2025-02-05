using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Define
{
//commit
    private static Camera _mainCam = null;
    public static Camera MainCam
    {
        get
        {
            if(_mainCam == null)
            {
                _mainCam = Camera.main;
                
            }
            return _mainCam;
        }
    }
    private static CinemachineVirtualCamera _cmVCam = null;
    public static CinemachineVirtualCamera VCam
    {
        get
        {
            _cmVCam ??= GameObject.FindObjectOfType<CinemachineVirtualCamera>();
            return _cmVCam;
        }
    }
}
