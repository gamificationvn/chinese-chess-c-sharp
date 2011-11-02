using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;

namespace chessclient
{   
    public class drawing
    {

        chessboard qp;
        Bitmap bitmap;
        Image qppic;
        Graphics graphicbuff;
        /// <summary>
        /// Drawing
        /// </summary>
        /// <param name="g"></param>
        /// <param name="qipan"></param>
        public drawing(Graphics g,chessboard qipan) 
        {
            qp = qipan;
            qppic=Image.FromFile("./pic/qp.jpg");
            bitmap = new Bitmap(qppic.Width+110, qppic.Height+110);//Properties.Resources.qp.Width, Properties.Resources.qp.Height);
            graphicbuff = Graphics.FromImage(bitmap);
                 
        }
        public void draw(Graphics g) 
        {

            graphicbuff.DrawImage(qppic, 0, 0, qppic.Width, qppic.Height); //绘棋盘
            foreach (var q in qp.qz) //循环绘棋子
            {
                drawpic(q.pic, q.position);
                if (q.selected == true)
                {
                    drawpic(Image.FromFile("./pic/selected.png"), q.position);
                }
            }
            if (qp.mode == "human_vs_human") 
            {
                drawpic(Image.FromFile("./pic/removepiece.png"),new Point(9,0));
                foreach (var q in qp.qzside) 
                {
                    drawpic(q.pic, q.position);
                }
            }
            g.DrawImage(bitmap, new Point(0, 0)); //绘出bitmap

            
        }

        public void drawpic(Image image,Point point) 
        {
            graphicbuff.DrawImage(image, point_reverse(point.X,point.Y).X, point_reverse(point.X,point.Y).Y, image.Width, image.Height);
        }
        private Point point_reverse(int x, int y)
        {
            return new Point(x * 56 + 5, y * 56 + 5);
        }


    }
}
