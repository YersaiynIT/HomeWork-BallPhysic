using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private GameLogic _gameLogic;

    private void OnTriggerEnter(Collider other)
    {
        BallMovement ball = other.GetComponent<BallMovement>();

        if (ball != null)
        {
            _gameLogic.IncreaseNumberOfCoins();

            gameObject.SetActive(false);
        }
    }
}
