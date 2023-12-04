using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private int _id;
    private int _x;
    private int _y;

    public int ID => _id;

    public void SetTile(int x, int y, int id)
    {
        _x = x;
        _y = y;
        _id = id;
    }
}
