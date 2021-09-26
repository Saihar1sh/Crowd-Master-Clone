using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdIncrementer : MonoBehaviour
{
    public CrowdIncrementOptions incrementOptions;
    public int incrementValue;
    private int incrementFinalVal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            switch (incrementOptions)
            {
                case CrowdIncrementOptions.None:
                    return;
                case CrowdIncrementOptions.Add:
                    incrementFinalVal = CrowdService.Instance.crowdControllers.Count + incrementValue;
                    break;
                case CrowdIncrementOptions.Multiply:
                    if (incrementValue == 0)
                    {
                        incrementFinalVal = 1;
                        return;
                    }
                    incrementFinalVal = CrowdService.Instance.crowdControllers.Count * incrementValue;
                    break;
                default:
                    break;
            }
            CrowdService.Instance.CreateCrowd(incrementFinalVal);
        }
    }
}
public enum CrowdIncrementOptions
{
    None,
    Add,
    Multiply
}