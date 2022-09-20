using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObtacleController : MonoBehaviour
{

    private bool isLeft;
    private bool _isReady = true;
    private Sequence _sequence;
    private float _rotateSpeed;
    void Start()
    {
        DOTween.Init();
        
    }
    void FixedUpdate()
    {
        _rotateSpeed = isLeft ? 180 * -Time.deltaTime : 180 * Time.deltaTime;
       transform.Rotate(0,0,_rotateSpeed);
        if (_isReady)
        {
            _sequence = DOTween.Sequence();
            _isReady = false;
            transform.DOMoveX(isLeft ? 2 : -2, 2f).OnComplete(() =>
            {
                _sequence.Kill();
                isLeft = !isLeft;
                _isReady = true; });
        }
        
    }

  


    }

