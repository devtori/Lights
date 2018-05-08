using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_ManageLightObject : MonoBehaviour
{

    public GameObject Onobject;
    public GameObject Offobject;

    public enum property { type1, type2 };
    public property Property;

    private A_DisplayImage currentdisply;
    void Start()
    {
        currentdisply = GameObject.Find("displayImage").GetComponent<A_DisplayImage>();
        if(currentdisply.CurrentWall < 10 && Property == property.type2)
        {
            Offobject.SetActive(false);
        }
        else
        {
            Offobject.SetActive(true); 
        }
       
    }
    void Update()
    {
        
        CheckType();
    }

    public void CheckType()
    {
       
        if (Property == property.type1)
        {

            if (Onobject.activeSelf)
            {
                Offobject.SetActive(false);
               
            }

            else if(Onobject.activeSelf == false)
            {
                Offobject.SetActive(true);
                Offobject.SetActive(true);
            }
        }
        else
        {

            if (Onobject.activeSelf == true)
            {
                Offobject.SetActive(true);
                Offobject.SetActive(true);
            }
            else if(Onobject.activeSelf == false)
            {
                Offobject.SetActive(false);
            }
        }
    }


}