#shader fragment
#version 450 core

layout (location = 0) in vec4 v_Color;
layout (location = 1) in vec2 v_TextureCoord;
layout (location = 2) in float v_TextureIndex;
layout (location = 3) in float v_LayerIndex;

layout (location = 0) out vec4 fFragColor;

uniform sampler2D u_Texture;

void main() 
{
    vec4 fragColor = texture(u_Texture, v_TextureCoord);

    // if(fragColor.a < 0.1){
    //     discard;
    // }

    //gl_FragDepth = v_LayerIndex;

    // if(fragColor.a >= 0.2){
    //     gl_FragDepth = v_LayerIndex;
    // }else{
    //     gl_FragDepth = 1.0f;
    // }

    fFragColor = fragColor;
}

#shader vertex
#version 450 core

layout (location = 0) in vec3 a_position;
layout (location = 1) in vec4 a_color;
layout (location = 2) in vec2 a_texture;
layout (location = 3) in float a_textureIndex;
layout (location = 4) in float a_layerIndex;

layout (location = 0) out vec4 vColor;
layout (location = 1) out vec2 vTexture;
layout (location = 2) out float vTextureIndex;
layout (location = 3) out float vLayerIndex;

void main() 
{
    gl_Position =  vec4(vec3(a_position), 1.0);
    //gl_Position = vec4(vec3(a_position), 1.0);
    vTexture = a_texture;
    vColor = a_color;
    vTextureIndex = a_textureIndex;
    vLayerIndex = a_layerIndex;
}