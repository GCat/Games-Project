using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Hand : MonoBehaviour {

    public enum HandStatus {Open, Close};
    HandStatus hand = HandStatus.Open;
    public bool holding = false;
    public Vector3[] fingers = new Vector3[5];

    private bool change = false;

    private Vector3 lastPosition;
    private Vector3 velocity;
    GameObject heldObject;


    public Collider[] things;
    public AudioClip[] hitSounds;
    public AudioSource audioSource;
    public GameObject close_hand;
    public GameObject open_hand;
    public GameObject grab_position;
    public BodySourceView kinect_view;
    public Renderer renderer_open;
    public Renderer renderer_closed;
    private ResourceCounter resources;
    public Color defaultColor;

    private HashSet<Collider> onBounds;

    public bool useMouse = true;
    public bool right_hand;

    public bool wasKinematic = false;
    public bool usedGravity = false;

    private Vector3[] held_object_positions;
    private float[] held_object_times;


    public enum PropType { Building, Human, Tool, Handle, None};
    float rotationTimer;
    float startTime;
    Collider heldCollider;

    private int grabLayer = (1 << 9) | (1 << 10) | (1 << 14);


    private void Awake()
    {
        onBounds = new HashSet<Collider>();
    }

    // Use this for initialization
    void Start () {
        held_object_times = new float[5];
        held_object_positions = new Vector3[5];
        held_object_positions[0] = Vector3.zero;
        held_object_positions[1] = Vector3.zero;
        held_object_positions[2] = Vector3.zero;
        held_object_positions[3] = Vector3.zero;
        held_object_positions[4] = Vector3.zero;
        resources = GameObject.FindGameObjectWithTag("Tablet").GetComponent<ResourceCounter>();
        if (kinect_view == null) useMouse = true;
        defaultColor = renderer_open.material.GetColor("_Color");
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update () {
        velocity = (transform.position - lastPosition) / Time.deltaTime;
        lastPosition = transform.position;
        // MOUSE TESTING
        if (useMouse)
        {
            mouseMovement();
        }
        else
        {
            if ((right_hand && kinect_view.rightHandClosed) || (!right_hand && kinect_view.leftHandClosed))
            {
                closeHand();
            }
            else
            {
                openHand();
            }
        }
        if (change)
        {
            if (hand == HandStatus.Open)
            {
                releaseObject();
                //reset the tracking context
                kinect_view.setTrackingContext(BodySourceView.TrackingContext.Medium, right_hand);
            }
            else
            {
                grabObject();
            }
            change = false;
        }

        if (holding)
        {
            for (int i = 4; i >0; i--) {
                held_object_positions[i] = held_object_positions[i - 1];
                held_object_times[i] = held_object_times[i - 1];
            }
            held_object_positions[0] = transform.position;
            held_object_times[0] = Time.deltaTime;
            //Vector3 p = grab_position.transform.position;//new Vector3(transform.position.x - 14, transform.position.y - 18, transform.position.z);
            //heldObject.transform.position = p;
        }

               
    }

    //handle player interaction using the mouse foor testing
    void mouseMovement()
    {
        Vector3 curLocation = transform.position;
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.position = new Vector3(curLocation.x - 6 * v, curLocation.y - 20 * scroll, curLocation.z + 6 * h);
        curLocation.x -= 14;
        curLocation.y -= 10;

        if (Input.GetMouseButtonDown(0))
        {
            openHand();
        }
        if (Input.GetMouseButtonDown(1))
        {
            closeHand();
        }

    }
    //changes colour of wrist band based on tracking
    void setTrackingColour()
    {
        if (right_hand)
        {
            if (!kinect_view.rightHandTracked)
            {
                renderer_open.material.SetColor("_Color", Color.red);
                renderer_closed.material.SetColor("_Color", Color.red);

            }
            else
            {
                renderer_open.material.SetColor("_Color", defaultColor);
                renderer_closed.material.SetColor("_Color", defaultColor);

            }
        }
        else
        {
            if (!kinect_view.leftHandTracked)
            {
                renderer_open.material.SetColor("_Color", Color.red);
                renderer_closed.material.SetColor("_Color", Color.red);

            }
            else
            {
                renderer_open.material.SetColor("_Color", defaultColor);
                renderer_closed.material.SetColor("_Color", defaultColor);

            }

        }

    }

    public void openHand()
    {

        open_hand.SetActive(true);
        close_hand.SetActive(false);
        if (hand == HandStatus.Close)
        {
            hand = HandStatus.Open;
            change = true;
        }
        
    }

    public void closeHand()
    {
        open_hand.SetActive(false);
        close_hand.SetActive(true);
        if (hand == HandStatus.Open)
        {
            hand = HandStatus.Close;
            change = true;
        }

    }

    private GameObject getClosestObject()
    {
        GameObject closest = null;
        Vector3 p = grab_position.transform.position;
        float distance = Mathf.Infinity;
        if (onBounds.Count > 0)
        {
            foreach (Collider g in onBounds)
            {
                if (g != null)
                {
                    Vector3 diff = g.ClosestPointOnBounds(p) - p;
                    float current_distance = diff.sqrMagnitude;
                    if (current_distance < distance)
                    {
                        distance = current_distance;
                        closest = g.gameObject;
                    }
                }
            }
        }
        return closest;
    }

    private PropType getPropType(GameObject prop)
    {
        if (prop.GetComponent<Building>() != null) return PropType.Building;
        if (prop.GetComponent<Agent>() != null) return PropType.Human;
        if (prop.GetComponent<Tool>() != null) return PropType.Tool;
        if (prop.GetComponent<Handle>() != null) return PropType.Handle;

        return PropType.None;
    }

    //checks a surrounding sphere for objects, grabs them
    private void grabObject()
    {
        if (holding) return;
        heldObject = null;

        if(velocity.magnitude > 100)
        {
            return;
        }

        GameObject grabTarget = getClosestObject();
        if (grabTarget == null ) return;

        PropType propType = getPropType(grabTarget);
        switch (propType)
        {
            case PropType.Building:
                Building building = grabTarget.GetComponent<Building>();
                if (!building.canBeGrabbed || (!resources.hasGameStarted() && grabTarget.tag != "Temple")) return;
                if (building.canBuy() || building.bought)
                {
                    heldObject = grabTarget;
                    building.transform.parent = null;
                    holding = true;
                    building.initialRotation = building.transform.rotation;
                    building.held = true;
                    Debug.Log("Grab BUILDING");
                    building.GetComponent<Grabbable>().grab();
                    snapToHand(grabTarget);
                    heldObject.transform.parent = transform;
                    kinect_view.setTrackingContext(BodySourceView.TrackingContext.Slow, right_hand);
                }
                break;
            case PropType.Tool:
                Tool tool = grabTarget.GetComponent<Tool>();
                if (tool.canBuy())
                {
                    heldObject = grabTarget;
                    snapToHand(heldObject);
                    grabTarget.transform.parent = transform;
                    holding = true;
                }
                else
                {
                    heldObject = null;
                }
                break;
            case PropType.Human:
                Grabbable human = grabTarget.GetComponent<Grabbable>();
                heldObject = grabTarget;
                human.grab();
                snapToHand(grabTarget);
                grabTarget.transform.parent = transform;
                holding = true;
                kinect_view.setTrackingContext(BodySourceView.TrackingContext.Fast, right_hand);
                break;
            case PropType.Handle:
                Grabbable handle = grabTarget.GetComponent<Grabbable>();
                heldObject = grabTarget;
                handle.grab();
                snapToHand(grabTarget);
                heldObject.transform.parent = transform;
                holding = true;
                kinect_view.setTrackingContext(BodySourceView.TrackingContext.Slow, right_hand);
                break;
            case PropType.None:
                return;
        }
        colourChange(grabTarget);

    }

    private void releaseObject ()
    {
        if (holding)
        {
            onBounds.Remove(heldObject.GetComponent<Collider>());

            holding = false;
            heldObject.transform.parent = null;
            Building building = heldObject.GetComponent<Building>();

            if(building != null)
            {
               
                if(building.canPlace() && (building.bought || building.canBuy()))
                {
                    //this is why the building had a grabbable interface :p - this should be there ;)
                    snapToGrid(heldObject);
                    building.audioSource.clip = building.buildClip;
                    building.audioSource.Play();
                    building.activate();
                    building.removeOutline();
                }
                else
                {
                    building.highlightDestroy();
                    if (resources.withinBounds(heldObject.transform.position))
                    {
                        if (building.gameObject.tag != "Temple")
                        {
                            Destroy(heldObject);
                        }
                    }
                    else
                    {
                        throwObject(heldObject);
                    }
                }
            }
            else
            {
                
                throwObject(heldObject);
            }
            heldObject = null;
        }

    }

    //changing the colour of the bracelets when something grabbed
    private void colourChange(GameObject heldObject)
    {
 
        if (holding && heldObject != null)                                  //success you've grabbed an object
        {
            renderer_closed.material.SetColor("_Color", Color.green); 
        }else                                                               //fail you've grabbed the air
        {
            renderer_closed.material.SetColor("_Color", Color.red);         
        }
    }
        
    //function called to snap object to palm 
    private void snapToHand(GameObject placeable)
    {
         // might need to change the positions slightly to make it nicer looking
        placeable.transform.position = gameObject.transform.position;
    }

    //function called to place an object neatly on the game board
    private void snapToGrid(GameObject placeable)
    {
        float x = placeable.transform.position.x;
        float z = placeable.transform.position.z;
        placeable.transform.position = new Vector3(x, 0, z);
        if(placeable.GetComponent<Wall>() == null)
        {
            placeable.transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
        }
        // if we are not alowing hand rotation is this still nesesary?
    }

    //function called to release any physics object from the hand
    private void throwObject(GameObject projectile)
    {
        float time = 0;
        foreach (float t in held_object_times)
        {
            time += t;
        }
        Vector3 velocity = (projectile.transform.position - held_object_positions[4]) / (time);

        Grabbable placeable = heldObject.GetComponent<Grabbable>();
        if (placeable != null)
        {
            placeable.release(velocity);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject gother = other.gameObject;
        if (gother.layer == 9 || gother.layer == 10 || gother.layer == 14 && !holding)
        {
            onBounds.Add(other);
        }else if(gother.layer == 11)
        {
            //slap baddies
            HealthManager healthManager = gother.GetComponent<HealthManager>();
            if(healthManager != null && velocity.magnitude > 100)
            {
                int seed = Random.Range(0, hitSounds.Length);
                audioSource.PlayOneShot(hitSounds[seed], 0.9f);
                healthManager.decrementHealth(1);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other == null) return;
        GameObject gother = other.gameObject;
        if (gother.layer == 9 || gother.layer == 10 || gother.layer == 14 && !holding)
        {
            onBounds.Add(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GameObject gother = other.gameObject;
        if (gother.layer == 9 || gother.layer == 10 || gother.layer == 14 && !holding)
        {
            onBounds.Remove(other);
        }
    }
}
