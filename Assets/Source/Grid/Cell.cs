using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Cell : MonoBehaviour
{
    private Ball _ball;

    public event Action CellsContainChanged;

    public Ball Ball => _ball;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Ball ball))
        {
            _ball = ball;
            CellsContainChanged?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Ball _))
        {
            _ball = null;
            CellsContainChanged?.Invoke();
        }
    }

    public void RemoveBall()
    {
        Ball.gameObject.SetActive(false);
        _ball = null;
    }
}