﻿using System;
using UnityEngine;

public class DestroyCubes : MonoBehaviour
{     
    public playerMovement pm;
    public EnemyMovement em;
    float groundRaycastRange;
    RaycastHit lastHit;
    RaycastHit hit;
    bool lastHitInitializated = false;
    
    void Start(){
        if(pm != null)
        {
            groundRaycastRange = pm.RaycastRange + 0.1f;
        }
        else if(em != null)
        {
            groundRaycastRange = em.RaycastRange + 0.1f;
        }
        else
        {
            Debug.Log("DestroyCubes: Kein Script referenziert");
        }
    }
    void Update(){

        if((pm != null && pm.IsGrounded()) || (em != null && em.IsGrounded())){
            
            if (Physics.Raycast(transform.position, Vector3.down, out hit, groundRaycastRange) && hit.collider.tag == "Cube" && !lastHitInitializated)
            {
                lastHit = hit;
                lastHitInitializated = true;
            }
            try {
                if (lastHit.transform.gameObject != hit.transform.gameObject)
                {
                Destroy(lastHit.transform.gameObject);
                lastHitInitializated = false;
                }
            }
            catch (Exception e) {
                lastHit = hit;
                e = null;
            }  
            
            
            if ( Input.GetKeyDown(KeyCode.L)){
                Debug.Log(hit.transform.name + lastHit.transform.name);
            }
        }        
        
    }
}
