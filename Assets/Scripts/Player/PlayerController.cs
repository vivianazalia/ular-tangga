using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    #region
    public enum BoardType
    {
        Easy,
        Hard
    }
    #endregion

    #region VARIABLES
    [SerializeField]
    private int _currentPosition = 0;
    [SerializeField]
    private BoardType _boardType;

    private int _diceResult;
    private string _playerName;

    public string PlayerName { get => _playerName; }

    public static UnityAction<int> OnPlayerMoveUp;
    public static UnityAction<int> OnPlayerMoveDown;
    #endregion

    #region BUILT-IN METHODS
    private void Awake()
    {
        OnPlayerMoveUp += MoveUp;
        OnPlayerMoveDown += MoveDown;
    }

    private void OnDestroy()
    {
        OnPlayerMoveUp -= MoveUp;
        OnPlayerMoveDown -= MoveDown;
    }
    #endregion

    // Untuk menggerakkan player
    private void MoveUp(int dice)
    {
        _currentPosition += dice;

        MovePosition();
    }

    private void MoveDown(int dice)
    {
        _currentPosition -= dice;

        MovePosition();
    }

    private void MovePosition()
    {
        if(_boardType == BoardType.Easy && _currentPosition >= 16)
        {
            _currentPosition = 16;
            ResultUI.OnWinCondition?.Invoke();
        } 
        else if(_boardType == BoardType.Hard && _currentPosition >= 36)
        {
            _currentPosition = 36;
            ResultUI.OnWinCondition?.Invoke();
        }

        Vector3 tilePosition = BoardManager.Instance.GetTilePosition(_currentPosition);
        transform.position = tilePosition;
        StartCoroutine(CheckTileDelay());
    }

    private IEnumerator CheckTileDelay()
    {
        yield return new WaitForSeconds(.1f);
        BoardManager.Instance.CheckTile(_currentPosition);
    }
}