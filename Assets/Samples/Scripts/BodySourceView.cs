using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kinect = Windows.Kinect;
using System.IO;

public class BodySourceView : MonoBehaviour 
{
    public Material BoneMaterial;
    public GameObject BodySourceManager;
    public GameObject startBody;
    public GameObject headCamera;
    public GameObject right_hand;
    public GameObject left_hand;
    public GameObject player_body;
    public GameObject kinectLocation;
    public bool rightHandClosed = false;
    public bool leftHandClosed = false;
    private int r_hand_closed_frames = 0;
    private int r_hand_open_frames = 0;
    private int l_hand_closed_frames = 0;
    private int l_hand_open_frames = 0;

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
                    _Bodies[body.TrackingId] = CreateBodyObject(body.TrackingId);
                }
                
                RefreshBodyObject(body, _Bodies[body.TrackingId]);
                adjustBodyParts(body, _Bodies[body.TrackingId]);
                break;
            }
        }
    }



    private void adjustBodyParts(Kinect.Body body, GameObject bodyObject)
    {

        headCamera.transform.position = player_objects[Kinect.JointType.Head].transform.position;
        right_hand.transform.position = player_objects[Kinect.JointType.HandRight].transform.position;
        left_hand.transform.position = player_objects[Kinect.JointType.HandLeft].transform.position;
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

        //Debug.Log((r_handVector.sqrMagnitude + r_handRotation.sqrMagnitude));

        player_body.transform.position = player_objects[Kinect.JointType.SpineMid].transform.position;


        //120 -> 60 at about 1.5m

        if (body.HandRightState == Windows.Kinect.HandState.Closed)
        {
            r_hand_closed_frames++;
            if (r_hand_closed_frames > 6)
            {
                rightHandClosed = true;
                r_hand_open_frames = 0;
            }
            Quaternion target = Quaternion.LookRotation(r_wristVector);
            right_hand.transform.rotation = Quaternion.Slerp(right_hand.transform.rotation, target, Time.deltaTime * 15.0f);

        }
        else
        {
            r_hand_open_frames++;
            if (r_hand_open_frames > 6)
            {
                rightHandClosed = false;
                r_hand_closed_frames = 0;
            }
            Quaternion target = Quaternion.LookRotation(r_handVector, r_handUp);
            right_hand.transform.rotation = Quaternion.Slerp(right_hand.transform.rotation, target, Time.deltaTime * 15.0f);

        }

        if (body.HandLeftState == Windows.Kinect.HandState.Closed)
        {
            l_hand_closed_frames++;
            if (l_hand_closed_frames > 3)
            {
                leftHandClosed = true;
                l_hand_open_frames = 0;
            }
            Quaternion target = Quaternion.LookRotation(l_wristVector);
            left_hand.transform.rotation = Quaternion.Slerp(left_hand.transform.rotation, target, Time.deltaTime * 15.0f);
        }
        else
        {
            l_hand_open_frames++;
            if (l_hand_open_frames > 3)
            {
                leftHandClosed = false;
                l_hand_closed_frames = 0;
            }
            Quaternion target = Quaternion.LookRotation(l_handVector, l_handUp);
            left_hand.transform.rotation = Quaternion.Slerp(left_hand.transform.rotation, target, Time.deltaTime * 15.0f);
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
            SphereCollider collider = jointObj.GetComponent<SphereCollider>();
            Destroy(collider);
            LineRenderer lr = jointObj.AddComponent<LineRenderer>();
            lr.SetVertexCount(2);
            lr.material = BoneMaterial;
            lr.SetWidth(0.05f, 0.05f);
            
            jointObj.transform.localScale = new Vector3(5f, 5f, 5f);
            jointObj.name = jt.ToString();
            jointObj.transform.parent = body.transform;

            player_objects.Add(jt, jointObj);
        }


 
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
            jointObj.localPosition = GetVector3FromJoint(sourceJoint)*10;

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
        return new Vector3(-joint.Position.X * 10, joint.Position.Y * 10, joint.Position.Z * 10);
    }
}
