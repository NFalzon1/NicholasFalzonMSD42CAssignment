using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    [SerializeField] AudioClip shredderHRSound;

    //allows the variable to be set in the Inspector from 0 to 1
    [SerializeField] [Range(0, 1)] float shredderHRVolume = 0.5f;

    [SerializeField] int scoreValue = 5;

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.GetComponent<PolygonCollider2D>())
        {
            FindObjectOfType<GameSession>().AddToScore(scoreValue);
            
            AudioSource.PlayClipAtPoint(shredderHRSound, Camera.main.transform.position, shredderHRVolume);
        }
        Destroy(otherObject.gameObject);
    }
}
