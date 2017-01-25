using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kinect = Windows.Kinect;

public class BodySourceView : MonoBehaviour 
{
    public Material BoneMaterial;
    public GameObject BodySourceManager;
    public GameObject startBody;
    public GameObject headCamera;
    public GameObject right_hand;
    public GameObject left_hand;

    public bool rightHandClosed = false;
    public bool leftHandClosed = false;

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

            Vector3 r_handRotation = player_objects[Kinect.JointType.ThumbRight].transform.position - player_objects[Kinect.JointType.HandRight].transform.position;
            Vector3 l_handRotation = player_objects[Kinect.JointType.ThumbLeft].transform.position - player_objects[Kinect.JointType.HandLeft].transform.position;

            Vector3 r_handUp = Vector3.Cross(r_handRotation, r_handVector);
            Vector3 l_handUp = Vector3.Cross(l_handVector, l_handRotation);

            right_hand.transform.rotation = Quaternion.LookRotation(r_handVector, r_handUp);
            left_hand.transform.rotation = Quaternion.LookRotation(l_handVector, l_handUp);

        if ((r_handVector.sqrMagnitude + r_handRotation.sqrMagnitude) < 50)
        {
            rightHandClosed = true;
        }
        else
        {
            rightHandClosed = false;
        }


        if ((l_handVector.sqrMagnitude + l_handRotation.sqrMagnitude) < 50)
        {
            leftHandClosed = true;
        }
        else
        {
            leftHandClosed = false;
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
