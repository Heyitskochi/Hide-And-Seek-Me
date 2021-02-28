using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
 
public class TutorialPlayer : MonoBehaviour
{
 
    public GameObject Planet;
    public GameObject PlayerPlaceholder;
 
 
    public float speed = 4;
    public float JumpHeight = 1.2f;
 
    float gravity = 15;
    bool OnGround = false;
 
 
    float distanceToGround;
    Vector3 Groundnormal;
    Vector3 currentVelocity;
    
 
    private Rigidbody rb;
    public  PhotonView PV;
    // Start is called before the first frame update
    private void Awake()
    {

        rb = GetComponent<Rigidbody>();
        PV = GetComponent<PhotonView>();
    }
    void Start()
    {
        rb.freezeRotation = true;
        if(!PV.IsMine)        transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().enabled = false;
    }
 
    // Update is called once per frame
    void Update()
    {
        if (!PV.IsMine) return;
        //MOVEMENT
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        float x = Input.GetAxis("Horizontal") * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * Time.deltaTime;
        currentVelocity = new Vector3(x, 0, z).normalized * speed;

        if (runPressed)
            currentVelocity = currentVelocity * 2;


        //transform.Translate(x, 0, z);
        //Local Rotation
 
        if (Input.GetKey(KeyCode.E)) {
 
            transform.Rotate(0, 150 * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
 
            transform.Rotate(0, -150 * Time.deltaTime, 0);
        }



        //GroundControl

        Vector3 rayDownward = transform.position - Planet.transform.position;
        distanceToGround = rayDownward.magnitude;
        Groundnormal = rayDownward.normalized;
        if (distanceToGround <= 5.0f)
        {
            OnGround = true;
            rb.drag = 3;
        }
        else
        {
            OnGround = false;
            rb.drag = 0;
        }
        /*
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, -transform.up, out hit, 10)) {
 
            distanceToGround = hit.distance;
            Groundnormal = hit.normal;
 
            if (distanceToGround <= 0.05f)
            {
                OnGround = true;
            }
            else {
                OnGround = false;
            }
 
 
        }*/

        //Jump

        if (Input.GetKeyDown(KeyCode.Space) && OnGround)
        {
            rb.AddForce(transform.up * JumpHeight);

        }



    }
    private void FixedUpdate()
    {
        if (!PV.IsMine) return;
        //GRAVITY and ROTATION

        Vector3 gravDirection = (transform.position - Planet.transform.position).normalized;

        if (OnGround == false)
        {
            rb.AddForce(gravDirection * -gravity);

        }
        else
        {
            rb.AddRelativeForce(currentVelocity);
        }

        //

        Quaternion toRotation = Quaternion.FromToRotation(transform.up, Groundnormal) * transform.rotation;
        transform.rotation = toRotation;


    }


    //CHANGE PLANET

    private void OnTriggerEnter(Collider collision)
    {
        if (!PV.IsMine) return;
        if (collision.tag != "GravField") return;      //terminate if it does not have planet tag
        if (collision.transform.parent != Planet.transform) {
 
            Planet = collision.transform.parent.gameObject;
 
            Vector3 gravDirection = (transform.position - Planet.transform.position).normalized;
 
            Quaternion toRotation = Quaternion.FromToRotation(transform.up, gravDirection) * transform.rotation;
            transform.rotation = toRotation;
 
            //rb.velocity = Vector3.zero;
            rb.AddForce(gravDirection * gravity);
 
 
            PlayerPlaceholder.GetComponent<TutorialPlayerPlaceholder>().NewPlanet(Planet);
 
        }
    }
 
 
}