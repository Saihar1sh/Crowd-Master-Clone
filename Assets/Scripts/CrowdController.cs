using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        CrowdService.Instance.crowdControllers.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -4.5f, 4.5f);
        transform.position = pos;
    }
    private void OnDestroy()
    {
        CrowdService.Instance.crowdControllers.Remove(this);
    }
}
