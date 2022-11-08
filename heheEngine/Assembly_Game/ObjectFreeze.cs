
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heheEngine
{
    public class ObjectFreeze : ScriptComponent
    {
        // params
        private Vector2 savedVelocity;

        public void FreezeObject(bool set)
        {
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            if (set)
            {
                Debug.Log("Frozen! " + gameObject.name);
                savedVelocity = rb.velocity;                                    //save velocity, set velocity to 0.
                rb.velocity = Vector2.zero;
                //rb.constraints = RigidbodyConstraints2D.FreezeAll;              //constrain the object from moving.
            }

            else if (!set)
            {
                Debug.Log("Unfrozen!" + gameObject.name);
                //rb.constraints = RigidbodyConstraints2D.None;
                //rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.velocity = savedVelocity;
            }


        }

    }
}
