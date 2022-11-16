
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heheEngine
{
    public class ObjectFF : ScriptComponent
    {
        // params
        public enum ObjectAge { AGE_YOUNG, AGE_ADULT, AGE_DEAD };

        public float ageValue;
        float maxAge = 4;
        float objectAgingIntervals;
        ObjectAge age;

        // Object Manipulation Settings
        bool constrainScaleX;
        bool constrainScaleY;

        /*
        public UnityAction YoungAgeAction;
        public UnityAction AdultAgeAction;
        public UnityAction OldAgeAction;
        public UnityAction OnIncreaseAge;
        */

        // Age Sprites
        //public List<Sprite> AgeSprite;

        bool playerTouch;

        private GameObject uiObj;

        public void Awake()
        {
            uiObj = GameObject.Find("UI Gameplay");
        }

        public void Start()
        {
            ageValue = 0f;
        }

        public void Update()
        {
            if (ageValue == 0)
            {
                //this.gameObject.GetChild(0).GetComponent<SpriteRenderer>().sprite = AgeSprite[0];
            }

            if (ageValue <= 0.5)
            {
                //this.gameObject.GetChild(0).GetComponent<SpriteRenderer>().sprite = AgeSprite[1];

            }

            if (ageValue >= 1)
            {
                //this.gameObject.GetChild(0).GetComponent<SpriteRenderer>().sprite = AgeSprite[2];
            }

            if (ageValue >= 1.5)
            {
                //this.gameObject.GetChild(0).GetComponent<SpriteRenderer>().sprite = AgeSprite[3];
            }

            if (ageValue >= 2)
            {
                //this.gameObject.GetChild(0).GetComponent<SpriteRenderer>().sprite = AgeSprite[4];

                /*
                // to fix: what happens if player ff tree from right side? they cant go to the left to use the ramp collider
                if (this.gameObject.name == "FF_Tree" && ProgressTracker.JobDone == false)
                {
                    // only activate ramp collider if player is on the left
                    if (CheckCollide.playerHit == true)
                    {
                        this.gameObject.GetComponent<PolygonCollider2D>().enabled = true;
                    }
                    // disable only if player is no longer on the left or standing on the ramp
                    else if (CheckCollide.playerHit == false && playerTouch == false)
                    {
                        this.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                    }

                    this.gameObject.GetComponent<BoxCollider2D>().enabled = false;

                }
                */
            }
        }

        public void FastForwardObject(float ageSpeed)
        {
            ageValue += Time.deltaTime * ageSpeed;
            ageValue = Mathf.Clamp(ageValue, 0f, maxAge);
            CheckObjectAge();
            //Debug.Log(ageValue);
            //uiObj.GetComponent<UI_Controller>().UpdateFastForwardBar(maxAge, ageValue);
        }

        public void CheckObjectAge()
        {
            ObjectAge ageLastFrame = age;
            if (ageValue <= objectAgingIntervals * 2f)
            {
                SetObjectAge(ObjectAge.AGE_YOUNG);
                //YoungAgeAction();
            }

            if (ageValue > objectAgingIntervals * 2f && ageValue <= objectAgingIntervals * 3f)
            {
                SetObjectAge(ObjectAge.AGE_ADULT);
                //AdultAgeAction();
            }

            if (ageValue >= maxAge)
            {
                SetObjectAge(ObjectAge.AGE_DEAD);
                DisintegrateObject();
            }
            /*
            if (ageLastFrame != age && OnIncreaseAge != null)
            {
                OnIncreaseAge();
            }
            */
        }

        public void SetObjectAge(ObjectAge ageState)
        {
            age = ageState;
        }

        public void DisintegrateObject()
        {
            //play a particle effect here
            this.gameObject.SetActive(false);
        }

        public void ScaleObject()
        {
            Vector3 oldScale = this.gameObject.GetComponent<Transform>().localScale;
            Vector3 newScale = oldScale;

            if (!constrainScaleX) { newScale.x = oldScale.x + Time.deltaTime; }
            if (!constrainScaleY) { newScale.y = oldScale.y + Time.deltaTime; }

            this.gameObject.GetComponent<Transform>().localScale = new Vector3(newScale.x, newScale.y, newScale.z);
            /*
            if (GameStateHandler.gameStateHandler.GetDebugEnable())
            {
                Debug.Log("Scaling");
            }
            */
        }
    }
}
