/*_______________________________________________________________________________
 * file:           ColorLight.cs
 * project:        heheEngine
 * author:         Chiok Wei Wen Gabriel (chiok.w@digipen.edu) [100%]
 * co-author:      -
 * course:         CSD 2400, Section A
 * git-repo:       https://github.com/yinshengkai/SEP3
 * brief:          This script changes the color of a light component
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
    public class ColorLight : ScriptComponent
    {
        
        public void Update()
        {
            Color color2 = Color.Lerp(Color.blue, Color.red, (Mathf.Sin(Time.time * 2) + 1) / 2);
            gameObject.GetComponent<PointLight2D>().color = color2;
        }
    }
}
