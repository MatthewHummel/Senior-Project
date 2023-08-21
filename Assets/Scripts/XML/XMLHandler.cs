using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

//UNUSED CURRENTLY, POSSIBLY USEFUL LATER - Matt
public class XMLHandler : MonoBehaviour
{
    
    public struct XMLStruct
    {
        public string funcName;
        public object[] funcParams;
    }



    void CallFunctionFromXML (XMLStruct data)
    {
        //get the method information using methodInfo class
        MethodInfo method = this.GetType().GetMethod(data.funcName);

        //invoke the method here
        method.Invoke(this, data.funcParams);
    }


}
