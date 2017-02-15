using UnityEngine;
using System.Collections;

public interface Building : HealthManager{

    string getName();
    Vector3 getLocation();
    void activate();
    void deactivate();
}
