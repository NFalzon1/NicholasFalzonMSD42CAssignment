using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{

    [SerializeField] int scoreValue = 50;
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        Destroy(otherObject.gameObject);

        FindObjectOfType<GameSession>().AddToScore(scoreValue);
    }
}
