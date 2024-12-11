Shader "Custom/LeftEyeShader"
{
    Properties
    {
        _ColorLeft ("Left Eye Color", Color) = (1,0,0,1)
        _ColorRight ("Right Eye Color", Color) = (0,0,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _Contrast ("Contrast", Range(0,3)) = 1.0
        _DistortionStrength ("Distortion Strength", Range(0,0.1)) = 0.05
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM

        #pragma surface surf Standard fullforwardshadows

        #pragma target 3.0

        #pragma multi_compile_instancing

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _ColorLeft;
        fixed4 _ColorRight;
        half _Contrast;
        half _DistortionStrength;

        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            float isLeftEye = unity_StereoEyeIndex == 0 ? 1.0 : 0.0;

            fixed4 eyeColor = isLeftEye > 0.5 ? _ColorLeft : _ColorRight;

            float2 distortedUV = IN.uv_MainTex;
            distortedUV.x += sin(distortedUV.y * 10.0) * _DistortionStrength * isLeftEye;
            distortedUV.y += cos(distortedUV.x * 10.0) * _DistortionStrength * (1.0 - isLeftEye);

            fixed4 c = tex2D(_MainTex, distortedUV) * eyeColor;

            c.rgb = (c.rgb - 0.5) * _Contrast + 0.5;

            o.Albedo = c.rgb;
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}