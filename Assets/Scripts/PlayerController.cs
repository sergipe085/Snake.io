using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Snake snake = null;

    private void Start() {
        CameraController.Instance.AttachTo(snake.GetHead().transform);
    }

    private void Update() {
        SnakeBody head = snake.GetHead();
        Vector2 desiredDirection = head.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        snake.Control(desiredDirection);
    }
}
