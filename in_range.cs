using UnityEditor;
using UnityEngine;

public class in_range : MonoBehaviour
{
    public CircleCollider2D CircleCollider2D;

    public GameObject pre;
    public GameObject spawnpoint;

    public bool inrange;

    public GameObject First_enemy_in_range;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.layer == 6)

        {
            inrange = true;
            Debug.Log("shot");
            Instantiate(pre, gameObject.transform.position, gameObject.transform.rotation);
            First_enemy_in_range = collision.gameObject;
            // Destroy(collision.gameObject);
        }
    }
}
