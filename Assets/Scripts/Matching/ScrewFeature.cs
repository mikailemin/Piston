using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewFeature : FeaturesState
{
    public Vector3 endPos1;
    public Vector3 endPos2;
 
    public ScrewFeature screwFeatureEx;
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
                    AssemblyControl assembly = assemblyControls[i];

                    assembly.gameObject.transform.DOLocalMove(endPos1, .5f).OnComplete(() =>
                    {
                        assembly.gameObject.transform.DORotate(new Vector3(0, 0, 1440), 3, RotateMode.LocalAxisAdd).SetEase(Ease.Linear);

                        assembly.gameObject.transform.DOLocalMove(endPos2, 1f);
                        screwFeatureEx.assemblyControls.Remove(assembly);
                        screwFeatureEx.assemblyControlsBack.Add(assembly);
                        assemblyControlsBack.Add(assembly);
                        assemblyControls.Remove(assembly);
                        boxCollider.enabled = false;
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
