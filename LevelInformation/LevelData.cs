using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelData
{
    private int _currLevel = 0;
    private Dictionary<int, int> _levelCardAmount = new Dictionary<int, int>()
    {
        { 1, 3 },
        { 2, 6 },
        { 3, 9 }
    };

    public Dictionary<int, int> LevelCardAmount => _levelCardAmount;
    public int CurrLevel => _currLevel;

    public void NextLevel()
    {
        _currLevel++;
    }

    public void ResetLevelCount()
    {
        _currLevel = 0;
    }
}