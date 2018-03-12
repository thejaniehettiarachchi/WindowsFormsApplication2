using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum Player
{
    Odd,
    Even
}

namespace WindowsFormsApplication2
{
    class State
    {
        public int?[] array = new int?[16];
        public List<int> numberList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }; // Enumerable.Range(1, 16).ToList();
        public readonly  List<int[]> lines = new List<int[]> {
            new int[] { 0, 1, 2, 3 },
            new int[] { 4, 5, 6, 7 },
            new int[] { 8, 9, 10, 11 },
            new int[] { 12, 13, 14, 15 },
            new int[] { 0, 4, 8, 12 },
            new int[] { 1, 5, 9, 13 },
            new int[] { 2, 6, 10, 14 },
            new int[] { 3, 7, 11, 15 },
            new int[] { 0, 5, 10, 15 },
            new int[] { 3, 6, 9, 12 },
        };

        //List<int> oddList = new List<int>() { 1, 3, 5, 7, 9, 11, 13, 15 };
        //List<int> evenList = new List<int>() { 2, 4, 6, 8, 10, 12, 14, 16 };
        public State()
        {

        }

        public State (int?[] numArray)
        {
            this.array = numArray;
            for (int i=1; i<=16; i++)
            {
                if (array.Contains(i))
                {
                    numberList.Remove(i);
                }
            }

        }
        //public State(int n0, int n1, int n2, int n3, int n4, int n5, int n6, int n7, int n8, int n9, int n10, int n11, int n12, int n13, int n14, int n15 )
        //{
        //    this.array[0] = n0;
        //    this.array[1] = n1;
        //    this.array[2] = n2;
        //    this.array[3] = n3;
        //    this.array[4] = n4;
        //    this.array[5] = n5;
        //    this.array[6] = n6;
        //    this.array[7] = n7;
        //    this.array[8] = n8;
        //    this.array[9] = n9;
        //    this.array[10] = n10;
        //    this.array[11] = n11;
        //    this.array[12] = n12;
        //    this.array[13] = n13;
        //    this.array[14] = n14;
        //    this.array[15] = n15;
        //}

        public State createNewState (int position, int num )
        {
            State newState = new State();
            newState.array = (int?[])this.array.Clone();
            newState.array[position] = num;
            newState.numberList = new List<int>( numberList);
            //newState.oddList = this.oddList;
            //newState.evenList = this.evenList;
            //if (num%2 == 0)
            //{
            //    newState.evenList.Remove(num);
            //}
            //else
            //{
            //    newState.oddList.Remove(num);
            //}
            newState.numberList.Remove(num);
            return newState;
        }

        public List<State> getNewStates ( Player pl)
        {
            List<State> newStates = new List<State>();
            for (int i=0; i < 16; i++) //TODO
            {
                int div = (pl == Player.Even) ? 0 : 1;
                //List<int> availList = new List<int>();
                
                //List<int> availList2 = from num in numberList where num % 2 == div select num;
                //List<int> availList1 = (pl == Player.Odd) ? oddList : evenList;
                if (this.array[i] == null)
                {
                    for ( int n=0; n <numberList.Count; n++)
                    {
                        if (numberList[n] % 2 == div)
                        {
                            newStates.Add( this.createNewState(i, numberList[n]));
                            //Console.WriteLine("new :" + i + "  " + numberList[n]);
                        }
                        
                    }
                }
            }
            return newStates;
        }

        public string displayState1 ()
        {
            string disp = "";
            for (int i=0; i<16; i++)
            {

                disp = disp+i+":"+array[i].ToString() + " ";
            }
            return disp;
        }

        public bool checkWin ()
        {
            foreach (int[] arr in lines)
            {
                //if (array[arr[0]]+ array[arr[1]] + array[arr[2]] + array[arr[3]] >= 34)
                //{
                //    return true;
                //}
                var nums = new int?[] { array[arr[0]], array[arr[1]], array[arr[2]], array[arr[3]] };
                var sum = nums.Sum();
                if (sum >= 34)
                {
                    return true;
                }
            }
            return false;
        }
    }


} 
