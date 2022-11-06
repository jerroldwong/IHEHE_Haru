/*_______________________________________________________________________________
 * file:           ColorScript.cs
 * project:        heheEngine
 * author:         Chiok Wei Wen Gabriel (chiok.w@digipen.edu) [100%]
 * co-author:      -
 * course:         CSD 2400, Section A
 * git-repo:       https://github.com/yinshengkai/SEP3
 * brief:          This script will change the size of the object
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
    public class GrowScript : ScriptComponent
    {
        [HideFromInspector]
        public bool isGrow = false;

        public void Update()
        {
            if (isGrow)
            {
                Transform t = gameObject.GetComponent<Transform>();
                if (t.scale.y < 2)
                {
                    t.scale += new Vector3(0.001f, 0.001f, 0);
                }
            }
        }


    }
}
