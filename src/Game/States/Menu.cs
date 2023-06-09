﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameEngine.src.Game;


namespace MonoGameEngine.src.Engine.States
{
    internal class Menu : State
    {
        Drawable background;
        Drawable gameBanner;
        Button playButton;
        Button settingsButton;
        Button exitButton;

        public Menu()
        {

        }

        public override void Init()
        {
            background = new Drawable();
            background.Texture = Config.Instance.background;
            background.position = new Vector2(0, 0);
            background.dimensions = new Vector2(1920, 1080);

            gameBanner = new Drawable();
            gameBanner.Texture = Config.Instance.gameBanner;
            gameBanner.position = new Vector2(260, 150);
            gameBanner.dimensions = new Vector2(1400, 600);

            playButton = new Button(() => StateManager.Instance.SwitchState(GAME_STATE.MODE_SELECT));
            playButton.Texture = Config.Instance.playButton;
            playButton.position = new Vector2(260, 820);
            playButton.dimensions = new Vector2(540, 160);
            playButton.setSoundEff(Config.Instance.clickSound);

            settingsButton = new Button(() => StateManager.Instance.SwitchState(GAME_STATE.INFO));
            settingsButton.Texture = Config.Instance.settingsButton;
            settingsButton.position = new Vector2(1120, 820);
            settingsButton.dimensions = new Vector2(540, 160);
            settingsButton.setSoundEff(Config.Instance.clickSound);

            exitButton = new Button(() => Game1.end = true);
            exitButton.Texture = Config.Instance.exitButton;
            exitButton.position = new Vector2(1770, 50);
            exitButton.dimensions = new Vector2(100, 100);
            exitButton.setSoundEff(Config.Instance.clickSound);
        }

        public override void Update()
        {
            playButton.update();
            settingsButton.update();
            exitButton.update();

            base.Update();
        }

        public override void draw()
        {
            base.draw();

            background.draw();
            gameBanner.draw();
            playButton.draw();
            settingsButton.draw();
            exitButton.draw();
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
