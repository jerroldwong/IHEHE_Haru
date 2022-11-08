
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heheEngine
{
    public class PlayerActions : ScriptComponent
    {
        // params
        public enum CameraPowerType { POWER_TIMEPORTAL, POWER_STASIS, POWER_FASTFORWARD, POWER_PHASE, TYPE_MAX };
        private CameraPowerType currPowerType;

        //generic camera things
        private Camera mainCam;
        private GameObject userInterface;

        //for portal function
        private GameObject portalObj;
        private bool doesPortalExist = false;

        //generic camera skill
        public delegate void PlayerActionFunction();
        public PlayerActionFunction FlashSkill;

        //for the FreezeObject function
        private GameObject frozenObject;
        private bool haveObjectsFrozen = false;

        //for the FastForward function //if multiple objects are to be added, turn it into a list instead.
        private GameObject fastForwardObject;
        private bool haveObjectsFastForwarded = false;

        private GameObject phaseObject;
        private bool haveObjectsPhased = false;

        public GameObject highlightedObj;

        private void Awake()
        {
            mainCam = GameObject.Find("Camera").GetComponent<Camera>();
            userInterface = GameObject.Find("UI Gameplay");
        }

        void Start()
        {
            // to be done after porting UI_Controller
            //SetCameraPower(CameraPowerType.POWER_TIMEPORTAL);
        }

        public GameObject GetFastFowardObject()
        {
            return fastForwardObject;
        }

        public GameObject GetFrozenObject()
        {
            return frozenObject;
        }

        public CameraPowerType GetCameraPowerType()
        {
            return currPowerType;
        }

        // to do: check if raycasting is available, if have, port CheckForHighlightObject() & UnhighlightObject()

        //Camera Abilities
        /*
        void FreezeObject()
        {
            Ray ray = mainCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (haveObjectsFrozen)
            {
                UnfreezeAllObjects();
                haveObjectsFrozen = false;
            }

            if (hit.collider != null)
            {
                if (hit.collider.tag == ("Prop"))
                {
                    hit.transform.gameObject.GetComponent<ObjectFreeze>().FreezeObject(true);
                    frozenObject = hit.transform.gameObject;
                    haveObjectsFrozen = true;
                    return;
                }

                else
                {
                    Debug.Log("Camera did not pick up a valid object to freeze");
                }
            }

            else
            {
                Debug.Log("Camera did not pick up anything to freeze");
            }
        }

        private void UnfreezeAllObjects()
        {
            frozenObject.GetComponent<ObjectFreeze>().FreezeObject(false);
            frozenObject = null;
        }
        */
    }
}
