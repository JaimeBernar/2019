namespace TFG
{
    public class Settings
    {
        public static readonly string FontBitmapFilename = "test.png";
        public static readonly int GlyphsPerLine = 16;
        public static readonly int GlyphLineCount = 16;
        public static readonly int GlyphWidth = 11;//11
        public static readonly int GlyphHeight = 22;//22

        public static readonly int CharXSpacing = 11;

        public static readonly string Text = "GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);";

        // Used to offset rendering glyphs to bitmap
        public static readonly int AtlasOffsetX = -3, AtlassOffsetY = -1;
        internal int FontSize = 18;
        public static readonly bool BitmapFont = false;
        public static readonly string FromFile;//"C:/Users/jbern/Desktop/TFG/Font.png";
        public static readonly string FontName = "Consolas";
    }
}
