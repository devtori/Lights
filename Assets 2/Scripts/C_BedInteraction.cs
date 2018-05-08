using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_BedInteraction : MonoBehaviour, C_IInteractable
{

    private enum InteractionProperty { open, close }

    private InteractionProperty Property;

    public GameObject openbed;

    void Start()
    {

        Property = InteractionProperty.close;
        openbed.SetActive(false);
    }

    void Update()
    {

    }

    public void Interact(C_DisplayImage currentDisplay)
    {
        if (Property == InteractionProperty.close)
        {
            openbed.SetActive(true);
            Property = InteractionProperty.open;
        }
        else if (Property == InteractionProperty.open)
        {
            openbed.SetActive(false);
            Property = InteractionProperty.close;
        }
    }
}
