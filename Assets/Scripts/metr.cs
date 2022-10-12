using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metr : MonoBehaviour
{
    public float value = 0f;
    public GameObject pointer;

    private float rotation_value = 0f;
    private float current_rotation_value = 270.5f;

    private float max_rotation = 270.5f;
    private float max_value = 1.6f;

    // Start is called before the first frame update
    void Start()
    {
        rotation_value = value / max_value * max_rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!shared_data.isSimulatonEnabled) return;

        float rot_value = Time.deltaTime * 16;

        if (current_rotation_value > rotation_value) {
            current_rotation_value -= rot_value;
            pointer.transform.Rotate(0, 0, rot_value);
        }
    }
}
