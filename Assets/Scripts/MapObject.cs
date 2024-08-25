using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapObject : MonoBehaviour, ISelectable
{
    private Image _image;
    private bool _selected;

    void Start()
    {
        _image = GetComponent<Image>();
    }

    public void Select()
    {
        _image.color = Color.red;
    }

    public void Deselect()
    {
        _image.color = Color.white;
    }
}
