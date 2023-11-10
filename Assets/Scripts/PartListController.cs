using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PartListController : MonoSingelton<PartListController>
{
    public List<AssemblyList> assemblyList;


    public AssemblyControl GetAssemblyLast(string name)
    {
        for (int i = 0; i < assemblyList.Count; i++)
        {
            if (assemblyList[i].name == name)
            {
                return assemblyList[i].SideList[assemblyList[i].SideList.Count - 1];
            }
        }
        Debug.Log("bir sorun olabilir");
        return null;
    }
    public void BackGetFalse(string name, AssemblyControl assembly, bool value)
    {
        for (int i = 0; i < assemblyList.Count; i++)
        {
            if (assemblyList[i].name == name)
            {
                for (int j = 0; j < assemblyList[i].SideList.Count; j++)
                {
                    if (assemblyList[i].SideList[j].assemblyName == assembly.assemblyName)
                    {
                        if (j == 0)
                        {
                            return;
                        }
                       // Debug.Log("kolaydır etkileşim" + assembly.gameObject.name + "  " + value);
                        assemblyList[i].SideList[j - 1].GetComponent<BoxCollider>().enabled = value;

                    }
                }
            }
        }
    }
    public void WinControl()
    {


        for (int i = 0; i < assemblyList.Count; i++)
        {

            for (int j = 0; j < assemblyList[i].SideList.Count; j++)
            {
                if (!assemblyList[i].SideList[j].isBack)
                {
                    return;

                }
            }

        }

        Debug.Log("winnnn");

    }
    public void GetFalse(string name, AssemblyControl assembly, bool value)
    {
        for (int i = 0; i < assemblyList.Count; i++)
        {
            if (assemblyList[i].name == name)
            {
                for (int j = 0; j < assemblyList[i].SideList.Count; j++)
                {
                    if (assemblyList[i].SideList[j].assemblyName == assembly.assemblyName)
                    {
                        if (j == 0)
                        {
                            return;
                        }
                      //  Debug.Log("kolaydır etkileşim" + assembly.gameObject.name + "  " + value);
                        assemblyList[i].SideList[j].GetComponent<BoxCollider>().enabled = value;

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
