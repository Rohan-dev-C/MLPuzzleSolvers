using System;

namespace TicTacToeAI
{
    public partial class Form1 : Form
    {
        Button[,] buttons;

        public Form1()
        {

            InitializeComponent();
        }
        private void Button_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text[0] == 'X' || ((Button)sender).Text[0] == 'O')
            {
                MessageBox.Show("Choose a valid move");
                return;
            }
            else
            {
                int XCount = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (((Button)sender).Text[0] == 'X') { XCount++; }
                    }
                }
                if (XCount % 2 == 0)
                {
                    ((Button)sender).Text = "X";

                    var newGameState = new GameState(UpdateGameState(), false);

                    int childIndex = correctChildIndex(graph.currentGameState, newGameState);
                    graph.currentGameState = graph.currentGameState.children[childIndex];
                    UpdateScreen(graph.currentGameState);
                    graph.currentGameState = graph.FindBestMove(graph.currentGameState);
                    UpdateScreen(graph.currentGameState);
                    if (graph.currentGameState.children == null ||
                        graph.currentGameState.children.Count == 0 ||
                        graph.currentGameState.children[0].children.Count == 0)
                    {
                        var score = graph.currentGameState.score;
                        if (score == 1)  {  MessageBox.Show("You win");}
                        else if (score == -1) { MessageBox.Show("computer wins"); }
                        else { MessageBox.Show("draw"); }
                        foreach (var item in buttons)
                        {
                            item.Enabled = false; 
                        }
                        return;
                    }
                }
            }
        }

        private int correctChildIndex(GameState currState, GameState childIAmLookingFor)
        {
            for (int k = 0; k < currState.children.Count; k++)
            {
                bool isSame = true;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (childIAmLookingFor.currentState[i, j] != currState.children[k].currentState[i, j]) { isSame = false;}
                    }
                }
                if (isSame)  {  return k; }
            }
            return 0;
        }


        private char[,] UpdateBoardState(char[,] temp)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Text = temp[i, j].ToString();
                }
            }
            return temp;
        }

        private char[,] UpdateGameState()
        {
            char[,] temp = new char[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    temp[i, j] = buttons[i, j].Text[0];
                }
            }
            return temp;
        }

        private void UpdateScreen(GameState gameState)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Text = gameState.currentState[i, j].ToString();
                }
            }
        }

        MiniMaxGraph graph;
        private void Form1_Load(object sender, EventArgs e)
        {
            buttons = new Button[,]
            {
                { button1, button2, button3},
                { button4, button5, button6},
                { button7, button8, button9 }
            };
            graph = new MiniMaxGraph();

            graph.GenerateGraph();
            graph.root.CalcNextScore(true);
            UpdateScreen(graph.currentGameState);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (graph.currentGameState.children == null || graph.currentGameState.children.Count == 0)
            {
                var score = graph.currentGameState.score;
                if (score == 1)
                {
                    MessageBox.Show("You win");

                }
                else if (score == -1)
                {
                    MessageBox.Show("computer wins");
                }
                else
                {
                    MessageBox.Show("draw");
                }
                return;
            }
        }
    }
}
