using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioClip boom; 
    [SerializeField] private float speed = 3;
    [SerializeField] private float attack = 20;
    [SerializeField] private GameObject particleSystem;
    private GameManager gameManager;
    public GameObject goal;

    // Start is called before the first frame update
    void Start()
    {
        gameManager=Object.FindObjectOfType<GameManager>().GetComponent<GameManager>();
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
            gameManager.takeDmg(5);
            Destroy(this.gameObject);
        }
        if (c.gameObject.CompareTag("boulder")) {
            gameManager.explode(this.gameObject);
            Instantiate(particleSystem, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);

        }
        if (c.gameObject.CompareTag("trap"))
        {
            gameManager.explode(this.gameObject);
            Instantiate(particleSystem, this.transform.position, Quaternion.identity);
            Destroy(c.gameObject);
            Destroy(this.gameObject);
            
        }
       
    }
}
