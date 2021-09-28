using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdService : MonoSingletonGeneric<CrowdService>
{
    [SerializeField]
    private CrowdController crowd;
    [SerializeField]
    private Transform crowdParent;
    [SerializeField]
    float radius = 0;
    int checkLimiterpercirle = 0;
    int limitPerCirle = 5;
    int serialElementinCircle = 0;
    Vector3 offset;

    public PlayerController player;

    public List<CrowdController> crowdControllers;

    // Start is called before the first frame update
    void Start()
    {
        CreateCrowd(20);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (CrowdController item in crowdControllers)
        {
            item.transform.position = Vector3.ClampMagnitude(player.transform.position, radius);
        }
    }

    public void CreateCrowd(int value = 1)
    {
        for (int i = 0; i < value; i++)
        {
            checkLimiterpercirle = serialElementinCircle % limitPerCirle;
            if (checkLimiterpercirle == 0)
            {
                radius += .5f;
                limitPerCirle += 5;
                serialElementinCircle = 0;
            }
            float theta = serialElementinCircle * 2 * Mathf.PI / limitPerCirle;
            float x = Mathf.Sin(theta) * radius;
            float y = Mathf.Cos(theta) * radius;
            serialElementinCircle++;
            Debug.Log(i + "  clpc: " + checkLimiterpercirle + " limit: " + limitPerCirle + " theta" + theta);
            CrowdController obj = Instantiate(crowd, crowdParent);

            obj.transform.localPosition = obj.offset = new Vector3(x, 0, y);
            //p += .2f;
        }
        /*        for (int i = 0; i < q; i++)
                {
                    CrowdController crowdObj = 
                    Vector3 pos = Vector3.zero;
                    switch (i % 8)
                    {
                        case 0:
                            pos = new Vector3(0.3f, 0, 0.3f);
                            p++;
                            break;
                        case 1:
                            pos = new Vector3(-0.3f, 0, 0.3f);
                            break;
                        case 2:
                            pos = new Vector3(0.3f, 0, -0.3f);
                            break;
                        case 3:
                            pos = new Vector3(-0.3f, 0, -0.3f);
                            break;
                        case 4:
                            pos = new Vector3(0, 0, -.3f);
                            break;
                        case 5:
                            pos = new Vector3(0, 0, .3f);
                            break;
                        case 6:
                            pos = new Vector3(-.3f, 0, 0);
                            break;
                        case 7:
                            pos = new Vector3(.3f, 0, 0);
                            break;

                        default:
                            break;
                    }

                    crowdObj.transform.position = crowdObj.offset = pos * p;
                }
        */
    }
}
