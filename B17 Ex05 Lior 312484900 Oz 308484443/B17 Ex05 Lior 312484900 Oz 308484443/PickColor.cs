using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace B17_Ex05_Lior_312484900_Oz_308484443
{
    public class PickColor : Form
    {
        private const int k_separator = 12;
        private Button[] m_colorArr;
        private Color[] m_colors = new Color[8];
        private Color m_pickedColor;
        private bool m_closedByUser = true;

        public PickColor(int i_NumOfButtons)
        {
            CreateColors();
            m_colorArr = new Button[i_NumOfButtons];
            int top = Top + k_separator;
            int left = Left + k_separator;
            for (int i = 0; i < i_NumOfButtons; i++)
            {
                m_colorArr[i] = new Button();
                m_colorArr[i].BackColor = m_colors[i];
                m_colorArr[i].Size = new Size(50, 50);
                m_colorArr[i].Click += new EventHandler(color_Click);
                m_colorArr[i].Top = top;
                m_colorArr[i].Left = left;
                Controls.Add(m_colorArr[i]);
                if (i_NumOfButtons / 2 == i + 1)
                {
                    top = top + m_colorArr[i].Height + k_separator;
                    left = Left + k_separator;
                }
                else
                {
                    left += m_colorArr[i].Width + k_separator;
                }
            }

            Text = "Pick A Color";
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Size = new Size(280, 180);
            StartPosition = FormStartPosition.CenterScreen;
        }

        public void CreateColors()
        {
            m_colors[0] = Color.Purple;
            m_colors[1] = Color.Red;
            m_colors[2] = Color.LawnGreen;
            m_colors[3] = Color.PaleTurquoise;
            m_colors[4] = Color.Blue;
            m_colors[5] = Color.Yellow;
            m_colors[6] = Color.Brown;
            m_colors[7] = Color.White;
        }

        public void ResetColors()
        {
            for (int i = 0; i < m_colorArr.Length; i++)
            {
                m_colorArr[i].BackColor = m_colors[i];
                m_colorArr[i].Enabled = true;
            }
        }

        public void color_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            m_pickedColor = button.BackColor;
            button.BackColor = Color.LightGray;
            button.Enabled = false;
            m_closedByUser = false;
            Close();
        }

        public Color ColorPicked
        {
            get
            {
                return m_pickedColor;
            }

            set
            {
                m_pickedColor = value;
            }
        }

        public bool IsForcedClosed
        {
            get
            {
                return m_closedByUser;
            }

            set
            {
                m_closedByUser = value;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }
    }
}
