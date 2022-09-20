using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnStartLevel,IdleAnimation);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnStartLevel,IdleAnimation);
    }

    public void DanceAnimation()
    {
        _animator.SetBool("Dance",true);
    }
    public void RunAnimation()
    {
        _animator.SetBool("Idle",false);
        _animator.SetBool("Run",true);
        _animator.SetBool("Run2",false);
    }
    public void Run2Animation()
    {
        _animator.SetBool("Idle",false);
        _animator.SetBool("Run",false);
        _animator.SetBool("Run2",true);
    }

    public void IdleAnimation()
    {
        _animator.SetBool("Idle",true);
        _animator.SetBool("Run",false);
        _animator.SetBool("Run2",false);
        _animator.SetBool("Dance",false);
    }
   
}
