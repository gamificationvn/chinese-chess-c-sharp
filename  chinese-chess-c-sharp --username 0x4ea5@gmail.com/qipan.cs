using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace chessclient
{
    public class chessboard
    {
        public List<chesspiece> qz;
        public List<chesspiece> qzside;
        string m;

        public chessboard()
        {
            qzside = new List<chesspiece>();
            getpostion();
        }
        public string mode
        {
            get
            {
                return m; //throw new System.NotImplementedException();
            }
            set
            {
                m = value;
            }
        }

        public IList<chesspiece> getpostion()
        {
            qz = new List<chesspiece>();
            return qz;
        }

        public void clearboard()
        {
            qz.RemoveAll(qizi => qizi!=null);
            qz.RemoveAll(qizi => qizi.selected == true);
        }



    }
}
