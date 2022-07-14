﻿using System;
using Sword.Casting;
using Sword.Directing;
using Sword.Scripting;
using Sword.Services;

namespace Sword
{
    public class Program
    {
        static void Main(string[] args)
        {
            IServiceFactory serviceFactory = new RaylibServiceFactory();

            // Instantiate the actors that are used in this example.
            Label instructions = new Label();
            instructions.Display("'w', 's', 'a', 'd' to move");
            instructions.MoveTo(25, 25);

            Label status = new Label();
            status.Display("x:-, y:-");
            status.MoveTo(25, 55);
            
            Actor player = new Actor();
            player.SizeTo(50, 50);
            player.MoveTo(640, 480);
            player.Tint(Color.Red());

            Actor screen = new Actor();
            screen.SizeTo(640, 480);
            screen.MoveTo(0, 0);

            Actor world = new Actor();
            world.SizeTo(1280, 960);
            world.MoveTo(0, 0);

            Camera camera = new Camera(player, screen, world);

            // Instantiate the actions that use the actors.
            SteerPlayerAction steerPlayerAction = new SteerPlayerAction(serviceFactory);
            MovePlayerAction movePlayerAction = new MovePlayerAction();
            UpdateStatusAction updateStatusAction = new UpdateStatusAction();
            DrawActorsAction drawActorsAction = new DrawActorsAction(serviceFactory);

            // Instantiate a new scene, add the actors and actions.
            Scene scene = new Scene();
            scene.AddActor("instructions", instructions);
            scene.AddActor("status", status);
            scene.AddActor("player", player);
            scene.AddActor("camera", camera);
            
            scene.AddAction(Phase.Input, steerPlayerAction);
            scene.AddAction(Phase.Update, movePlayerAction);
            scene.AddAction(Phase.Update, updateStatusAction);
            scene.AddAction(Phase.Output, drawActorsAction);
            
            Director director = new Director(SceneManager.VideoService);
            director.StartGame();
        }
    }
}