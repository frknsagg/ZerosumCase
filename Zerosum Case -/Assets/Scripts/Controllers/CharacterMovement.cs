using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Inputs;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Image stackBar;
    private Rigidbody _rigidbody;
    private CharacterInputSystem _characterInputSystem;
    private CharacterAnimationController _characterAnimationController;
    [SerializeField] private float characterSpeed;
    private bool _isReadyToPlay;
    private bool _isReadyToMove;
    
    public int StackAmount {
        get;
        private set;
    }

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnPlaying,ActivateMovement);
        EventManager.AddHandler(GameEvent.OnIncreaseStackAmount,SetStackAmount);
        EventManager.AddHandler(GameEvent.OnLevelEnd,LevelEndAnimation);
        EventManager.AddHandler(GameEvent.OnStartLevel,OnStart);
        EventManager.AddHandler(GameEvent.OnLevelEnd,DeActivateMovement);
        EventManager.AddHandler(GameEvent.OnCollectDiamond,OnCollectDiamond);
        EventManager.AddHandler(GameEvent.OnCollisionObstacle,PushBackMovement);
        EventManager.AddHandler(GameEvent.OnUpdateStartStack,UpgradeStartStack);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnPlaying,ActivateMovement);
        EventManager.RemoveHandler(GameEvent.OnIncreaseStackAmount,SetStackAmount);
        EventManager.RemoveHandler(GameEvent.OnLevelEnd,LevelEndAnimation);
        EventManager.RemoveHandler(GameEvent.OnStartLevel,OnStart);
        EventManager.RemoveHandler(GameEvent.OnLevelEnd,DeActivateMovement);
        EventManager.RemoveHandler(GameEvent.OnCollectDiamond,OnCollectDiamond);
        EventManager.RemoveHandler(GameEvent.OnCollisionObstacle,PushBackMovement);
        EventManager.RemoveHandler(GameEvent.OnUpdateStartStack,UpgradeStartStack);
        
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _characterAnimationController = GetComponent<CharacterAnimationController>();
        _characterInputSystem = GetComponent<CharacterInputSystem>();
        
    }


    private void FixedUpdate()
    {
        
        if (_isReadyToPlay)
        {
            if (_isReadyToMove)
            {
               Move(); 
            }
        }
    }

    void Move()
    {
        ChangeRunAnimation();
        var velo = _rigidbody.velocity;
        velo.z = characterSpeed;
        velo.x = _characterInputSystem.MoveFactorX * Time.deltaTime * characterSpeed;
        _rigidbody.velocity = velo;
        _rigidbody.position = new Vector3(Mathf.Clamp(transform.position.x, -2.0f, 2.0f), _rigidbody.position.y,
            _rigidbody.position.z);
    }

    private void ActivateMovement()
    {
        _isReadyToMove = true;
        _isReadyToPlay = true;
        
    }

    private void ChangeRunAnimation()
    {
        if (StackAmount<=0)
        {
            _characterAnimationController.RunAnimation();
        }
        else
        {
            _characterAnimationController.Run2Animation();
        }
    }

    private void ChangeStackAmount(int value)
    {
        StackAmount += value;
        if (StackAmount<=0)
        {
            StackAmount = 0;
        }
        else if(StackAmount>=100)
        {
            StackAmount = 100;
        }
       
        EventManager.Broadcast(GameEvent.OnIncreaseStackAmount);
        
        
    }

    private void SetStackAmount()
    {
        stackBar.fillAmount = (float)StackAmount / 100;
    }

    private void DeActivateMovement()
    {
        _isReadyToMove = false;
        _isReadyToPlay = false;
    }

    void LevelEndAnimation()
    {
        _characterAnimationController.DanceAnimation();
        
    }

    void OnCollectDiamond()
    {
        ChangeStackAmount(10);
        
    }

    void PushBackMovement()
    {
        _isReadyToPlay = false;
        transform.DOMoveZ(transform.position.z - 5f, 2f).OnComplete((() => { _isReadyToPlay = true; }));
        ChangeStackAmount(-5);
    }

    void OnStart()
    {
        
        transform.position = new Vector3(0, 0, 1);
        StackAmount = 0;
        EventManager.Broadcast(GameEvent.OnIncreaseStackAmount);
    }

    void UpgradeStartStack()
    {
        ChangeStackAmount(5);
        SetStackAmount();
    }

   
}
