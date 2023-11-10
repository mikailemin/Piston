using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpClipFeature : FeaturesState
{
    public Vector3 endPos1;
    public Vector3 endPos2;
    public PistonFeature pistonFeature;
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
                    AssemblyControl assembly = assemblyControls[i];
                    assembly.referanceFuture = this;
                    assembly.isBack = true;

                    assembly.gameObject.transform.DOLocalMove(endPos1, .5f).OnComplete(() =>
                    {
                        assembly.gameObject.transform.DOLocalMove(endPos2, 1f);
                        upClipEx.assemblyControls.Remove(assembly);
                        upClipEx.assemblyControlsBack.Add(assembly);
                        assemblyControlsBack.Add(assembly);
                        assemblyControls.Remove(assembly);
                        ColliderOppenOrFalse(false);
                        if (assemblyControlsBack.Count > 0)
                        {
                            AssemblyControl control = PartListController.Instance.GetAssemblyLast(pistonFeature.referansName);
                            PartListController.Instance.GetFalse(pistonFeature.referansName, control, false);
                            pistonFeature.isOkey = false;

                        }
                        else
                        {
                            pistonFeature.isOkey = true;
                        }
                        PartListController.Instance.WinControl();
                    });
                }
            }



        }


    }
    public override void CheckUp(AssemblyControl assembly)
    {
        base.CheckUp(assembly);

        assembly.gameObject.transform.DOLocalMove(endPos2, .5f).OnComplete(() =>
        {
            assembly.gameObject.transform.DOLocalMove(endPos1, 1f).OnComplete(() =>
            {
                assembly.gameObject.transform.position = assembly.startPos;
            }); 
        });
        upClipEx.assemblyControlsBack.Remove(assembly);
        upClipEx.assemblyControls.Insert(0, assembly);
        if (assemblyControlsBack.Count == 0)
        {
            AssemblyControl control = PartListController.Instance.GetAssemblyLast(pistonFeature.referansName);
            PartListController.Instance.GetFalse(pistonFeature.referansName, control, true);
            pistonFeature.isOkey = true;

        }
        else
        {
            pistonFeature.isOkey = false;
        }
       

    }
    public override void ColliderOppenOrFalse(bool value)
    {
        base.ColliderOppenOrFalse(value);
        upClipEx.boxCollider.enabled = value;
    }

}
