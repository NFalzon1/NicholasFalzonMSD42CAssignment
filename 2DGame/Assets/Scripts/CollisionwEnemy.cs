using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionwEnemy : MonoBehaviour
{

    [SerializeField] float health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            Destroy(gameObject);
        }
    }
}
