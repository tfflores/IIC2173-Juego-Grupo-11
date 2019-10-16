using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public int contactDamage;

    private Transform target;
    public GameObject Player;



    void Start()
    {
        if (GameObject.Find("Player") != null)
        {
            target = GameObject.Find("Player").GetComponent<Transform>();
            Player = GameObject.Find("Player");
        }
        
    }


    void Update()
    {
        if (Player != null)
            {
            Player character = Player.GetComponent<Player>();
            if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }

            else if (Vector2.Distance(transform.position, target.position) <= stoppingDistance)
            {
                if (character.vulnerable)
                {
                    character.TakeDamage(contactDamage);
                }
                
            }
        }
        
    }
}
