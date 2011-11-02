using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
namespace chessclient
{
    public class chesspiece
    {


        public chesspiece(string type)
        {

        }
        public Image pic;
        public player.colour color;
        public Point position;
        public game.type type { get; set; }
        public bool selected;
        public bool generallegaljudge(Point target)
        {

            if (target.X > 8 || target.Y > 9)
            {
                return false;
            }

            return true;
        }
        public void move(Point target)
        {

            this.position = target;

            return;
        }
        public chesspiece()
        {
            // TODO: Complete member initialization
        }

    }
    class che : chesspiece
    {
        public che(player.colour a)
        {
            this.type = game.type.che;
            this.color = a;
            switch (color)
            {
                case player.colour.black:
                    this.pic = Image.FromFile("./pic/1.png");
                    return;
                case player.colour.red:
                    this.pic = Image.FromFile("./pic/11.png");
                    return;
            }
        }


    }
    class ma : chesspiece
    {
        public ma(player.colour a)
        {
            this.type = game.type.ma;
            this.color = a;
            switch (color)
            {
                case player.colour.black:
                    this.pic = Image.FromFile("./pic/2.png");
                    return;
                case player.colour.red:
                    this.pic = Image.FromFile("./pic/21.png");
                    return;
            }

        }
    }
    class xiang : chesspiece
    {
        public xiang(player.colour a)
        {
            this.type = game.type.xiang;
            this.color = a;
            switch (color)
            {
                case player.colour.black:
                    this.pic = Image.FromFile("./pic/5.png");
                    return;
                case player.colour.red:
                    this.pic = Image.FromFile("./pic/51.png");
                    return;
            }

        }
    }
    class shi : chesspiece
    {
        public shi(player.colour a)
        {
            this.type = game.type.shi;
            this.color = a;
            switch (color)
            {
                case player.colour.black:
                    this.pic = Image.FromFile("./pic/4.png");
                    return;
                case player.colour.red:
                    this.pic = Image.FromFile("./pic/41.png");
                    return;
            }

        }
    }
    class jiang : chesspiece
    {
        public jiang(player.colour a)
        {
            this.type = game.type.jiang;
            this.color = a;
            switch (color)
            {
                case player.colour.black:
                    this.pic = Image.FromFile("./pic/0.png");
                    return;
                case player.colour.red:
                    this.pic = Image.FromFile("./pic/01.png");
                    return;
            }

        }
    }
    class pao : chesspiece
    {
        public pao(player.colour a)
        {
            this.type = game.type.pao;
            this.color = a;
            switch (color)
            {
                case player.colour.black:
                    this.pic = Image.FromFile("./pic/3.png");
                    return;
                case player.colour.red:
                    this.pic = Image.FromFile("./pic/31.png");
                    return;
            }

        }
    }
    class bing : chesspiece
    {
        public bing(player.colour a)
        {
            this.type = game.type.bing;
            this.color = a;
            switch (color)
            {
                case player.colour.black:
                    this.pic = Image.FromFile("./pic/6.png");
                    return;
                case player.colour.red:
                    this.pic = Image.FromFile("./pic/61.png");
                    return;
            }

        }
    }
}
