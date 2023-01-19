Shader "Unlit/SimpleSlide" {

    Properties {
        _BaseColor ("Base Color", Color) = (0, 0, 0, 1)
        _FillColor ("Fill Color", Color) = (1, 1, 1, 1)
        _Coverage ("Coverage", Range(0.0, 1.0)) = 0
    }

    SubShader {

        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass {
            CGPROGRAM

            #pragma vertex vertexFunction
            #pragma fragment fragmentFunction
            #pragma target 2.0

            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float4 position : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            fixed4 _BaseColor;
            fixed4 _FillColor;
            float _Coverage;

            v2f vertexFunction(appdata v) {
                v2f o;
                o.position = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 fragmentFunction(v2f i) : SV_Target {
                fixed4 o;
                if (_Coverage > i.uv.x) {
                    o = _FillColor;
                } else {
                    o = _BaseColor;
                }
                return o;
            }

            ENDCG
        }
    }
}
