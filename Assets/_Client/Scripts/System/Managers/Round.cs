using System;
using System.Collections;
using _Client.Player;
using DG.Tweening;
using FMODUnity;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace _Client.System.Managers
{
    public class Round : MonoBehaviour
    {
        [SerializeField] private int numberGoalsPlayerOne;
        [SerializeField] private int numberGoalsPlayerTwo;
        [SerializeField] private TextMeshProUGUI playerOneCounter;
        [SerializeField] private TextMeshProUGUI playerTwoCounter;
        [SerializeField] private int goalsToWin = 2;
        [SerializeField] private UnityEvent onWinPlayerOne;
        [SerializeField] private UnityEvent onWinPlayerTwo;
        [SerializeField] private TextMeshProUGUI roundTimeText;
        [SerializeField] private float roundTime;
        [SerializeField] private PlayerController playerOne;
        [SerializeField] private PlayerController playerTwo;
        [SerializeField] private GameObject ball;
        [SerializeField] private GameObject playerSpawnOne;
        [SerializeField] private GameObject playerSpawnTwo;
        [SerializeField] private GameObject ballSpawn;
        [SerializeField] private TextMeshProUGUI roundCounter;
        [SerializeField] private EventReference buzzer;
        private bool pause = true;

        private void Start()
        {
            StartCoroutine(StartRound());
        }

        private IEnumerator StartRound()
        {
            roundCounter.text = "3";
            yield return new WaitForSeconds(1f);
            roundCounter.text = "2";
            yield return new WaitForSeconds(1f);
            roundCounter.text = "1";
            yield return new WaitForSeconds(1f);
            roundCounter.text = "0";
            playerOne.SetPause(false);
            playerTwo.SetPause(false);
            pause = false;
            RuntimeManager.PlayOneShot(buzzer);
            Destroy(roundCounter);
        }
        private void Update()
        {
            if (pause) return;
            roundTime = roundTime + Time.deltaTime;
            int minutes = (int)roundTime / 60;
            int seconds = (int)roundTime % 60;
            string text = "0:00";
            if (seconds / 10 == 0)
                text = minutes + ":0" + seconds;
            else
                text = minutes + ":" + seconds;
            roundTimeText.text = text;
        }

        public void Goal(int playerId)
        {
            if (playerId == 1)
            {
                numberGoalsPlayerOne++;
                playerOneCounter.text = numberGoalsPlayerOne.ToString();
                if (numberGoalsPlayerOne >= goalsToWin)
                {
                    print("pobeda pervogo");
                }
            }
            else
            {
                numberGoalsPlayerTwo++;
                playerTwoCounter.text = numberGoalsPlayerTwo.ToString();
                if (numberGoalsPlayerTwo >= goalsToWin)
                {
                    print("pobeda vtorogo");
                }
            }
            spawnpoints();
        }
        public void spawnpoints()
        {
            playerOne.transform.position = playerSpawnOne.transform.position;
            playerTwo.transform.position = playerSpawnTwo.transform.position;
            ball.transform.position = ball.transform.position;
            RuntimeManager.PlayOneShot(buzzer);
        }
    }
}