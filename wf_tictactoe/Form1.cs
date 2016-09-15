using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf_tictactoe
{
    public partial class Form1 : Form
    {
        private bool turn = true;
        private int count_turn = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Стенчев Сергей", "Игра кретики нолики");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
            b.Enabled = false;
            turn = !turn;
            count_turn++;
            if (count_turn != 9) check_is_a_winner(sender);
            else
                MessageBox.Show("Ooops!!", "Draw!");
        }

        private bool check_is_a_winner(object sender)
        {
            bool winner = false;
            string s;
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled)) { winner = true; }
            else
            if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled)) { winner = true; }
            else
            if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled)) { winner = true; }
            else
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled)) { winner = true; }
            else
            if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled)) { winner = true; }
            else
            if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled)) { winner = true; }
            else
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A2.Enabled)) { winner = true; }
            else
            if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled)) { winner = true; }

            if (winner)
            {
                s = ((Button)sender).Text;
                disEnableButton();
                MessageBox.Show(s + " Wins!", "congratulations");
            }
            return winner;
        }

        private void disEnableButton()
        {
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    c.Enabled = false;
                }
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            count_turn = 0;
            turn = true;
            EmptyPool();
        }

        private void EmptyPool()
        {
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    c.Enabled = true;
                    c.Text = "";
                }
            }
        }
    }
}