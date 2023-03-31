using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : SnakeBody
{
    private void OnTriggerEnter2D(Collider2D col) {
        OnCollide?.Invoke(col.transform);
    }
}
