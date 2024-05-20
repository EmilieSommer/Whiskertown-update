Shader "Custom/ExactColorSwap"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        // Define properties for original and target colors for 16 sets
        _OriginalColor1("Original Color 1", Color) = (1,1,1,1)
        _TargetColor1("Target Color 1", Color) = (1,1,1,1)
        _OriginalColor2("Original Color 2", Color) = (1,1,1,1)
        _TargetColor2("Target Color 2", Color) = (1,1,1,1)
        _OriginalColor3("Original Color 3", Color) = (1,1,1,1)
        _TargetColor3("Target Color 3", Color) = (1,1,1,1)
        _OriginalColor4("Original Color 4", Color) = (1,1,1,1)
        _TargetColor4("Target Color 4", Color) = (1,1,1,1)
        _OriginalColor5("Original Color 5", Color) = (1,1,1,1)
        _TargetColor5("Target Color 5", Color) = (1,1,1,1)
        _OriginalColor6("Original Color 6", Color) = (1,1,1,1)
        _TargetColor6("Target Color 6", Color) = (1,1,1,1)
        _OriginalColor7("Original Color 7", Color) = (1,1,1,1)
        _TargetColor7("Target Color 7", Color) = (1,1,1,1)
        _OriginalColor8("Original Color 8", Color) = (1,1,1,1)
        _TargetColor8("Target Color 8", Color) = (1,1,1,1)
        _OriginalColor9("Original Color 9", Color) = (1,1,1,1)
        _TargetColor9("Target Color 9", Color) = (1,1,1,1)
        _OriginalColor10("Original Color 10", Color) = (1,1,1,1)
        _TargetColor10("Target Color 10", Color) = (1,1,1,1)
        _OriginalColor11("Original Color 11", Color) = (1,1,1,1)
        _TargetColor11("Target Color 11", Color) = (1,1,1,1)
        _OriginalColor12("Original Color 12", Color) = (1,1,1,1)
        _TargetColor12("Target Color 12", Color) = (1,1,1,1)
        _OriginalColor13("Original Color 13", Color) = (1,1,1,1)
        _TargetColor13("Target Color 13", Color) = (1,1,1,1)
        _OriginalColor14("Original Color 14", Color) = (1,1,1,1)
        _TargetColor14("Target Color 14", Color) = (1,1,1,1)
        _OriginalColor15("Original Color 15", Color) = (1,1,1,1)
        _TargetColor15("Target Color 15", Color) = (1,1,1,1)
        _OriginalColor16("Original Color 16", Color) = (1,1,1,1)
        _TargetColor16("Target Color 16", Color) = (1,1,1,1)
        _OriginalColor17("Original Color 16", Color) = (1,1,1,1)
        _TargetColor17("Target Color 16", Color) = (1,1,1,1)
        _OriginalColor18("Original Color 16", Color) = (1,1,1,1)
        _TargetColor18("Target Color 16", Color) = (1,1,1,1)
        _Tolerance("Tolerance", Range(0, 1)) = 0.001  
    }
 
    SubShader
    {
        Tags { "RenderType" = "Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        Cull Off
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
 
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
 
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
 
            sampler2D _MainTex;
            float4 _MainTex_ST;
            // Define variables for original and target colors for 16 sets
            float4 _OriginalColor1;
            float4 _TargetColor1;
            float4 _OriginalColor2;
            float4 _TargetColor2;
            float4 _OriginalColor3;
            float4 _TargetColor3;
            float4 _OriginalColor4;
            float4 _TargetColor4;
            float4 _OriginalColor5;
            float4 _TargetColor5;
            float4 _OriginalColor6;
            float4 _TargetColor6;
            float4 _OriginalColor7;
            float4 _TargetColor7;
            float4 _OriginalColor8;
            float4 _TargetColor8;
            float4 _OriginalColor9;
            float4 _TargetColor9;
            float4 _OriginalColor10;
            float4 _TargetColor10;
            float4 _OriginalColor11;
            float4 _TargetColor11;
            float4 _OriginalColor12;
            float4 _TargetColor12;
            float4 _OriginalColor13;
            float4 _TargetColor13;
            float4 _OriginalColor14;
            float4 _TargetColor14;
            float4 _OriginalColor15;
            float4 _TargetColor15;
            float4 _OriginalColor16;
            float4 _TargetColor16;
            float4 _OriginalColor17;
            float4 _TargetColor17;
            float4 _OriginalColor18;
            float4 _TargetColor18;
            float _Tolerance;
 
            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }
 
            half4 frag(v2f i) : SV_Target
            {
                half4 col = tex2D(_MainTex, i.uv);
 
                if (col.a == 0)
                {
                    return half4(0, 0, 0, 0);
                }
 
                // Check for each set of original and target colors
                if (length(col - _OriginalColor1) < _Tolerance)
                {
                    return half4(_TargetColor1.rgb, col.a);
                }
                else if (length(col - _OriginalColor2) < _Tolerance)
                {
                    return half4(_TargetColor2.rgb, col.a);
                }
                else if (length(col - _OriginalColor3) < _Tolerance)
                {
                    return half4(_TargetColor3.rgb, col.a);
                }
                else if (length(col - _OriginalColor4) < _Tolerance)
                {
                    return half4(_TargetColor4.rgb, col.a);
                }
                else if (length(col - _OriginalColor5) < _Tolerance)
                {
                    return half4(_TargetColor5.rgb, col.a);
                }
                else if (length(col - _OriginalColor6) < _Tolerance)
                {
                    return half4(_TargetColor6.rgb, col.a);
                }
                else if (length(col - _OriginalColor7) < _Tolerance)
                {
                    return half4(_TargetColor7.rgb, col.a);
                }
                else if (length(col - _OriginalColor8) < _Tolerance)
                {
                    return half4(_TargetColor8.rgb, col.a);
                }
                else if (length(col - _OriginalColor9) < _Tolerance)
                {
                    return half4(_TargetColor9.rgb, col.a);
                }
                else if (length(col - _OriginalColor10) < _Tolerance)
                {
                    return half4(_TargetColor10.rgb, col.a);
                }
                else if (length(col - _OriginalColor11) < _Tolerance)
                {
                    return half4(_TargetColor11.rgb, col.a);
                }
                else if (length(col - _OriginalColor12) < _Tolerance)
                {
                    return half4(_TargetColor12.rgb, col.a);
                }
                else if (length(col - _OriginalColor13) < _Tolerance)
                {
                    return half4(_TargetColor13.rgb, col.a);
                }
                else if (length(col - _OriginalColor14) < _Tolerance)
                {
                    return half4(_TargetColor14.rgb, col.a);
                }
                else if (length(col - _OriginalColor15) < _Tolerance)
                {
                    return half4(_TargetColor15.rgb, col.a);
                }
                else if (length(col - _OriginalColor16) < _Tolerance)
                {
                    return half4(_TargetColor16.rgb, col.a);
                }
                else if (length(col - _OriginalColor17) < _Tolerance)
                {
                    return half4(_TargetColor17.rgb, col.a);
                }
                else if (length(col - _OriginalColor18) < _Tolerance)
                {
                    return half4(_TargetColor18.rgb, col.a);
                }
 
                return col;
            }
 
            ENDCG
        }
    }
}
