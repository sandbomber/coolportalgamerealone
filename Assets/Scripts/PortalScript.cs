using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    /*
     these are fields.
     exit is the position of the exit for the portal
     the name of the other portal 
     "GameObject other portal" is the actual portal
    */
    public Transform exit;
    public string otherPortalTag;
    public GameObject otherPortal;

    private void OnCollisionEnter(Collision coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            otherPortal = GameObject.FindGameObjectWithTag(otherPortalTag);
            if (otherPortal != null)
            {
                coll.transform.position = otherPortal.GetComponent<PortalScript>().exit.position;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
 