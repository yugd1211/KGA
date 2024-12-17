Shader "Custom/MyShader"
{
    Properties
    {
        _MainTex("Texture", 2D) = "White" {}
        OverlapTex("Overlap Texture", 2D) = "gray" {}
        _ColorMultiple("Color Multiple", Range(0, 1)) = 1
        _ClippingMultiple("Clipping Multiple", Integer) = 1
        _ClippingInclin("Clipping Inclinnation", Float) = 1
    }
    SubShader
    {
        Tags {"RenderType"="Opaque"}
        CGPROGRAM
        #pragma surface surf Lambert
        sampler2D _MainTex;
        float _ColorMultiple;
        int _ClippingMultiple;
        float _ClippingInclin;

        
        sampler2D OverlapTex;
        struct Input
        {
            float2 uv_MainTex;
            // float2 uvOverlapTex;
            float4 screenPos;
            float3 worldPos;
        };

        void surf(Input IN, inout SurfaceOutput output)
        {
            clip(frac((IN.worldPos.y * _ClippingMultiple) + (IN.worldPos.x * _ClippingInclin)) - 0.5);
            output.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb * _ColorMultiple;
            // output.Albedo *= tex2D(OverlapTex, IN.uvOverlapTex);
            
            float2 screenUV = (IN.screenPos.xy / IN.screenPos.w) * float2(10, 5);

            float2 timeScale = float2(_SinTime.w, _CosTime.w);

            output.Albedo *= tex2D(OverlapTex, screenUV + timeScale).r * 2;
            // output.Albedo *= tex2D(OverlapTex, screenUV + _CosTime.w).r * 2;
        }
        ENDCG
    }

    FallBack "Diffuse" // off = 
}
