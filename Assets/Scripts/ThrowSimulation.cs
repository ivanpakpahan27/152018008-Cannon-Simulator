using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowSimulation : MonoBehaviour
{
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
    public Text Value_11;
    public Text Value_12;

    public Transform Target;
    public float firingAngle = 45.0f;
    public float gravity = 9.8f;
    public Transform pof;
    public Transform barrel;
    public int magazineFlak = 1;

    public float _x_;
    public float _z_;

    public Transform Projectile;        
    private Transform myTransform;

    private bool rotating = true;
   
    void Awake()
    {
        myTransform = transform;      
    }

    void Update()
    { 
        // groundTarget.position = new Vector3(_x_,0.55f,_z_);

        Value_1.text = firingAngle.ToString();
        
        Value_7.text = magazineFlak.ToString();

        barrel.LookAt(new Vector3(Target.position.x, barrel.position.y, Target.position.z));

        barrel.rotation = Quaternion.Euler(-(firingAngle), barrel.eulerAngles.y, barrel.eulerAngles.z);

        myTransform.LookAt(Target);

        if (Input.GetButtonDown("Fire1"))
            {
                if (magazineFlak >= 1) 
                {
                    StartCoroutine(SimulateProjectile());
                    magazineFlak -= 1;
                    StartCoroutine(WaitTime());   
                }
            }
    }
 
    IEnumerator SimulateProjectile()
    {

        // Move projectile to the position of throwing object + add some offset if needed.
        Projectile.position = barrel.position + new Vector3(0, 0.0f, 0);
       
        // Calculate distance to target
        float target_Distance = Vector3.Distance(Projectile.position, Target.position);

        Value_9.text = (Mathf.Round(target_Distance * 10f)* 0.1f).ToString()+" m";

        // Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);
 
        // Extract the X  Y componenent of the velocity
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        Value_2.text = (Mathf.Round(Vy * 10f)* 0.1f).ToString()+" m/s";
        Value_3.text = (Mathf.Round(Vx * 10f)* 0.1f).ToString()+" m/s";
 
        // Calculate flight time.
        float flightDuration = target_Distance / Vx;

        // Rotate projectile to face the target.
        Projectile.rotation = Quaternion.LookRotation(Target.position - Projectile.position);
       
        float elapse_time = 0;
 
        while (elapse_time < flightDuration)
        {
            Projectile.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);
           
            elapse_time += Time.deltaTime;

            // Calculate Vx and Vy while t.
            float VX_ = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
            float VY_ = (Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad))-(gravity*elapse_time);
            float Vt = Mathf.Sqrt(Mathf.Pow(VX_,2)+Mathf.Pow(VY_,2));

            

            Value_4.text = (Mathf.Round(Vt * 10f)* 0.1f).ToString() + "m/s";

            // Calculate X while t.

            float X_ = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad) * elapse_time;

            Value_12.text = (Mathf.Round(X_ * 10f)* 0.1f).ToString() + "m";

            Debug.Log(elapse_time);

            Value_5.text = (Mathf.Round(elapse_time * 10f)* 0.1f).ToString() + " s";

            yield return null;
        }
    }

    IEnumerator WaitTime() 
    {
        Value_8.text = "Isi ulang...";
        yield return new WaitForSeconds(10f);
        magazineFlak = 1;
        Value_8.text = "";
        Value_1.text = "";
        Value_2.text = "";
        Value_3.text = "";
        Value_4.text = "";
        Value_5.text = "";
        Value_6.text = "";
        Value_7.text = "";
        Value_9.text = "";
        Value_10.text = "";
    }  
}
