using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdService : MonoSingletonGeneric<CrowdService>
{
    [SerializeField]
    private CrowdController crowd;

    public List<CrowdController> crowdControllers;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateCrowd(int q = 1)
    {
        for (int i = 0; i < q; i++)
        {
            CrowdController crowdObj = Instantiate(crowd);
        }
    }
}
