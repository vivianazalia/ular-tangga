using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    #region VARIABLES
    [SerializeField]
    private int _currentPosition = 0;

    private int _diceResult;
    private string _playerName;

    public string PlayerName { get => _playerName; }

    public static UnityAction<int> OnPlayerMove;
    #endregion

    #region BUILT-IN METHODS
    private void Awake()
    {
        OnPlayerMove += Move;
    }

    private void OnDestroy()
    {
        OnPlayerMove -= Move;
    }
    #endregion

    // Untuk menggerakkan player
    private void Move(int dice)
    {
        _currentPosition += dice;

        if(_currentPosition >= 36)
        {
            _currentPosition = 36;
        }

        Vector3 tilePosition = BoardManager.Instance.GetTilePosition(_currentPosition);
        transform.position = tilePosition;
    }
}
