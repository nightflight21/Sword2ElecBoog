using System.Numerics;

namespace Sword.Casting
{
    /// <summary>
    /// An image.
    /// </summary>
    public class Image : Actor
    {
        private string filename;
        private double scale;
        private int rotation;
        private int _frame = 0;
        private int _index = 0;
        private int _keyFrame = 0;
        private string[] _files = new string[] { String.Empty };
        private bool _repeated = false;

        /// <summary>
        /// Constructs a new instance of Image.
        /// </summary>
        public Image(string filename, double scale = 1.0, int rotation = 0)
        {
            this.filename = filename;
            this.scale = scale;
            this.rotation = rotation;
        }

        /// <summary>
        /// Gets the filename.
        /// </summary>
        /// <returns>The filename.</returns>
        public string GetFilename()
        {
            return filename;
        }

        /// <summary>
        /// Sets the rotation to the given value.
        /// </summary>
        /// <param name="rotation">The given rotation.</param>
        public void SetRotation(int rotation)
        {
            this.rotation = rotation;
        }

        /// <summary>
        /// Sets the scale to the given value.
        /// </summary>
        /// <param name="scale">The given scale.</param>
        public void SetScale(double scale)
        {
            this.scale = scale;
        }

        public string GetFile()
        {
            _frame++;
            if (_frame >= _keyFrame)
            {
                _frame = 0;
                if (_repeated)
                {
                    _index = (_index + 1) % (_files.Length - 1);
                }
                else
                {
                    _index = Math.Min(_index + 1, _files.Length - 1);
                }
            }
            return _files[_index].Trim();
        }
    }
}