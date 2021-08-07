using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CardBundle
{
    [SerializeField] private string _type;
    [SerializeField] private Sprite[] _sprites;

    public string Type => _type;
    public Sprite[] Sprites => _sprites;
}
