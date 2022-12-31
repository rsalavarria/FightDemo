using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    protected bool isExecuting;
    protected float currentTime;

    protected void StartExecute()
    {
        isExecuting = true;
    }

    protected void FinishExecute()
    {
        isExecuting = false;
        currentTime = 0;
    }
}
