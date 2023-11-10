using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpClipFeature : FeaturesState
{
    public Vector3 endPos1;
    public Vector3 endPos2;
    public bool isOkey;
    public UpClipFeature upClipEx;
    public override void Check(string name)
    {

        if (isOkey)
        {
            if (assemblyControls.Count == 0)
            {
                Debug.Log("bir sorun olabilir kontrol et");
                return;
            }
            for (int i = 0; i < assemblyControls.Count; i++)
            {
                if (assemblyControls[i].assemblyName == name)
                {
                    assemblyControls[i].gameObject.transform.position = gameObject.transform.position;

                    assemblyControls[i].isDone = false;
                    AssemblyControl assembly = assemblyControls[0];

                    assembly.gameObject.transform.DOLocalMove(endPos1, .5f).OnComplete(() =>
                    {
                        assembly.gameObject.transform.DOLocalMove(endPos2, 1f);
                        upClipEx.assemblyControls.Remove(assembly);
                        assemblyControls.Remove(assembly);
                    });

                }
            }
               
            
            if (assemblyControls.Count == 0)
            {
             
                return;
            }
        }
      

    }
}
