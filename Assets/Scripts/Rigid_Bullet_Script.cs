using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rigid_Bullet_Script : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Value_1;
    public Text Value_2;
    public Text Value_3;
    public Text Value_4;
    public Text Value_5;
    public Text Value_6;
    public Text Value_7;
    public Text Value_8;
    public Text Value_9;
    public Text Value_10;
    private Rigidbody rb;
    public bool ada_Rigidbody;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Rigidbody> () != null)
        {
            rb = gameObject.GetComponent<Rigidbody>();
            string speed = (Mathf.Round(rb.velocity.magnitude * 10f)* 0.1f).ToString();
            string angularSpeed = (Mathf.Round(rb.angularVelocity.magnitude * 10f)* 0.1f).ToString();
            Value_3.text = speed + " m/s";
            Value_10.text = angularSpeed + " m/s";
            Value_2.text = "X = "+((Mathf.Round(transform.position.x * 10f)* 0.1f).ToString())+"; Y = "+((Mathf.Round(transform.position.y * 10f)* 0.1f).ToString())+"; Z = "+((Mathf.Round(transform.position.z * 10f)* 0.1f).ToString());
            ada_Rigidbody = true;
        }
        else
        {
            ada_Rigidbody = false;
        }
        
    }
}
