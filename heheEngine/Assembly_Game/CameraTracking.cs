
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heheEngine
{
    // this script handles cameraTracking (disable camera tracking if player enters)
    public class CameraTracking : ScriptComponent
    {
        // params
        private GameObject player;
        private GameObject leftHitbox;
        private GameObject rightHitbox;

        CameraScript cameraScript;

        public void Start()
        {
            leftHitbox = GameObject.Find("leftHitbox");
            rightHitbox = GameObject.Find("rightHitbox");
            player = GameObject.Find("Player");
        }

        public void Update()
        {
            if (cameraScript == null)
            {
                cameraScript = GameObject.Find("Camera").GetComponent<CameraScript>();
            }

        }

        public void OnTriggerEnter()
        {
            cameraScript.isTracking = false;
            /*
            if (col.gameObject.name == "Player")
            {
                Debug.Log("collided");
            }
            */
            //Debug.Log("collided");

        }

        public void OnTriggerExit()
        {
            cameraScript.isTracking = true;

            //Debug.Log("left collider");
        }
    }
}
