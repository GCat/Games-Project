using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Character : HealthManager
{
    void changeMoving(bool val);
    void changeMode(bool val);
}
