using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodBearingFeature : FeaturesState
{
    public ScrewFeature[] screwFeatures;
    
    public override void Check(string name)
    {
        if (isOkey)
        {
            base.Check(name);
        }
        StartCoroutine(Delay());

    }
    IEnumerator Delay()
    {

        yield return new WaitForSeconds(.6f);
        if (assemblyControls.Count == 0)
        {
          //  isOkey = false;
            for (int i = 0; i < screwFeatures.Length; i++)
            {
                screwFeatures[i].isOkey = true;
            }


        }
    }
}
