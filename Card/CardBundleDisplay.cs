using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBundleDisplay : MonoBehaviour
{
    [SerializeField] private GameObject _cardData;
    [SerializeField] private SOCardBundles _cardBundles;
    [SerializeField] private Text _taskText;
    [SerializeField] private Button _replayButton;
    [SerializeField] private GameObject _fade;
    private LevelData _levelData;
    private CardSetOnBoardLogic _cardSetOnBoardLogic;
    private PrevTaskStorage _prevTaskStorage;

    private void Awake()
    {
        _levelData = new LevelData();
        _cardSetOnBoardLogic = new CardSetOnBoardLogic();
        _replayButton.onClick.AddListener(ResetLevel);
        _prevTaskStorage = new PrevTaskStorage();
    }

    private void Start()
    {
        _prevTaskStorage.CountAmountOfPossibleTasks(_cardBundles.CardBundles);
        ResetLevel();
    }

    private int GetCurrAmountOfCards(Dictionary<int, int> levelCardAmount, int currLevel)
    {
        levelCardAmount.TryGetValue(currLevel, out int cardAmount);
        return cardAmount;
    }

    private void FillPanelByCards(Sprite[] sprites, int rightAnswerIndex)
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            GameObject newCard = Instantiate(_cardData, transform);
            newCard.GetComponent<SpriteRenderer>().sprite = sprites[i];
            if (i == rightAnswerIndex) newCard.GetComponent<CardData>().IsRightAnswer = true;
            newCard.GetComponent<CardData>().CardEvent.AddListener(ResetLevel);
            if (_levelData.CurrLevel == 1) newCard.GetComponent<CardData>().DoBounceOnBegin();
        }
    }

    private void ResetLevel()
    {
        _levelData.NextLevel();
        if (_levelData.CurrLevel > _levelData.LevelCardAmount.Count)
        {
            _levelData.ResetLevelCount();
            _fade.GetComponent<Fade>().FadeIn();
            _taskText.GetComponent<TaskText>().FadeOut(); 
            _replayButton.gameObject.SetActive(true);
        } 
        else
        {
            DeleteAllCards();
            if (_prevTaskStorage.UsedSpritesAsTask.Count < _prevTaskStorage.MaxAmountOfTasks)
            {
                bool isNewTaskNotFound = true;
                Sprite[] cardSpriteSet = null;
                int randomCardSpriteIndex = 0;
                while (isNewTaskNotFound)
                {
                    cardSpriteSet = _cardSetOnBoardLogic.TakeRandomCardSpriteSet(
                        _cardSetOnBoardLogic.TakeRandomCardBundle(_cardBundles),
                        GetCurrAmountOfCards(_levelData.LevelCardAmount, _levelData.CurrLevel));
                    randomCardSpriteIndex = _prevTaskStorage.CheckNewTask(cardSpriteSet);
                    if (randomCardSpriteIndex != -1) isNewTaskNotFound = false;
                }
                FillPanelByCards(cardSpriteSet, randomCardSpriteIndex);
                _taskText.text = $"Find {cardSpriteSet[randomCardSpriteIndex].name}";
            }
            else _taskText.text = "There are no more tasks";
        }
    }

    private void DeleteAllCards()
    {
        foreach (Transform cards in transform)
        {
            Destroy(cards.gameObject);
        }
    }
}
