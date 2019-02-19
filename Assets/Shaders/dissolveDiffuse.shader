Shader "Custom/Dissolve Diffuse" {
    Properties
    {
        _MainTex("Diffuse", 2D) = "white"{}
        _DissolveTex("Dissolve", 2D) = "white"{}
        // _ReflectionMask("Reflection Mask", 2D) = "white"{}
        // _Cube("Cubemap", CUBE) = ""{}
        _Dissolve ("Dissolve", Range(0, 1)) = 0
    }

    SubShader 
    {
    Tags { "RenderType" = "Opaque" }
    Cull Off
    CGPROGRAM
    #pragma surface surf Lambert vertex:vert addshadow
      
    struct Input 
    {
          float2 uv_MainTex;
        //   float3 worldRefl;
    };

    float _Dissolve;

    void vert(inout appdata_full v)
    {
        v.vertex.xyz += v.normal * _Dissolve;
    }

    sampler2D _MainTex;
    sampler2D _DissolveTex;
    // sampler2D _ReflectionMask;
    // samplerCUBE _Cube;
    void surf (Input IN, inout SurfaceOutput o) 
    {
        clip (tex2D(_DissolveTex, IN.uv_MainTex) - _Dissolve) ;
        o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
        // o.Emission = texCUBE(_Cube, IN.worldRefl).rgb * tex2D(_ReflectionMask, IN.uv_MainTex).rgb;
    }
      ENDCG
    }

    Fallback "Diffuse"
  }