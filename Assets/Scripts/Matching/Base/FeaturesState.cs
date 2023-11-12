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

    /// <summary>
    /// I took the interaction process with parameters and performed the post-comparison operations.
    /// </summary>
    /// <param name="name">
    /// I cannot match the name I sent from the name parameter in the assemblycontrol list.
    /// </param>
    public virtual void Check(string name)
    {
        if (assemblyControls.Count == 0)
        {

            Debug.Log("bir sorun olabilir kontrol et");
            return;
        }

        if (assemblyControls[0].assemblyName == name)
        {
            AssemblyControl assembly = assemblyControls[0];

            assembly.isDone = false;
          
            assembly.isBack = true;



            assembly.gameObject.transform.DOLocalMove(assembly.endPos1, .5f).OnComplete(() =>
            {
                assembly.gameObject.transform.DOLocalMove(assembly.endPos2, 1f);
                assemblyControlsBack.Add(assembly);
                assemblyControls.RemoveAt(0);
                PartListController.Instance.BackGetFalse(referansName, assembly, false);
                ColliderOppenOrFalse(false);
            });




            // assemblyControls.Add(assembly);



        }


    }
    /// <summary>
    /// I send the completed piece of interaction back to its old place.
    /// </summary>
    /// <param name="assembly">
    /// 
    /// </param>
    public virtual void CheckUp(AssemblyControl assembly)
    {

        assemblyControlsBack.Remove(assembly);
        assemblyControls.Insert(0, assembly);

    }

    public virtual void ColliderOppenOrFalse(bool value)
    {
        boxCollider.enabled = value;
    }

    public virtual void CheckShine(string name)
    {
        if (assemblyControls.Count == 0)
        {

            Debug.Log("bir sorun olabilir kontrol et");
            return;
        }

        if (assemblyControls[0].assemblyName == name)
        {
            ColliderDedector.Instance.isShiine = true;


            AssemblyControl assembly = assemblyControls[0];
            assembly.ghostObje.gameObject.SetActive(true);
            assembly.ghostObje.GiveEffect();

        }
    }
}
