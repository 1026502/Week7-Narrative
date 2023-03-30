using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public GameManager GameManager;
    public LayerMask pickupLayerMask;
    public Camera playerCamera;
    public Transform pickupPoint;
    public float pickupRange;
    public Rigidbody currentObject;
    private bool hasPickedUpLantern;
    // Start is called before the first frame update
    void Start()
    {
        hasPickedUpLantern = false;
        GameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentObject)
            {
                //currentObject.GetComponent<BoxCollider>().enabled = true;
                currentObject.useGravity = true;
                currentObject = null;
                
                return;
            }

            Ray CameraRay = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            if(Physics.Raycast(CameraRay,out RaycastHit hitInfo, pickupRange, pickupLayerMask))
            {
                currentObject = hitInfo.rigidbody;
                currentObject.useGravity = false;

                if(currentObject.tag == "Page")
                {
                    GameManager.PagePickup();
                    
                    Destroy(currentObject.gameObject);
                    
                }

                if (currentObject.tag == "Lantern" && hasPickedUpLantern == false)
                {

                    GameManager.LanternPickup();
                    hasPickedUpLantern = true;
                }
                //currentObject.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (currentObject)
        {
            Vector3 DirectionToPoint = pickupPoint.position - currentObject.position;
            float DistanceToPoint = DirectionToPoint.magnitude;

            currentObject.velocity = DirectionToPoint * 12f * DistanceToPoint;
        }
    }
}
