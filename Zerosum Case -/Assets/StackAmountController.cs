using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackAmountController : MonoBehaviour

{
    [SerializeField] private GameObject character;
    [SerializeField] private Mesh diamondMesh;
    
    private Vector3 _offset;
    private void Start()
    {
        _offset = character.transform.position - transform.position;
        Debug.Log(_offset);
    }
    void Movement()
    {
        transform.position = Vector3.Lerp(transform.position, character.transform.position - _offset, 1.5f);
    }

    private void LateUpdate()
    {
        Movement();
        
    }

    void StackAmountAnimation()
    {
        var amount =(float) character.GetComponent<CharacterMovement>().StackAmount / 100;
        transform.DOScale(amount, 1).SetEase(Ease.InBounce);
    }

   

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnIncreaseStackAmount,StackAmountAnimation);
        EventManager.AddHandler(GameEvent.OnIncreaseStackAmount,ActivateController);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnIncreaseStackAmount,StackAmountAnimation);
        EventManager.RemoveHandler(GameEvent.OnIncreaseStackAmount,ActivateController);
    }

    private void ActivateMesh()
    {
        gameObject.GetComponent<MeshFilter>().mesh = diamondMesh;
    }

    private void DeactivateMesh()
    {
        gameObject.GetComponent<MeshFilter>().mesh = null;
    }

    void ActivateController()
    {
        if (character.GetComponent<CharacterMovement>().StackAmount>0)
        {
            ActivateMesh();
        }
        else
        {
            DeactivateMesh();
        }
    }
}
