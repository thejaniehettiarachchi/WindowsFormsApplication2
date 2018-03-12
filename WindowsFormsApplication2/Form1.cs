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

            foreach (Control ctrl in this.tableLayoutPanel1.Controls)
            {
                ctrl.Text = null;
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Validating(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int?[] stNums = new int?[16];

            foreach (Control ctrl in this.tableLayoutPanel1.Controls)
            {
                if (ctrl.Text != "")
                {
                    string name = ctrl.Name.Substring(13, ctrl.Name.Length-13);
                    int x = Int32.Parse(name);
                    stNums[x - 1] = Int32.Parse( ctrl.Text);
                }
            }

            //numericUpDown1.Text = null;

            // int?[] stNums = { numericUpDown1.Value, 2, 3, 4, 5, 6, 7, 8, 9, null, null, null, null, 14, null, 15 };

            //int?[] stNum = { 1, 2, 3, 4, 5, 6, 7, 8, 9, null, null, null, null, 14, null, 15 };
            State state1 = new State(stNums);
            Minimax mm = new Minimax();

            State state2 = mm.minimaxDec(state1, Player.Even);
            displayState(state2);
            editLabels(state2);
            //int[] dec = mm.minmaxDec(state1, Player.Even);

            //String nm = "numericUpDown" + (dec[0] + 1).ToString();
            ////MessageBox.Show(nm);
            //string numb = dec[1].ToString();
            //var numud = this.Controls.Find(nm, true).FirstOrDefault() as NumericUpDown;
            //numud.Value = (decimal)dec[1];



            //List<State> stateList = state1.getNewStates(Player.Odd);
            //Console.WriteLine("***************");
            //List<State> stateList2 = stateList[0].getNewStates(Player.Even);
            //Console.WriteLine("***************");
            //List<State> stateList3 = stateList2[0].getNewStates(Player.Odd);
            //foreach (State st in stateList)
            //{
            //    MessageBox.Show(st.displayState1());
            //}
        }
        private void editLabels(State state)
        {

            for (int i=0; i<10; i++)
            {
                string name = "label"+ (i+1).ToString();
                var label = this.Controls.Find(name, true).FirstOrDefault() as Label;
                label.Text = (state.array[state.lines[i][0]] + state.array[state.lines[i][1]] + state.array[state.lines[i][2]] + state.array[state.lines[i][3]]).ToString();
            }
        }
        private void displayState (State st)
        {
            for (int i=0; i<16; i++)
            {
                if (st.array[i] != null)
                {
                    string name = "numericUpDown" + (i + 1).ToString();
                    var numUD = this.Controls.Find(name, true).FirstOrDefault() as NumericUpDown;
                    numUD.Value = (decimal)st.array[i]; 
                }
            }
        }
    }
}
