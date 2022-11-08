﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heheEngine
{
    public class ObjectBehaviour : ScriptComponent
    {
        // params
        public enum ObjectType { Ladder, Tree, GenericProp }
        public static List<GameObject> objectList;

        public ObjectType objectType;

        public bool canBePortaled = false;

        public bool canBeFastForwarded = false;

        public bool canBeFrozen = false;

        public bool canBePhased = false;

        private GameObject player;

        Color portalHighlightColor;
        Color frozenHighlightColor;
        Color fastForwardHighlightColor;
        Color phasedHighlightColor;
        Color defaultColor;

        CameraScript cameraScript;

        public void Awake()
        {
            player = GameObject.Find("Player");
            objectList = new List<GameObject>();
            objectList.Add(this.gameObject);
        }
        
        public void Start()
        {
            portalHighlightColor = new Color(0.7f, 0.7f, 0.3f, 1f);
            frozenHighlightColor = new Color(0.6f, 0.8f, 1f, 255f);
            fastForwardHighlightColor = new Color(1f, 0.8f, 0.7f, 255f);
            phasedHighlightColor = new Color(1f, 0.7f, 1f, 1f);
            defaultColor = new Color(1f, 1f, 1f, 0f);

            cameraScript = GameObject.Find("Camera").GetComponent<CameraScript>();
        }

        public void FreezeObject(bool set)
        {
            if (canBeFrozen)
            {
                if (set)
                {
                    gameObject.GetComponent<ObjectFreeze>().FreezeObject(true);
                }

                else
                {
                    gameObject.GetComponent<ObjectFreeze>().FreezeObject(false);
                }
            }
        }

    }
}