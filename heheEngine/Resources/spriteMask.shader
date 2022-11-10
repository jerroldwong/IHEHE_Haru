#shader fragment
#version 450 core

layout (location = 0) in vec4 v_Color;
layout (location = 1) in vec2 v_TextureCoord;
layout (location = 2) in float v_TextureIndex;

layout (location = 0) out vec4 fFragColor;

uniform sampler2D textureA;
uniform sampler2D maskTexture;

uniform bool isInnerMask;

void main() 
{
    vec4 maskColor = texture(maskTexture, v_TextureCoord);

    if(isInnerMask) {
        if(maskColor.a > 0.0){
            fFragColor = texture(textureA, v_TextureCoord);    
        }
    }else{
         if(maskColor.a <= 0.0){
            fFragColor = texture(textureA, v_TextureCoord);
        }
    }

   
}

#shader vertex
#version 450 core

layout (location = 0) in vec3 a_position;
layout (location = 1) in vec4 a_color;
layout (location = 2) in vec2 a_texture;
layout (location = 3) in float a_textureIndex;

layout (location = 0) out vec4 vColor;
layout (location = 1) out vec2 vTexture;
layout (location = 2) out float vTextureIndex;

void main() 
{
    gl_Position = vec4(vec3(a_position), 1.0);
    vTexture = a_texture;
    vColor = a_color;
    vTextureIndex = a_textureIndex;
}