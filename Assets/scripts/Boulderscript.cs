using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulderscript : MonoBehaviour
{
    private Quaternion correctionQuaternion;
    [SerializeField] private float speed;
    [SerializeField] private float strafeSpeed; 
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
        Debug.Log("Gyro Enabled");
        correctionQuaternion = Quaternion.Euler(90.0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.gyro.attitude.x > 0)
        {
            Debug.Log("hmm");
        }

        Quaternion q = correctionQuaternion * GyroToUnity(Input.gyro.attitude) * new Quaternion(0, 1, 0, 0);
        this.gameObject.transform.Translate(-speed * Time.deltaTime, 0, q.x * strafeSpeed);
    }
    private Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(-q.x, q.y, -q.z, -q.w);
    }
}
