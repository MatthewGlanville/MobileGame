using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killScript : MonoBehaviour
{
    [SerializeField] GameManager gameManager; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            gameManager.takeDmg(10);
            Debug.Log("test");
        }
    }
}
