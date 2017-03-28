using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class Food : Grabbable
{


    public override void grab()
    {
        throw new NotImplementedException();
    }

    public override void release(Vector3 vel)
    {
        GetComponent<Rigidbody>().velocity = vel;
        removeOutline();
    }


}
