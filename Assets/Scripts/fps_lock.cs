using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fps_lock : MonoBehaviour
{
    public int targetFrameRate = 30;
    public int vSyncCount = 0;
 
    private void Start()
    {
        QualitySettings.vSyncCount = vSyncCount;

        if (targetFrameRate > 0 && vSyncCount == 0)
        {
            Application.targetFrameRate = targetFrameRate > 0 ? targetFrameRate : -1;
        }
    }
}
