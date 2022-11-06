/*_______________________________________________________________________________
 * file:           ColorScript.cs
 * project:        heheEngine
 * author:         Chiok Wei Wen Gabriel (chiok.w@digipen.edu) [100%]
 * co-author:      -
 * course:         CSD 2400, Section A
 * git-repo:       https://github.com/yinshengkai/SEP3
 * brief:          This script changes the color of a sprite renderer
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
    public class ColorScript : ScriptComponent
    {
        public float speed = 2.0f;
        private SpriteRenderer spriteRenderer;

        public void Start()
        {
            
        }
        
        public void Update()
        {
            if(spriteRenderer == null)
            {
                spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            }
           spriteRenderer.color = Color.Lerp(Color.green,Color.yellow, (Mathf.Sin(Time.time * speed) + 1) / 2);
          
        }
    }
}
