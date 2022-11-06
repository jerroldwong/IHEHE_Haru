/*_______________________________________________________________________________
 * file:           BobbingScript.cs
 * project:        heheEngine
 * author:         Chiok Wei Wen Gabriel (chiok.w@digipen.edu) [100%]
 * co-author:      -
 * course:         CSD 2400, Section A
 * git-repo:       https://github.com/yinshengkai/SEP3
 * brief:          This script moves an object up and down
 *
 * copyright:      All content (C) 2022 DigiPen Institute of Technology Singapore. All rights reserved.
 * _______________________________________________________________________________*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heheEngine
{
    public class BobbingScript : ScriptComponent
    {
        public float speed = MonoRandom.Range(0, 10);
        private Transform transform;

        public void Start()
        {

        }

        public void Update()
        {

            if(transform == null)
            {
                transform = gameObject.GetComponent<Transform>();
            }
            Vector3 newPosition = Vector3.Lerp(new Vector3(0, 5, 0), new Vector3(0, -5, 0), (Mathf.Sin(Time.time * 2) + 1) / 2);
            transform.Translate(newPosition * Time.deltaTime);
        }
    }
}
