using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Experimental.Rendering.Universal;

public class TorchAnimation : MonoBehaviour
{
    [SerializeField]
    private bool _changeRadius; //흔들릴 때 반경까지 흔들리게 할거냐

    [SerializeField]
    private float _intensityRandom, _radiusRandom, _timeRandom;

    private float _baseIntensity;
    private float _baseTime = 0.3f;
    private float _baseRadius;

    private Sequence _mySequence = null;
    private Light2D _light;

    private void Awake()
    {
        _light = transform.Find("Light").GetComponent<Light2D>();
        _baseIntensity = _light.intensity;
        _baseRadius = _light.pointLightOuterRadius;
    }

    private void OnEnable()
    {
        ShakeLight();
    }

    private void ShakeLight()
    {
        float targetIntensity = _baseIntensity + Random.Range(-_intensityRandom, +_intensityRandom);
        float targetTime = _baseTime + Random.Range(-_timeRandom, +_timeRandom);

        if (!gameObject.activeSelf) return;
        _mySequence = DOTween.Sequence();
        _mySequence.Append(DOTween.To(
            () => _light.intensity,
            value => _light.intensity = value,
            targetIntensity,
            targetTime
         ));

        _mySequence.AppendCallback(() => ShakeLight());
    }
}
