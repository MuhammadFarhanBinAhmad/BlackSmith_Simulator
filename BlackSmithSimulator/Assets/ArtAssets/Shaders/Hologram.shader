Shader "GP4/Hologram" {
    Properties {
      _RimColor ("Rim Color", Color) = (0,0.5,0.5,0.0)
      _RimPower ("Rim Power", Range(0.5,8.0)) = 3.0
	  _myDiffuse ("Diffuse Texture", 2D) = "white" {}
      _myBump ("Bump Texture", 2D) = "bump" {}
      _mySlider ("Bump Amount", Range(0,10)) = 1
      _myBright ("Brightness", Range(0,10)) = 1
    }
    SubShader {
      Tags{"Queue" = "Transparent"}

      Pass {
        ZWrite On
        ColorMask 0
		//ColorMask RGB
      }


      CGPROGRAM
      
      #pragma surface surf Lambert alpha:fade
      

      float4 _RimColor;
      float _RimPower;
	  sampler2D _myDiffuse;
      sampler2D _myBump;
      half _mySlider;
      half _myBright;
	  

	  struct Input {
          float3 viewDir;
		  float2 uv_myDiffuse;
          float2 uv_myBump;
          float3 worldRefl; INTERNAL_DATA
      };

      void surf (Input IN, inout SurfaceOutput o) {
          half rim = 1.0 - saturate(dot (normalize(IN.viewDir), o.Normal));
          o.Emission = _RimColor.rgb * pow (rim, _RimPower) * 10;
          o.Alpha = pow (rim, _RimPower);
		  o.Albedo = tex2D(_myDiffuse, IN.uv_myDiffuse).rgb;

      }
      ENDCG
    } 
    Fallback "Diffuse"
  }