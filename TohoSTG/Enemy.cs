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
        private double ivx;
        private double ivy;
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

        public Enemy(double x, double y, double ivx, double ivy)
        {
            this.x = x;
            this.y = y;
            this.ivx = ivx; // 初速x
            this.ivy = ivy; // 初速y
            isAlive = true;

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
            if (isAlive == false) return false;
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

        internal void move(Point gravitySource)
        {
            // 敵の速度を変える処理
            double gravity = 48.8;  // かなりてきとーな重力定数
            // 重力源までの距離を求める
            int dx = (int)x - gravitySource.X;
            int dy = (int)y - gravitySource.Y;
            // ピタゴラスの定理
            int distanceSquare = dx * dx + dy * dy;
            //double d = Math.Sqrt(dx * dx + dy * dy);

            // もくず(敵が撃墜された残骸)なら加速度処理は行わない
            if (isAlive)
            {
                if (distanceSquare == 0) distanceSquare = 1;    // ゼロ除算を防ぐため
                ivx += -dx * gravity / distanceSquare;
                ivy += -dy * gravity / distanceSquare;
            }

            //int dx = 1; // x方向の速度
            //int dy = 0; // y方向の速度
            int d = 1;  // 速度係数

            x += ivx * d;
            y += ivy * d;
            //x += dx * d;
            //y += dy * d;
        }
    
        internal void die()
        {
            isAlive = false;
            // TODO: 敵機を撃墜したのでBMPを差し替えるなど
            bmp = new Bitmap(BMPMokuzuFileName);
            bmp.MakeTransparent();
        }

        protected bool isAlive;
        public bool IsAlive { get { return isAlive; } }

        internal bool isFadeOut(int screenWidth, int screenHeight)
        {
            if (x >= screenWidth + 20) return true;
            if (x < -20) return true;
            if (y >= screenHeight + 20) return true;
            if (y < -20) return true;

            return false;
        }
    }
}
