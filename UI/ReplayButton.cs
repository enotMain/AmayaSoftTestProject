using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ReplayButton : MonoBehaviour
{    
    [SerializeField] private GameObject _fade;
    [SerializeField] private GameObject _task;
    private Button _replayButton;

    public Button ReplayButtonProp { get => _replayButton; set => _replayButton = value; }

    private void Awake()
    {
        _replayButton = GetComponent<Button>();
        _replayButton.onClick.AddListener(_fade.GetComponent<Fade>().FadeOut);
        _replayButton.onClick.AddListener(_task.GetComponent<TaskText>().FadeIn);
        _replayButton.onClick.AddListener(DisableReplayButton);
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }


    private void OnEnable()
    {
        SetCardsUnclickable();
    }

    private void SetCardsUnclickable()
    {
        GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
        if (cards != null)
        {
            foreach (GameObject card in cards)
            {
                card.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    private void DisableReplayButton()
    {
        gameObject.SetActive(false);
    }
}
