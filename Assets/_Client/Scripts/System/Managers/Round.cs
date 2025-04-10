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
        private void Goal(int playerId)
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
        }
    }
}