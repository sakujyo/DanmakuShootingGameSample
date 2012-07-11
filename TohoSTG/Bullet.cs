using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TohoSTG
{
    class Bullet : Obj
    {
        internal enum Sides
        {
            teki,
            mikata
        }
        // 弾幕用の弾丸1個

        private double vx;
        private double vy;
        private Sides side;
        public Sides Side
        {
            get
            {
                return side;
            }
        }

        //public Bullet(double x, double y, double vx, double vy) : this(Side.teki, x, y, vx, vy)
        //{
        //}

        public Bullet(Sides side, double x, double y, double vx, double vy)
        {
            this.side = side;   // teki, mikataの区別
            this.x = x;
            this.y = y;
            this.vx = vx;
            this.vy = vy;
        }

        internal void draw(Form1 form1, Graphics g)
        {
            Pen p;
            if (side == Sides.teki)
            {
                p = Pens.LightPink;
            }
            else
            {
                p = Pens.SkyBlue;
            }
            // 十字型の弾丸をプログラムで描画
            g.DrawLine(p, (float)(x + 1), (float)(y), (float)(x + 1), (float)(y + 2));
            g.DrawLine(p, (float)(x), (float)(y + 1), (float)(x + 2), (float)(y + 1));
            g.DrawLine(Pens.White, (float)(x + 1), (float)(y + 1), (float)(x + 1), (float)(y + 1));
            
            //g.FillRectangle(Brushes.Black, (int)(x), (int)(y), 3, 3);

            //g.FillRectangle(Brushes.Black, (int)(x), (int)(y), 3, 3);
            
            //form1.Refresh();
            //throw new NotImplementedException();
        }

        //internal void zanzou(Form1 form1, Graphics g)
        //{
        //    g.FillRectangle(Brushes.Gray, (int)(x), (int)(y), 3, 3);
        //    //form1.Refresh();
        //    //throw new NotImplementedException();
        //}

        internal void move()
        {
            // 弾の移動
            x += vx;
            y += vy;
            //throw new NotImplementedException();
        }

        internal Boolean isFadeOut(int screenWidth, int screenHeight)
        {
            if (x >= screenWidth) return true;
            if (x < 0) return true;
            if (y >= screenHeight) return true;
            if (y < 0) return true;
            return false;
        }

        internal Boolean inquire(Jiki j)
        {
            return j.judge(x, y);
            //throw new NotImplementedException();
        }

        internal Boolean inquire(Enemy e)
        {
            return e.judge(x, y);
            //throw new NotImplementedException();
        }
    }
}
