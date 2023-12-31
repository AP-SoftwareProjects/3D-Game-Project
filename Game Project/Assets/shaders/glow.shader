Shader"Custom/GlowOutline" {
    Properties {
        _Color ("Main Color", Color) = (.5,.5,.5,1)
        _OutlineColor ("Outline Color", Color) = (1,0,0,1)
        _Outline ("Outline width", Range (.002, 0.03)) = .005
    }

CGINCLUDE
#include "UnityCG.cginc"
    CGINCLUDE

void main()
{
        // Combine outline and main color
    fixed4 mainColor = _Color;
    fixed4 outlineColor = _OutlineColor;
    fixed4 col = mainColor;

        // Calculate outline color
    float4 outline = tex2D(_Outline, o.uv);
    col.rgb = outline.rgb * outlineColor.rgb;

        // Mix the outline and main color
    fixed4 finalColor = lerp(mainColor, col, outline.a);

        // Output final color with alpha
    o.Albedo = finalColor.rgb;
    o.Alpha = finalColor.a;
}
}
