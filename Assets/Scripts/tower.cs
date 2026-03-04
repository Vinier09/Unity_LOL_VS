using UnityEngine;

public class tower : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firepoint;
    public float cooldown = 1f;
    public float attackTimer;

    public Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;
        if (target && attackTimer <= 0f)
        {
            attackTimer = cooldown;
            Instantiate(projectilePrefab, firepoint);
            Debug.Log("FirePoint positon:" + firepoint.position);
            Vector2 dirc = (target.position - firepoint.position).normalized;
            transform.position = dirc;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            target = collision.transform;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform == target)
        {
            target = null;
        }
    }
}
