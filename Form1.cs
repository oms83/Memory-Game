using Memory_Game.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GameResult.Move = 1;
            GameResult.Counter = 60;
            GameResult.Score = 1;
            PlayerInfo.Name = "";

            EnableAllChoicesButtons(false);
        }

        Random random = new Random();

        public stGameResult GameResult;

        public stPlayerInfo PlayerInfo;

        public struct stPlayerInfo
        {
            public string Name;
        }

        public struct stGameResult
        {
            public int Score;
            public int Move;
            public int Counter;
        }

        private int GetAPositiveNumber(int From, int To)
        {
            return random.Next(From, To + 1);
        }

        public List<Button> buttons = new List<Button>();
        
        public List<Button> buttons1 = new List<Button>();


        private void FillButton()
        {
            buttons.Add(btn1);
            buttons.Add(btn2);
            buttons.Add(btn3);
            buttons.Add(btn4);
            buttons.Add(btn5);
            buttons.Add(btn6);
            buttons.Add(btn7);
            buttons.Add(btn8);
            buttons.Add(btn9);
            buttons.Add(btn10);
            buttons.Add(btn11);
            buttons.Add(btn12);
            buttons.Add(btn13);
            buttons.Add(btn14);
            buttons.Add(btn15);
            buttons.Add(btn16);
        }

        private void SetlblTimeForeColor(Label lbl, int Counter)
        {
            if(Counter>=45)
                lbl.ForeColor = Color.GreenYellow;
            else if(Counter>=30)
                lbl.ForeColor = Color.Yellow;
            else if (Counter>=15)
                lbl.ForeColor = Color.Orange;
            else if (Counter>=0)
                lbl.ForeColor = Color.Red;
        }

        private void EnableAllChoicesButtons(bool EnabledStatus)
        {
            btn11.Enabled = EnabledStatus;
            btn12.Enabled = EnabledStatus;
            btn13.Enabled = EnabledStatus;
            btn14.Enabled = EnabledStatus;
            btn15.Enabled = EnabledStatus;
            btn16.Enabled = EnabledStatus;
            btn1.Enabled = EnabledStatus;
            btn2.Enabled = EnabledStatus;
            btn3.Enabled = EnabledStatus;
            btn4.Enabled = EnabledStatus;
            btn5.Enabled = EnabledStatus;
            btn6.Enabled = EnabledStatus;
            btn7.Enabled = EnabledStatus;
            btn8.Enabled = EnabledStatus;
            btn9.Enabled = EnabledStatus;
            btn10.Enabled = EnabledStatus;
        }
        
        private void SetTimeGame()
        {
            lblTime.Text = GameResult.Counter--.ToString();
            if(GameResult.Counter<0)
            {
                timer1.Enabled = false;
                MessageBox.Show("Game Over");
                EnableAllChoicesButtons(false);

            }
            else
            {
                SetlblTimeForeColor(lblTime, GameResult.Counter);
            }
        }

        private void StarGame()
        {
            EnableAllChoicesButtons(true);

        }
       
        private void GetPlayerName()
        {
            frmPlayerInfo frm = new frmPlayerInfo();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                PlayerInfo.Name = frm.FullName;

                lblPlayeName.Text = PlayerInfo.Name;
            }

        }
        
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            GetPlayerName();
            StarGame();

            timer1.Enabled = true;

        }
       
        private void SetNumberOfMove()
        {
            lblMove.Text = GameResult.Move++.ToString();
        }
        
        private void NotifyIconMessage()
        {
            notifyIcon1.Icon = SystemIcons.Information;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipText = "Oh, you won the game !!";
            notifyIcon1.BalloonTipTitle = "Game Result";
            notifyIcon1.ShowBalloonTip(1000);

        }
        
        private void CheckToWinner()
        {
            if(GameResult.Score == 9)
            {
                timer1.Stop();
                MessageBox.Show("Oh, you won the game");
                NotifyIconMessage();
            }
        }
        
        private void CheckedButtons(Button btn)
        {
            buttons1.Add(btn);
            SetNumberOfMove();

            if (buttons1.Count == 2)
            {
                if (buttons1[0].Tag != buttons1[1].Tag)
                {
                    buttons1[0].BackgroundImage = Resources.question;
                    buttons1[1].BackgroundImage = Resources.question;
                }
                else
                {
                    lblScore.Text = GameResult.Score++.ToString();
                    buttons1[0].Enabled = false;
                    buttons1[1].Enabled = false;
                    CheckToWinner();
                }

                buttons1.Clear();
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            btn1.BackgroundImage = Resources.giraffe;
            CheckedButtons((Button)(sender));
        }

        private void btn15_Click(object sender, EventArgs e)
        {
            btn15.BackgroundImage = Resources.monkey;
            CheckedButtons((Button)(sender));
        }

        private void btn14_Click(object sender, EventArgs e)
        {
            btn14.BackgroundImage = Resources.elephant;
            CheckedButtons((Button)(sender));
        }

        private void btn13_Click(object sender, EventArgs e)
        {
            btn13.BackgroundImage = Resources.whale;
            CheckedButtons((Button)(sender));
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            btn11.BackgroundImage = Resources.giraffe;
            CheckedButtons((Button)(sender));
        }

        private void btn12_Click(object sender, EventArgs e)
        {
            btn12.BackgroundImage = Resources.lion;
            CheckedButtons((Button)(sender));
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            btn10.BackgroundImage = Resources.cat;
            CheckedButtons((Button)(sender));
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            btn9.BackgroundImage = Resources.monkey;
            CheckedButtons((Button)(sender));
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            btn8.BackgroundImage = Resources.whale;
            CheckedButtons((Button)(sender));
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            btn7.BackgroundImage = Resources.lion;
            CheckedButtons((Button)(sender));
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            btn6.BackgroundImage = Resources.hen;
            CheckedButtons((Button)(sender));
        }

        private void btn5_Click(object sender, EventArgs e)
        {

            btn5.BackgroundImage = Resources.dog;
            CheckedButtons((Button)(sender));
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            btn4.BackgroundImage = Resources.elephant;
            CheckedButtons((Button)(sender));
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            btn3.BackgroundImage = Resources.cat;
            CheckedButtons((Button)(sender));
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            btn2.BackgroundImage = Resources.hen;
            CheckedButtons((Button)(sender));
        }
        
        private void btn16_Click(object sender, EventArgs e)
        {
            btn16.BackgroundImage = Resources.dog;
            CheckedButtons((Button)(sender));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SetTimeGame();
        }

        private void RestGameResults()
        {
            GameResult.Move = 1;
            GameResult.Counter = 60;
            GameResult.Score = 1;

            PlayerInfo.Name = "";

            lblMove.Text = 0.ToString();
            lblScore.Text = 0.ToString();
            lblTime.Text = 0.ToString();
            lblPlayeName.Text = "";

            lblTime.ForeColor = Color.White;
            buttons1.Clear();
        }
        
        public void RestImages()
        {
            FillButton();
            for(int i = 0; i < buttons.Count; i++)
            {
                buttons[i].BackgroundImage = Resources.question;
            }
        }
        public void Rest()
        {
            RestGameResults();
            EnableAllChoicesButtons(false);
            RestImages();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Rest();
        }

    }
}
