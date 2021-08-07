using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSetOnBoardLogic
{
    public CardBundle TakeRandomCardBundle(SOCardBundles soCardBundles)
    {
        return soCardBundles.CardBundles[Random.Range(0, soCardBundles.CardBundles.Length)];
    }

    public Sprite[] TakeRandomCardSpriteSet(CardBundle cardBundle, int cardSetSize)
    {
        return CopyPartOfSpriteArrayToAnother(
            RandomizeSpriteArray(cardBundle.Sprites), cardSetSize);
    }

    private Sprite[] CopyPartOfSpriteArrayToAnother(Sprite[] array, int length)
    {
        Sprite[] limitedArray = new Sprite[length];
        for (int i = 0; i < length; i++)
        {
            limitedArray[i] = array[i];
        }
        return limitedArray;
    }

    private Sprite[] RandomizeSpriteArray(Sprite[] array)
    {
        List<Sprite> randomizedObjectList = new List<Sprite>();
        for (int i = 0; i < array.Length; i++)
        {
            int randomIndex = Random.Range(i, array.Length);

            Sprite tempObj = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = tempObj;

            randomizedObjectList.Add(array[i]);
        }
        return randomizedObjectList.ToArray();
    }
}
