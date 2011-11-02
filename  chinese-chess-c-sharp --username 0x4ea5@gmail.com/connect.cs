using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Org.Nc.NNP3;
using Org.Nc.NNP3.Client;
using Org.Nc.NNP3.Base;
using Org.Nc.Chess;


namespace chessclient
{
    public class connect
    {
        public SerialUser<ChessCommand> command;
        public Connector connector;
        public string message;
        game gamee;
        public connect(game game) 
        {
            connector = new Connector();
            connector.ConnectedEvent += new ConnectedHandler(connector_ConnectedEvent);
            connector.Connect("127.0.0.1",59398);
            gamee = game;
            return;
        }

        void connector_ConnectedEvent(System.Net.Sockets.TcpClient client)
        {
            command = new SerialUser<ChessCommand>(client);
            command.SerialPackageRecivedEvent += new SerialPackageRecivedHandler<ChessCommand>(command_SerialPackageRecivedEvent);
            command.DisconnectEvent += new TcpDisconnectHander(command_DisconnectEvent);
            command.Start();    
            //command.Send(,)
            //throw new NotImplementedException();
        }

        public void move(Point position,Point target)
        {
            command.Send(ChessCommand.CreateChessmanMoveCommand(position, target));
            //ChessCommand.CreateChessmanMoveCommand(new Point(7, 2), new Point(7, 3));

        }

        void command_SerialPackageRecivedEvent(ChessCommand obj)
        {
            switch (obj.Command)
            {
                case ChessCommand.CommandType.Active:
                    break;

                case ChessCommand.CommandType.Chat:
                    try
                    {
                        gamee.msgtext = gamee.msgtext + "\r\n" + obj.Message;
                    }
                    catch { }
                    break;
                case ChessCommand.CommandType.ChessmanMove:
                    //gamee.control.point_move(obj.ChessPosition, obj.PurposePosition);
                    break;

                case ChessCommand.CommandType.ClientInit:
                    command.Send(ChessCommand.CreateLoginCommand("4e"));
                    if (obj.PlayerType.ToString() == "黑方")
                    {
                        //gamee.playerA = new player(gamee.qipan, "black", "bottom");
                        //gamee.playerA.color = player.colour.black;
                        //gamee.playerA.color= player.set
                        //gamee.playerA.ini();
                        //gamee.playerB = new player(gamee.qipan, "red", "top");
                        //gamee.playerB.ini();
                    }
                    else if (obj.PlayerType.ToString() == "红方")
                    {
                        //gamee.playerA = new player(gamee.qipan, "red", "bottom");
                        //gamee.playerA.ini("red", "bottom");
                        //gamee.playerB = new player(gamee.qipan, "black", "top");
                        //gamee.playerB.ini("black", "top");
                    }
                    //gamee.playerA = new player(gamee.qipan, obj.PlayerType.ToString(), obj.FirstPlayer.ToString());
                    break;

                case ChessCommand.CommandType.Login:


                    break;

                case ChessCommand.CommandType.PlayerExit:
                    break;

                case ChessCommand.CommandType.Victory:
                    break;

                case ChessCommand.CommandType.ServerInfo:
                    try
                    {
                        gamee.msgtext = gamee.msgtext + "\r\n" + obj.Message;
                    }
                    catch { }
                    break;
            }

            //throw new NotImplementedException();
        }

        void command_DisconnectEvent(string reason)
        {
            throw new NotImplementedException();
        }


    }
}
