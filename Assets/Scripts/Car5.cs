using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Car5 : MonoBehaviour
{
    public float MoveSpeed;
    private Vector3 MoveForce;
    public float MaxSpeed;
    public float steerAngle;
    bool MovingForward;
    public float Drag;
    bool MovingRight;
    bool MovingLeft;
    public GameObject SmokeParticle1, SmokeParticle2;
    private void FixedUpdate()
    {
        
        if (MovingRight)
        {
            float steerInput = 1;
            transform.Rotate(Vector3.up * steerInput * MoveForce.magnitude * steerAngle * Time.deltaTime);
            SmokeParticle1.GetComponent<ParticleSystem>().Play();
            SmokeParticle2.GetComponent<ParticleSystem>().Play();
            SmokeParticle1.GetComponent<ParticleSystem>().loop = true;
            SmokeParticle2.GetComponent<ParticleSystem>().loop = true;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 30), 170 * Time.deltaTime);
        }
        else 
        if (MovingLeft)
        {
            float steerInput = -1;
            transform.Rotate(Vector3.up * steerInput * MoveForce.magnitude * steerAngle * Time.deltaTime);
            SmokeParticle1.GetComponent<ParticleSystem>().Play();
            SmokeParticle2.GetComponent<ParticleSystem>().Play();
            SmokeParticle1.GetComponent<ParticleSystem>().loop = true;
            SmokeParticle2.GetComponent<ParticleSystem>().loop = true;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, -30), 170 * Time.deltaTime);
        }
        else
        {
            SmokeParticle1.GetComponent<ParticleSystem>().loop = false;
            SmokeParticle2.GetComponent<ParticleSystem>().loop = false;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0), 170 * Time.deltaTime);
        }

        MoveForce += transform.forward * Time.deltaTime * MoveSpeed;
        transform.position += MoveForce * Time.deltaTime;
        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, MaxSpeed);
        /*
        MoveForce += transform.forward * Time.deltaTime*MoveSpeed;
        transform.position += MoveForce * Time.deltaTime;
        
          float steerInput = Input.GetAxis("Horizontal");
          transform.Rotate(Vector3.up * steerInput * MoveForce.magnitude * steerAngle * Time.deltaTime);

          MoveForce *= Drag;
          MoveForce = Vector3.ClampMagnitude(MoveForce, MaxSpeed);*/
    }


    public void Right()
    {
        MovingRight = true;

    }
    public void RightNo()
    {
        MovingRight = false;
    }
    public void Left()
    {
        MovingLeft = true;

    }
    public void LeftNo()
    {
        MovingLeft = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn")
        {
            SceneManager.LoadScene(0);
        }
    }
}
