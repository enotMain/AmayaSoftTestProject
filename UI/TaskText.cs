using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Text))]
public class TaskText : MonoBehaviour
{
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    private void Start()
    {
        FadeIn();
    }

    public void FadeIn()
    {
        _text.DOFade(1f, 10f);
    }

    public void FadeOut()
    {
        _text.DOFade(0f, 3f);
    }
}
