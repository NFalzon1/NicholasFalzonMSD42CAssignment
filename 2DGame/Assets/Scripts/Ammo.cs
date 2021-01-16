using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] float health = 100;

    [SerializeField] float shotCounter;

    [SerializeField] float minTimeBetweenShots = 0.2f;

    [SerializeField] float maxTimeBetweenShots = 3f;

    [SerializeField] GameObject deathVFX;

    [SerializeField] float explosionDuration = 1f;




    // Start is called before the first frame update
    void Start()
    {
        //generate a random number
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    private void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0f)
        {
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }



    private void OnTriggerEnter2D(Collider2D bullet)
    {
        DamageDealer DmgDeal = bullet.gameObject.GetComponent<DamageDealer>();

        if (!DmgDeal)
        {
            return;
        }

        ProcessHit(DmgDeal);

    }

    private void ProcessHit(DamageDealer dmgDeal)
    {
        health -= dmgDeal.GetDamage();

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(explosion, explosionDuration);
    }
}
