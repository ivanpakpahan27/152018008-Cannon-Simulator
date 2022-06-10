using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Script : MonoBehaviour
{  
    public Camera camera1;
    public Camera camera2;
    public Camera camera3;
    public GameObject panel_1;
    public GameObject panel_2;
    public GameObject player1;
    public GameObject player2;
    
    void Start()
    {
        camera1.enabled = true;
        camera2.enabled = false;
        camera3.enabled = false;
        panel_1.SetActive(true);
        panel_2.SetActive(false);
        player1.SetActive(true);
        player2.SetActive(false);
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            camera1.enabled = true;
            camera2.enabled = false;
            camera3.enabled = false;
            panel_1.SetActive(true);
            panel_2.SetActive(false);
            player1.SetActive(true);
            player2.SetActive(false);
        }
        
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            camera1.enabled = false;
            camera2.enabled = true;    
            camera3.enabled = false;
            panel_1.SetActive(false);
            panel_2.SetActive(true);
            player1.SetActive(false);
            player2.SetActive(true);
        
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            camera1.enabled = false;
            camera2.enabled = false;    
            camera3.enabled = true;
            panel_1.SetActive(true);
            panel_2.SetActive(false);
            player1.SetActive(true);
            player2.SetActive(false);
        }
    }
}
