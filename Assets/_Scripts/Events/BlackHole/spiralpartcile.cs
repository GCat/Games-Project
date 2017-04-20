using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiralpartcile : MonoBehaviour
{

    public int frequency = 1; //repeat rate
    public float resolution = 20f;
    public float amplitude = 1.0f;
    public float zvalue = 0f;

    // Use this for initialization
    void Start()
    {
        CreateCircles();
    }

    void CreateCircles()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var vel = ps.velocityOverLifetime;
        vel.enabled = true;
        vel.space = ParticleSystemSimulationSpace.Local;

        vel.z = new ParticleSystem.MinMaxCurve(10.0f, zvalue);
        AnimationCurve curveX = new AnimationCurve();
        AnimationCurve curveY = new AnimationCurve();
        for (int i =0; i < resolution; i++)
        {
            float newtime = i / (resolution - 1);
            float myvaluex = amplitude * Mathf.Sin(newtime * frequency * 2 * Mathf.PI);
            float myvaluey = amplitude * Mathf.Cos(newtime * frequency * 2 * Mathf.PI);
            curveX.AddKey(newtime, myvaluex);
            curveY.AddKey(newtime, myvaluey);
        }
        vel.x = new ParticleSystem.MinMaxCurve(10.0f, curveX);
        vel.y = new ParticleSystem.MinMaxCurve(10.0f, curveY);
    }
}