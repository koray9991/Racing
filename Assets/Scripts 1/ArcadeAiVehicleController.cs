using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeAiVehicleController : MonoBehaviour
{
    public enum groundCheck { rayCast, sphereCaste };
    public enum MovementMode { Velocity, AngularVelocity };
    public MovementMode movementMode;
    public groundCheck GroundCheck;
    public LayerMask drivableSurface;

    public float MaxSpeed, accelaration, turn;
    public Rigidbody rb, carBody;

    [HideInInspector]
    public RaycastHit hit;
    public AnimationCurve frictionCurve;
    public AnimationCurve turnCurve;
    public PhysicMaterial frictionMaterial;
    [Header("Visuals")]
    public Transform BodyMesh;
    public Transform[] FrontWheels = new Transform[2];
    public Transform[] RearWheels = new Transform[2];
    [HideInInspector]
    public Vector3 carVelocity;
    public GameObject ExplodeEffect;
    [Range(0, 10)]
    public float BodyTilt;
    [Header("Audio settings")]
    public AudioSource engineSound;
    [Range(0, 1)]
    public float minPitch;
    [Range(1, 3)]
    public float MaxPitch;
    public AudioSource SkidSound;

    [HideInInspector]
    public float skidWidth;

    
    private float radius;
    private Vector3 origin;

    //ai
    public Transform target;

    //Ai stuff
    [HideInInspector]
    public float TurnAI = 1f;
    [HideInInspector]
    public float SpeedAI = 1f;
    [HideInInspector]
    public float brakeAI = 0f;
    public float brakeAngle = 30f;

    private float desiredTurning;
    public GameObject Sphere,body, wheel1, wheel2, wheel3, wheel4,light;
    public bool Rot;
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        radius = rb.GetComponent<SphereCollider>().radius;
        if (movementMode == MovementMode.AngularVelocity)
        {
            Physics.defaultMaxAngularSpeed = 100;
        }
    }
    private void Update()
    {
        Visuals();
        AudioManager();

        //
        // the new method of calculating turn value
        Vector3 aimedPoint = target.position;
        aimedPoint.y = transform.position.y;
        Vector3 aimedDir = (aimedPoint - transform.position).normalized;
        Vector3 myDir = transform.forward;
        myDir.Normalize();
        desiredTurning = Mathf.Abs(Vector3.Angle(myDir, Vector3.ProjectOnPlane( aimedDir,transform.up)));
        //

        float reachedTargetDistance = 1f;
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        Vector3 dirToMovePosition = (target.position - transform.position).normalized;
        float dot = Vector3.Dot(transform.forward, dirToMovePosition);
        float angleToMove = Vector3.Angle(transform.forward, dirToMovePosition);
        if (angleToMove > brakeAngle)
        {
            if (carVelocity.z > 15)
            {
                brakeAI = 1;
            }
            else
            {
                brakeAI = 0;
            }

        }
        else { brakeAI = 0; }

        if (distanceToTarget > reachedTargetDistance)
        {

            if (dot > 0)
            {
                SpeedAI = 1f;

                float stoppingDistance = 5f;
                if (distanceToTarget < stoppingDistance)
                {
                    brakeAI = 1f;
                }
                else
                {
                    brakeAI = 0f;
                }
            }
            else
            {
                float reverseDistance = 5f;
                if (distanceToTarget > reverseDistance)
                {
                    SpeedAI = 1f;
                }
                else
                {
                    brakeAI = -1f;
                }
            }

            float angleToDir = Vector3.SignedAngle(transform.forward, dirToMovePosition, Vector3.up);

            if (angleToDir > 0)
            {
                TurnAI = 1f * turnCurve.Evaluate(desiredTurning / 90);
            }
            else
            {
                TurnAI = -1f * turnCurve.Evaluate(desiredTurning / 90);
            }

        }
        else 
        {
            if (carVelocity.z > 1f)
            {
                brakeAI = -1f;
            }
            else
            {
                brakeAI = 0f;
            }
            TurnAI = 0f;
        }


    }
    public void AudioManager()
    {
        engineSound.pitch = Mathf.Lerp(minPitch, MaxPitch, Mathf.Abs(carVelocity.z) / MaxSpeed);
        if (Mathf.Abs(carVelocity.x) > 10 && grounded())
        {
            SkidSound.mute = false;
        }
        else
        {
            SkidSound.mute = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Police" || collision.gameObject.tag == "Player")
        {
            Instantiate(ExplodeEffect, transform.position, Quaternion.identity);
            GetComponent<BoxCollider>().enabled = false;
          //  Rot = true;
            Sphere.GetComponent<SphereCollider>().enabled = false;
           // GetComponent<Rigidbody>().AddForce(Random.Range(-300, 300), Random.Range(200, 300), Random.Range(-300, 300));
            /* body.transform.parent = null;
             wheel1.transform.parent = null;
             wheel2.transform.parent = null;
             wheel3.transform.parent = null;
             wheel4.transform.parent = null;
           // Destroy(GetComponent<Rigidbody>());
            body.AddComponent<Rigidbody>();
            body.GetComponent<Rigidbody>().AddForce(Random.Range(-300, 300), Random.Range(200, 300), Random.Range(-300, 300));
            wheel1.AddComponent<Rigidbody>();
            wheel1.GetComponent<Rigidbody>().AddForce(Random.Range(-300, 300), Random.Range(200, 300), Random.Range(-300, 300));
            wheel2.AddComponent<Rigidbody>();
            wheel2.GetComponent<Rigidbody>().AddForce(Random.Range(-300, 300), Random.Range(200, 300), Random.Range(-300, 300));
            wheel3.AddComponent<Rigidbody>();
            wheel3.GetComponent<Rigidbody>().AddForce(Random.Range(-300, 300), Random.Range(200, 300), Random.Range(-300, 300));
            wheel4.AddComponent<Rigidbody>();
            wheel4.GetComponent<Rigidbody>().AddForce(Random.Range(-300, 300), Random.Range(200, 300), Random.Range(-300, 300));
            light.AddComponent<Rigidbody>();
            light.GetComponent<Rigidbody>().AddForce(Random.Range(-300, 300), Random.Range(200, 300), Random.Range(-300, 300));*/
            body.GetComponent<Rotate>().enabled = true;
            wheel1.GetComponent<Rotate>().enabled = true;
            wheel2.GetComponent<Rotate>().enabled = true;
            wheel3.GetComponent<Rotate>().enabled = true;
            wheel4.GetComponent<Rotate>().enabled = true;
            light.GetComponent<Rotate>().enabled = true;



            GetComponent<ArcadeAiVehicleController>().enabled = false;
            Destroy(gameObject,3f);
        }
    }


    void FixedUpdate()
    {
        
        carVelocity = carBody.transform.InverseTransformDirection(carBody.velocity);

        if (Mathf.Abs(carVelocity.x) > 0)
        {
            //changes friction according to sideways speed of car
            frictionMaterial.dynamicFriction = frictionCurve.Evaluate(Mathf.Abs(carVelocity.x / 100));
        }


        if (grounded())
        {
            //turnlogic
            float sign = Mathf.Sign(carVelocity.z);
            float TurnMultiplyer = turnCurve.Evaluate(carVelocity.magnitude / MaxSpeed);
            if (SpeedAI > 0.1f || carVelocity.z > 1)
            {
                carBody.AddTorque(Vector3.up * TurnAI * sign * turn * 100 * TurnMultiplyer);
            }
            else if (SpeedAI < -0.1f || carVelocity.z < -1)
            {
                carBody.AddTorque(Vector3.up * TurnAI * sign * turn * 100 * TurnMultiplyer);
            }

            //brakelogic
            if (brakeAI > 0.1f)
            {
                rb.constraints = RigidbodyConstraints.FreezeRotationX;
            }
            else
            {
                rb.constraints = RigidbodyConstraints.None;
            }

            //accelaration logic

            if (movementMode == MovementMode.AngularVelocity)
            {
                if (Mathf.Abs(SpeedAI) > 0.1f)
                {
                    rb.angularVelocity = Vector3.Lerp(rb.angularVelocity, carBody.transform.right * SpeedAI * MaxSpeed / radius, accelaration * Time.deltaTime);
                }
            }
            else if (movementMode == MovementMode.Velocity)
            {
                if (Mathf.Abs(SpeedAI) > 0.1f && brakeAI < 0.1f)
                {
                    rb.velocity = Vector3.Lerp(rb.velocity, carBody.transform.forward * SpeedAI * MaxSpeed, accelaration / 10 * Time.deltaTime);
                }
            }

            //body tilt
            carBody.MoveRotation(Quaternion.Slerp(carBody.rotation, Quaternion.FromToRotation(carBody.transform.up, hit.normal) * carBody.transform.rotation, 0.12f));
        }
        else
        {
            carBody.MoveRotation(Quaternion.Slerp(carBody.rotation, Quaternion.FromToRotation(carBody.transform.up, Vector3.up) * carBody.transform.rotation, 0.02f));
        }

    }
    public void Visuals()
    {
        //tires
        foreach (Transform FW in FrontWheels)
        {
            FW.localRotation = Quaternion.Slerp(FW.localRotation, Quaternion.Euler(FW.localRotation.eulerAngles.x,
                               30 * TurnAI, FW.localRotation.eulerAngles.z), 0.1f);
            FW.GetChild(0).localRotation = rb.transform.localRotation;
        }
        RearWheels[0].localRotation = rb.transform.localRotation;
        RearWheels[1].localRotation = rb.transform.localRotation;

        //Body
        if (carVelocity.z > 1 )
        {
            BodyMesh.localRotation = Quaternion.Slerp(BodyMesh.localRotation, Quaternion.Euler(Mathf.Lerp(0, -5, carVelocity.z / MaxSpeed),
                               BodyMesh.localRotation.eulerAngles.y, Mathf.Clamp(desiredTurning * TurnAI, -BodyTilt, BodyTilt)), 0.05f);
        }
        else
        {
            BodyMesh.localRotation = Quaternion.Slerp(BodyMesh.localRotation, Quaternion.Euler(0, 0, 0), 0.05f);
        }


    }

    public bool grounded() //checks for if vehicle is grounded or not
    {
        origin = rb.position + rb.GetComponent<SphereCollider>().radius * Vector3.up;
        var direction = -transform.up;
        var maxdistance = rb.GetComponent<SphereCollider>().radius + 0.2f;

        if (GroundCheck == groundCheck.rayCast)
        {
            if (Physics.Raycast(rb.position, Vector3.down, out hit, maxdistance, drivableSurface))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        else if (GroundCheck == groundCheck.sphereCaste)
        {
            if (Physics.SphereCast(origin, radius + 0.1f, direction, out hit, maxdistance, drivableSurface))
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        else { return false; }
    }

    private void OnDrawGizmos()
    {
        //debug gizmos
        radius = rb.GetComponent<SphereCollider>().radius;
        float width = 0.02f;
        if (!Application.isPlaying)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(rb.transform.position + ((radius + width) * Vector3.down), new Vector3(2 * radius, 2 * width, 4 * radius));
            if (GetComponent<BoxCollider>())
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireCube(transform.position, GetComponent<BoxCollider>().size);
            }

        }

    }
}
