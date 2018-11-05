/*
MIT License

Copyright (c) 2017 Luke Kabat

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

Shader "Outline/Uniform"
{
	Properties
	{
		_Color ("Main Color", color) = (0.5,0.5,0.5,1)
		_OutlineColor ("Outline Color", color) = (0,0,0,1)
		_OutlineWidth ("Outline Width", Range (0,0.6)) = 0.1
		_MainTex ("Texture", 2D) = "white" {}
	}

	CGINCLUDE
#include "UnityCG.cginc"

	struct appdata
	{
		float4 vertex : POSITION;
	};

	struct v2f
	{
		float4 pos : POSITION;
	};

	uniform float _OutlineWidth;
	uniform float _OutlineColor;
	uniform sampler2D _MainTex;
	uniform float4 _Color;

	ENDCG


	SubShader
	{
		Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" }

		Pass
	{
		Zwrite Off
		Cull Back
		CGPROGRAM

		#pragma vertex vert
		#pragma fragment frag

		v2f vert(appdata v)
	{
		appdata original = v;
		v.vertex.xyz += _OutlineWidth * normalize(v.vertex.xyz);

		v2f o;
		o.pos = UnityObjectToClipPos(v.vertex);
		return o;
	}

	half4 frag(v2f i) : COLOR
	{
		return _OutlineColor;
	}

	ENDCG

	}

		Tags { "Queue" = "Geometry"}

		CGPROGRAM
#pragma surface surf Lambert

	struct Input
	{
		float2 uv_MainTex;
	};

	void surf(Input IN, inout SurfaceOutput o)
	{
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		o.Albedo = c.rgb;
		o.Alpha = c.a;
	}

		ENDCG
	}
		Fallback "Diffuse"
}
