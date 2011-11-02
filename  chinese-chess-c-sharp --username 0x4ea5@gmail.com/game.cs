using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace chessclient
{
    /// <summary>
    /// 
    /// </summary>
    public class game
    {

        //初始化
        //string m;
        public drawing drawing;
        public chessboard qipan;
        public player playerA;
        public player playerB;
        public control control;
        public connect connect;
        public string msgtext;

       // public enum turngo { turngo, free }
        public enum mode {free_local, turn_local, networking, AI }
        public enum turnm { playerA, playerB }
        public enum type { che, ma, xiang, shi, jiang, pao, bing }

    //    public turngo turn_mode { get; set; }
        public mode gamemode { get; set; }
        public turnm turn { get; set; }


        public game(Graphics g)
        {
            init(g);
        }


        /// <summary>
        /// initialize the the board
        /// put chess on board
        /// </summary>
        /// <param name="g"></param>
        public void init(Graphics g)
        {
            qipan = new chessboard();
            drawing = new drawing(g, qipan);

            switch (gamemode)
            {
                case mode.free_local:
                    playerA = new player(this);
                    playerA.seat = player.set.top;
                    playerA.playersource = player.source.local;
                    playerA.color = player.colour.black;
                    playerA.ini();

                    playerB = new player(this);
                    playerB.seat = player.set.bottom;
                    playerB.playersource = player.source.local;
                    playerB.color = player.colour.red;
                    playerB.ini();


                    break;
                case mode.turn_local:
                    playerA = new player(this);
                    playerA.seat = player.set.top;
                    playerA.playersource = player.source.local;
                    playerA.color = player.colour.black;
                    playerA.ini();

                    playerB = new player(this);
                    playerB.seat = player.set.bottom;
                    playerB.playersource = player.source.local;
                    playerB.color = player.colour.red;
                    playerB.ini();

                    playerB.turn = true;
                    this.turn = turnm.playerB;

                    break;
                case mode.networking:
                    break;

                case mode.AI:
                    break;
            }

        }




        public void clicked(chessclient.chessboard b, Point point)
        {
            Point p = new Point((point.X - 5) / 55, (point.Y - 5) / 55);
            Point selectedPiecePoint = new Point(0, 0);
            //foreach (var piecee in b.qz)
            //{
            //    if (piecee.selected == true)
            //    {
            //        selectedPiecePoint = piecee.position;
            //        break;
            //    }
            //}
            switch (this.gamemode)
            {
                case mode.turn_local:
                    switch (this.turn)
                    {
                        case turnm.playerA:
                            {
                                playerA.clicked(p);
                                return;
                            }
                        case turnm.playerB:
                            {
                                playerB.clicked(p);
                                return;
                            }
                    }
                    return;
                case mode.free_local:
                    freeGoMode(b, p);
                    return;
                case mode.AI:
                    break;
                case mode.networking:
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b">chessboard</param>
        /// <param name="point">point that clicked</param>
        private void freeGoMode(chessboard b, Point point)
        {
            foreach (var r in b.qz) //r is the piece that clicked on.
            {
                if (r.position == point) //按键处有子
                {
                    foreach (var p in this.qipan.qz) // p is selected
                    {
                        if (p.selected && p.position == r.position)//if it's select, and clicked on it again, then dis-select it.
                        {
                            p.selected = false;
                            return;
                        }
                        else if (p.selected && p.color == r.color) //if the one clicked and the one selected are in the same color, then select the one clicked.
                        {
                            p.selected = false;
                            r.selected = true;
                            return;
                        }
                        else if (p.selected && p.color != r.color) //吃子
                        {
                            move(p.position, r.position);
                            //p.position = point;
                            //p.selected = false;
                            return;
                        }
                    }
                    r.selected = true;  //no piece is selected, select the one that clicked on.
                    return;

                }
            }
            if (true) //no piece is on the point that clicked.
            {
                foreach (var p in b.qz)
                {
                    if (p.selected == true)
                    {
                        move(p.position,point);
                        return;
                    }
                }
            }


        }
        private void clearseleced()
        {
            foreach (var p in this.qipan.qz)
            {
                p.selected = false;
            }
        }
        public bool move(Point from, Point to)
        {
            if (rule.test(this, from, to))
            {
                foreach (var p in qipan.qz)
                {
                    if (p.position == to)
                    {
                        qipan.qz.Remove(p);
                        break;
                    }
                }
                foreach (var p in qipan.qz)
                {
                    if (p.position == from)
                    {
                        p.position = to;
                        break;
                    }   
                }
            }

                 // check legality 
                // move the chess(operate)
            return false;
        }




    }
}