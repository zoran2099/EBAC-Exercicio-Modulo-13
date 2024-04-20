using Ebac.Core.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
public class VFXManager : Singleton3<VFXManager>

{
    public enum VFX_Type
    {
        JUMP,RUN
    }

    public List<VFXManagerSetup> VFXSetups;

    public void PlayVFXByType(VFX_Type vfxType, Vector3 position)
    {
        if (VFXSetups != null)
        {
            foreach (var vfx in VFXSetups)
            {
                if (vfx.VFX_Type == vfxType) {
                
                    var itemPrefab = Instantiate(vfx.prefab);
                    itemPrefab.transform.position = position;
                    
                    itemPrefab.GetComponent<ParticleSystem>().Play();

                    Destroy(itemPrefab.gameObject, vfx.LifeTime);
                    break;
                }
            }


            
        }
        
    }
}
