using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kinect = Windows.Kinect;
using System.IO;
using UnityEngine.VR;

public class BodySourceView : MonoBehaviour 
{
    public Material BoneMaterial;
    public GameObject BodySourceManager;
    public GameObject startBody;
    //headCamera is the parent of the oculus camera
    public GameObject headCamera;
    //head model is the face model, moves independently of camera
    public GameObject head_model;
    //eyes is the actual position of the oculus
    public GameObject eyes;
    public GameObject right_hand;
    public GameObject left_hand;
    public GameObject player_body;
    public GameObject kinectLocation;
    public GameObject left_foot;
    public GameObject right_foot;
    public int tracking_frames = 8;
    public bool rightHandClosed = false;
    public bool leftHandClosed = false;
    public bool rightHandTracked = false;
    public bool leftHandTracked = false;
    private int r_hand_closed_frames = 0;
    private int r_hand_open_frames = 0;
    private int l_hand_closed_frames = 0;
    private int l_hand_open_frames = 0;
    private ulong player_id = 99;
    private Renderer renderer;

    //holds all the hand joint objects - palm, wrist, thumb, tip
    public Dictionary<Kinect.JointType, GameObject> player_objects = new Dictionary<Kinect.JointType, GameObject>();

    private Dictionary<ulong, GameObject> _Bodies = new Dictionary<ulong, GameObject>();
    private BodySourceManager _BodyManager;
    

    private Dictionary<Kinect.JointType, Kinect.JointType> _BoneMap = new Dictionary<Kinect.JointType, Kinect.JointType>()
    {
        { Kinect.JointType.FootLeft, Kinect.JointType.AnkleLeft },
        { Kinect.JointType.AnkleLeft, Kinect.JointType.KneeLeft },
        { Kinect.JointType.KneeLeft, Kinect.JointType.HipLeft },
        { Kinect.JointType.HipLeft, Kinect.JointType.SpineBase },
        
        { Kinect.JointType.FootRight, Kinect.JointType.AnkleRight },
        { Kinect.JointType.AnkleRight, Kinect.JointType.KneeRight },
        { Kinect.JointType.KneeRight, Kinect.JointType.HipRight },
        { Kinect.JointType.HipRight, Kinect.JointType.SpineBase },
        
        { Kinect.JointType.HandTipLeft, Kinect.JointType.HandLeft },
        { Kinect.JointType.ThumbLeft, Kinect.JointType.HandLeft },
        { Kinect.JointType.HandLeft, Kinect.JointType.WristLeft },
        { Kinect.JointType.WristLeft, Kinect.JointType.ElbowLeft },
        { Kinect.JointType.ElbowLeft, Kinect.JointType.ShoulderLeft },
        { Kinect.JointType.ShoulderLeft, Kinect.JointType.SpineShoulder },
        
        { Kinect.JointType.HandTipRight, Kinect.JointType.HandRight },
        { Kinect.JointType.ThumbRight, Kinect.JointType.HandRight },
        { Kinect.JointType.HandRight, Kinect.JointType.WristRight },
        { Kinect.JointType.WristRight, Kinect.JointType.ElbowRight },
        { Kinect.JointType.ElbowRight, Kinect.JointType.ShoulderRight },
        { Kinect.JointType.ShoulderRight, Kinect.JointType.SpineShoulder },
        
        { Kinect.JointType.SpineBase, Kinect.JointType.SpineMid },
        { Kinect.JointType.SpineMid, Kinect.JointType.SpineShoulder },
        { Kinect.JointType.SpineShoulder, Kinect.JointType.Neck },
        { Kinect.JointType.Neck, Kinect.JointType.Head },
    };

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void Update () 
    {
        if (BodySourceManager == null)
        {
            return;
        }
        
        _BodyManager = BodySourceManager.GetComponent<BodySourceManager>();
        if (_BodyManager == null)
        {
            return;
        }
        
        Kinect.Body[] data = _BodyManager.GetData();
        if (data == null)
        {
            return;
        }
        
        List<ulong> trackedIds = new List<ulong>();
        foreach(var body in data)
        {
            if (body == null)
            {
                continue;
              }
                
            if(body.IsTracked)
            {
                trackedIds.Add (body.TrackingId);
                break;
            }
        }
        
        List<ulong> knownIds = new List<ulong>(_Bodies.Keys);
        
        // First delete untracked bodies
        foreach(ulong trackingId in knownIds)
        {
            if(!trackedIds.Contains(trackingId))
            {
                Destroy(_Bodies[trackingId]);
                _Bodies.Remove(trackingId);
            }
        }

        foreach(var body in data)
        {
            if (body == null)
            {
                continue;
            }
            
            if(body.IsTracked)
            {
                if(!_Bodies.ContainsKey(body.TrackingId))
                {
                    if (player_id == 99)
                    {
                        _Bodies[body.TrackingId] = CreateBodyObject(body.TrackingId);
                        Vector3 foot = GetVector3FromJoint(body.Joints[Kinect.JointType.FootRight]);
                        float footHeight = foot.y;
                        float floorHeight = -70;
                        float feetOffset = footHeight - floorHeight;
                        kinectLocation.transform.position += new Vector3(0,-feetOffset,0);
                        player_id = body.TrackingId;
                    }
                }
                if (body.TrackingId == player_id)
                {
                    RefreshBodyObject(body, _Bodies[body.TrackingId]);
                    adjustBodyParts(body, _Bodies[body.TrackingId]);
                }
                break;
            }
        }
    }


    //I'm really sorry about this
    private void adjustBodyParts(Kinect.Body body, GameObject bodyObject)
    {

        headCamera.transform.position = player_objects[Kinect.JointType.Head].transform.position;
        right_hand.transform.position = Vector3.Slerp(right_hand.transform.position, player_objects[Kinect.JointType.HandRight].transform.position, Time.deltaTime * 10.0f);
        left_hand.transform.position = Vector3.Slerp(left_hand.transform.position, player_objects[Kinect.JointType.HandLeft].transform.position, Time.deltaTime * 10.0f);




        Vector3 right_foot_direction = player_objects[Kinect.JointType.FootRight].transform.position - player_objects[Kinect.JointType.AnkleRight].transform.position;
        Vector3 left_foot_direction = player_objects[Kinect.JointType.FootLeft].transform.position - player_objects[Kinect.JointType.AnkleLeft].transform.position;

        //right_foot.transform.rotation = Quaternion.Slerp(right_foot.transform.rotation, Quaternion.LookRotation(right_foot_direction), Time.deltaTime * 10.0f);
        //left_foot.transform.rotation = Quaternion.Slerp(left_foot.transform.rotation, Quaternion.LookRotation(left_foot_direction), Time.deltaTime * 10.0f);
        right_foot.transform.position = Vector3.Slerp(right_foot.transform.position, player_objects[Kinect.JointType.FootRight].transform.position, Time.deltaTime * 10.0f);
        left_foot.transform.position = Vector3.Slerp(left_foot.transform.position, player_objects[Kinect.JointType.FootLeft].transform.position, Time.deltaTime * 10.0f);

        //Adjust body rotation
        Vector3 spine = player_objects[Kinect.JointType.SpineShoulder].transform.position - player_objects[Kinect.JointType.SpineMid].transform.position;
        Vector3 spine_rotation = player_objects[Kinect.JointType.ShoulderLeft].transform.position - player_objects[Kinect.JointType.ShoulderRight].transform.position;
        Vector3 spine_forward = Vector3.Cross(spine_rotation, spine);

        player_body.transform.position = player_objects[Kinect.JointType.SpineMid].transform.position;
        player_body.transform.rotation = Quaternion.Slerp(player_body.transform.rotation, Quaternion.LookRotation(spine_forward, spine), Time.deltaTime * 10.0f);

        //Adjust head rotation
        Vector3 head_up = player_objects[Kinect.JointType.Head].transform.position - player_objects[Kinect.JointType.Neck].transform.position;
        head_model.transform.position = player_objects[Kinect.JointType.Head].transform.position;
        head_model.transform.rotation = Quaternion.Slerp(head_model.transform.rotation, eyes.transform.rotation, Time.deltaTime * 10.0f);


        Vector3 r_handVector = player_objects[Kinect.JointType.HandTipRight].transform.position - player_objects[Kinect.JointType.HandRight].transform.position;
        Vector3 l_handVector = player_objects[Kinect.JointType.HandTipLeft].transform.position - player_objects[Kinect.JointType.HandLeft].transform.position;
        Vector3 r_wristVector = player_objects[Kinect.JointType.HandTipRight].transform.position - player_objects[Kinect.JointType.WristRight].transform.position;
        Vector3 l_wristVector = player_objects[Kinect.JointType.HandTipLeft].transform.position - player_objects[Kinect.JointType.WristLeft].transform.position;

        Vector3 r_handRotation = player_objects[Kinect.JointType.ThumbRight].transform.position - player_objects[Kinect.JointType.HandRight].transform.position;
        Vector3 l_handRotation = player_objects[Kinect.JointType.ThumbLeft].transform.position - player_objects[Kinect.JointType.HandLeft].transform.position;

        Vector3 r_handUp = Vector3.Cross(r_handRotation, r_handVector);
        Vector3 l_handUp = Vector3.Cross(l_handVector, l_handRotation);

        Vector3 r_handDist = player_objects[Kinect.JointType.HandRight].transform.position - kinectLocation.transform.position;
        Vector3 l_handDist = player_objects[Kinect.JointType.HandLeft].transform.position - kinectLocation.transform.position;



        if (body.HandRightConfidence == Windows.Kinect.TrackingConfidence.Low)
        {
            rightHandTracked = false;
        }
        else
        {
            rightHandTracked = true;
        }

        if (body.HandLeftConfidence == Windows.Kinect.TrackingConfidence.Low)
        {
            leftHandTracked = false;
        }
        else
        {
            leftHandTracked = true;
        }


        //Adjust hand rotations
        if (body.HandRightState == Windows.Kinect.HandState.Closed)
        {
            r_hand_closed_frames++;
            if (r_hand_closed_frames > tracking_frames || body.HandRightConfidence == Kinect.TrackingConfidence.High)
            {
                rightHandClosed = true;
                r_hand_open_frames = 0;
            }
           

        }
        else
        {
            r_hand_open_frames++;
            if (r_hand_open_frames > tracking_frames || body.HandRightConfidence == Kinect.TrackingConfidence.High)
            {
                rightHandClosed = false;
                r_hand_closed_frames = 0;
            }
         

        }

        if (body.HandLeftState == Windows.Kinect.HandState.Closed)
        {
            l_hand_closed_frames++;
            if (l_hand_closed_frames > tracking_frames || body.HandLeftConfidence == Kinect.TrackingConfidence.High)
            {
                leftHandClosed = true;
                l_hand_open_frames = 0;
            }
          
        }
        else
        {
            l_hand_open_frames++;
            if (l_hand_open_frames > tracking_frames || body.HandLeftConfidence == Kinect.TrackingConfidence.High)
            {
                leftHandClosed = false;
                l_hand_closed_frames = 0;
            }

        }


        if (rightHandClosed)
        {
            Quaternion target = Quaternion.LookRotation(r_wristVector);
            right_hand.transform.rotation = Quaternion.Slerp(right_hand.transform.rotation, target, Time.deltaTime * 10.0f);
        }
        else
        {
            Quaternion target = Quaternion.LookRotation(r_handVector, r_handUp);
            right_hand.transform.rotation = Quaternion.Slerp(right_hand.transform.rotation, target, Time.deltaTime * 10.0f);
        }
        if (leftHandClosed)
        {
            Quaternion target = Quaternion.LookRotation(l_wristVector);
            left_hand.transform.rotation = Quaternion.Slerp(left_hand.transform.rotation, target, Time.deltaTime * 10.0f);
        }
        else
        {
            Quaternion target = Quaternion.LookRotation(l_handVector, l_handUp);
            left_hand.transform.rotation = Quaternion.Slerp(left_hand.transform.rotation, target, Time.deltaTime * 10.0f);
        }

        //Debug.Log("Right hand spread: " + (r_handVector.sqrMagnitude + r_handRotation.sqrMagnitude));
    }

    public void nDrawGizmos()
    {
        Vector3 r_handVector = player_objects[Kinect.JointType.HandTipRight].transform.position - player_objects[Kinect.JointType.HandRight].transform.position;
        Vector3 l_handVector = player_objects[Kinect.JointType.HandTipLeft].transform.position - player_objects[Kinect.JointType.HandLeft].transform.position;
        Gizmos.DrawLine(player_objects[Kinect.JointType.HandRight].transform.position, player_objects[Kinect.JointType.HandTipRight].transform.position);
    }
    private GameObject CreateBodyObject(ulong id)
    {
        GameObject body = startBody;
        for (Kinect.JointType jt = Kinect.JointType.SpineBase; jt <= Kinect.JointType.ThumbRight; jt++)
        {
            GameObject jointObj = new GameObject();
            //jointObj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            LineRenderer lr = jointObj.AddComponent<LineRenderer>();
            lr.SetVertexCount(2);
            lr.material = BoneMaterial;
            lr.SetWidth(0.05f, 0.05f);
            
            jointObj.transform.localScale = new Vector3(5f, 5f, 5f);
            jointObj.name = jt.ToString();
            jointObj.transform.parent = body.transform;

            player_objects.Add(jt, jointObj);
        }
        InputTracking.Recenter();



        return body;
    }
    
    private void RefreshBodyObject(Kinect.Body body, GameObject bodyObject)
    {
        for (Kinect.JointType jt = Kinect.JointType.SpineBase; jt <= Kinect.JointType.ThumbRight; jt++)
        {
            Kinect.Joint sourceJoint = body.Joints[jt];
            Kinect.Joint? targetJoint = null;
            
            if(_BoneMap.ContainsKey(jt))
            {
                targetJoint = body.Joints[_BoneMap[jt]];
            }
            
            Transform jointObj = bodyObject.transform.FindChild(jt.ToString());
            jointObj.localPosition = GetVector3FromJoint(sourceJoint);

            LineRenderer lr = jointObj.GetComponent<LineRenderer>();
            if(targetJoint.HasValue)
            {
                //lr.SetPosition(0, jointObj.localPosition*10);
                //lr.SetPosition(1, GetVector3FromJoint(targetJoint.Value)*10);
                lr.SetColors(GetColorForState (sourceJoint.TrackingState), GetColorForState(targetJoint.Value.TrackingState));
            }
            else
            {
                lr.enabled = false;
            }
        }
    }
    
    private static Color GetColorForState(Kinect.TrackingState state)
    {
        switch (state)
        {
        case Kinect.TrackingState.Tracked:
            return Color.green;

        case Kinect.TrackingState.Inferred:
            return Color.red;

        default:
            return Color.black;
        }
    }
    
    private static Vector3 GetVector3FromJoint(Kinect.Joint joint)
    {
        return new Vector3(-joint.Position.X * 70, joint.Position.Y * 70, joint.Position.Z * 70 );
    }
}
