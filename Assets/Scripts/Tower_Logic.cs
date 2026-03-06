using NUnit.Framework;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Logic : MonoBehaviour
{
    public CircleCollider2D CircleCollider2D;

    public GameObject pre;
    public GameObject spawnpoint;

    public List<GameObject> Enemies_in_range = new List<GameObject>();
    public GameObject Target_NOW;
    public float cooldown;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Target_NOW == null && Enemies_in_range.Count > 0)
        {
            Target_NOW = Enemies_in_range[0];
        }
        if (Target_NOW!= null)
        {
            cooldown   += Time.deltaTime;
            if (cooldown >= 1.2)
            {
                Shot();
                cooldown = 0f;
            }

            if (Target_NOW == null)
            {
                Choose_Next_Target();
            }
        }

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.layer == 6)

        {
            Enemies_in_range.Add(collision.gameObject);
            if (Target_NOW == null)
            {
                Target_NOW = collision.gameObject;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Enemies_in_range.Remove(collision.gameObject);
            if (Target_NOW == collision.gameObject)
            {
                Target_NOW = null;
            }
        }
    }
    private void Shot()
    {
        Debug.Log("shot");
        Instantiate(pre, gameObject.transform.position, gameObject.transform.rotation);
    }
    private void Choose_Next_Target()
    {
        Enemies_in_range.RemoveAll(item => item == null);
        if (Enemies_in_range.Count > 0)
        {
            Target_NOW = Enemies_in_range[0];
        }
    }
}
