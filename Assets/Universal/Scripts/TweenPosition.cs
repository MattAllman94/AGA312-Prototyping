using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenPosition : JMC
{
    public float tweenTime = 2f;
    public Ease ease;
    public Camera cam;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            TweenPos();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PingPong();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Hit();
        }
    }

    void TweenPos()
    {
        transform.DOMoveX(5, tweenTime).SetLoops(-1).SetEase(ease);
    }

    void PingPong()
    {
        transform.DOMoveX(5, tweenTime).SetEase(ease).OnComplete(() =>
            transform.DOMoveX(-5, tweenTime).SetEase(ease).OnComplete(() =>
            PingPong()));

    }

    private void Hit()
    {
        transform.DOPunchScale(Vector3.one * 1.5f, tweenTime, 5, -1);
        GetComponent<Renderer>().material.DOColor(Color.yellow, 0.1f).OnComplete(() =>
            GetComponent<Renderer>().material.DOColor(Color.red, tweenTime).SetEase(ease));
        cam.DOShakeRotation(0.5f, 1 , 10 , 20);
        cam.DOShakePosition(0.5f, 1 , 10 , 20);
        cam.DOFieldOfView(70, 0.3f).SetEase(ease).OnComplete(() =>
            cam.DOFieldOfView(60, 0.2f).SetEase(ease));
    }
}
