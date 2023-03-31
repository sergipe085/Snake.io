using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

public class Snake : MonoBehaviour
{
    [Range(1, 1000)]
    [SerializeField] private int length = 15;
    [SerializeField] private SnakeBody bodyPrefab = null;
    [SerializeField] private SnakeHead headPrefab = null;

    private List<SnakeBody> body = new List<SnakeBody>();
    private Vector2 direction = Vector2.zero;

    [Header("SCORE")]
    private int score = 0;
    private int addedScore = 0;

    private void Start() {
        for (int i = 0; i < length; i++) {
            AddBody();
        }
    }

    private void IgnoreCollisions() {
        foreach(SnakeBody b in body) {

        }
    }

    private void AddBody() {   
        SnakeBody newBodyInstance = null;
        if (body.Count > 0) {
            newBodyInstance = Instantiate(bodyPrefab, transform);
            newBodyInstance.Initialize(this, null);
        }
        else {
            Debug.Log("HEAEAEAEAEADADAD");
            newBodyInstance = Instantiate(headPrefab, transform);
            newBodyInstance.Initialize(this, OnHeadCollideAction);
            CameraController.Instance.AttachTo(newBodyInstance.transform);
        }
        body.Add(newBodyInstance);
        newBodyInstance.RandomColor();
    }

    private void MoveForward() {
        SnakeBody head = GetHead();
        Vector2 desiredDirection = head.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = Vector2.Lerp(direction, desiredDirection, 5f * Time.deltaTime);

        head.transform.position -= (Vector3)direction.normalized * Time.deltaTime * 3f;
        head.transform.up = direction;
    }

    public void Move(Vector2 desiredDirection) {
        SnakeBody head = GetHead();
        // Vector2 desiredDirection = head.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = Vector2.Lerp(direction, desiredDirection, 5f * Time.deltaTime);

        head.transform.position -= (Vector3)direction.normalized * Time.deltaTime * 3f;
        head.transform.up = direction;
    }

    private void Update() {
        UpdateBodyPositions();
        MoveForward();
    }
    private void FixedUpdate() {
        UpdateBodyPositions();
    }

    private void UpdateBodyPositions() {
        for (int i = body.Count - 1; i >= 0; i--) {
            body[i].UpdatePosition();
        }
    }

    public SnakeBody GetHead() {
        if (body.Count <= 0) {
            return null;
        }

        return body[0];
    }

    public SnakeBody GetLastTail() {
        if (body.Count <= 0) {
            return null;
        }

        return body[body.Count - 1];
    }

    public int GetLastIndex() {
        return body.Count;
    }

    public void AddScore(int q) {
        score += q;
        UpdateSnakeByAddedScore(score - addedScore);
    }

    private void UpdateSnakeByAddedScore(int scoreToAdd) {
        int score = scoreToAdd - (scoreToAdd % 10);
        int length = score / 10;
        int size = score / 20;
        addedScore += score;

        if (size > 0) {
            foreach(SnakeBody b in body) {
                b.transform.DOScale(b.transform.localScale + Vector3.one * 0.1f, 0.4f).SetEase(Ease.OutQuad);
            }
        }

        for (int i = 0; i < length; i++) {
            AddBody();
        }
    }

    private void OnHeadCollideAction(Transform other) {
        if (other.TryGetComponent<ScoreBlock>(out ScoreBlock otherBlock)) {
            AddScore(otherBlock.GetScore());
            Destroy(otherBlock.transform.gameObject);
        }

        if (other.TryGetComponent<SnakeBody>(out SnakeBody otherBody)) {
            if (otherBody.GetParent() == this) return;

            Debug.Log(otherBody);
            Debug.Log(this);

            Destroy(this.gameObject);
        }
    }
}
