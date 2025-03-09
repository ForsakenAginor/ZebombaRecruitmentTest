using System;
using System.Collections.Generic;
using UnityEngine;

public class BallPool : MonoBehaviour
{
    private readonly List<GameObject> _list = new List<GameObject>();
    private readonly Dictionary<BallColor, Color> _ballColors = new Dictionary<BallColor, Color>()
    {
        { BallColor.Red, Color.red},
        { BallColor.Green, Color.green},
        { BallColor.Blue, Color.blue}
    };

    [SerializeField] private BallFacade _ballPrefab;

    public void Init()
    {
        int amount = 10;
        AddBallsToPool(amount);
    }

    public Rigidbody2D GetBall()
    {
        if(_list.Count == 0)
        {
            int amount = 2;
            AddBallsToPool(amount);
        }

        int index = UnityEngine.Random.Range(0, _list.Count);
        var ball = _list[index];
        _list.Remove(ball);
        ball.SetActive(true);
        return ball.GetComponent<Rigidbody2D>();
    }

    private void AddBallsToPool(int amount)
    {
        foreach (var color in Enum.GetValues(typeof(BallColor)))
        {
            BallColor ballColor = (BallColor)color;

            if (_ballColors.ContainsKey(ballColor) == false)
                throw new Exception("Can't associate sprite color with BallColor enum value");

            for (int i = 0; i < amount; i++)
            {
                var ball = Instantiate(_ballPrefab);
                ball.gameObject.SetActive(false);
                ball.Init(ballColor, ReturnToPool, _ballColors[ballColor]);
                _list.Add(ball.gameObject);
            }
        }
    }

    private void ReturnToPool(GameObject gameObject)
    {
        _list.Add(gameObject);
    }
}