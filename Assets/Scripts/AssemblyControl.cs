using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblyControl : MonoBehaviour
{
    public Vector3 endPos1;
    public Vector3 endPos2;

    private Vector3 startPos;  
    private Vector3 mousePosition;
   
    
    [HideInInspector]
    public bool isDone;

    


    public string assemblyName;


    private void Start()
    {
      
        
        startPos = transform.position;
    }
    private Vector3 GetmousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }
    /// <summary>
    /// 
    /// 
    /// 
    /// </summary>
    private void OnMouseDown()
    {
        if (!ColliderDedector.Instance.isClicked && !isDone)
        {
            mousePosition = Input.mousePosition - GetmousePos();
            ColliderDedector.Instance.isClicked = true;
            ColliderDedector.Instance.assemblyReferanceName = assemblyName;
            isDone = true;
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
