using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Placeable {


    //function to be called when grabbed by hand
    void grab();

    //function to be called when released from hand
    void release(Vector3 vel);
}
