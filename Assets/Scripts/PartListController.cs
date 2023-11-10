using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartListController : MonoSingelton<PartListController>
{
    public List<AssemblyList> assemblyList;

    public void BackGetFalse(string name,AssemblyControl assembly)
    {
        for (int i = 0; i < assemblyList.Count; i++)
        {
          if(assemblyList[i].name == name)
            {
                for (int j = 0; j < assemblyList[i].SideList.Count; j++)
                {
                    if (assemblyList[i].SideList[i] == assembly)
                    {
                        assemblyList[i].SideList[i].isBack=true;
                     
                    }
                }
            }
        }
    }
   
}

[Serializable]
public class AssemblyList
{
    public string name;
    public List<AssemblyControl> SideList;
}
