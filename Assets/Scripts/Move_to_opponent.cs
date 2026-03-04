using JetBrains.Annotations;
using UnityEngine;

public class Move_to_opponent : MonoBehaviour
{
    public in_range in_Range;
    public GameObject Enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        in_Range = GameObject.FindWithTag("Tower").GetComponent<in_range>();
        Enemy = in_Range.First_enemy_in_range.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (in_Range.inrange)
        {

            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, Enemy.transform.position, 10f * Time.deltaTime);
            Rotate_towards_enemy();
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {   
        
        if (collision.gameObject.layer == 6)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);


        }
    }
    void Rotate_towards_enemy ()
    {
        Vector3 dir = Enemy.transform.position - transform.position;
        transform.up = dir;
    }
}

