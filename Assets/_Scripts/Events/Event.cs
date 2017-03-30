using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class Event : MonoBehaviour
{
    public Time eventDuration;
    public AudioSource audioSource;
    public AudioClip[] audioClip; // this might just be an array of clips

    public abstract void startEvent();
}
