using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody rb3d;
    public float jumppower;
    private float lookHorizontal;
    private float lookVertical;
    public float dash;
    public float sprint;
    public float walkSpeed;
    public float runSpeed;
    public GameObject orangePortal;
    public GameObject bluePortal;
    public GameObject orangeCubePortal;
    public GameObject blueCubePortal;
    // prefabricated 
    public GameObject orangePortalPrefab;
    public GameObject bluePortalPrefab;
    public GameObject orangeCubePortalPrefab;
    public GameObject blueCubePortalPrefab;
    // Start is called before the first frame update
    void Start()
    {
        rb3d = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Spawn();
    }
    void Spawn()
    {
        //this will shoot out a ray that will check the position that it hits and will make a orange portal in that position
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = new Ray();
            ray.origin = Camera.main.transform.position;
            ray.direction = Camera.main.transform.forward;
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.blue, 3f);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                Quaternion rotation = Quaternion.LookRotation(hit.normal, Vector3.up);
                if (orangeCubePortal != null)
                
                  
                
                orangeCubePortal = (GameObject) Instantiate(orangeCubePortalPrefab, hit.point, rotation);
                Destroy(orangeCubePortal);
            }   

        }
       
        
          if (Input.GetMouseButtonDown(1))
        {
            //this will shoot out a ray that wil; check the position that it hits and will make a blue portal in that position
            Ray ray = new Ray();
            ray.origin = Camera.main.transform.position;
            ray.direction = Camera.main.transform.forward;
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.blue, 3f);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                Quaternion rotation = Quaternion.LookRotation(hit.normal, Vector3.up);
                if (blueCubePortal != null)
                
                  
                
                blueCubePortal = (GameObject) Instantiate(blueCubePortalPrefab, hit.point, rotation);
                Destroy(blueCubePortal);
            }
          
        } 
    }
    void Movement()
    {
        //these if statments define player movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            
        }
        // if (Input.GetKey(KeyCode))
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb3d.velocity = Vector3.zero;
            rb3d.AddForce(Vector3.up * jumppower, ForceMode.Impulse);

        }
        lookHorizontal += Input.GetAxis("Mouse X");
        lookVertical += Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(-lookVertical, lookHorizontal, 0f);

        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
    }
 }


