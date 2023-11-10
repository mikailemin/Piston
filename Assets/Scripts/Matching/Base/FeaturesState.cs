using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FeaturesState : MonoBehaviour, IPartFutures
{
  
    public List<AssemblyControl> assemblyControls = new List<AssemblyControl>();
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

            assembly.gameObject.transform.DOLocalMove(assembly.endPos1, .5f).OnComplete(()=>{
                assembly.gameObject.transform.DOLocalMove(assembly.endPos2, 1f);
                assemblyControls.RemoveAt(0);
            });


          

            // assemblyControls.Add(assembly);



        }

       
    }
}
