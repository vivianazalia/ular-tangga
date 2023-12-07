using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResultUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _winPanel;
    [SerializeField]
    private GameObject _losePanel;

    public static UnityAction OnWinCondition;
    public static UnityAction OnLoseCondition;

    private void Awake()
    {
        OnWinCondition += Win;
        OnLoseCondition += Lose;
    }

    private void OnDestroy()
    {
        OnWinCondition -= Win;
        OnLoseCondition -= Lose;
    }

    public void Win()
    {
        _winPanel.SetActive(true);
    }

    public void Lose()
    {
        _losePanel.SetActive(true);
    }
}
