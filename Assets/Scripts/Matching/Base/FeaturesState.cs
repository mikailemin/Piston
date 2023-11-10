using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class FeaturesState : MonoBehaviour, IPartFutures
{
    public string referansName;
 
    public bool isOkey;
    [HideInInspector]
    public BoxCollider boxCollider;
    public List<AssemblyControl> assemblyControls = new List<AssemblyControl>();
    public List<AssemblyControl> assemblyControlsBack = new List<AssemblyControl>();

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }
    public virtual void Check(string name)
    {
        if (assemblyControls.Count==0)
        {
           
            Debug.Log("bir sorun olabilir kontrol et");
            return;
        }

        if (assemblyControls[0].assemblyName==name)
        {
            assemblyControls[0].gameObject.transform.position=gameObject.transform.position;

            assemblyControls[0].isDone=false;
            AssemblyControl assembly = assemblyControls[0];
            assemblyControls[0].isBack=true;
           


            assembly.gameObject.transform.DOLocalMove(assembly.endPos1, .5f).OnComplete(()=>{
                assembly.gameObject.transform.DOLocalMove(assembly.endPos2, 1f);
                assemblyControlsBack.Add(assembly);
                assemblyControls.RemoveAt(0);
                boxCollider.enabled=false;

            });


          

            // assemblyControls.Add(assembly);



        }

       
    }
}
