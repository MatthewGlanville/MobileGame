using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private float spawnTimer = 4.0f;
    [SerializeField] private float speed = 3;
    [SerializeField] private float attack = 20;
    [SerializeField] private GameObject goal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, 0, speed);

    }
    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject == goal)
        {

        }
    }
}
