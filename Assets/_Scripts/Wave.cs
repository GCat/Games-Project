﻿

using UnityEngine;

[System.Serializable]
public class Wave {
    [Tooltip("The monsters that will spawn in this wave.")]
    public Portal.MonsterType[] monsters;

    [Tooltip("The time until the next wave spawns")]
    [Range(1, 120)]
    public float waveTime = 30;

}