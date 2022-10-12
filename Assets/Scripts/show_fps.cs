using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class show_fps : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        textDisplay.text = ((int)(1.0f / Time.smoothDeltaTime)).ToString();
    }
}
