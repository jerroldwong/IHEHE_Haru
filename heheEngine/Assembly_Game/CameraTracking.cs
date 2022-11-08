
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heheEngine
{
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

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.name == "Player")
            {
                cameraScript.isTracking = false;
            }
        }
    }
}