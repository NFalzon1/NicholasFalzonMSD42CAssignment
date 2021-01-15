using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float health = 100f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.7f;

    [SerializeField] AudioClip playerHRSound;

    //allows the variable to be set in the Inspector from 0 to 1
    [SerializeField] [Range(0, 1)] float playerHRVolume = 0.5f;

    [SerializeField] AudioClip playerBRSound;

    //allows the variable to be set in the Inspector from 0 to 1
    [SerializeField] [Range(0, 1)] float playerBRVolume = 0.5f;


    float xMin, xMax;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(playerBRSound, Camera.main.transform.position, playerBRVolume);
        SetUpMoveBoundaries(); 
    }

    // Update is called once per frame
    void Update()
    {
        Move();  
    }

    //setup the boundaries according to the camera
    private void SetUpMoveBoundaries()
    {
        //get the camera from Unity
        Camera gameCamera = Camera.main;

        //xMin = 0 xMax = 1
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }

    //moves the Player car
    private void Move()
    {
        //deltaX is updated with the movement in the x-axis 
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        //newXPos = current x-pos of player
        //+ difference in X by keyboard Input
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);


        //move the car to the newXPos
        this.transform.position = new Vector2(newXPos, transform.position.y);

    }

    private void OnTriggerEnter2D(Collider2D bullet)
    {
        DamageDealer DmgDeal = bullet.gameObject.GetComponent<DamageDealer>();

        if (!DmgDeal)
        {
            
            return;
        }
        ProcessHit(DmgDeal);
        AudioSource.PlayClipAtPoint(playerHRSound, Camera.main.transform.position, playerHRVolume);

    }

    private void ProcessHit(DamageDealer dmgDeal)
    {
        health -= dmgDeal.GetDamage();

        if (health <= 0)
        {
            Destroy(gameObject);
            FindObjectOfType<Level>().LoadGameOver();
        }
    }


}
