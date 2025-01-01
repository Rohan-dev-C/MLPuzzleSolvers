using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpectimaxTicTacToe
{

    public class GameState
    {
        public char[,] currentState = new char[3, 3];
        public bool nextMoveX;
        public List<GameState> children;
        public int score;
        public double chance;
        NodeTypes nodeType;
        public List<List<GameState>> chanceGroups;


        public enum NodeTypes
        {
            Minimizer,
            Maximizer,
            Chance,
        }


        public List<(int, int)> GetPossibleMoves(char[,] current)
        {
            List<(int, int)> Listington = new List<(int, int)>();
            for (int i = 0; i < current.GetLength(0); i++)
            {
                for (int j = 0; j < current.GetLength(1); j++)
                {
                    if (current[i, j] == 'E')
                    {
                        Listington.Add((i, j));
                    }
                }
            }
            return Listington;
        }

        public List<(int, int)> CurrentPossibleMoves => GetPossibleMoves(currentState);

        public GameState(char[,] state, bool nextMoveX, NodeTypes type)
        {
            currentState = state;
            this.nextMoveX = nextMoveX;
            nodeType = type; 
        }

        public List<GameState> GenerateNextChildren()
        {
            List<GameState> children = new List<GameState>();

            if (isWin('X')
                || isWin('O'))
            {
                return children;
            }
            foreach (var index in CurrentPossibleMoves)
            {
                char[,] savedCurrentState = (char[,])currentState.Clone();
                if (nextMoveX) savedCurrentState[index.Item1, index.Item2] = 'X';
                else savedCurrentState[index.Item1, index.Item2] = 'O';
                children.Add(new GameState(savedCurrentState, !nextMoveX, nodeType+1));
            }
            return children;
        }
        public bool isWin(char currCheck)
        {
            if (currCheck == 'X')
            {
                return CalculateScore() == 1;
            }
            else
            {
                return CalculateScore() == -1;
            }
        }

        public int CalculateScore()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == 0)
                    {
                        if (currentState[i, j] == currentState[i, j + 1] &&
                            currentState[i, j] == currentState[i, j + 2])
                        {
                            if (currentState[i, j] == 'X')
                            {
                                return 1;
                            }
                            else if (currentState[i, j] == 'O')
                            {
                                return -1;
                            }
                        }
                    }
                    if (i == 0)
                    {
                        if (currentState[i, j] == currentState[i + 1, j] &&
                            currentState[i, j] == currentState[i + 2, j])
                        {
                            if (currentState[i, j] == 'X')
                            {
                                return 1;
                            }
                            else if (currentState[i, j] == 'O')
                            {
                                return -1;
                            }
                        }
                    }
                    if (currentState[0, 0] == currentState[1, 1] &&
                        currentState[2, 2] == currentState[0, 0])
                    {
                        if (currentState[0, 0] == 'X')
                        {
                            return 1;
                        }
                        else if (currentState[0, 0] == 'O')
                        {
                            return -1;
                        }
                    }
                    if (currentState[2, 0] == currentState[1, 1] &&
                        currentState[0, 2] == currentState[2, 0])
                    {
                        if (currentState[2, 0] == 'X')
                        {
                            return 1;
                        }
                        else if (currentState[2, 0] == 'O')
                        {
                            return -1;
                        }
                    }
                }
            }
            return 0;
        }

        public int CalcNextScore(bool nextMoveX)
        {
            if (children == null)
            {
                children = GenerateNextChildren();
            }
            if (children.Count == 0)
            {
                score = CalculateScore();

                return CalculateScore();
            }

            int currMaxOrMin = 0;
            if (nextMoveX) currMaxOrMin = -2;
            else currMaxOrMin = 2;
            for (int i = 0; i < children.Count; i++)
            {
                children[i].score = children[i].CalcNextScore(!nextMoveX);
                if (nextMoveX)
                {
                    if (children[i].score > currMaxOrMin)
                    {
                        currMaxOrMin = children[i].score;
                    }
                }
                else if (!nextMoveX)
                {
                    if (children[i].score < currMaxOrMin)
                    {
                        currMaxOrMin = children[i].score;
                    }
                }
            }
            return currMaxOrMin;
        }

        public void GroupChildren()
        {

            List<GameState> currGroup = new List<GameState>();
            for (int i = -1; i < 2; i++)
            {
                foreach (var item in children)
                {
                    if (item.score == i - 1)
                    {
                        currGroup.Add(item);
                    }
                }
                chanceGroups.Add(currGroup); 
            }

        }



    }
    internal class ExpectiMaxGraph
    {
        char[,] defaultGameState = new char[,] { { 'E', 'E', 'E' }, { 'E', 'E', 'E' }, { 'E', 'E', 'E' } };
        public GameState currentGameState;
        public GameState root;
        public ExpectiMaxGraph()
        {
            root = new GameState(defaultGameState, true);
        }

        public void GenerateGraph()
        {
            currentGameState = root;
            currentGameState.nextMoveX = true;
            root.CalcNextScore(currentGameState.nextMoveX);
        }

        public GameState GenerateGraph(GameState state, bool nextMoveX)
        {
            state.nextMoveX = nextMoveX;
            state.children = state.GenerateNextChildren();
            foreach (var item in state.children)
            {
                GenerateGraph(item, !state.nextMoveX);
            }
            return state;
        }

        public GameState FindBestMove(GameState current)
        {
            if (current.children.Count == 0)
            {
                return null;
            }
            var savedBiggestIndex = 0;
            var smallestVal = 2;
            for (int i = 0; i < current.children.Count; i++)
            {
                if (current.children[i].score < smallestVal)
                {
                    savedBiggestIndex = i;
                    smallestVal = current.children[i].score;
                }
            }
            return current.children[savedBiggestIndex];
        }
    }
}
