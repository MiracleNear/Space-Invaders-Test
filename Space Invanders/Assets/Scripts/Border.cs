using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Border : MonoBehaviour
{
    private BoxCollider2D _boxCollider2D;

    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public bool Contains(Vector2 point)
    {
        return _boxCollider2D.bounds.Contains(point);
    }
}
