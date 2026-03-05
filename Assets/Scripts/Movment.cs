using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 targetPosition;
    private bool isMoving = false;
    private Rigidbody2D rb;

    public GameObject Pointer;
    public GameObject projectilePrefab;
    public Transform firePoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = transform.position;
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; // Z bleibt 0, weil 2D

     
        // Rechte Maustaste → Ziel setzen
        if ( Input.GetMouseButton(1))
        {
            
          
            Pointer.transform.position = mousePos;
            targetPosition = mousePos;
            RotatePlayer(targetPosition);
            isMoving = true;
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Shoot();
        }
    }
       void Shoot()
    {
        GameObject proj = Instantiate(projectilePrefab, firePoint.position, transform.rotation);


    }


    void RotatePlayer(Vector3 target) {
        Vector3 direction = target - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }
    void FixedUpdate()
    {
        if (isMoving)
        {
            Vector2 newPos = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);

            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
            }
        }
    }
}
