using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _number;
    [SerializeField]
    private Image _image;

    private int _id;
    private int _x;
    private int _y;
    private TileSO _tileSO;

    public int ID => _id;
    public TileSO TileSO => _tileSO;

    public void SetTile(int x, int y, int id, TileSO so)
    {
        _x = x;
        _y = y;
        _id = id;
        _tileSO = so;

        _number.SetText($"{_id}");

        if(_tileSO.sprite != null)
        {
            _image.sprite = _tileSO.sprite;
        }
    }

    public TileType CheckTileType()
    {
        return _tileSO.type;
    }
}
