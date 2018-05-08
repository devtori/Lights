using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_ManageLightObject : MonoBehaviour
{

    public GameObject Onobject;
    public GameObject Offobject;

    public enum property { type1, type2 };
    public property Property;

    private C_DisplayImage currentdisply;
    void Start()
    {
        currentdisply = GameObject.Find("displayImage").GetComponent<C_DisplayImage>();
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
                //Offobject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            }
        }
    }


}