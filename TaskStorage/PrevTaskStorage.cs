using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrevTaskStorage
{
    private List<Sprite> _usedSpritesAsTask = new List<Sprite>();
    private int _maxAmountOfTasks = 0;

    public List<Sprite> UsedSpritesAsTask { get => _usedSpritesAsTask; set => _usedSpritesAsTask = value; }
    public int MaxAmountOfTasks { get => _maxAmountOfTasks; set => _maxAmountOfTasks = value; }

    public void CountAmountOfPossibleTasks(CardBundle[] cardBundles)
    {
        int spriteCount = 0;
        foreach (CardBundle cardBundle in cardBundles)
        {
            foreach (Sprite sprite in cardBundle.Sprites)
            {
                spriteCount++;
            }
        }
        _maxAmountOfTasks = spriteCount;
    }

    public int CheckNewTask(Sprite[] cardSpriteSet)
    {
        for (int i = 0; i < cardSpriteSet.Length; i++)
        {
            if (_usedSpritesAsTask.LastIndexOf(cardSpriteSet[i]) == -1)
            {
                _usedSpritesAsTask.Add(cardSpriteSet[i]);
                return i;
            }
        }
        return -1;
    }
}
