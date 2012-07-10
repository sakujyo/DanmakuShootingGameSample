using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TohoSTG
{
    class Jiki : Obj
    {
        private const string BMPFileName = @"C:\Users\s\Documents\Visual Studio 2010\Projects\TohoSTG\TohoSTG\image\Jiki.bmp";
        private Bitmap bmp;
        private int width;
        private int height;
        public int Width
        {
            get
            {
                return width;
            }
        }
        public int Height
        {
            get
            {
                return height;
            }
        }
        
        //private int dx;         // Tickごとの自機のx座標の増分
        //private int dy;         // Tickごとの自機のy座標の増分

        public Jiki(double x, double y)
        {
            this.x = x;
            this.y = y;
            bmp = new Bitmap(BMPFileName);
            width = bmp.Width;
            height = bmp.Height;
            bmp.MakeTransparent();
        }

        internal void draw(Graphics g)
        {
            g.DrawImage(bmp, (int)(x), (int)(y));
        }

        internal Boolean judge(double x, double y)
        {
            if (x < this.x + width / 5 ) return false;
            if (x >= this.x + width * 4 / 5) return false;
            if (y < this.y + height / 5 ) return false;
            if (y >= this.y + height * 4 / 5) return false;
                
            return true;
            //throw new NotImplementedException();
        }

        //internal void difference(int ddx, int ddy)
        //{
        //    dx += ddx;
        //    dy += ddy;
        //    //throw new NotImplementedException();
        //}

        internal void move(PadState padState)
        {
            int dx = 0;
            int dy = 0;
            int d = 2;

            dx += padState.osareteru(PadState.Buttons.left) ? -d : 0;
            dx += padState.osareteru(PadState.Buttons.right) ? +d : 0;
            dy += padState.osareteru(PadState.Buttons.up) ? -d : 0;
            dy += padState.osareteru(PadState.Buttons.down) ? +d : 0;
            //if (e.KeyCode == Keys.A) j1.difference(-1, 0);
            //if (e.KeyCode == Keys.D) j1.difference(+1, 0);
            //if (e.KeyCode == Keys.W) j1.difference(0, -1);
            //if (e.KeyCode == Keys.S) j1.difference(0, +1);
            x += dx;
            y += dy;
            //throw new NotImplementedException();
        }
    }
}
