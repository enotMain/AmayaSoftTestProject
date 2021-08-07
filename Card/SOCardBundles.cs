using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardBundles", menuName = "Card Bundles", order = 10)]
public class SOCardBundles : ScriptableObject
{
    [SerializeField] private CardBundle[] _cardBundles;

    public CardBundle[] CardBundles => _cardBundles;
}
