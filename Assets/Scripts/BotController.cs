using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
    [SerializeField] private Snake snake = null;

    private void Update() {
        snake.Control(new Vector2(Mathf.Cos(Time.time), Mathf.Sin(Time.time)));
    }
}
