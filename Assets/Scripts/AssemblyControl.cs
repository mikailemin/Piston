using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AssemblyControl : MonoBehaviour
{
    public Vector3 endPos1;
    public Vector3 endPos2;

    public Vector3 startPos;
    private Vector3 mousePosition;


    public FeaturesState referanceFuture;
    public PistonGhost ghostObje;


    public string assemblyName;

    [HideInInspector]
    public bool isDone;
    [HideInInspector]
    public bool isBack;

    private void Start()
    {


        startPos = transform.position;
    }
    private Vector3 GetmousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }
    /// <summary>
    /// When the object is clicked, its location is checked and the part where it interacts 
    /// </summary>
    private void OnMouseDown()
    {
        if (!ColliderDedector.Instance.isClicked && !isDone && !isBack)
        {
            mousePosition = Input.mousePosition - GetmousePos();
            ColliderDedector.Instance.isClicked = true;
            ColliderDedector.Instance.assemblyReferanceName = assemblyName;
            isDone = true;
            referanceFuture.ColliderOppenOrFalse(true);



        }
        else if (!ColliderDedector.Instance.isClicked && !isDone && isBack)
        {
          
                mousePosition = Input.mousePosition - GetmousePos();
              
                ColliderDedector.Instance.assemblyReferanceName = assemblyName;
                PartListController.Instance.BackGetFalse(referanceFuture.referansName, this, true);
              
                referanceFuture.isOkey = true;
            
                isBack = false;
                if (referanceFuture.assemblyControls.Contains(this)) return;



                referanceFuture.CheckUp(this);



        }

    }
    private void OnMouseDrag()
    {
        if (ColliderDedector.Instance.isClicked && isDone)
        {

            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);

        }
    }

    private void OnMouseUp()
    {


        StartCoroutine(Delay());


    }

    public IEnumerator Delay()
    {

        yield return new WaitForSeconds(0.2f);
        if (isDone)
        {
            ColliderDedector.Instance.isClicked = false;
            isDone = false;
            transform.position = startPos;
            ColliderDedector.Instance.assemblyReferanceName = "none";
        }
    }


}
