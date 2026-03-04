using UnityEngine;

public class Enemy_Movment : MonoBehaviour
{
    public float speed = 2f;
    public Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject aa = GameObject.FindWithTag("Tower");
        target = aa.transform;

    }

    // Update is called once per frame
    void Update()
    {
        if(target)
        {
            Vector2 direc = (target.position - transform.position).normalized;
            transform.Translate(direc * speed * Time.deltaTime);

        }
        
    }
}
