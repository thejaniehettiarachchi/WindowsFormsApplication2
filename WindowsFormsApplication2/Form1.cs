using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Validating(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            State state1 = new State();
            List<State> stateList = state1.getNewStates(Player.Odd);
            Console.WriteLine("***************");
            List<State> stateList2 = stateList[0].getNewStates(Player.Even);
            Console.WriteLine("***************");
            List<State> stateList3 = stateList2[0].getNewStates(Player.Odd);
            //foreach (State st in stateList)
            //{
            //    MessageBox.Show(st.displayState1());
            //}
        }
    }
}
