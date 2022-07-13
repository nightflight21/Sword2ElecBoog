using System;

namespace Sword.Casting
{
    /// <summary>
    /// A color. 
    /// </summary>
    public class Color
    {
        private byte _red = 0;
        private byte _green = 0;
        private byte _blue = 0;
        private byte _alpha = 0;

        /// <summary>
        /// Constructs a new instance of Color.
        /// </summary>
        public static Color Black() { return new Color(0, 0, 0); }
        public static Color Red() { return new Color(255, 0, 0); }
        public static Color Orange() { return new Color(255, 128, 0); }
        public static Color Yellow() { return new Color(255, 255, 0); }
        public static Color Green() { return new Color(0, 255, 0); }
        public static Color Blue() { return new Color(0, 128, 255); }
        public static Color Purple() { return new Color(127, 0, 255); }
        public static Color White() { return new Color(255, 255, 255); }
        public static Color Gray() { return new Color(128, 128, 128); }

        public Color(byte red, byte green, byte blue, byte alpha = 255)
        {
            _red = red;
            _green = green;
            _blue = blue;
            _alpha = alpha;
        }

        /// <summary>
        /// Gets the alpha value.
        /// </summary>
        /// <returns>The alpha value.</returns>
        public int GetAlpha()
        {
            return _alpha;
        }

        /// <summary>
        /// Gets the blue value.
        /// </summary>
        /// <returns>The blue value.</returns>
        public int GetBlue()
        {
            return _blue;
        }

        /// <summary>
        /// Gets the green value.
        /// </summary>
        /// <returns>The green value.</returns>
        public int GetGreen()
        {
            return _green;
        }

        /// <summary>
        /// Gets the red value.
        /// </summary>
        /// <returns>The red value.</returns>
        public int GetRed()
        {
            return _red;
        }
        public Tuple<byte, byte, byte, byte> ToTuple()
        {
            return Tuple.Create(_red, _green, _blue, _alpha);
        }
        
    }
}