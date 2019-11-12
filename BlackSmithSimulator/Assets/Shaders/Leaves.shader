Shader "GP4/Leaves" {
Properties{
		_MainTex ("MainTex", 2D) = "white" {}

	}
	SubShader{
		Tags{
			//"Queue" = "Geometry"	
			"Queue" = "Transparent"	
		}


		CGPROGRAM
		//#pragma surface surf Lambert
		#pragma surface surf Lambert alpha:fade

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutput o) {
		    //o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"

}
