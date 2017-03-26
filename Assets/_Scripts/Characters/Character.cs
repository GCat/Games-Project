﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Character : MonoBehaviour, HealthManager
{
    protected GameObject healthBar;
    protected Quaternion healthBarOri;
    protected GameObject infoText;
    protected Quaternion infoTextOri;

    protected abstract void hit();
    public abstract void decrementHealth(float damage);
    protected NavMeshAgent agent;
    protected ResourceCounter resources;


    //checks whether agent has reached a point -- takes stopping distance into account
    protected virtual bool atDestination(Vector3 target)
    {
        return Vector3.Distance(target, transform.position) < (agent.stoppingDistance + 3);
    }

    protected void createHealthBar()
    {
        Bounds dims = gameObject.GetComponent<Collider>().bounds;
        Vector3 actualSize = dims.size;
        healthBar = GameObject.Instantiate(Resources.Load("CharacterHealthBar")) as GameObject;
        healthBar.transform.position = gameObject.GetComponent<Collider>().transform.position;
        healthBar.transform.Translate(new Vector3(0, 0, dims.size.y * -1.0f));
        healthBar.transform.SetParent(gameObject.transform);
    }

    protected void createInfoText()
    {
        Bounds dims = gameObject.GetComponent<Collider>().bounds;
        Vector3 actualSize = dims.size;
        infoText = GameObject.Instantiate(Resources.Load("AttackSprite")) as GameObject;
        infoText.transform.position = gameObject.transform.position;
        infoText.transform.localScale *= 2;
        infoText.transform.Translate(new Vector3(0, actualSize.y * 1.4f, 0));
        infoText.transform.localRotation = gameObject.transform.localRotation;
        infoText.transform.Rotate(new Vector3(0, -90, 0));
        infoText.transform.SetParent(gameObject.transform);
        infoText.SetActive(false);
    }

    protected void setDestination(Vector3 target)
    {
        if(agent.destination != target)
        {
            agent.destination = target;
        }
    }
}