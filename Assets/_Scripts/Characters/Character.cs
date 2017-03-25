using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, HealthManager
{
    protected abstract void hit();

    public abstract void decrementHealth(float damage);
}
