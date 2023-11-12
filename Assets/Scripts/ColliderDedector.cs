using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDedector : MonoSingelton<ColliderDedector>
{
    public LayerMask targetlayer;
    public bool isClicked=false;
    public bool isShiine=false;
    [HideInInspector]
    public string assemblyReferanceName;

  
    void Update()
    {


        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(ray, out hit, Mathf.Infinity, targetlayer);
            if (hit.collider != null && isClicked&&!isShiine)
            {


                IPartFutures partFutures = hit.collider.gameObject.GetComponent<IPartFutures>();
                partFutures.CheckShine(assemblyReferanceName);

            }
        }
        /// <summary>
        /// where it interacts when you release the mouse button
        /// </summary>
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(ray, out hit,Mathf.Infinity,targetlayer);
            if (hit.collider!=null&&isClicked)
            {
               

                IPartFutures partFutures=hit.collider.gameObject.GetComponent<IPartFutures>();
                partFutures.Check(assemblyReferanceName);
                isClicked = false;
            }
           
        }
    }
}





