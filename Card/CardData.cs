using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.Events;

public class CardData: MonoBehaviour
{
    [SerializeField] private GameObject _stars; 
    private bool _isRightAnswer = false;
    private UnityEvent _cardEvent;

    public bool IsRightAnswer { get => _isRightAnswer; set => _isRightAnswer = value; }
    public UnityEvent CardEvent => _cardEvent;

    public void DoBounceOnWrong()
    {
        transform.DOShakePosition(2.0f, strength: new Vector3(10, 0, 0),
                vibrato: 3, randomness: 1, snapping: false, fadeOut: true);
    }

    public void DoBounceOnBegin()
    {
        StartCoroutine(WaitForBounceOnBegin());
    }

    private void OnEnable()
    {
        if (_cardEvent == null) _cardEvent = new UnityEvent();
    }

    private void OnMouseDown()
    {
        if (_isRightAnswer) 
        {
            Instantiate(_stars, transform);
            StartCoroutine(StarsLiveDuration());
        } 
        else
        {
            DoBounceOnWrong();
        }    
    }

    private IEnumerator WaitForBounceOnBegin()
    {
        yield return new WaitForSeconds(0.1f);
        transform.DOPunchScale(new Vector3(-0.5f, -0.5f, -0.5f), 2f, 0, 0);
    }

    private IEnumerator StarsLiveDuration()
    {
        yield return new WaitForSeconds(2f);
        _cardEvent.Invoke();
    }
}
