using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameLogic : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsUI;
    [SerializeField] private TMP_Text _timeUI;

    [SerializeField] private BallMovement _ball;
    private Vector3 _startPosition;

    [SerializeField] private List<Transform> _coins;

    private int _numberOfCoinsCollected;
    private int _maxCoins;


    [SerializeField] private float _timeLimit;

    private float _time;

    private bool _isWorking;

    private void Awake()
    {
        _maxCoins = _coins.Count;

        _startPosition = _ball.transform.position;

        StartGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            StartGame();

        if (_isWorking)
        {
            if (_time >= _timeLimit)
            {
                Debug.Log("Время вышло! Вы проиграли!");

                StopGame();
                return;
            }

            if (_numberOfCoinsCollected == _maxCoins)
            {
                Debug.Log("Вы собрали все монеты! Вы победили!");

                StopGame();
                return;
            }

            _time += Time.deltaTime;

            _timeUI.text = _time.ToString("0.00");
        }
    }

    private void StopGame()
    {
        _isWorking = false;
    }

    private void StartGame()
    {
        foreach (var coin in _coins)
            coin.gameObject.SetActive(true);

        _maxCoins = _coins.Count;
        _numberOfCoinsCollected = 0;

        _time = 0;
        _timeUI.text = _time.ToString("0.00");

        _ball.transform.position = _startPosition;

        _isWorking = true;
    }

    public void IncreaseNumberOfCoins()
    {
        _numberOfCoinsCollected++;

        _coinsUI.text = _numberOfCoinsCollected.ToString("0");
    }

}
