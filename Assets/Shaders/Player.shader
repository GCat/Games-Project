Shader "Custom/Player" {
	Properties{
		_Color("Main Color", Color) = (1,1,1,1)
		_MainTex("Base (RGB) Trans (A)", 2D) = "white" {}
	}

		SubShader{
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		LOD 200

		CGPROGRAM
#pragma surface surf Lambert alpha vertex:vert

		sampler2D _MainTex;
	fixed4 _Color;

	float3 forward = float3(1, 0, 0);
	struct Input {
		float2 uv_MainTex;
		fixed viewIntensity;
		fixed viewDist;
	};

	void vert(inout appdata_full v, out Input o)
	{
		UNITY_INITIALIZE_OUTPUT(Input,o);

		float3 viewDir = ObjSpaceViewDir(v.vertex);
		float3 roundedDir = round(viewDir);
		float i = saturate(dot(normalize(roundedDir), v.normal));
		i = step(0.1,i)*i;
		o.viewIntensity = step(0.2, i);
		o.viewDist = length(viewDir);
	}

	void surf(Input IN, inout SurfaceOutput o)
	{
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		o.Albedo = c.rgb;
		if (IN.viewDist < 1000 ) {
			o.Alpha = c.a*IN.viewIntensity;
		}
		else {
			o.Alpha = 0;
		}
	}
	ENDCG
	}

		Fallback "Standard/Diffuse"
}