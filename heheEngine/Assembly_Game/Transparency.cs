/*_______________________________________________________________________________
 * file:           Transparency.cs
 * project:        heheEngine
 * author:         Chiok Wei Wen Gabriel (chiok.w@digipen.edu) [100%]
 * co-author:      -
 * course:         CSD 2400, Section A
 * git-repo:       https://github.com/yinshengkai/SEP3
 * brief:          This script will change the alpha value of a color of sprite
 * copyright:      All content (C) 2022 DigiPen Institute of Technology Singapore. All rights reserved.
 * _______________________________________________________________________________*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heheEngine
{
    public class Transparency : ScriptComponent
    {

        public void Update()
        {
            SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
            float alpha = (Mathf.Sin(Time.time * 2) + 1) / 2;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, alpha);
        }
    }
}
