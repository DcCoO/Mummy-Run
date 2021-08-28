using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VortexController : MonoBehaviour
{
    
    [SerializeField] Vortex[] ins;
    [SerializeField] Transform[] outs;
    void Start()
    {
        List<Transform> outsList = new List<Transform>(outs).OrderBy(a => System.Guid.NewGuid()).ToList();
        for (int i = 0; i < ins.Length; ++i) ins[i].SetTeleportPosition(outsList[i]);        
    }

    
}
