
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heheEngine
{
    public class Portal : ScriptComponent
    {
        // params
        private float scaleSpeed = 2.0f;
        private float scaleCap = 10.0f;
        GameObject player;
        PlayerActions playerActions;
        private float xScale = 0.0f;
        private float yScale = 0.0f;
        private bool portalExpansion = true;

        public void Start()
        {
            player = GameObject.Find("Player");
            playerActions = player.GetComponent<PlayerActions>();
            xScale = gameObject.GetComponent<Transform>().localScale.x;
            yScale = gameObject.GetComponent<Transform>().localScale.y;
        }

        public void Update()
        {
            if (GetPortalExpansion() == true)
            {
                ExpandPortal();
            }
            else
            {
                ShrinkPortal();
            }
        }

        public void SetPortalExpansion(bool result)
        {
            portalExpansion = result;
        }

        public bool GetPortalExpansion()
        {
            return portalExpansion;
        }

        void ExpandPortal()
        {
            if (xScale <= scaleCap || yScale <= scaleCap)
            {
                xScale += 1.0f * scaleSpeed * Time.deltaTime;
                yScale += 1.0f * scaleSpeed * Time.deltaTime;
                gameObject.GetComponent<Transform>().localScale = new Vector3(xScale, yScale);
            }
        }


        void ShrinkPortal()
        {
            xScale -= 1.0f * scaleSpeed * Time.deltaTime;
            yScale -= 1.0f * scaleSpeed * Time.deltaTime;
            gameObject.GetComponent<Transform>().localScale = new Vector3(xScale, yScale);

            if (xScale <= 0.0f || yScale <= 0.0f)
            {
                gameObject.SetActive(false);
                playerActions.SetPortalExist(false);
            }
        }
    }
}
