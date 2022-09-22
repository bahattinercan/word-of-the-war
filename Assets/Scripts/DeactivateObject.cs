using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObject : MonoBehaviour
{
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void DeactivateParent()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
