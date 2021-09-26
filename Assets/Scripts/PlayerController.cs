using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float mvtSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMvt();

    }

    private void PlayerMvt()
    {
        if (InputManager.Instance.isDragging)
        {
            Vector3 desiredPos = new Vector3(InputManager.Instance.SwipeDelta.normalized.x, 0, 0f) * -1 + transform.position;
            //playerRb.MovePosition(playerRb.position + desiredPos * mvtSpeed * Time.deltaTime);                //mvt using rb
            desiredPos.x = Mathf.Clamp(desiredPos.x, -4.5f, 4.5f);
            transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * mvtSpeed);     //mvt using lerp
            //transform.position = Vector3.SmoothDamp(transform.position, desiredPos, ref currentSpeed, Time.deltaTime * mvtSpeed); //mvt using SmoothDamp
        }
    }
}
