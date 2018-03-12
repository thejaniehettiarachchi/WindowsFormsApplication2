using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Minimax
    {
        int alpha;
        int beta;
        readonly int maxLimit = 2;

        public int start()
        {
            return 0;
        }
        
        public State minimaxDec (State state, Player player)
        {
            Random rnd = new Random();
            List<State> newStates = new List<State>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            newStates = state.getNewStates(player);
            int? bestVal = null;
            List<State> bestList =new List<State>();
            for (int i = 0; i < maxLimit; i++)
            {
                foreach (State st in newStates)
                {
                    //if (st.checkWin())
                    //{
                    //    return st;
                    //}
                    int? maxVal = maxDFS(st, 0, i, player);
                    if (maxVal == 1)
                    {
                        //stopwatch.Stop();
                        return st;
                    }
                    if (bestVal == -1 && (maxVal == 0 || maxVal == null))
                    {
                        bestVal = maxVal;
                        bestList.Clear();
                        //if (bestVal < maxVal)
                        //{
                        //    bestList.Clear();
                        //}
                       
                    }
                    if (maxVal != 1)
                    {
                        bestList.Add(st);
                    }
                    if (stopwatch.ElapsedMilliseconds > 2000)
                    {
                        return bestList[rnd.Next(bestList.Count)];
                    }
                } 
            }
            //return bestState;
            return bestList[rnd.Next(bestList.Count)];
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
                            int? maxRet = maxDFS(child, depth + 1, limit, newPl);
                            if (minVal == null || minVal > maxRet) {
                                minVal = maxRet;
                            }
                        }
                        depth++;
                        stateStack.Pop();
                    }
                }
                else
                {
                    return minVal;
                }

            }
            return minVal;
        }

        public int? maxDFS(State st, int depth, int limit, Player pl)
        {
            int? maxVal = null;
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
                            int? minRet = minDFS(child, depth + 1, limit, newPl);
                            if (maxVal == null || maxVal > minRet)
                            {
                                maxVal = minRet;
                            }
                            //return minDFS(child, depth + 1, limit, newPl);
                        }
                        depth++;
                        stateStack.Pop();
                    }
                }
                else
                {
                    return maxVal;
                }

            }
            return maxVal;
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
