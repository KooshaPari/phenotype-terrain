namespace UnityEngine
{
    public struct Color
    {
        public float r, g, b, a;
        public static Color white => new Color(1f, 1f, 1f, 1f);
        public static Color red => new Color(1f, 0f, 0f, 1f);
        public static Color black => new Color(0f, 0f, 0f, 1f);
        public Color(float r, float g, float b, float a) { this.r = r; this.g = g; this.b = b; this.a = a; }
        public static bool operator ==(Color a, Color b) => a.r == b.r && a.g == b.g && a.b == b.b && a.a == b.a;
        public static bool operator !=(Color a, Color b) => !(a == b);
        public override bool Equals(object obj) => obj is Color c && this == c;
        public override int GetHashCode() => (r, g, b, a).GetHashCode();
    }
}
