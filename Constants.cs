using System.Collections.Generic;
using Sword.Casting;


namespace Sword
{
    public class Constants
    {
        // ----------------------------------------------------------------------------------------- 
        // GENERAL GAME CONSTANTS
        // ----------------------------------------------------------------------------------------- 

        // GAME
        public static string GAME_NAME = "Sword";
        public static int FRAME_RATE = 60;

        // SCREEN
        public static int SCREEN_WIDTH = 1040;
        public static int SCREEN_HEIGHT = 680;
        public static int CENTER_X = SCREEN_WIDTH / 2;
        public static int CENTER_Y = SCREEN_HEIGHT / 2;

        // FIELD
        public static int FIELD_TOP = 60;
        public static int FIELD_BOTTOM = SCREEN_HEIGHT;
        public static int FIELD_LEFT = 0;
        public static int FIELD_RIGHT = SCREEN_WIDTH;

        // FONT
        public static string FONT_FILE = "Assets/Fonts/zorque.otf";
        public static int FONT_SIZE = 32;

        // SOUND
        public static string BOUNCE_SOUND = "Assets/Sounds/boing.wav";
        public static string WELCOME_SOUND = "Assets/Sounds/start.wav";
        public static string OVER_SOUND = "Assets/Sounds/over.wav";

        // TEXT
        public static int ALIGN_LEFT = 0;
        public static int ALIGN_CENTER = 1;
        public static int ALIGN_RIGHT = 2;


        // COLORS
        public static Color BLACK = new Color(0, 0, 0);
        public static Color WHITE = new Color(255, 255, 255);
        public static Color PURPLE = new Color(255, 0, 255);

        // KEYS
        public static string LEFT = "left";
        public static string RIGHT = "right";
        public static string UP = "up";
        public static string DOWN = "down";
        public static string SPACE = "attack";
        public static string ENTER = "enter";
        public static string PAUSE = "p";

        // SCENES
        public static string NEW_GAME = "new_game";
        public static string TRY_AGAIN = "try_again";
        // public static string NEXT_LEVEL = "next_level";
        public static string IN_PLAY = "in_play";
        public static string GAME_OVER = "game_over";

        // LEVELS
        // public static string LEVEL_FILE = "Assets/Data/level-{0:000}.txt";
        // public static int BASE_LEVELS = 5;

        // ----------------------------------------------------------------------------------------- 
        // SCRIPTING CONSTANTS
        // ----------------------------------------------------------------------------------------- 

        // PHASES
        public static string INITIALIZE = "initialize";
        public static string LOAD = "load";
        public static string INPUT = "input";
        public static string UPDATE = "update";
        public static string OUTPUT = "output";
        public static string UNLOAD = "unload";
        public static string RELEASE = "release";

        // ----------------------------------------------------------------------------------------- 
        // CASTING CONSTANTS
        // ----------------------------------------------------------------------------------------- 

        // STATS
        public static string STATS_GROUP = "stats";
        // public static int DEFAULT_LIVES = 3;
        public static int MAX_HP = 1;
        public static int SCORE = 0;

        // HUD
        public static int HUD_MARGIN = 15;
        // public static string LEVEL_GROUP = "level";
        public static string HEALTH_GROUP = "Health";
        public static string SCORE_GROUP = "score";
        // public static string LEVEL_FORMAT = "LEVEL: {0}";
        public static string HEALTH_FORMAT = "Health: {0}";
        public static string SCORE_FORMAT = "SCORE: {0}";

        // ENEMY
        public static string ENEMY_GROUP = "enemy";
        // public static string BALL_IMAGE = "Assets/Images/000.png";
        public static int ENEMY_WIDTH = 28;
        public static int ENEMY_HEIGHT = 28;
        public static int ENEMY_HEALTH = 40;
        public static int ENEMY_DMG = 1;
        public static int ENEMY_VELOCITY = 1;

        // PLAYER
        public static string PLAYER_GROUP = "player";
        public static int PLAYER_WIDTH = 30;
        public static int PLAYER_HEIGHT = 30;
        public static int PLAYER_HEALTH = 1;
        public static int PLAYER_DMG = 20;
        public static int PLAYER_VELOCITY = 15;
        
        public static List<string> PLAYER_IMAGES
            = new List<string>() {
                "Assets/Images/100.png",
                "Assets/Images/101.png",
                "Assets/Images/102.png"
            };

        public static List<string> Map_IMAGES
            = new List<string>() {
                "Assets/Images/100.png"
            };
        
        public static Dictionary<string, List<string>> ENEMY_IMAGES
            = new Dictionary<string, List<string>>() {
                { "Skeleton", new List<string>() {
                    // "Assets/Images/010.png",
                    // "Assets/Images/011.png",
                    // "Assets/Images/012.png",
                    // "Assets/Images/013.png",
                    // "Assets/Images/014.png",
                    // "Assets/Images/015.png",
                    // "Assets/Images/016.png",
                    // "Assets/Images/017.png",
                    // "Assets/Images/018.png"
                } },
                { "Slime", new List<string>() {
                    // "Assets/Images/020.png",
                    // "Assets/Images/021.png",
                    // "Assets/Images/022.png",
                    // "Assets/Images/023.png",
                    // "Assets/Images/024.png",
                    // "Assets/Images/025.png",
                    // "Assets/Images/026.png",
                    // "Assets/Images/027.png",
                    // "Assets/Images/028.png"
                } },
        };

        // DIALOG
        public static string DIALOG_GROUP = "dialogs";
        public static string ENTER_TO_START = "PRESS ENTER TO START";
        public static string PREP_TO_LAUNCH = "PREPARING TO LAUNCH";
        public static string WAS_GOOD_GAME = "GAME OVER";

    }
}