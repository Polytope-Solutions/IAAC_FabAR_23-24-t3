Shader "PolytopeSolutions/UnityToolset/ClippingShader"
{
    // Based on https://www.ronja-tutorials.com/post/021-plane-clipping/
    // With correction based on https://stackoverflow.com/questions/75492809/problem-with-surface-shader-for-clipping-with-a-plane-in-augmented-reality
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _ClippedTex ("Texture", 2D) = "white" {}
        _ClippedColor ("Clipped Render Color", Color) = (1,1,1,1)
        [Toggle] _Clip ("Clip or not", float) = 1

        [HideInInspector] _ClippingPlane ("Clipping Plane", vector) = (0,0,0,0.15)
        [HideInInspector] [Toggle] _RemapFacing ("Remap Facing", float) = 1
    }
       
    SubShader
    {
        Tags { "RenderType" = "Opaque" "Queue"="Geometry" }
        Cull Off
        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows
        #pragma target 3.0
     
        struct Input
        {
            float2 uv_MainTex;
            float3 worldPos;
            
            float facing : VFACE;
        };
         
        sampler2D _MainTex;
        fixed4 _Color;
        sampler2D _ClippedTex;
        float4 _ClippingPlane;
        fixed4 _ClippedColor;
        bool _Clip;
        bool _RemapFacing;
         
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            if (_Clip){
                float distance = dot(IN.worldPos, _ClippingPlane.xyz);
                distance += _ClippingPlane.w;
                clip(-distance);
            }

            float facing = 1;
            if (_RemapFacing)
                facing = IN.facing * 0.5 + 0.5;
            else
                facing = IN.facing;
            facing = step(0.5, facing);

            fixed4 mainCol = tex2D(_MainTex, IN.uv_MainTex);
            mainCol *= _Color;
            fixed4 clippedCol = tex2D(_ClippedTex, IN.uv_MainTex);
            clippedCol *= _ClippedColor;
            fixed4 col = lerp(clippedCol, mainCol, facing);
            o.Albedo = col.rgb * facing;
            o.Emission = lerp(clippedCol, fixed3(0,0,0), facing);
        }
        ENDCG
    }
    Fallback "Standard"
}
