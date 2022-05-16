using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed;
    public float stoppingDistance;
    public float retreatDistance;
    public float freezeDistance;

    public GameObject projectile;
    public Transform player;

    private float timeBtwShots;
    public float startTimeBtwShots;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > freezeDistance)
        {
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position, player.position) > stoppingDistance && Vector2.Distance(transform.position, player.position) < freezeDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, enemySpeed * Time.deltaTime); //move enemy towards player
        }
        else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -enemySpeed * Time.deltaTime);
        }
       


        if (timeBtwShots <= 0) //if shot cooldown = 0
        {
            Instantiate(projectile, transform.position, Quaternion.identity); //shooty bullet
            timeBtwShots = startTimeBtwShots; //reset cooldown
        }
        else //cooldown != 0
        {
            timeBtwShots -= Time.deltaTime; //reduce cooldown
        }



    }
}
