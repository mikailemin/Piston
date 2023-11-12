using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewFeature : FeaturesState
{
    public Vector3 endPos1;
    public Vector3 endPos2;
    public RodBearingFeature bearingFeature;
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
                  

                    AssemblyControl assembly = assemblyControls[i];
                    assembly.isDone = false;
                    assembly.referanceFuture = this;
                    assembly.isBack = true;

                    assembly.gameObject.transform.DOLocalMove(endPos1, .5f).OnComplete(() =>
                    {
                        assembly.gameObject.transform.DORotate(new Vector3(0, 0, 1440), 3, RotateMode.LocalAxisAdd).SetEase(Ease.Linear);

                        assembly.gameObject.transform.DOLocalMove(endPos2, 1f);
                        screwFeatureEx.assemblyControls.Remove(assembly);
                        screwFeatureEx.assemblyControlsBack.Add(assembly);
                        assemblyControlsBack.Add(assembly);
                        assemblyControls.Remove(assembly);
                        ColliderOppenOrFalse(false);

                        if (assemblyControlsBack.Count > 0)
                        {
                            AssemblyControl control = PartListController.Instance.GetAssemblyLast(bearingFeature.referansName);
                            PartListController.Instance.GetFalse(bearingFeature.referansName, control, false);
                            bearingFeature.isOkey = false;

                        }
                        else
                        {
                            bearingFeature.isOkey = true;
                        }
                        PartListController.Instance.WinControl();
                    });

                }
            }

        }

    }
    public override void CheckShine(string name)
    {
        if (isOkey)
        {
            for (int i = 0; i < assemblyControls.Count; i++)
            {
                if (assemblyControls[i].assemblyName == name)
                {
                    AssemblyControl assembly = assemblyControls[i];
                    assembly.referanceFuture = this;
                    assembly.ghostObje.gameObject.SetActive(true);
                    assembly.ghostObje.GiveEffect();

                }
            }
        }
                
        
    }
    public override void CheckUp(AssemblyControl assembly)
    {
        base.CheckUp(assembly);
        assembly.gameObject.transform.DOLocalMove(endPos2, 1f).OnComplete(() =>
        {
            assembly.gameObject.transform.DORotate(new Vector3(0, 0, -1440), 3, RotateMode.LocalAxisAdd).SetEase(Ease.Linear);
            assembly.gameObject.transform.DOLocalMove(endPos1, 0.5f).OnComplete(() =>
            {
                assembly.gameObject.transform.position = assembly.startPos;
            });
        });

        screwFeatureEx.assemblyControlsBack.Remove(assembly);
        screwFeatureEx.assemblyControls.Insert(0, assembly);
        if (assemblyControlsBack.Count == 0)
        {
            AssemblyControl control = PartListController.Instance.GetAssemblyLast(bearingFeature.referansName);
            PartListController.Instance.GetFalse(bearingFeature.referansName, control, true);
            bearingFeature.isOkey = true;

        }
        else
        {
            bearingFeature.isOkey = false;
        }


    }
    public override void ColliderOppenOrFalse(bool value)
    {
        base.ColliderOppenOrFalse(value);
        screwFeatureEx.boxCollider.enabled = value;
    }
}
