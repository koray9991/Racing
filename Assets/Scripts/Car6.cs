using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Car6 : MonoBehaviour
{
    public DynamicJoystick Joys;
    public float MoveSpeed;
    private Vector3 MoveForce;
    public float MaxSpeed;
    public float Drag;
    public float steerAngle;
    public GameObject SmokeParticle1,SmokeParticle2;
    float MouseXZero;

    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        MoveForce += transform.forward * Time.deltaTime*MoveSpeed;
        transform.position += MoveForce * Time.deltaTime;

       if(Input.GetAxis("Mouse X") != 0)
        {
            
            MouseXZero = 0;
            float steerInput = Joys.Horizontal;
            transform.Rotate(Vector3.up * steerInput * MoveForce.magnitude * steerAngle * Time.deltaTime);
        }
        if (Input.GetAxis("Mouse X") == 0)
        {

            MouseXZero += Time.deltaTime;
            if (MouseXZero > 0.5f)
            {   
                float steerInput = 0;
                transform.Rotate(Vector3.up * steerInput * MoveForce.magnitude * steerAngle * Time.deltaTime);
            }
            else
            {
                float steerInput = Joys.Horizontal;
                transform.Rotate(Vector3.up * steerInput * MoveForce.magnitude * steerAngle * Time.deltaTime);
            }
          
        }

        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, MaxSpeed);
        //if(transform.eulerAngles.y==)
       
        if (Joys.Horizontal<-0.9f && transform.eulerAngles.y < 30 && transform.eulerAngles.y > 20)
        {
            //  SmokeTimer += Time.deltaTime;
            MoveSpeed = 5;
           MaxSpeed = 15;
            SmokeParticle1.GetComponent<ParticleSystem>().Play();
            SmokeParticle2.GetComponent<ParticleSystem>().Play();
            SmokeParticle1.GetComponent<ParticleSystem>().loop = true;
            SmokeParticle2.GetComponent<ParticleSystem>().loop = true;
           transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 20), 170 * Time.deltaTime);


            /* if (SmokeTimer > 0)
             {
                 SmokeTimer = -0.05f;
                 Instantiate(SmokeParticle, new Vector3(transform.position.x, transform.position.y , transform.position.z - 2.2f), Quaternion.identity);
             }*/
        }
        else
        if (Joys.Horizontal >0.9f && transform.eulerAngles.y > 330 && transform.eulerAngles.y < 340)
        {
            //SmokeTimer += Time.deltaTime;
            MoveSpeed = 5;
            MaxSpeed = 15;
            SmokeParticle1.GetComponent<ParticleSystem>().Play();
            SmokeParticle2.GetComponent<ParticleSystem>().Play();
            SmokeParticle1.GetComponent<ParticleSystem>().loop = true;
            SmokeParticle2.GetComponent<ParticleSystem>().loop = true;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, -20), 170 * Time.deltaTime);

            /*if (SmokeTimer > 0)
            {
                SmokeTimer = -0.05f;
                Instantiate(SmokeParticle, new Vector3(transform.position.x, transform.position.y , transform.position.z - 2.2f), Quaternion.identity);
            }*/
        }
        else
        {
            MoveSpeed = 15;
            MaxSpeed = 30;
            SmokeParticle1.GetComponent<ParticleSystem>().loop = false;
            SmokeParticle2.GetComponent<ParticleSystem>().loop = false;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0), 1 * Time.deltaTime);


        }

       if (transform.eulerAngles.y > 180)
        {
            if (transform.eulerAngles.y <= 330)
            {
                transform.rotation = Quaternion.Euler(transform.eulerAngles.x, 330, transform.eulerAngles.z);
            }
        }
        else
        {
            if (transform.eulerAngles.y >= 30)
            {
                transform.rotation = Quaternion.Euler(transform.eulerAngles.x, 30, transform.eulerAngles.z);
            }
        }
        Debug.Log(Joys.Horizontal);
        //transform.rotation = Quaternion.Euler(0, Mathf.Clamp(transform.eulerAngles.y, 330, 30), 0);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn")
        {
            SceneManager.LoadScene(0);
        }
    }
}
