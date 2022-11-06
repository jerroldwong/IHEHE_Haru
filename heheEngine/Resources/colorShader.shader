#shader fragment
#version 450 core

layout (location = 0) in vec4 v_Color;
layout (location = 1) in vec2 v_TextureCoord;
layout (location = 2) in float v_TextureIndex;

layout (location = 0) out vec4 fFragColor;

void main() 
{
    gl_FragDepth = 0.0f;
    fFragColor = v_Color;
    //if(u_Textures[1] == 0){
    //    fFragColor = vec4(1.0f,0.0f,1.0f,1.0f);
    //}else {
    //     fFragColor = vec4(1.0f,1.0f,0.0f,1.0f);
    //}
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

uniform mat4 u_ViewProjection;

void main() 
{
    gl_Position = u_ViewProjection * vec4(vec3(a_position), 1.0);
    vTexture = a_texture;
    vColor = a_color;
    vTextureIndex = a_textureIndex;
}