using UnityEngine;
using System.Collections;

public interface Building {

    string getName();
    Vector3 getLocation();
    void activate();
    void deactivate();
}
