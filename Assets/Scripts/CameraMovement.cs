using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float upLimit;
    public float downLimit;

    public bool moveUp = false;
    public bool moveDown = false;

    public bool trackOn = false;
    public float speed = 7;

    public float xPos;
    public float playerYPos;

    public GameObject player;

    Quaternion rotation;

    // Start is called before the first frame update
    void Awake()
    {
        rotation = transform.rotation;
        xPos = gameObject.transform.localPosition.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        //transform.rotation = rotation;
        this.gameObject.transform.localPosition = new Vector3(0, player.gameObject.transform.localPosition.y, -10);


        /*
        yPos = this.gameObject.transform.localPosition.y;
        playerYPos = player.gameObject.transform.localPosition.y;

        if(trackOn == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, playerYPos, -10f), speed * Time.deltaTime);
            yPos = this.gameObject.transform.localPosition.y;
            playerYPos = player.gameObject.transform.localPosition.y;

            if (yPos - playerYPos >= 0.5f || yPos - playerYPos <= -0.5f)
            {
                trackOn = false;
            }

        }

        else if(yPos - playerYPos >= 3 || yPos - playerYPos <= -3)
        {
            trackOn = true;
        }


        */

        /*
        if (moveUp == true)
        {
            if (yPos + 0.05f <= upLimit)
            {
                yPos = yPos + 0.05f;
                this.gameObject.transform.localPosition = new Vector3(0, yPos, -10);
            }
        }

        if (moveDown == true)
        {
            if (yPos - 0.05 >= downLimit)
            {
                yPos = yPos - 0.05f;
                this.gameObject.transform.localPosition = new Vector3(0, yPos, -10);
            }
        }
        */
    }

    public void MoveUp()
    {
        moveUp = true;
    }

    public void MoveDown()
    {
        moveDown = true;
    }

    public void StopUp()
    {
        moveUp = false;
    }

    public void StopDown()
    {
        moveDown = false;
    }

}

