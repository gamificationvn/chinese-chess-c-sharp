using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace chessclient
{
    public class control
    {
        public control()
        {
        }
        game game;
        public control(game g)
        {
            game = g;
        }
        public virtual void clicked(Point p, player.colour color) { }
    }


    public class local_control : control
    {
        game game;
        public local_control(game g)
        {
            game = g;
        }
        public override void clicked(Point point, player.colour color)
        {
            foreach (var piece1 in game.qipan.qz)
            {
                if (piece1.position == point && piece1.color == color)
                {
                    foreach (var piece2 in game.qipan.qz)
                    {
                        if (piece2.selected && piece2.position == piece1.position)//if it's select, and clicked on it again, then dis-select it.
                        {
                            piece2.selected = false;
                            return;
                        }
                        else if (piece2.selected && piece2.color == piece1.color) //if the one clicked and the one selected are in the same color, then select the one clicked.
                        {
                            piece2.selected = false;
                            piece1.selected = true;
                            return;
                        }
                        else if (piece2.selected && piece2.color != piece1.color) //吃子
                        {
                            game.move(piece2.position, piece1.position);
                            //p.position = point;
                            //p.selected = false;
                            return;
                        }
                    }
                    piece1.selected = true;
                    return;
                }
            }
            foreach (var piece1 in game.qipan.qz) 
            {
                if (piece1.selected)
                {
                    game.move(piece1.position, point);
                    return;
                }
            }

        }

    }
    public class AI_control : control
    {
        public AI_control(game g)
        {
            
        }
    }
    public class Net_control : control
    {
        connect c;
        public Net_control(game g)
        {
            c = new connect(g);
            
        }

        public connect connection
        {
            get
            {
                return c;
               // throw new System.NotImplementedException();
            }
            set
            {

            }
        }

        public connect connect
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }

}
