﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TohoSTG
{
    class PadState : Dictionary<TohoSTG.PadState.Buttons, bool>
    {
        private Dictionary<Buttons, bool> osaretaInt;
        internal enum Buttons
        {
            left/* = System.Windows.Forms.Keys.A*/,
            right/* = System.Windows.Forms.Keys.D*/,
            up/* = System.Windows.Forms.Keys.W*/,
            down/* = System.Windows.Forms.Keys.S*/,
            button1/* = System.Windows.Forms.Keys.Space*/,
            //button2,
            reset,
        }

        public PadState()
        {
            initialize();
        }

        internal void initialize()
        {
            this.Add(Buttons.left, false);
            this.Add(Buttons.right, false);
            this.Add(Buttons.up, false);
            this.Add(Buttons.down, false);

            this.Add(Buttons.button1, false);
            this.Add(Buttons.reset, false);

            osaretaInt = new Dictionary<Buttons, bool>();
            osaretaInt[Buttons.left] = false;
            osaretaInt[Buttons.right] = false;
            osaretaInt[Buttons.up] = false;
            osaretaInt[Buttons.down] = false;
            osaretaInt[Buttons.button1] = false;
            osaretaInt[Buttons.reset] = false;
        }

        // ぼくたちはこの関数の名前をまだ知らない
        // あえて命名するならpoll()?
        internal void funcA(Buttons b)
        {
            if (this[b] == false) osaretaInt[b] = true;
            this[b] = true;
        }

        internal void KeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.A) funcA(Buttons.left);
            //if (e.KeyCode == System.Windows.Forms.Keys.Left) funcA(Buttons.left);
            if (e.KeyCode == System.Windows.Forms.Keys.D) funcA(Buttons.right);
            if (e.KeyCode == System.Windows.Forms.Keys.W) funcA(Buttons.up);
            if (e.KeyCode == System.Windows.Forms.Keys.S) funcA(Buttons.down);
            if (e.KeyCode == System.Windows.Forms.Keys.Space) funcA(Buttons.button1);
            if (e.KeyCode == System.Windows.Forms.Keys.Z) funcA(Buttons.reset);
        }

        internal void KeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.A) this[Buttons.left] = false;
            if (e.KeyCode == System.Windows.Forms.Keys.D) this[Buttons.right] = false;
            if (e.KeyCode == System.Windows.Forms.Keys.W) this[Buttons.up] = false;
            if (e.KeyCode == System.Windows.Forms.Keys.S) this[Buttons.down] = false;
            if (e.KeyCode == System.Windows.Forms.Keys.Space) this[Buttons.button1] = false;
            if (e.KeyCode == System.Windows.Forms.Keys.Z) this[Buttons.reset] = false;
        }

        internal bool 押された(Buttons b)
        {
#if DEBUG
            if (osaretaInt[b])
            {
                /* do nothing */;
            }
#endif

            return osaretaInt[b];
        }

        internal bool osareteru(Buttons b)
        {
            return this[b];
        }

        internal void clearPressed(Buttons b)
        {
            osaretaInt[b] = false;
        }

        //internal bool isChanged(Buttons buttons)
        //{
        //    return is
        //    throw new NotImplementedException();
        //}
    }
}
