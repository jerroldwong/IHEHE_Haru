
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heheEngine
{
    public class ObjectPhase : ScriptComponent
    {
        // params
        Color phaseColor;

        public void PhaseObject(bool set)
        {
            if (set)
            {
                Debug.Log("Phased! " + gameObject.name);
                phaseColor = new Color(gameObject.GetComponent<SpriteRenderer>().color.r, gameObject.GetComponent<SpriteRenderer>().color.g,
                    gameObject.GetComponent<SpriteRenderer>().color.b, 0.7f);
                gameObject.GetComponent<SpriteRenderer>().color = phaseColor;
            }

            else
            {
                Debug.Log("Unphased!" + gameObject.name);
                phaseColor = new Color(gameObject.GetComponent<SpriteRenderer>().color.r, gameObject.GetComponent<SpriteRenderer>().color.g,
                gameObject.GetComponent<SpriteRenderer>().color.b, 1f);
                gameObject.GetComponent<SpriteRenderer>().color = phaseColor;
            }

            PhaseCollision(set);
        }

        private void PhaseCollision(bool set)
        {
            List<GameObject> objList = ObjectBehaviour.objectList;

            foreach (GameObject obj in objList)
            {
                if (obj != this.gameObject)
                {
                    //Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>(), set);
                    // Find alternative to ignore collision
                    gameObject.GetComponent<BoxCollider2D>().enabled = set;
                }

            }

            GameObject player = GameObject.Find("Player Body");
            //Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>(), set);
        }

    }
}
