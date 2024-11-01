using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private float health = 50;
    [SerializeField] private float maxTimer = 3.0f;
    [SerializeField] private GameObject goal;
    private float timer;
    [SerializeField] private GameObject enemy;
    private GameObject enemyClone;
    private Enemy enemyScript;
    private GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        timer = maxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            enemyClone = Instantiate (enemy,this.transform.position,Quaternion.identity);
            enemyScript = enemyClone.GetComponent<Enemy>();
            enemyScript.transform.Rotate(new Vector3(0, 180, 0));
            enemyScript.goal = goal;
            timer = maxTimer;
        }
    }
    public void knockBack(float amount)
    {
        if (enemyClone != null)
        {
            Debug.Log("this is happening");
            enemies = GameObject.FindGameObjectsWithTag("enemy");
            foreach(GameObject opponent in enemies)
            {

                opponent.transform.Translate(new Vector3(amount, 0, 0));
            }
        }
    }
}

