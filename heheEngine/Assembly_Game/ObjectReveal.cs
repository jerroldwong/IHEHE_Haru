
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heheEngine
{
    public class ObjectReveal : ScriptComponent
    {
        // params
        Color phaseColor;

        public void RevealObject(bool set, bool canBePortaled)
        {
            if (set)
            {
                phaseColor = new Color(gameObject.GetComponent<SpriteRenderer>().color.r, gameObject.GetComponent<SpriteRenderer>().color.g,
                gameObject.GetComponent<SpriteRenderer>().color.b, 0.7f);
                gameObject.GetComponent<SpriteRenderer>().color = phaseColor;
            }
            else
            {
                phaseColor = new Color(gameObject.GetComponent<SpriteRenderer>().color.r, gameObject.GetComponent<SpriteRenderer>().color.g,
                gameObject.GetComponent<SpriteRenderer>().color.b, 1f);
                gameObject.GetComponent<SpriteRenderer>().color = phaseColor;
            }

            if (canBePortaled)
            {
                GameObject pastChild = gameObject.GetChild(0);
                GameObject presentChild = gameObject.GetChild(1);
                pastChild.GetComponent<SpriteRenderer>().color = phaseColor;
                presentChild.GetComponent<SpriteRenderer>().color = phaseColor;

                Debug.Log("object revealed");
            }

            else
            {
                GameObject presentChild = gameObject.GetChild(0);
                presentChild.GetComponent<SpriteRenderer>().color = phaseColor;


                Debug.Log("object UNrevealed");
            }
        }
    }
}
