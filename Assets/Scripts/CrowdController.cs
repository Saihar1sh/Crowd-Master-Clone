using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdController : MonoBehaviour
{
    public float mvtSpeed;

    public Vector3 offset;

    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        CrowdService.Instance.crowdControllers.Add(this);
        player = CrowdService.Instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -4.5f, 4.5f);
        Vector3 playerPos = player.transform.position;
        //transform.position = Vector3.Lerp(pos, playerPos /*- offset*/, Time.deltaTime * mvtSpeed);
        transform.localPosition = offset;

    }
    private void OnDestroy()
    {
        CrowdService.Instance.crowdControllers.Remove(this);
    }
}
