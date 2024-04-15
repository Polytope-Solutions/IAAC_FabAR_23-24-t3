Shader "DaniilToolset/MeshVertexShader"
{
	Properties{
		_Transparency("Transparency", Float) = 1
	}
	SubShader
	{
		Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
		LOD 200

		CGPROGRAM
		#pragma surface surf Lambert vertex:vert alpha
		#pragma target 3.0

		float _Transparency;
		struct Input {
			float4 vertColor;
		};

		void vert(inout appdata_full v, out Input o) {
			UNITY_INITIALIZE_OUTPUT(Input, o);
			o.vertColor = v.color;
		}

		void surf(Input IN, inout SurfaceOutput o) {
			o.Albedo = IN.vertColor.rgb;
			o.Alpha = _Transparency;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
