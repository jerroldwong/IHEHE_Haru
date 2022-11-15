
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

        public void Awake()
        {
            mainCam = GameObject.Find("Camera").GetComponent<Camera>();
            userInterface = GameObject.Find("UI Gameplay");
        }

        public void Start()
        {
            // to be done after porting UI_Controller
            SetCameraPower(CameraPowerType.POWER_STASIS);
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

        public void SetCameraPower(CameraPowerType type)
        {
            //UI_Controller uiComponent = userInterface.GetComponent<UI_Controller>();
            currPowerType = type;
            switch (type)
            {
                case (CameraPowerType.POWER_TIMEPORTAL):
                    {
                        //FlashSkill = SpawnTimePortal;
                        //uiComponent.EnableFastForwardProgressBar(false);
                        //uiComponent.SetFlashTypeText("Portal");
                        //uiComponent.SetFlashTypeOverlay(CameraPowerType.POWER_TIMEPORTAL);
                        break;
                    }
                case (CameraPowerType.POWER_STASIS):
                    {
                        FlashSkill = FreezeObject;
                        //uiComponent.EnableFastForwardProgressBar(false);
                        //uiComponent.SetFlashTypeText("Stasis");
                        //SetFlashTypeOverlay(CameraPowerType.POWER_STASIS);
                        break;
                    }
                case (CameraPowerType.POWER_FASTFORWARD):
                    {
                        //FlashSkill = SelectToFastForward;
                        //uiComponent.EnableFastForwardProgressBar(true);
                        //uiComponent.SetFlashTypeText("Fast Forward");
                        //uiComponent.SetFlashTypeOverlay(CameraPowerType.POWER_FASTFORWARD);
                        break;
                    }

                case (CameraPowerType.POWER_PHASE):
                    {
                        //FlashSkill = SelectPhaseObject;
                        //uiComponent.EnableFastForwardProgressBar(false);
                        //uiComponent.SetFlashTypeText("Phaser");
                        //uiComponent.SetFlashTypeOverlay(CameraPowerType.POWER_PHASE);
                        break;
                    }
                default:
                    break;
            }
        }

        // to do: check if raycasting is available, if have, port CheckForHighlightObject() & UnhighlightObject()

        //Camera Abilities
        
        void FreezeObject()
        {

            if (haveObjectsFrozen)
            {
                UnfreezeAllObjects();
                haveObjectsFrozen = false;
            }

            if (CameraScript.camHit.GetComponent<BoxCollider2D>() != null)
            {

                if (CameraScript.camHit.tag == "Prop")
                {
                    CameraScript.camHit.GetComponent<ObjectFreeze>().FreezeObject(true);
                    frozenObject = CameraScript.camHit;
                    haveObjectsFrozen = true;
                    Debug.Log(CameraScript.camHit + "is frozen!");
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
                return;
            }
        }

        private void UnfreezeAllObjects()
        {
            frozenObject.GetComponent<ObjectFreeze>().FreezeObject(false);
            frozenObject = null;
        }
        
    }
}
