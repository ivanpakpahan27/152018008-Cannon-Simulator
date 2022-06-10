using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manual_Aim : MonoBehaviour
{
    public float x;
    public float z;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(x,0.55f,z);
        
    }
}
