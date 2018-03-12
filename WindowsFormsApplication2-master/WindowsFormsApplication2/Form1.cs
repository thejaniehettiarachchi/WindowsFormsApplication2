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

        State currentState = new State();
        Player currentPlayer = Player.Odd;

        public Form1()
        {
            List<int> cbList = new List<int>();

            InitializeComponent();
            
            int div = (currentPlayer == Player.Even) ? 0 : 1;
            for (int n = 0; n < currentState.numberList.Count; n++)
            {
                if (currentState.numberList[n] % 2 == div)
                {
                    cbList.Add(currentState.numberList[n]);
                }
            }
            
            foreach (ComboBox cb in this.tableLayoutPanel1.Controls)
            {
                cb.DataSource = new List<int>(cbList);
                //cb.SelectedIndexChanged -= comboBox_SelectedIndexChanged;
                cb.Text = null;
            }
            enableCB();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int?[] stNums = new int?[16];

            foreach (Control ctrl in this.tableLayoutPanel1.Controls)
            {
                if (ctrl.Text != "")
                {
                    string name = ctrl.Name.Substring(8, ctrl.Name.Length-8);
                    int x = Int32.Parse(name);
                    stNums[x - 1] = Int32.Parse( ctrl.Text);
                }
            }

            //numericUpDown1.Text = null;
            // int?[] stNums = { numericUpDown1.Value, 2, 3, 4, 5, 6, 7, 8, 9, null, null, null, null, 14, null, 15 };
            //int?[] stNum = { 1, 2, 3, 4, 5, 6, 7, 8, 9, null, null, null, null, 14, null, 15 };
            State state1 = new State(stNums);
            if (state1.checkWin())
            {
                MessageBox.Show("You won!!!");
            }
            Minimax mm = new Minimax();

            State state2 = mm.minimaxDec(state1, Player.Even);
            displayState(state2);
            editLabels(state2);
            dsCombobox(state2);
            enableCB();
            if (state2.checkWin())
            {
                MessageBox.Show("You lost...");
            }
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
                var nums = new int?[] { state.array[state.lines[i][0]], state.array[state.lines[i][1]], state.array[state.lines[i][2]], state.array[state.lines[i][3]] };
                //var sum = nums.Sum();

                string name = "label"+ (i+1).ToString();
                var label = this.Controls.Find(name, true).FirstOrDefault() as Label;
                label.Text = nums.Sum().ToString();
            }
        }

        private void dsCombobox(State st)
        {
            List<int> cbList = new List<int>();

            int div = (this.currentPlayer == Player.Even) ? 0 : 1;
            for (int n = 0; n < st.numberList.Count; n++)
            {

                if (st.numberList[n] % 2 == div)
                {
                    cbList.Add(st.numberList[n]);
                }
            }
            foreach (ComboBox cb in this.tableLayoutPanel1.Controls)
            {
                string tmp = cb.Text;
                cb.DataSource = new List<int>(cbList);
                //cb.SelectedIndexChanged -= comboBox_SelectedIndexChanged;
                cb.Text = tmp;
            }
            enableCB();
        }
        private void displayState (State st)
        {
            for (int i=0; i<16; i++)
            {
                if (st.array[i] != null)
                {
                    string name = "comboBox" + (i + 1).ToString();
                    var cb = this.Controls.Find(name, true).FirstOrDefault() as ComboBox;
                    cb.Text = st.array[i].ToString(); 
                }
            }
        }

        private void endGame()
        {
            //TODO
        }

        private void enableCB()
        {
            foreach (ComboBox cb in this.tableLayoutPanel1.Controls)
            {
                if (cb.Text == "" || cb.Text == null)
                {
                    cb.Enabled = true;
                }
            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ComboBox cb in this.tableLayoutPanel1.Controls)
            {
                cb.Enabled = false;
            }
        }
    }
}
