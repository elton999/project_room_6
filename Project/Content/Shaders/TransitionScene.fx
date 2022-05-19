#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

Texture2D SpriteTexture;
int BlurFactor = 8;

sampler2D SpriteTextureSampler = sampler_state
{
	Texture = <SpriteTexture>;
};

struct VertexShaderOutput
{
	float4 Position : SV_POSITION;
	float4 Color : COLOR0;
	float2 TextureCoordinates : TEXCOORD0;
};

float4 MainPS(VertexShaderOutput input) : COLOR
{
	int Size = BlurFactor;
    float pixel = 0.01;
    float4 color = float4(0,0,0,0);

	for(int e = 0 ; e < (Size * Size) * 2; e++)
	{
		int i = e / Size - Size;
		int j = e % Size - Size;

		if(i != 0 && j != 0)
			color = color + tex2D(SpriteTextureSampler, input.TextureCoordinates + (float2(i, j) * pixel));
	}

	return color / (Size * Size * 8 - 1);
}

technique SpriteDrawing
{
	pass P0
	{
		PixelShader = compile PS_SHADERMODEL MainPS();
	}
};