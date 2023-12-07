using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Tile", menuName ="SO/Tile")]
public class TileSO : ScriptableObject
{
    public TileType type;
    public Sprite sprite;
    public CardSO card = null;
    public int tileDestination;
}

public enum TileType
{
    None,
    SpesialCard,
    PunishmentCard,
    Ladder,
    Snake
}
