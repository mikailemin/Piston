using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDedector : MonoSingelton<ColliderDedector>
{
    public LayerMask targetlayer;
    public bool isClicked=false;
    [HideInInspector]
    public string assemblyReferanceName;
    void Update()
    {
      

        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(ray, out hit,Mathf.Infinity,targetlayer);
            if (hit.collider!=null&&isClicked)
            {
                Debug.Log(hit.collider.gameObject.name);

                IPartFutures partFutures=hit.collider.gameObject.GetComponent<IPartFutures>();
                partFutures.Check(assemblyReferanceName);
                isClicked = false;
            }
           
        }
    }
}





