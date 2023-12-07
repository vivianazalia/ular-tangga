using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance = null;

    [SerializeField]
    private Tile _tilePrefab;
    [SerializeField]
    private Vector2Int _size;
    [SerializeField]
    private Vector2 _offsetTile;
    [SerializeField]
    private Vector2 _offsetBoard;
    [SerializeField]
    private TileSO[] _tileSO;

    private Vector2 _startPosition;
    private Vector2 _endPosition;
    private Tile[,] _tiles;
    private Vector2 _tileSize;
    private int _index;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    // Mengatur spawn papan 
    private void Start()
    {
        _tiles = new Tile[_size.x, _size.y];
        _tileSize = _tilePrefab.GetComponent<SpriteRenderer>().size;

        Vector2 totalSize = (_tileSize + _offsetTile) * _size;
        _startPosition = (Vector2)transform.position - (totalSize / 2) + _offsetBoard;
        _endPosition = _startPosition + totalSize;

        for (int i = 0; i < _size.x; i++)
        {
            for(int j = 0; j < _size.y; j++)
            {
                _index++;
                Tile obj = Instantiate(_tilePrefab, transform);
                obj.SetTile(i, j, _index, _tileSO[_index - 1]);
                obj.transform.position = new Vector2(_startPosition.y + (_tileSize.y + _offsetTile.y) * j, _startPosition.x + (_tileSize.x + _offsetTile.x) * i);
                _tiles[i, j] = obj;
            }
        }
    }

    public Vector3 GetTilePosition(int id)
    {
        for (int i = 0; i < _size.x; i++)
        {
            for (int j = 0; j < _size.y; j++)
            {
                if (_tiles[i, j].ID == id)
                    return _tiles[i, j].transform.position;
            }
        }

        return Vector3.zero;
    }

    // Untuk cek apakah kotak saat ini berupa kartu spesial, tangga, atau ular
    public void CheckTile(int id)
    {
        for (int i = 0; i < _size.x; i++)
        {
            for (int j = 0; j < _size.y; j++)
            {
                if (_tiles[i, j].ID == id)
                {
                    if (_tiles[i, j].CheckTileType() == TileType.SpesialCard)
                    {
                        CardUI.OnSetDataCard?.Invoke(_tiles[i,j].TileSO.card);
                    } 
                    else if(_tiles[i, j].CheckTileType() == TileType.Ladder)
                    {
                        int offset = _tiles[i, j].TileSO.tileDestination - id;
                        PlayerController.OnPlayerMoveUp?.Invoke(offset);
                    } 
                    else if(_tiles[i, j].CheckTileType() == TileType.Snake)
                    {
                        int offset = id - _tiles[i, j].TileSO.tileDestination;
                        PlayerController.OnPlayerMoveDown?.Invoke(offset);
                    }
                }
            }
        }
    }
}
