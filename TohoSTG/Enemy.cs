using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TohoSTG
{
    class Enemy : Obj
    {
        private const string BMPFileName = @"C:\Users\s\Documents\Visual Studio 2010\Projects\TohoSTG\TohoSTG\image\Jiki.bmp";
        private const string BMPMokuzuFileName = @"C:\Users\s\Documents\Visual Studio 2010\Projects\TohoSTG\TohoSTG\image\EnemyMokuzu.bmp";
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

        public Enemy(double x, double y)
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
            // TODO: 敵機の当たり判定のバランスは調整が必要
            if (x < this.x) return false;
            if (x >= this.x + width) return false;
            if (y < this.y) return false;
            if (y >= this.y + height) return false;
                
            return true;
            //throw new NotImplementedException();
        }

        //internal void difference(int ddx, int ddy)
        //{
        //    dx += ddx;
        //    dy += ddy;
        //    //throw new NotImplementedException();
        //}

        internal void move()
        {
            int dx = 1; // x方向の速度
            int dy = 0; // y方向の速度
            int d = 2;  // 速度係数

            x += dx;
            y += dy;
        }
    
        internal void die()
        {
            // TODO: 敵機を撃墜したのでBMPを差し替えるなど
            bmp = new Bitmap(BMPMokuzuFileName);
            bmp.MakeTransparent();
        }
    }
}
