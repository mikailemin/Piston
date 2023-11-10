using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AssemblyControl : MonoBehaviour
{
    public Vector3 endPos1;
    public Vector3 endPos2;

    private Vector3 startPos;
    private Vector3 mousePosition;
    

    [HideInInspector]
    public bool isDone;
    [HideInInspector]
    public bool isBack;
  

    [SerializeField]
    private  FeaturesState referanceFuture;
    private BoxCollider referansBoxColiider;

    public string assemblyName;


    private void Start()
    {
        referansBoxColiider=referanceFuture.GetComponent<BoxCollider>();

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
        if (!ColliderDedector.Instance.isClicked && !isDone && !isBack)
        {
            mousePosition = Input.mousePosition - GetmousePos();
            ColliderDedector.Instance.isClicked = true;
            ColliderDedector.Instance.assemblyReferanceName = assemblyName;
            isDone = true;
            referansBoxColiider.enabled = true;

        }
        else if (!ColliderDedector.Instance.isClicked && !isDone&&isBack)
        {
            if (referanceFuture.assemblyControlsBack[referanceFuture.assemblyControlsBack.Count-1]!=this)
            {
                Debug.Log("eşleşmedi");
                return;
            }
            else
            {
                mousePosition = Input.mousePosition - GetmousePos();
                ColliderDedector.Instance.isClicked = true;
                ColliderDedector.Instance.assemblyReferanceName = assemblyName;
                referansBoxColiider.enabled = true;
                referanceFuture.isOkey = true;
                isDone = true;
                isBack=false;
                for (int i = 0; i < referanceFuture.assemblyControls.Count; i++)
                {
                    if (referanceFuture.assemblyControls[i]==this)
                    {
                      
                        return;
                    }

                }
                referanceFuture.assemblyControlsBack.Remove(referanceFuture.assemblyControlsBack[referanceFuture.assemblyControlsBack.Count - 1]);
                referanceFuture.assemblyControls.Insert(0, this); ;
              
            }
          
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
