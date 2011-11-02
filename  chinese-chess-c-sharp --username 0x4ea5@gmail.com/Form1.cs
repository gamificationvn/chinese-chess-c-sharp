using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace chessclient
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        game game;
        Graphics g;
        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton4.Select();

            pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);


            g = pictureBox1.CreateGraphics();
            game = new game(g);

        }

        void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = game.turn.ToString() + this.PointToClient(Form1.MousePosition).ToString() + game.playerB.color.ToString();

            //throw new NotImplementedException();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            //click_event +=new click_handle(Form1_click_event);
            game.clicked(game.qipan, this.PointToClient(Form1.MousePosition));
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                game.drawing.draw(g);
                textBox1.Text = game.msgtext;
                toolStripStatusLabel1.Text = game.turn.ToString() + this.PointToClient(Form1.MousePosition).ToString() + game.playerB.color.ToString();
            }
            catch { }
        }

        //public delegate void click_handle(object sender, EventArgs e);
        //public event click_handle click_event;




        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton4.Checked) 
            {
                game.gamemode = chessclient.game.mode.free_local;
                game.init(g);
            }
            else if (radioButton1.Checked) //local
            {

                game.gamemode = chessclient.game.mode.turn_local;
                // button2.Enabled = true;
                game.init(g);
               // game.gamemode = chessclient.game.mode.turn_local;
                //  game.playerA.ini(game.playerA.side, "top");
                //  game.playerB.ini(game.playerB.side, "bottom");

            }
            else if (radioButton2.Checked) //AI
            {

                game.gamemode = chessclient.game.mode.AI;
                //button2.Enabled = false;
                game.qipan.clearboard();
            }
            else if (radioButton3.Checked) //remote
            {

                game.gamemode = chessclient.game.mode.networking;
                //button2.Enabled = false;
                game.qipan.clearboard();
                game.init(g);

            }

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox1.Checked)
            //    game.turn_mode = chessclient.game.turngo.turngo;
            //else
            //    game.turn_mode = chessclient.game.turngo.free;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }













    }
}
