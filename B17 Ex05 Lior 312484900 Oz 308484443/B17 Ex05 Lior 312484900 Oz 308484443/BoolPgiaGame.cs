using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ComputerChoise;

namespace B17_Ex05_Lior_312484900_Oz_308484443
{
    public class BoolPgiaGame : Form
    {
        private const int k_numOfColorChoise = 4;
        private const int k_numOfColors = 8;
        private int m_currLine = 0;
        private List<Button> m_blackButtonList = new List<Button>();
        private PickColor m_pickColorForm = new PickColor(k_numOfColors);
        private List<List<Button>> m_buttonsMatrix;
        private List<Button> m_confirmationList;
        private List<Color> m_resultColor;
        private List<List<Button>> m_resultList;
        private ComputerChoise.ComputerChoise m_compChoise;
        private int m_choiseCounter = 0;

        public BoolPgiaGame(int i_NumLines)
        {
            Text = "Bool Pgia";
            m_compChoise = new ComputerChoise.ComputerChoise(k_numOfColorChoise);
            BuildBoolPgia(i_NumLines);
            BuildConfirmationList(i_NumLines);
            BuildResultList(i_NumLines);
        }

        private static Button buildOneCube(Color i_Color, bool i_IsEnable, Point i_Point, Size i_Size, string i_Text)
        {
            Button button = new Button();
            button.BackColor = i_Color;
            button.Enabled = i_IsEnable;
            button.Location = i_Point;
            button.Size = i_Size;
            button.Text = i_Text;
            return button;
        }

        private void BuildConfirmationList(int i_NumOfLines)
        {
            Point position = new Point(208, 82);
            Size size = new Size(40, 20);
            m_confirmationList = new List<Button>(i_NumOfLines);
            for (int i = 0; i < i_NumOfLines; i++)
            {
                m_confirmationList.Add(buildOneCube(Color.LightGray, false, position, size, "-->>"));
                m_confirmationList[i].Click += new EventHandler(confirm_Click);
                Controls.Add(m_confirmationList[i]);
                position.Y += 50;
            }
        }

        private void BuildResultList(int i_NumOfLines)
        {
            Point position;
            Size size = new Size(15, 15);
            m_resultList = new List<List<Button>>(i_NumOfLines);
            for (int i = 0; i < i_NumOfLines; i++)
            {
                m_resultList.Add(new List<Button>(k_numOfColorChoise));
                position = new Point(254, 75 + (i * 50));

                for (int j = 0; j < k_numOfColorChoise / 2; j++) 
                {
                    m_resultList[i].Add(buildOneCube(Color.Gray, false, position, size, string.Empty));
                    Controls.Add(m_resultList[i][j]);
                    position.X += 22;
                }

                position.X = 254;
                position.Y += 22;
                for (int j = k_numOfColorChoise / 2; j < k_numOfColorChoise; j++) 
                {
                    m_resultList[i].Add(buildOneCube(Color.Gray, false, position, size, string.Empty));
                    Controls.Add(m_resultList[i][j]);
                    position.X += 22;
                }
            }
        }

        private void confirm_Click(object i_sender, EventArgs i_event)
        {
            Button button = i_sender as Button;
            List<Color> colorChoise = new List<Color>();
            for (int i = 0; i < k_numOfColorChoise; i++)
            {
                colorChoise.Add(m_buttonsMatrix[m_currLine][i].BackColor);
            }

            m_resultColor = m_compChoise.CheckUserChoise(colorChoise);
            UpdateResultList();
            checkifFinishAndUpdateInitLine();
            m_currLine++;
            m_choiseCounter = 0;
            m_pickColorForm.ResetColors();
            button.Enabled = false;
        }

        private void checkifFinishAndUpdateInitLine()
        {
            bool success = true;
            for (int i = 0; i < k_numOfColorChoise; i++)
            {
                if(m_resultList[m_currLine][i].BackColor != Color.Black)
                {
                    success = false;
                }
            }

            if(success == true)
            {
                for (int i = 0; i < m_blackButtonList.Count; i++)
                {
                    m_blackButtonList[i].BackColor = m_buttonsMatrix[m_currLine][i].BackColor;
                }
            }
        }

        private void UpdateResultList()
        {
            for (int i = 0; i < m_resultColor.Count; i++)
            {
                m_resultList[m_currLine][i].BackColor = m_resultColor[i];
            }
        }

        private void pickColor_Click(object i_sender, EventArgs i_event)
        {
            Button button = i_sender as Button;
            if(m_currLine == (int)button.Tag)
            {
                m_pickColorForm.ShowDialog();
            }

            if (!m_pickColorForm.IsForcedClosed)
            {
                button.Enabled = false;
                button.BackColor = m_pickColorForm.ColorPicked;
                m_choiseCounter++;
            }

            m_pickColorForm.IsForcedClosed = true;
            if(m_choiseCounter == k_numOfColorChoise)
            {
                m_confirmationList[m_currLine].Enabled = true;
            }
        }

        private void BuildBoolPgia(int i_NumLines)
        {
            BuildInitLine(); // the first 4 black button
            m_buttonsMatrix = new List<List<Button>>(i_NumLines);
            Point position = new Point(12, 75);
            Size size = new Size(35, 35);
            for (int i = 0; i < i_NumLines; i++)
            {
                position.X = 12;
                m_buttonsMatrix.Add(new List<Button>(k_numOfColorChoise)); // each line contains 4 cube;
                for (int j = 0; j < k_numOfColorChoise; j++)
                {
                    m_buttonsMatrix[i].Add(buildOneCube(Color.LightGray, true, position, size, string.Empty));
                    position.X += 50;
                    m_buttonsMatrix[i][j].Tag = i;
                    m_buttonsMatrix[i][j].Click += new EventHandler(pickColor_Click);
                    Controls.Add(m_buttonsMatrix[i][j]);
                }

                position.Y += 50;
            }
        }

        private void BuildInitLine()
        {
            Point position = new Point(12, 12);
            Size size = new Size(35, 35);
            for (int i = 0; i < 4; i++)
            {
                m_blackButtonList.Add(buildOneCube(Color.Black, false, position, size, string.Empty));
                Controls.Add(m_blackButtonList[i]);
                position.X = position.X + 50;
            }
        }
    }
}
