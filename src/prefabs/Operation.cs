﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MonoGameEngine.src.Engine;
using MonoGameEngine.src.Game;

namespace MonoGameEngine.src.prefabs
{
    internal class Operation
    {
        protected int value;
        protected Rectangle rect;
        protected string sign;

        protected Operation() { }
        public virtual void execute(Player _player) { }
        public virtual void drawOperation()
        {

        }
        public virtual void setValue(int _value)
        {
            value = _value;
        }

        public virtual void setSign(string _sign)
        {
            sign = _sign;
        }

        public virtual void setRect(Rectangle _rect)
        {
            this.rect = _rect;
        }
        public virtual void draw()
        {
            Color color = new Color(255, 175, 177, 1);
            Render.drawString(Config.Instance.arialFont, sign + value.ToString(), rect, color, "XXXX");
        }
    }

    internal class OperationAdd : Operation
    {
        public OperationAdd()
        {
            sign = "+";
        }
        public override void execute(Player _player)
        {
            _player.points += value;
        }
    }

    internal class OperationSubstract : Operation
    {
        public OperationSubstract()
        {
            sign = "-";
        }
        public override void execute(Player _player)
        {
            _player.points -= value;
        }

    }

    internal class OperationMultiply : Operation
    {
        public OperationMultiply()
        {
            sign = "x";
        }
        public override void execute(Player _player)
        {
            _player.points *= value;
        }
    }

    internal class OperationDivide : Operation
    {
        public OperationDivide()
        {
            sign = ":";
        }
        public override void execute(Player _player)
        {
            _player.points /= value;
        }
    }
}
