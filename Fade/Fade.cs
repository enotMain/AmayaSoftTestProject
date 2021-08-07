using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fade : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FadeIn()
    {
        _spriteRenderer.material.DOFade(1f, 5f);
    }

    public void FadeOut()
    {
        _spriteRenderer.material.DOFade(0f, 5f);
    }
}
