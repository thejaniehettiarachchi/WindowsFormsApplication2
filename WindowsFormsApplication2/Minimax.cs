using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Minimax
    {
        int alpha;
        int beta;
        readonly int maxLimit = 20;

        public int start()
        {
            return 0;
        }
        
        public State minimaxDec (State state, Player player)
        {
            List<State> newStates = new List<State>();
            newStates = state.getNewStates(player);

            for (int i = 0; i < maxLimit; i++)
            {
                foreach (State st in newStates)
                {
                    if (st.checkWin())
                    {
                        return st;
                    }
                  // minDFS(state, 0, i, player);
               } 
            }
            Random rnd = new Random();
            return newStates[rnd.Next(0, newStates.Count)];
        }
        public int[] testminmaxDec (State st, Player pl)
        {
            int[] decision = new int[2];
            Random rnd = new Random();
            int pos;
            do
            {
                pos = rnd.Next(0, 16);
            } while (st.array[pos]!=null);
            int num = rnd.Next(0, st.numberList.Count());
            decision[0] = pos;
            decision[1] = st.numberList[num];
            return decision;
        }

        public int? minDFS(State st, int depth, int limit, Player pl)
        {
            int? minVal = null;
            Stack<State> stateStack = new Stack<State>();
            stateStack.Push(st);

            while (stateStack.Count != 0)
            {
                if (depth <= limit)
                {
                    State cur = stateStack.Peek();
                    if (cur.checkWin())
                    {
                        return -1;
                    }
                    if (depth == limit)
                    {
                        stateStack.Pop();
                        depth--;
                    }
                    else
                    {
                        foreach (State child in cur.getNewStates(pl))
                        {
                            Player newPl = (pl == Player.Odd) ? Player.Even : Player.Odd;
                            //TODO
                            //if (DFS(child, depth + 1, limit, newPl, !max) != null)
                            //{
                            //    return true;
                            //}
                            return maxDFS(child, depth + 1, limit, newPl);
                        }
                        depth++;
                        stateStack.Pop();
                    }
                }
                else
                {
                    return null;
                }

            }
            return null;
        }

        public int? maxDFS(State st, int depth, int limit, Player pl)
        {
            Stack<State> stateStack = new Stack<State>();
            stateStack.Push(st);

            while (stateStack.Count != 0)
            {
                if (depth <= limit)
                {
                    State cur = stateStack.Peek();
                    if (cur.checkWin())
                    {
                        return 1;
                    }
                    if (depth == limit)
                    {
                        stateStack.Pop();
                        depth--;
                    }
                    else
                    {
                        foreach (State child in cur.getNewStates(pl))
                        {
                            Player newPl = (pl == Player.Odd) ? Player.Even : Player.Odd;
                            //TODO
                            //if (DFS(child, depth + 1, limit, newPl, !max) != null)
                            //{
                            //    return true;
                            //}
                            return minDFS(child, depth + 1, limit, newPl);
                        }
                        depth++;
                        stateStack.Pop();
                    }
                }
                else
                {
                    return null;
                }

            }
            return null;
        }


        //public int? DFS (State st, int depth, int limit, Player pl, bool max)
        //{
        //    Stack<State> stateStack = new Stack<State>();
        //    stateStack.Push(st);

        //    while (stateStack.Count != 0)
        //    {
        //        if (depth<=limit)
        //        {
        //            State cur = stateStack.Peek();
        //            if (cur.checkWin())
        //            {
        //                return (max) ? 1: -1 ;
        //            }
        //            if (depth == limit)
        //            {
        //                stateStack.Pop();
        //                depth--;
        //            }
        //            else
        //            {
        //                foreach (State child in cur.getNewStates(pl) )
        //                {
        //                    Player newPl = (pl == Player.Odd) ? Player.Even : Player.Odd;
        //                    //TODO
        //                    //if (DFS(child, depth + 1, limit, newPl, !max) != null)
        //                    //{
        //                    //    return true;
        //                    //}
        //                    return DFS(child, depth + 1, limit, newPl, !max);
        //                }
        //                depth++;
        //                stateStack.Pop();
        //            }
        //        }
        //        else
        //        {
        //            return false;
        //        }

        //    }
        //    return false;
        //}
    }

}
