using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_cs;
using Sword.Casting;


namespace Sword.Services
{
    public class RaylibVideoService : IVideoService 
    {
        private Casting.Color color;
        private int height;
        private string title;
        private int width;
        
        private Dictionary<string, Raylib_cs.Font> fonts
            = new Dictionary<string, Raylib_cs.Font>();
        
        private Dictionary<string, Raylib_cs.Texture2D> textures
            = new Dictionary<string, Raylib_cs.Texture2D>();
        
        public RaylibVideoService(string title, int width, int height, Casting.Color color)
        {
            this.title = title;
            this.width = width;
            this.height = height;
            this.color = color;
        }
        /// </inheritdoc>
        public void ClearBuffer()
        {
            Raylib_cs.Color background = ToRaylibColor(color);
            Raylib.BeginDrawing();
            Raylib.ClearBackground(background);
        }

        /// </inheritdoc>

        /// </inheritdoc>
        public void DrawRectangle(Casting.Point size, Casting.Point position, Casting.Color color,
            bool filled = false)
        {
            int x = position.GetX();
            int y = position.GetY();
            int width = size.GetX();
            int height = size.GetY();
            Raylib_cs.Color raylibColor = ToRaylibColor(color);

            if (filled)
            {
                Raylib.DrawRectangle(x, y, width, height, raylibColor);
            }
            else
            {
                Raylib.DrawRectangleLines(x, y, width, height, raylibColor);
            }
        }

        /// </inheritdoc>
       

        /// </inheritdoc>
        public void FlushBuffer()
        {
            Raylib.EndDrawing(); 
        }

        /// </inheritdoc>
        public void Initialize()
        {
            Raylib.InitWindow(width, height, title);
            Raylib.SetTargetFPS(Constants.FRAME_RATE);
        }

        /// </inheritdoc>
        public bool IsWindowOpen()
        {
            return !Raylib.WindowShouldClose();
        }

        /// </inheritdoc>
        public void LoadFonts(string directory)
        {
            List<string> filters = new List<string>() { "*.otf", "*.ttf" };
            List<string> filepaths = GetFilepaths(directory, filters);
            foreach (string filepath in filepaths)
            {
                Raylib_cs.Font font = Raylib.LoadFont(filepath);
                fonts[filepath] = font;
            }
        }

        /// </inheritdoc>
        public void LoadImages(string directory)
        {
            List<string> filters = new List<string>() { "*.png", "*.gif", "*.jpg", "*.jpeg", "*.bmp" };
            List<string> filepaths = GetFilepaths(directory, filters);
            foreach (string filepath in filepaths)
            {
                Raylib_cs.Texture2D texture = Raylib.LoadTexture(filepath);
                textures[filepath] = texture;
            }
        }

        /// </inheritdoc>
        public void Release()
        {
            Raylib.CloseWindow();
        }

        /// </inheritdoc>
        public void UnloadFonts()
        {
            foreach (string key in fonts.Keys)
            {
                Raylib_cs.Font font = fonts[key];
                Raylib.UnloadFont(font);
            }
        }

        /// </inheritdoc>
        public void UnloadImages()
        {
            foreach (string key in textures.Keys)
            {
                Raylib_cs.Texture2D texture = textures[key];
                Raylib.UnloadTexture(texture);
            }
        }

        private List<string> GetFilepaths(string directory, List<string> filters)
        {
            List<string> results = new List<string>();
            foreach (string filter in filters)
            {
                string[] filepaths = Directory.GetFiles(directory, filter);
                results.AddRange(filepaths);
            }
            return results;
        }

        private int RecalcuteTextPosition(Font font, string text, int size, int x, int alignment)
        {
            int width = (int)Raylib.MeasureTextEx(font, text, size, 0).X;
            if (alignment == Constants.ALIGN_CENTER)
            {
                x = x - (width / 2);
            }
            else if (alignment == Constants.ALIGN_RIGHT)
            {
                x = x - width;
            }
            return x;
        }

        private Raylib_cs.Color ToRaylibColor(Casting.Color color)
        {
            return new Raylib_cs.Color(color.GetRed(), color.GetGreen(), color.GetBlue(), 
                System.Convert.ToByte(255));
        }
    
        private Raylib_cs.Color _background = Raylib_cs.Color.BLACK;
        private Dictionary<string, Font> _fonts = new Dictionary<string, Font>();
        private Dictionary<string, Texture2D> _textures = new Dictionary<string, Texture2D>();

        public void Draw(Actor actor)
        {
            Raylib_cs.Color color = GetRaylibColor(actor.GetTint());
            Vector2 position = actor.GetCenter();
            Vector2 size = actor.GetSize();
            float rotation = actor.GetRotation();
            
            Raylib_cs.Rectangle destination = new Raylib_cs.Rectangle(position.X, position.Y, size.X, size.Y);
            Vector2 origin = new Vector2(size.X / 2, size.Y / 2);
            
            Raylib.DrawRectanglePro(destination, origin, rotation, color);
        }

        public void Draw(Actor actor, Camera camera)
        {
            Actor focus = camera.GetFocus();
            Actor screen = camera.GetScreen();

            if (actor == focus || actor.Overlaps(screen))
            {
                Raylib_cs.Color color = GetRaylibColor(actor.GetTint());
                Vector2 position = actor.GetCenter() - camera.GetPosition();
                Vector2 size = actor.GetSize();
                float rotation = actor.GetRotation();

                Raylib_cs.Rectangle destination = new Raylib_cs.Rectangle(position.X, position.Y, size.X, size.Y);
                Vector2 origin = new Vector2(size.X / 2, size.Y / 2);

                Raylib.DrawRectanglePro(destination, origin, rotation, color);
            }
        }

        public void Draw(Casting.Image image)
        {
            Vector2 position = image.GetCenter();
            Vector2 originalSize = image.GetOriginalSize();
            Vector2 size = image.GetSize();
            
            Texture2D texture = GetRaylibTexture(image.GetFile());
            Raylib_cs.Rectangle source = new Raylib_cs.Rectangle(0, 0, originalSize.X, originalSize.Y);
            Raylib_cs.Rectangle destination = new Raylib_cs.Rectangle(position.X, position.Y, size.X, size.Y);
            Vector2 origin = new Vector2(size.X / 2, size.Y / 2);
            float rotation = image.GetRotation();
            Raylib_cs.Color tint = GetRaylibColor(image.GetTint());
            
            Raylib.DrawTexturePro(texture, source, destination, origin, rotation, tint);
        }

        public void Draw(Casting.Image image, Camera camera)
        {
            Actor focus = camera.GetFocus();
            Actor screen = camera.GetScreen();

            if (image == focus || image.Overlaps(screen))
            {
                Vector2 position = image.GetCenter() - camera.GetPosition();
                Vector2 originalSize = image.GetOriginalSize();
                Vector2 size = image.GetSize();
                
                Texture2D texture = GetRaylibTexture(image.GetFile());
                Raylib_cs.Rectangle source = new Raylib_cs.Rectangle(0, 0, originalSize.X, originalSize.Y);
                Raylib_cs.Rectangle destination = new Raylib_cs.Rectangle(position.X, position.Y, size.X, size.Y);
                Vector2 origin = new Vector2(size.X / 2, size.Y / 2);
                float rotation = image.GetRotation();
                Raylib_cs.Color tint = GetRaylibColor(image.GetTint());
                
                Raylib.DrawTexturePro(texture, source, destination, origin, rotation, tint);
            }
        }

        public void Draw(Label label)
        {
            Raylib_cs.Font font = GetRaylibFont(label.GetFontFile());   
            string text = label.GetText();
            Vector2 position = label.GetPosition();
            float fontSize = label.GetFontSize();
            float spacing = 2f;
            Raylib_cs.Color color = GetRaylibColor(label.GetFontColor());
            
            int alignment = label.GetAlignment();
            Vector2 size = Raylib.MeasureTextEx(font, text, fontSize, spacing);
            if (alignment == Label.Right) position.X = position.X - size.X;
            if (alignment == Label.Center) position.X = position.X - (size.X / 2);
            label.SizeTo(size);

            Raylib.DrawTextEx(font, text, position, fontSize, spacing, color);
        }

        public void Draw(Label label, Camera camera)
        {
            Actor focus = camera.GetFocus();
            Actor screen = camera.GetScreen();

            if (label == focus || label.Overlaps(screen))
            {
                Raylib_cs.Font font = GetRaylibFont(label.GetFontFile());   
                string text = label.GetText();
                Vector2 position = label.GetPosition() - camera.GetPosition();
                float fontSize = label.GetFontSize();
                float spacing = 2f;
                Raylib_cs.Color color = GetRaylibColor(label.GetFontColor());
                
                int alignment = label.GetAlignment();
                Vector2 size = Raylib.MeasureTextEx(font, text, fontSize, spacing);
                if (alignment == Label.Right) position.X = position.X - size.X;
                if (alignment == Label.Center) position.X = position.X - (size.X / 2);
                label.SizeTo(size);

                Raylib.DrawTextEx(font, text, position, fontSize, spacing, color);
            }
        }

        public void Draw(List<Actor> actors)
        {
            foreach (Actor actor in actors)
            {
                Draw(actor);
            }
        }

        public void Draw(List<Actor> actors, Camera camera)
        {
            foreach (Actor actor in actors)
            {
                Draw(actor, camera);
            }
        }

        public void Draw(List<Casting.Image> images)
        {
            foreach (Casting.Image image in images)
            {
                Draw(image);
            }
        }
        public void Draw(List<Casting.Image> images, Camera camera)
        {
            foreach (Casting.Image image in images)
            {
                Draw(image, camera);
            }
        }

        public void Draw(List<Label> labels)
        {
            foreach (Label label in labels)
            {
                Draw(label);
            }
        }

        public void Draw(List<Label> labels, Camera camera)
        {
            foreach (Label label in labels)
            {
                Draw(label, camera);
            }
        }

        public void DrawGrid(int cellSize, Casting.Color color)
        {
            Raylib_cs.Color raylibColor = GetRaylibColor(color);
            int width = Constants.SCREEN_WIDTH;
            int height = Constants.SCREEN_HEIGHT;
            
            for (int x = 0; x < width; x += cellSize)
            {
                Raylib.DrawLine(x, 0, x, height, raylibColor);
            }
            for (int y = 0; y < height; y += cellSize)
            {
                Raylib.DrawLine(0, y, width, y, raylibColor);
            }
        }

        public void DrawGrid(int cellSize, Casting.Color color, Camera camera)
        {
            Vector2 position = camera.GetPosition();
            Raylib_cs.Color raylibColor = GetRaylibColor(color);
            int width = (int) camera.GetWorld().GetWidth();
            int height = (int) camera.GetWorld().GetHeight();

            for (int x = 0; x < width; x += cellSize)
            {
                int newX = x - (int)position.X;
                Raylib.DrawLine(newX, 0, newX, height, raylibColor);
            }
            for (int y = 0; y < height; y += cellSize)
            {
                int newY = y - (int)position.Y;
                Raylib.DrawLine(0, newY, width, newY, raylibColor);
            }
        }

        public int GetFps()
        {
            return Raylib.GetFPS();
        }

        public float GetDeltaTime()
        {
            return Raylib.GetFrameTime();
        }

        public bool IsReady()
        {
            return Raylib.IsWindowReady();
        }

        public void SetBackground(Casting.Color color)
        {
            _background = GetRaylibColor(color);
        }

        private Raylib_cs.Color GetRaylibColor(Casting.Color color)
        {
            Tuple<byte, byte, byte, byte> tuple = color.ToTuple();
            return new Raylib_cs.Color(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
        }

        private Raylib_cs.Font GetRaylibFont(string posixFilepath)
        {
            Raylib_cs.Font font = Raylib.GetFontDefault();
            string filepath = posixFilepath.Replace('/', Path.DirectorySeparatorChar);
            if (filepath != string.Empty && !_fonts.ContainsKey(filepath))
            {
                _fonts[filepath] = Raylib.LoadFont(filepath);
                font = _fonts[filepath];
            }
            return font;
        }

        private Raylib_cs.Texture2D GetRaylibTexture(string posixFilepath)
        {
            string filepath = posixFilepath.Replace('/', Path.DirectorySeparatorChar);
            if (!_textures.ContainsKey(filepath))
            {
                _textures[filepath] = Raylib.LoadTexture(filepath);
            }
            return _textures[filepath];
        }
    }
}