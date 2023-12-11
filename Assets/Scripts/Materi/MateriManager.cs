using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MateriManager : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> _materiList = new List<Sprite>();
    [SerializeField]
    private Image _materiImage;

    private int index = 0;

    public void OnClickRightArrow()
    {
        index++;
        if(index < _materiList.Count)
        {
            _materiImage.sprite = _materiList[index];
        }
        else
        {
            index = _materiList.Count - 1;
        }
    }

    public void OnClickLeftArrow()
    {
        index--;
        if (index > 0)
        {
            _materiImage.sprite = _materiList[index];
        }
        else
        {
            index = 0;
        }
    }
}
