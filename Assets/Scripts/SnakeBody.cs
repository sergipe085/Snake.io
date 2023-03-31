using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SnakeBody : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer = null;

    private SnakeBody parent = null;
    private Snake parentSnake = null;

    private Vector3 posVelRef = Vector3.zero;
    private Vector3 rotVelRef = Vector3.zero;

    public Action<Transform> OnCollide = null;

    public void Initialize(Snake snake, Action<Transform> _OnCollide) {
        this.parent = snake.GetLastTail();
        this.parentSnake = snake;
        OnCollide += _OnCollide;

        SnakeBody lastTail = snake.GetLastTail();
        if (lastTail != null) {
            transform.position = lastTail.transform.position;
        }

        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutQuad);

        spriteRenderer.sortingOrder = -snake.GetLastIndex();
    }

    public void UpdatePosition() {
        if (!parent) return;

        transform.position = Vector3.SmoothDamp(transform.position, parent.transform.position, ref posVelRef, 0.3f);
        transform.up       = Vector3.SmoothDamp(transform.up, parent.transform.up, ref rotVelRef, 0.3f);
    }

    public void RandomColor() {
        spriteRenderer.color = SNAKE_CONFIG.Instance != null ? SNAKE_CONFIG.Instance.GetRandomColor() : new Color();
    }

    public Snake GetParent() {
        return parentSnake;
    }
}
