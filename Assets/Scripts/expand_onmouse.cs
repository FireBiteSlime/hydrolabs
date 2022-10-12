using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expand_onmouse : MonoBehaviour
{
    public Vector3 scale_value = new Vector3(0.5f, 0.5f, -2f);

    private Vector3 old_scale_value;

    private void Start()
    {
        old_scale_value = this.transform.localScale;
    }

    void OnMouseEnter()
    {
        this.transform.localScale += scale_value;
    }

    void OnMouseExit()
    {
        this.transform.localScale -= scale_value;
    }

    void OnDisable()
    {
        this.transform.localScale = old_scale_value;
    }
}
