using System.Drawing;
namespace chessclient
{

    /// <summary>
    /// player
    /// set color and and seat before ini()
    /// </summary>
    public class player
    {
        public bool turn{set; get;}
        chessboard qipan;

        public enum source { local, remote, AI };
        public enum colour { black, red }
        public enum set { top, bottom };

        public source playersource { set; get; }
        public colour color { set; get; }
        public set seat { set; get; }

        public control control;
        game game;
        public player(game g)
        {
            //control control = new chessclient.control();
            qipan = g.qipan;
            game = g;
        }
        public void ini()
        {
            switch (playersource) 
            {
                case source.local:
                    control = new local_control(game);
                    break;

                case source.remote:
                    control = new AI_control(game);
                    break;

                case source.AI:
                    control = new Net_control(game);
                    break;
            }

            switch (seat)
            {
                case set.top:
                    {
                        qipan.qz.Add(new che(color) { position = new Point(0, 0) });
                        qipan.qz.Add(new ma(color) { position = new Point(1, 0) });
                        qipan.qz.Add(new xiang(color) { position = new Point(2, 0) });
                        qipan.qz.Add(new shi(color) { position = new Point(3, 0) });
                        qipan.qz.Add(new jiang(color) { position = new Point(4, 0) });
                        qipan.qz.Add(new shi(color) { position = new Point(5, 0) });
                        qipan.qz.Add(new xiang(color) { position = new Point(6, 0) });
                        qipan.qz.Add(new ma(color) { position = new Point(7, 0) });
                        qipan.qz.Add(new che(color) { position = new Point(8, 0) });
                        qipan.qz.Add(new pao(color) { position = new Point(1, 2) });
                        qipan.qz.Add(new pao(color) { position = new Point(7, 2) });
                        qipan.qz.Add(new bing(color) { position = new Point(0, 3) });
                        qipan.qz.Add(new bing(color) { position = new Point(2, 3) });
                        qipan.qz.Add(new bing(color) { position = new Point(4, 3) });
                        qipan.qz.Add(new bing(color) { position = new Point(6, 3) });
                        qipan.qz.Add(new bing(color) { position = new Point(8, 3) });
                        break;
                    }
                case set.bottom:
                    {
                        qipan.qz.Add(new che(color) { position = new Point(0, 9) });
                        qipan.qz.Add(new ma(color) { position = new Point(1, 9) });
                        qipan.qz.Add(new xiang(color) { position = new Point(2, 9) });
                        qipan.qz.Add(new shi(color) { position = new Point(3, 9) });
                        qipan.qz.Add(new jiang(color) { position = new Point(4, 9) });
                        qipan.qz.Add(new shi(color) { position = new Point(5, 9) });
                        qipan.qz.Add(new xiang(color) { position = new Point(6, 9) });
                        qipan.qz.Add(new ma(color) { position = new Point(7, 9) });
                        qipan.qz.Add(new che(color) { position = new Point(8, 9) });
                        qipan.qz.Add(new pao(color) { position = new Point(1, 7) });
                        qipan.qz.Add(new pao(color) { position = new Point(7, 7) });
                        qipan.qz.Add(new bing(color) { position = new Point(0, 6) });
                        qipan.qz.Add(new bing(color) { position = new Point(2, 6) });
                        qipan.qz.Add(new bing(color) { position = new Point(4, 6) });
                        qipan.qz.Add(new bing(color) { position = new Point(6, 6) });
                        qipan.qz.Add(new bing(color) { position = new Point(8, 6) });
                        break;
                    }
            }



            return;




        }
        public void clicked(Point p) 
        {
            control.clicked(p, this.color);
        }

    }
}
