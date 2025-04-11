using System;
using UnityEngine;

namespace _Client.Player
{
    public class FootballBall : MonoBehaviour
    {
        public bool nomach = false;
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player" && !nomach)
            {
                other.GetComponent<PlayerController>().BallEnter(transform.parent.transform.GetComponent<Collider>(), this);
            }
        }

        public void afterdark()
        {
            nomach = true;
            Invoke(nameof(nomachfalse), 0.1f);
        }
        private void nomachfalse()
        {
            nomach = false;
        }
    }
}