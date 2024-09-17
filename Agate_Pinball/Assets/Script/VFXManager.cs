using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public GameObject vfxSwitchSourceOn;
    public GameObject vfxSwitchSourceOff;
    public GameObject vfxBumperSource;

    public void PlayVFXBumper(Vector3 spawnPosition)
    {
        GameObject.Instantiate(vfxBumperSource, spawnPosition, Quaternion.identity);
    }
    public void PlayVFXSwitchOn(Vector3 spawnPosition)
    {
        GameObject.Instantiate(vfxSwitchSourceOn, spawnPosition, Quaternion.identity);
    }
    public void PlayVFXSwitchOff(Vector3 spawnPosition)
    {
        GameObject.Instantiate(vfxSwitchSourceOff, spawnPosition, Quaternion.identity);
    }
}
