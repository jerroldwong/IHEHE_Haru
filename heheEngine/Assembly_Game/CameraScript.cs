/*_______________________________________________________________________________
 * file:           CameraScript.cs
 * project:        heheEngine
 * author:         Chiok Wei Wen Gabriel (chiok.w@digipen.edu) [100%]
 * co-author:      -
 * course:         CSD 2400, Section A
 * git-repo:       https://github.com/yinshengkai/SEP3
 * brief:          This script changes the behaviour of a camera component
 *
 * copyright:      All content (C) 2022 DigiPen Institute of Technology Singapore. All rights reserved.
 * _______________________________________________________________________________*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heheEngine
{
    public class CameraScript : ScriptComponent
    {
        //control various states of the camera
        public bool zoomIn = false;
        public bool zoomOut = false;
        public bool cameraMode = false;

        // controls camera tracking
        public bool isTracking = true;

        private GameObject player;
        private Camera camera;
        private Transform transform;
        private Transform playerTransform;

        //Calls every frame
        public void Update()
        {
            //set component variables
            if (camera == null)
            {
                camera = gameObject.GetComponent<Camera>();
            }

            if (player == null)
            {
                player = GameObject.Find("Player");
                playerTransform = player.GetComponent<Transform>();
            }

            if (transform == null)
            {
                transform = gameObject.GetComponent<Transform>();
            }


            //performs the zoom in effect
            if (zoomIn && camera.zoomLevel >= 3.5f)
            {
                camera.zoomLevel -= 0.1f;
                if (camera.zoomLevel <= 3.5f)
                {
                    zoomIn = false;
                }
            }


            //performs the zoom out effect
            if (zoomOut && camera.zoomLevel <= 5.0f)
            {
                camera.zoomLevel += 0.1f;
                if (camera.zoomLevel >= 5.0f)
                {
                    zoomOut = false;
                    cameraMode = false;
                }
            }


            //move the camera only when you are zoomed in
            if (cameraMode)
            {
                if (Input.GetKey(KeyCode.UP_ARROW))
                {
                    transform.Translate(new Vector3(0, 5 * Time.deltaTime, 0));
                }

                if (Input.GetKey(KeyCode.DOWN_ARROW))
                {
                    transform.Translate(new Vector3(0, -5 * Time.deltaTime, 0));
                }

                if (Input.GetKey(KeyCode.LEFT_ARROW))
                {
                    transform.Translate(new Vector3(-5 * transform.scale.x * Time.deltaTime, 0, 0));
                }


                if (Input.GetKey(KeyCode.RIGHT_ARROW))
                {
                    transform.Translate(new Vector3(5 * transform.scale.x * Time.deltaTime, 0, 0));
                }
            }

            else
            {
                if (isTracking == true)
                {
                    //make camera follow the player in zoomed out mode
                    transform.position = Vector3.Lerp(transform.position, playerTransform.position + new Vector3(0.0f, 3.0f, 0.0f), Time.deltaTime * 2.0f);

                    //Debug.Log("camera is tracking");
                }

                if (isTracking == false)
                {
                    transform.position = transform.position;

                    //Debug.Log("camera is not tracking");
                }
            }
        }
    }
}
