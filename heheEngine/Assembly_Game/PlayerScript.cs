/*_______________________________________________________________________________
 * file:           PlayerScript.cs
 * project:        heheEngine
 * author:         Chiok Wei Wen Gabriel (chiok.w@digipen.edu) [100%]
 * co-author:      -
 * course:         CSD 2400, Section A
 * git-repo:       https://github.com/yinshengkai/SEP3
 * brief:          This script will control act as the player's controller. This will
 *                 move the player around the game
 * copyright:      All content (C) 2022 DigiPen Institute of Technology Singapore. All rights reserved.
 * _______________________________________________________________________________*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heheEngine
{
    //this is a test enum for debugging purposes
    public enum Test123
    {
        Test1,
        Test2,
        Test3,

    }


    public class PlayerScript : ScriptComponent
    {

        //These are test variables
        public int intTest = 0;
        public float floatTest = 0;
        public double doubleTest = 0;
        public bool boolTest = false;
        public string stringTest = "Test";
        public Test123 enumTest = Test123.Test1;
        public string saif = "OMG";
        CameraScript cameraScript;
        Rigidbody2D rb;

        // movement variables
        float moveLeft = -0.5f;
        float moveRight = 0.5f;

        //This scripts is called during the Update loop of the game loop
        public void Update()
        {
            if (cameraScript == null)
            {
                cameraScript = GameObject.Find("Camera").GetComponent<CameraScript>();
                rb = gameObject.GetComponent<Rigidbody2D>();
            }

            //allow the player to move only if the camera is not zoomed in
            if (!cameraScript.cameraMode)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    Transform t = gameObject.GetComponent<Transform>();
                    t.scale = new Vector3(0.75f, t.scale.y, t.scale.z);
                    //t.Translate(new Vector3(-5*Time.deltaTime, 0, 0));
                    rb.AddForce(new Vector2(-1, 0));  
                }

                if (Input.GetKey(KeyCode.D))
                {
                    Transform t = gameObject.GetComponent<Transform>();
                    t.scale = new Vector3(-0.75f, t.scale.y, t.scale.z);
                    //t.Translate(new Vector3(5 * Time.deltaTime, 0, 0));
                    rb.AddForce(new Vector2(1, 0));
                }

                //Jump
                if (Input.GetKeyDown(KeyCode.SPACE))
                {
                    if (gameObject.GetComponent<Rigidbody2D>() != null)
                    {
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1000));
                    }

                }
     
            }

            //commands to do the camera powers
            else
            {
                if (Input.GetKeyDown(KeyCode.ALPHA_3))
                {
                    GameObject b = GameObject.Find("Big_Rock");
                    b.GetComponent<BoxCollider2D>().isTrigger = true;
                }

                if (Input.GetKeyDown(KeyCode.ALPHA_1))
                {
                    GameObject b = GameObject.Find("Rock");
                    Rigidbody2D r2d = b.GetComponent<Rigidbody2D>();
                    r2d.isStatic = true;
                }

                if (Input.GetKeyDown(KeyCode.ALPHA_2))
                {
                    GameObject b = GameObject.Find("Flower");
                    b.SetActive(true);
                    b.GetComponent<GrowScript>().isGrow = true;
                }
            }


            //commands to zoom in and zoom out camera
            if (Input.GetKeyDown(KeyCode.ALPHA_4))
            {
                cameraScript.cameraMode = true;
                cameraScript.zoomIn = true;

                Debug.Log("test");
            }

            if (Input.GetKeyDown(KeyCode.ALPHA_5))
            {
                cameraScript.zoomOut = true;
            }

        }

        //detect the collision of an object entering a trigger
        public void OnTriggerEnter()
        {
            GameObject b = GameObject.Find("Rock");
            b.SetActive(true);
            Rigidbody2D r2d = b.GetComponent<Rigidbody2D>();
            r2d.gravityScale = 0.01f;
        }

    }
}
