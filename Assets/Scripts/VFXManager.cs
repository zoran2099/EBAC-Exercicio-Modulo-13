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

    public void PlayVFXByType(VFX_Type vfxType, Transform parent )
    {
        if (VFXSetups != null)
        {
            //Vector3 position = transform.position;
            Debug.Log("PlayVFXByType was called.");
            foreach (var vfx in VFXSetups)
            {
                if (vfx.VFX_Type == vfxType) {
                
                    var itemPrefab = Instantiate(vfx.prefab, parent);
                    
                    itemPrefab.transform.position = parent.transform.position;
                    
                    itemPrefab.name = itemPrefab.name + "Dinamic";
                    
                    itemPrefab.SetActive(true);
                    
                    itemPrefab.GetComponent<ParticleSystem>().Play();
                    
                    if (vfx.LifeTime >= 0) Destroy(itemPrefab.gameObject, vfx.LifeTime);

                    break;
                }
            }


            
        }
        
    }
}
