using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelorometer : MonoBehaviour
{
    [SerializeField] private bool isFlat = true;
    private Rigidbody rigid; 
    // Start is called before the first frame update
    private void Start()
    {
        rigid = GetComponent <Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
