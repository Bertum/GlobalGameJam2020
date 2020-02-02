using System;
using UnityEngine;

public class WaterCollision : MonoBehaviour
{
    public event Action OnGameEnd;

    private void Awake()
    {
        OnGameEnd += FindObjectOfType<GameController>().EndGame;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnGameEnd?.Invoke();
        }
    }
}
