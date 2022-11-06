#shader fragment
#version 450 core

layout (location = 0) in vec4 v_Color;
layout (location = 1) in vec2 v_TextureCoord;
layout (location = 2) in float v_TextureIndex;
layout (location = 3) in float v_LayerIndex;

layout (location = 0) out vec4 fFragColor;

//uniform float u_Intensity;

void main() 
{
    //float lightLevel = length(v_TextureCoord - vec2(0.5, 0.5));
    float lightLevel = length(v_TextureCoord);
    vec4 fragColor = vec4(v_Color.rgb, v_Color.a * (1.0 - lightLevel));
    //vec4 fragColor = v_Color;

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

uniform mat4 u_ViewProjection;

void main() 
{
    gl_Position = u_ViewProjection * vec4(vec3(a_position), 1.0);
    vTexture = a_texture;
    vColor = a_color;
    vTextureIndex = a_textureIndex;
    vLayerIndex = a_layerIndex;
}