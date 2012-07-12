using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TohoSTG
{
    class Obj
    {
        protected double x;
        protected double y;
        protected int width;
        protected int height;

        public double X
        {
            get
            {
                return x;
            }
        }
        public double Y
        {
            get
            {
                return y;
            }
        }

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

        //public double getX()
        //{
        //    return x;
        //}

        //public double getY()
        //{
        //    return y;
        //}

        internal int renderingX()
        {
            // this.xを中心とするように描画したいときの左上x座標の例
            return (int)(x - width / 2);
        }
    }
}
