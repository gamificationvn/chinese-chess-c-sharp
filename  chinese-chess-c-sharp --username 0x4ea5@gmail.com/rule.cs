using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace chessclient
{
    public static class rule
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="game">game</param>
        /// <param name="from">point of piece from</param>
        /// <param name="to">point of piece to</param>
        /// <returns>true = legal move</returns>
        static public bool test(game game, Point from, Point to)
        {
            if (from == to || to.X > 8 || to.X < 0 || to.Y > 9 || to.Y < 0)
            {
                return false;
            }
            foreach (var p in game.qipan.qz)
                if (p.position == from)
                {
                    foreach (var p2 in game.qipan.qz)
                        if (p2.position == to)//target position has a piece
                        {
                            switch (p.type)
                            {
                                case chessclient.game.type.bing:
                                    if (
                                        (p.color == game.playerA.color && game.playerA.seat == player.set.bottom && (p.position.Y == to.Y + 1 && from.X == to.X || (p.position.X == to.X + 1 || p.position.X == to.X - 1) && p.position.Y <= 4 && from.Y == to.Y)) ||
                                        (p.color == game.playerB.color && game.playerB.seat == player.set.bottom && (p.position.Y == to.Y + 1 && from.X == to.X || (p.position.X == to.X + 1 || p.position.X == to.X - 1) && p.position.Y <= 4 && from.Y == to.Y)) ||
                                        (p.color == game.playerA.color && game.playerA.seat == player.set.top && (p.position.Y == to.Y - 1 && from.X == to.X || (p.position.X == to.X + 1 || p.position.X == to.X - 1) && p.position.Y > 4 && from.Y == to.Y)) ||
                                        (p.color == game.playerB.color && game.playerB.seat == player.set.top && (p.position.Y == to.Y - 1 && from.X == to.X || (p.position.X == to.X + 1 || p.position.X == to.X - 1) && p.position.Y > 4 && from.Y == to.Y))
                                        )
                                    {
                                        return true;
                                    }
                                    return false;
                                case chessclient.game.type.che:
                                    if (from.X == to.X)
                                    {
                                        foreach (var p3 in game.qipan.qz)
                                        {
                                            if (p3.position.X == p.position.X && inbetween(p3.position.Y, from.Y, to.Y))//make sure no piece is in between
                                                return false;
                                        }
                                        return true;
                                    }
                                    else if (from.Y == to.Y)
                                    {
                                        foreach (var p3 in game.qipan.qz)
                                        {
                                            if (p3.position.Y == p.position.Y && inbetween(p3.position.X, from.X, to.X))//make sure no piece is in between
                                                return false;
                                        }
                                        return true;
                                    }
                                    return false;
                                case chessclient.game.type.jiang:

                                    break;
                                case chessclient.game.type.ma:
                                    break;
                                case chessclient.game.type.pao:
                                    break;
                                case chessclient.game.type.shi:
                                    break;
                                case chessclient.game.type.xiang:
                                    break;
                            }
                            return true;
                        }
                    switch (p.type)
                    {
                        case chessclient.game.type.bing:
                            if (
                                (p.color == game.playerA.color && game.playerA.seat == player.set.bottom && (p.position.Y == to.Y + 1 && from.X == to.X || (p.position.X == to.X + 1 || p.position.X == to.X - 1) && p.position.Y <= 4 && from.Y == to.Y)) ||
                                (p.color == game.playerB.color && game.playerB.seat == player.set.bottom && (p.position.Y == to.Y + 1 && from.X == to.X || (p.position.X == to.X + 1 || p.position.X == to.X - 1) && p.position.Y <= 4 && from.Y == to.Y)) ||
                                (p.color == game.playerA.color && game.playerA.seat == player.set.top && (p.position.Y == to.Y - 1 && from.X == to.X || (p.position.X == to.X + 1 || p.position.X == to.X - 1) && p.position.Y > 4 && from.Y == to.Y)) ||
                                (p.color == game.playerB.color && game.playerB.seat == player.set.top && (p.position.Y == to.Y - 1 && from.X == to.X || (p.position.X == to.X + 1 || p.position.X == to.X - 1) && p.position.Y > 4 && from.Y == to.Y))
                                )
                            {
                                return true;
                            }
                            return false;
                        case chessclient.game.type.che:
                            if (from.X == to.X)
                            {
                                foreach (var p2 in game.qipan.qz)
                                {
                                    if (p2.position.X == p.position.X && inbetween(p2.position.Y, from.Y, to.Y))//make sure no piece is in between
                                        return false;
                                }
                                return true;
                            }
                            else if (from.Y == to.Y)
                            {
                                foreach (var p2 in game.qipan.qz)
                                {
                                    if (p2.position.Y == p.position.Y && inbetween(p2.position.X, from.X, to.X))//make sure no piece is in between
                                        return false;
                                }
                                return true;
                            }
                            return false;
                        case chessclient.game.type.jiang:
                            if (p.color == game.playerA.color && game.playerA.seat == player.set.bottom || p.color == game.playerB.color && game.playerB.seat == player.set.bottom)
                            {
                                if (to.X >= 3 && to.X <= 5 && to.Y >= 7)
                                    if (from.X == to.X && (to.Y + 1 == from.Y || to.Y - 1 == from.Y) || from.Y == to.Y && (to.X + 1 == from.X || to.X - 1 == from.X))
                                        return true;
                                return false;
                            }
                            else if (p.color == game.playerA.color && game.playerA.seat == player.set.top || p.color == game.playerB.color && game.playerB.seat == player.set.top)
                            {
                                if (to.X >= 3 && to.X <= 5 && to.Y <= 2)
                                    if (from.X == to.X && (to.Y + 1 == from.Y || to.Y - 1 == from.Y) || from.Y == to.Y && (to.X + 1 == from.X || to.X - 1 == from.X))
                                    return true;
                                return false;
                            }
                            return false;
                        case chessclient.game.type.ma:
                            if (to.X == from.X + 1 && to.Y == from.Y + 2|| to.X==from.X-1&&to.Y==from.Y+2)
                            {
                                foreach (var p3 in game.qipan.qz)
                                {
                                    if (p3.position == new Point(from.X, from.Y + 1))
                                        return false;
                                }
                                return true;
                            }
                            //else if()
                            break;
                        case chessclient.game.type.pao:
                            break;
                        case chessclient.game.type.shi:
                            break;
                        case chessclient.game.type.xiang:
                            break;
                    }
                    //target position has no piece
                    return true;
                }
            return true;
        }
        /// <summary>
        /// check if x is in bewteen of y and z
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        private static bool inbetween(int x, int y, int z)
        {
            if (x <= y && x <= z)
                return false;
            if (x >= y && x >= z)
                return false;

            return true;
        }
    }
}
