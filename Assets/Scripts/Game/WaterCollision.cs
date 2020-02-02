using System;
using UnityEngine;

public class WaterCollision : MonoBehaviour
{
    public event Action OnGameEnd;

    private void Awake()
    {
        var ctrl = FindObjectOfType<GameController>();
        if (ctrl != null) OnGameEnd += ctrl.EndGame;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.name == "Breath")
        {
            OnGameEnd?.Invoke();
        }
    }
}
