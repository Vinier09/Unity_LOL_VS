using JetBrains.Annotations;
using UnityEngine;

public class Tower_shot : MonoBehaviour
{
    public Tower_Logic in_Range;
    public Enemy_logic Enemy_logic;
    public GameObject Enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        in_Range = GameObject.FindWithTag("Tower").GetComponent<Tower_Logic>();
        Enemy = in_Range.Target_NOW.gameObject;
        Enemy_logic = Enemy.GetComponent<Enemy_logic>();

    }

    // Update is called once per frame
    void Update()
    {
       

            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, Enemy.transform.position, 10f * Time.deltaTime);
            Rotate_towards_enemy();
       

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {   
        
        if (collision.gameObject.layer == 6)
        {
            Enemy_logic.Health -= 100;
            Destroy(gameObject);


        }
    }
    void Rotate_towards_enemy ()
    {
        Vector3 dir = Enemy.transform.position - transform.position;
        transform.up = dir;
    }
}

