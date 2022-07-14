using System;
using System.Collections.Generic;
using System.IO;
using Sword.Casting;
using Sword.Scripting;
using Sword.Services;


namespace Sword.Directing
{
    public class SceneManager
    {
        //public static AudioService AudioService = new RaylibAudioService();
        //public static IKeyboardService KeyboardService = new RaylibKeyboardService();
        //public static IMouseService MouseService = new RaylibMouseService();
        //public static IPhysicsService PhysicsService = new RaylibPhysicsService();
        //public static IVideoService VideoService = new RaylibVideoService(Constants.GAME_NAME,
            //Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT, Constants.BLACK);
        public static IServiceFactory serviceFactory = new RaylibServiceFactory();

        public SceneManager()
        {
        }

        public void PrepareScene(string scene, Cast cast, Script script)
        {
            if (scene == Constants.NEW_GAME)
            {
                PrepareNewGame(cast, script);
            }
            else if (scene == Constants.TRY_AGAIN)
            {
                PrepareTryAgain(cast, script);
            }
            else if (scene == Constants.IN_PLAY)
            {
                PrepareInPlay(cast, script);
            }
            else if (scene == Constants.GAME_OVER)
            {
                PrepareGameOver(cast, script);
            }
        }

        private void PrepareNewGame(Cast cast, Script script)
        {
            AddStats(cast);
            AddScore(cast);
            AddEnemy(cast);
            AddPlayer(cast);
            AddDialog(cast, Constants.ENTER_TO_START);

            script.ClearAllActions();
            AddInitActions(script);
            AddLoadActions(script);

            AddOutputActions(script);
            AddUnloadActions(script);
            AddReleaseActions(script);
        }
        private void PlaceEnemies(Cast cast, Script script)
        {

        }
        
        private void PrepareTryAgain(Cast cast, Script script)
        {
            AddEnemy(cast);
            AddPlayer(cast);
            AddDialog(cast, Constants.PREP_TO_LAUNCH);

            script.ClearAllActions();
            
            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.IN_PLAY, 2, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);
            
            AddUpdateActions(script);
            AddOutputActions(script);
        }

        private void PrepareInPlay(Cast cast, Script script)
        {
            //ActivateBall(cast);
            cast.ClearActors(Constants.DIALOG_GROUP);

            script.ClearAllActions();

            SteerPlayerAction action = new SteerPlayerAction(serviceFactory);
            script.AddAction(Constants.INPUT, action);

            AddUpdateActions(script);    
            AddOutputActions(script);
        
        }

        private void PrepareGameOver(Cast cast, Script script)
        {
            AddEnemy(cast);
            AddPlayer(cast);
            AddDialog(cast, Constants.WAS_GOOD_GAME);

            script.ClearAllActions();

            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.NEW_GAME, 5, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);

            AddOutputActions(script);
        }

        // -----------------------------------------------------------------------------------------
        // casting methods
        // -----------------------------------------------------------------------------------------

        private void AddEnemy(Cast cast)
        {
            cast.ClearActors(Constants.ENEMY_GROUP);
        
            int x = Constants.CENTER_X - Constants.ENEMY_WIDTH / 2;
            int y = Constants.SCREEN_HEIGHT - Constants.ENEMY_HEIGHT;
        
            Point position = new Point(x, y);
            Point size = new Point(Constants.ENEMY_WIDTH, Constants.ENEMY_HEIGHT);
            Point velocity = new Point(0, 0);
        
            Body body = new Body(position, size, velocity);
            Enemy enemy = new Enemy(body);
        
            cast.AddActor(Constants.ENEMY_GROUP, enemy);
        }

        private void AddDialog(Cast cast, string message)
        {
            cast.ClearActors(Constants.DIALOG_GROUP);

            Text text = new Text(message, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_CENTER, Constants.WHITE);
            Point position = new Point(Constants.CENTER_X, Constants.CENTER_Y);

            //Label label = new Label(text, position);
            //cast.AddActor(Constants.DIALOG_GROUP, label);   
        }

        private void AddPlayer(Cast cast)
        {
            cast.ClearActors(Constants.PLAYER_GROUP);
        
            int x = Constants.CENTER_X - Constants.PLAYER_WIDTH / 2;
            int y = Constants.SCREEN_HEIGHT - Constants.PLAYER_HEIGHT;
        
            Point position = new Point(x, y);
            Point size = new Point(Constants.PLAYER_WIDTH, Constants.PLAYER_HEIGHT);
            Point velocity = new Point(0, 0);
        
            Body body = new Body(position, size, velocity);
            Player player = new Player(body);
        
            cast.AddActor(Constants.PLAYER_GROUP, player);
        }

        private void AddScore(Cast cast)
        {
            cast.ClearActors(Constants.SCORE_GROUP);

            Text text = new Text(Constants.SCORE_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_CENTER, Constants.WHITE);
            Point position = new Point(Constants.CENTER_X, Constants.HUD_MARGIN);
            
            //Label label = new Label(text, position);
            //cast.AddActor(Constants.SCORE_GROUP, label);   
        }

        private void AddStats(Cast cast)
        {
            cast.ClearActors(Constants.STATS_GROUP);
            //Stats stats = new Stats();
            //cast.AddActor(Constants.STATS_GROUP, stats);
        }

        private List<List<string>> LoadLevel(string filename)
        {
            List<List<string>> data = new List<List<string>>();
            using(StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string row = reader.ReadLine();
                    List<string> columns = new List<string>(row.Split(',', StringSplitOptions.TrimEntries));
                    data.Add(columns);
                }
            }
            return data;
        }

        // -----------------------------------------------------------------------------------------
        // scriptig methods
        // -----------------------------------------------------------------------------------------

        private void AddInitActions(Script script)
        {
            // script.AddAction(Constants.INITIALIZE, new InitializeDevicesAction( 
            //     VideoService));
        }

        private void AddLoadActions(Script script)
        {
            //script.AddAction(Constants.LOAD, new LoadAssetsAction( VideoService));
        }

        private void AddOutputActions(Script script)
        {
            //script.AddAction(Constants.OUTPUT, new StartDrawingAction(VideoService));
            //script.AddAction(Constants.OUTPUT, new DrawHudAction(VideoService));
            //script.AddAction(Constants.OUTPUT, new DrawEnemyAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawActorsAction(serviceFactory));
            //script.AddAction(Constants.OUTPUT, new DrawDialogAction(VideoService));
            //script.AddAction(Constants.OUTPUT, new EndDrawingAction(VideoService));
        }

        private void AddUnloadActions(Script script)
        {
            //script.AddAction(Constants.UNLOAD, new UnloadAssetsAction(VideoService));
        }

        private void AddReleaseActions(Script script)
        {
            // script.AddAction(Constants.RELEASE, new ReleaseDevicesAction( 
            //     VideoService));
        }

        private void AddUpdateActions(Script script)
        {
            //script.AddAction(Constants.UPDATE, new MoveBallAction());
            script.AddAction(Constants.UPDATE, new MovePlayerAction());
            //script.AddAction(Constants.UPDATE, new CollideBordersAction(PhysicsService));
            //script.AddAction(Constants.UPDATE, new CollideRacketAction(PhysicsService));
            //script.AddAction(Constants.UPDATE, new CheckOverAction());     
        }
    }
}