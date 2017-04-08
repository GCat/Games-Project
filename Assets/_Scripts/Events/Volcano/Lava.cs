using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Lava : MonoBehaviour
{
    public GameObject lavaBlob;

    void Start()
    {
        StartCoroutine(spawnBlobs());
    }

    void spawnBlob()
    {
        Vector3 offset = new Vector3(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), 0);
        Instantiate(lavaBlob, transform.position + offset, Quaternion.identity);
    }

    IEnumerator spawnBlobs()
    {
        while (true)
        {
            spawnBlob();
            yield return new WaitForSeconds(0.1f);
        }
    }
}

