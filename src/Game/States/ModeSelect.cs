﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameEngine.src.Game;
using MonoGameEngine.src.Game.States;
using MonoGameEngine.src.Engine.UI;


namespace MonoGameEngine.src.Engine.States
{
    internal class ModeSelect : State
    {
        Drawable background;
        Button singlePlayerButton;
        Button twoPlayerButton;
        Button backButton;
        Button exitButton;

        public static Slider sliderWidth;
        public static Slider sliderHeight;

        Drawable rows;
        Drawable cols;
        Rectangle rowVal;
        Rectangle colVal;

        public ModeSelect()
        {

        }

        public override void Init()
        {
            background = new Drawable();
            background.Texture = Config.Instance.background;
            background.position = new Vector2(0, 0);
            background.dimensions = new Vector2(1920, 1080);

            singlePlayerButton = new Button(() => StateManager.Instance.SwitchState(GAME_STATE.GAME_MODE_1), true);
            singlePlayerButton.Texture = Config.Instance.singlePlayerButton;
            singlePlayerButton.position = new Vector2(300, 200);
            singlePlayerButton.dimensions = new Vector2(560, 620);
            singlePlayerButton.setSoundEff(Config.Instance.clickSound);

            twoPlayerButton = new Button(() => StateManager.Instance.SwitchState(GAME_STATE.GAME_MODE_1));
            twoPlayerButton.Texture = Config.Instance.twoPlayerButton;
            twoPlayerButton.position = new Vector2(1920 - 860, 200);
            twoPlayerButton.dimensions = new Vector2(560, 620);
            twoPlayerButton.setSoundEff(Config.Instance.clickSound);

            exitButton = new Button(() => Game1.end = true);
            exitButton.Texture = Config.Instance.exitButton;
            exitButton.position = new Vector2(1770, 50);
            exitButton.dimensions = new Vector2(100, 100);
            exitButton.setSoundEff(Config.Instance.clickSound);

            backButton = new Button(() => StateManager.Instance.SwitchState(GAME_STATE.MENU));
            backButton.Texture = Config.Instance.backButton;
            backButton.position = new Vector2(50, 50);
            backButton.dimensions = new Vector2(100, 100);
            backButton.setSoundEff(Config.Instance.clickSound);

            sliderWidth = new Slider(new Vector2(260, 960), 4, 16);
            sliderHeight = new Slider(new Vector2(1120, 960), 4, 16);

        }

        public override void Update()
        {
            backButton.update();
            exitButton.update();
            //singlePlayerButton.update();
            twoPlayerButton.update();
            GamePlay.gridDimensions.X = sliderWidth.update();
            GamePlay.gridDimensions.Y = sliderHeight.update();

            base.Update();
        }

        public override void draw()
        {
            base.draw();

            background.draw();
            exitButton.draw();
            backButton.draw();
            singlePlayerButton.draw();
            twoPlayerButton.draw();
            sliderWidth.draw();
            sliderHeight.draw();

            Render.drawString(Config.Instance.arialFont,
                "Rows: " + sliderWidth.resultValue.ToString(), new Rectangle(260, 860, 500, 70), Color.White, "XXXXXXXX");
            Render.drawString(Config.Instance.arialFont,
                "Cols: " + sliderHeight.resultValue.ToString(), new Rectangle(1120, 860, 500, 70), Color.White, "XXXXXXXX");
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}

