using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour
{
    
    [SerializeField] private float speed = 3;
    [SerializeField] private float attack = 20;
    public GameObject goal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(-speed * Time.deltaTime, 0, 0);


    }
    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject == goal)
        {
            Debug.Log("wow");
            Destroy(this.gameObject);
            //SceneManager.LoadScene("MainMenu");
        }
        if (c.gameObject.tag == "trap")
        {
            Destroy(this.gameObject);
        }
    }
}
