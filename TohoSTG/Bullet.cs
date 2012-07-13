using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TohoSTG
{
    class Bullet : Obj
    {
        // 弾幕用の弾丸1個
        
        // 弾丸の敵・味方の区別
        internal enum Sides
        {
            teki,
            mikata
        }

        // 弾丸の動き方の区別
        internal enum Ugokikata
        {
            Concentric,
            Sighting, 
            Drill,
        }

        private double vx;
        private double vy;
        private Sides side;
        private Ugokikata ugokikata;
        private double px;  // プレーヤー機のx座標
        private double py;
        private double gx;
        private double gy;
        private double vgx;
        private double vgy;
        public Sides Side
        {
            get
            {
                return side;
            }
        }

        private const int zanzoun = 10;
        int[] oldx = new int[zanzoun];
        int[] oldy = new int[zanzoun];

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

        public Bullet(Ugokikata ugokikata, Sides sides, int x_2, int y_2, double p, double p_2, double px, double py, double speed) : this(sides, x_2, y_2, p, p_2)
        {
            // TODO: Complete member initialization
            this.ugokikata = ugokikata;
            this.px = px;
            this.py = py;
            
            double hi = speed / Math.Sqrt((px - x) * (px - x) + (py - y) * (py - y));
            switch (ugokikata)
            {
                case Ugokikata.Concentric:
                    break;
                case Ugokikata.Sighting:
                    vx = hi * (px - x);
                    vy = hi * (py - y);
                    break;
                case Ugokikata.Drill:
                    vx = hi * (px - x); // 弾丸の初速
                    vy = hi * (py - y);
                    gx = x;             // 独自の重力源の座標
                    gy = y;
                    vgx = vx;           // 独自の重力源の不変速度
                    vgy = vy;
                    x = x + 10 * vy; // 進行方向とは垂直にずらした座標
                    y = y - 10 * vx;
                    break;
                default:
                    break;
            }
            
            //this.sides = sides;
            //this.x = x_2;
            //this.y = y_2;
            //this.vx = p;
            //this.vy = p_2;
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
            
            int tx;
            int ty;
            if (ugokikata == Bullet.Ugokikata.Drill)
            {
                Pen p0 = p;
                Color c0 = p0.Color;
                Color c1 = Color.White;
                for (int i = zanzoun - 1; i >= 0; i--)
                {
                    c0 = Color.FromArgb(c0.R * i / (i + 1), c0.G * i / (i + 1), c0.B * i / (i + 1));
                    c1 = Color.FromArgb(c1.R * i / (i + 1), c1.G * i / (i + 1), c1.B * i / (i + 1));
                    p = new Pen(c0);
                    tx = oldx[zanzoun - 1 - i];
                    ty = oldy[zanzoun - 1 - i];
                    g.DrawLine(p, (float)(tx + 1), (float)(ty), (float)(tx + 1), (float)(ty + 2));
                    g.DrawLine(p, (float)(tx), (float)(ty + 1), (float)(tx + 2), (float)(ty + 1));

                    g.DrawLine(p, (float)(tx + 0), (float)(ty), (float)(tx + 0), (float)(ty + 2));
                    g.DrawLine(p, (float)(tx + 2), (float)(ty), (float)(tx + 2), (float)(ty + 2));
                    g.DrawLine(p, (float)(tx + 1), (float)(ty - 1), (float)(tx + 1), (float)(ty + 3));
                    g.DrawLine(p, (float)(tx), (float)(ty + 0), (float)(tx + 2), (float)(ty + 0));
                    g.DrawLine(p, (float)(tx), (float)(ty + 2), (float)(tx + 2), (float)(ty + 2));
                    g.DrawLine(p, (float)(tx - 1), (float)(ty + 1), (float)(tx + 3), (float)(ty + 1));
                    Pen p2 = new Pen(c1);
                    g.DrawLine(p2, (float)(tx + 1), (float)(ty), (float)(tx + 1), (float)(ty + 2));
                    g.DrawLine(p2, (float)(tx), (float)(ty + 1), (float)(tx + 2), (float)(ty + 1));
                }
                p = p0; // 退避したものを戻す
            }

            /* int */tx = (int)x;
            /* int */ty = (int)y;
                    
            //g.DrawLine(p, (float)(x + 1), (float)(y), (float)(x + 1), (float)(y + 2));
            //g.DrawLine(p, (float)(x), (float)(y + 1), (float)(x + 2), (float)(y + 1));

            g.DrawLine(p, (float)(tx + 1), (float)(ty), (float)(tx + 1), (float)(ty + 2));
            g.DrawLine(p, (float)(tx), (float)(ty + 1), (float)(tx + 2), (float)(ty + 1));


            g.DrawLine(p, (float)(tx + 0), (float)(ty), (float)(tx + 0), (float)(ty + 2));
            g.DrawLine(p, (float)(tx + 2), (float)(ty), (float)(tx + 2), (float)(ty + 2));
            g.DrawLine(p, (float)(tx + 1), (float)(ty - 1), (float)(tx + 1), (float)(ty + 3));
            g.DrawLine(p, (float)(tx), (float)(ty + 0), (float)(tx + 2), (float)(ty + 0));
            g.DrawLine(p, (float)(tx), (float)(ty + 2), (float)(tx + 2), (float)(ty + 2));
            g.DrawLine(p, (float)(tx - 1), (float)(ty + 1), (float)(tx + 3), (float)(ty + 1));
            p = Pens.White;
            g.DrawLine(p, (float)(tx + 1), (float)(ty), (float)(tx + 1), (float)(ty + 2));
            g.DrawLine(p, (float)(tx), (float)(ty + 1), (float)(tx + 2), (float)(ty + 1));
            //g.DrawLine(Pens.White, (float)(x + 1), (float)(y - 1), (float)(x + 1), (float)(y + 3));
            //Graphicsはおそらくベクターグラフィックスとして使うべきであって、点は結果としては打たれない

            //g.DrawLine(Pens.White, (float)(tx + 1), (float)(ty + 1), (float)(tx + 1), (float)(ty + 1));
            
            
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
            switch (ugokikata)
            {
                case Ugokikata.Concentric:
                    x += vx;
                    y += vy;
                    break;
                case Ugokikata.Sighting:
                    x += vx;
                    y += vy;
                    break;
                case Ugokikata.Drill:

                    // 弾の速度を変える処理
                    double gravity = 48.8;  // かなりてきとーな重力定数
                    // 重力源までの距離を求める
                    int distancex = (int)(x - gx);
                    int distancey = (int)(y - gy);
                    // ピタゴラスの定理
                    int distanceSquare = distancex * distancex + distancey * distancey;
                    //double d = Math.Sqrt(dx * dx + dy * dy);

                    if (distanceSquare == 0) distanceSquare = 1;    // ゼロ除算を防ぐため
                    double ivx;
                    ivx = -distancex * gravity / distanceSquare;
                    vx += ivx;
                    double ivy;
                    ivy = -distancey * gravity / distanceSquare;
                    vy += ivy;
                    //int dx = 1; // x方向の速度
                    //int dy = 0; // y方向の速度
                    int d = 1;  // 速度係数

                    x += vx * d;
                    y += vy * d;

                    // 残像のための座標の記録
                    for (int i = zanzoun - 1; i > 0; i--)
                    {
                        oldx[i] = oldx[i - 1];
                        oldy[i] = oldy[i - 1];
                    }
                    oldx[0] = (int)x;
                    oldy[0] = (int)y;

                    // 重力源の移動
                    gx += vgx;
                    gy += vgy;

                    break;
                default:
                    break;
            }
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
