using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    private bool _player1Turn = true;

    public bool Player1Turn { get => _player1Turn; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void ChangeTurn()
    {
        _player1Turn = !_player1Turn;
    }
}
