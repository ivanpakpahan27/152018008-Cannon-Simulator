using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireCannon : MonoBehaviour
{
    public GameObject cannonball;
    public float cannonballSpeed = 20;
    public Transform pof;
    public Transform barrel;
    public float scrollIncrements = 10;
    public Transform target;
    public int magazine = 1;
    public string speed;

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

    // Update is called once per frame
    void Update()
    {
        float rotateCannon = Input.GetAxis("Mouse X");
        transform.Rotate(0, rotateCannon, 0);  
        barrel.Rotate(Input.mouseScrollDelta.y * scrollIncrements, 0, 0);  

        string x = (Mathf.Round(pof.forward.x * 10f)* 0.1f).ToString();
        string y = (Mathf.Round(pof.forward.y * 10f)* 0.1f).ToString();
        string z = (Mathf.Round(pof.forward.z * 10f)* 0.1f).ToString();

        Value_1.text = "X = "+x+" Y = "+y+" Z = "+z;
        Value_7.text = magazine.ToString();

        if (Input.GetButtonDown("Fire1"))
            {
                if (magazine >= 1) 
                {
                    FireCannonball();
                    magazine -= 1;
                    StartCoroutine(WaitTime());
                    Value_8.text = "Isi ulang...";   
                }
            }

        void FireCannonball() {
            GameObject ball = Instantiate(cannonball, pof.position, Quaternion.identity);
            Rigidbody rb = ball.AddComponent<Rigidbody>();
            rb.velocity = cannonballSpeed * pof.forward;
            Debug.Log("Rb.Velocity  = "+rb.velocity);
            StartCoroutine(RemoveCannonball(ball));
        }

        IEnumerator RemoveCannonball(GameObject ball) {
            yield return new WaitForSeconds(10f);
            Value_2.text = "";
            Value_3.text = "0 m/s";
            Value_10.text = "0 m/s";
            Destroy(ball);
        }

        IEnumerator WaitTime() {
            yield return new WaitForSeconds(10f);
            magazine = 1;
            Value_8.text = "";
        }
    }
}
