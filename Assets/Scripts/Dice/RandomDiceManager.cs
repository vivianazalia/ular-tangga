using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomDiceManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _diceText;

    // Random kemunculan dadu
    public void RandomDice()
    {
        int rand = Random.Range(1, 6);
        _diceText.SetText($"{rand}");
        PlayerController.OnPlayerMoveUp?.Invoke(rand);
    }
}
