using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    
    public float cooldowm = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        cooldowm -= Time.deltaTime;
        if (cooldowm < 0.1)
        {
            cooldowm = 2f;
            Instantiate(prefab);
        }
;    }
}
