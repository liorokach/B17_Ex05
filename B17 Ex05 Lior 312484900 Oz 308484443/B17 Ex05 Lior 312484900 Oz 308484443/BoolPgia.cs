using System;
using System.Drawing;
using System.Windows.Forms;

namespace B17_Ex05_Lior_312484900_Oz_308484443
{
    public class BoolPgia : Form
    {
        private int m_countChances = 4;
        private Button m_numOfChances;
        private Button m_start;

        public BoolPgia()
        {
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(240, 125);
            Name = "BoolPgia";
            Text = "BoolPgia";
            buildForm();
            m_numOfChances.Text += m_countChances.ToString();
        }

        private void NumOfChances_Click(object sender, EventArgs e)
        {
            if (m_countChances < 10)
            {
                Button button = sender as Button;
                m_countChances++;
                button.Text = button.Text.Remove(button.Text.Length - 1);
                button.Text = button.Text.Insert(button.Text.Length, m_countChances.ToString());
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Close();
            BoolPgiaGame boolPgiaGame = new BoolPgiaGame(m_countChances);
            boolPgiaGame.AutoSize = true;
            boolPgiaGame.ShowDialog();
        }

        private void buildForm()
        {
            m_numOfChances = new Button();
            m_start = new Button();
            m_numOfChances.Location = new Point(12, 21);
            m_numOfChances.Name = "NumOfChances";
            m_numOfChances.Size = new Size(216, 23);
            m_numOfChances.TabIndex = 0;
            m_numOfChances.Text = "Number of Chances :";
            m_numOfChances.Click += new EventHandler(NumOfChances_Click);
            Controls.Add(m_numOfChances);
            m_start.Location = new Point(153, 90);
            m_start.Name = "Start";
            m_start.Size = new Size(75, 23);
            m_start.TabIndex = 1;
            m_start.Text = "Start";
            m_start.Click += new EventHandler(Start_Click);
            Controls.Add(m_start);
        }
    }
}
