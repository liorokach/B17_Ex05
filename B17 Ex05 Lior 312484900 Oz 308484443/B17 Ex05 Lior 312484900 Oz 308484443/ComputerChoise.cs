using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ComputerChoise
{
    public struct ComputerChoise
    {
        private readonly List<Color> m_colors;
        private List<Color> m_compColorChoise;

        public static List<Color> GenerateRndColors(int i_NumberOfColors, List<Color> i_ColorsArr)
        {
            List<Color> randomColorsArr = new List<Color>(i_NumberOfColors);
            Random random = new Random();
            Color pickColor;
            for (int i = 0; i < i_NumberOfColors; i++)
            {
                int offset;
                do
                {
                    offset = random.Next(0, 8);
                    pickColor = i_ColorsArr[offset];
                }
                while (randomColorsArr.Contains(pickColor));
                randomColorsArr.Add(pickColor);
            }

            return randomColorsArr;
        }

        public ComputerChoise(int i_numberOfColors)
        {
            m_colors = new List<Color>(8);
            m_colors.Add(Color.Purple);
            m_colors.Add(Color.Red);
            m_colors.Add(Color.LawnGreen);
            m_colors.Add(Color.PaleTurquoise);
            m_colors.Add(Color.Blue);
            m_colors.Add(Color.Yellow);
            m_colors.Add(Color.Brown);
            m_colors.Add(Color.White);
            m_compColorChoise = GenerateRndColors(i_numberOfColors, m_colors);
        }

        public List<Color> GetChoise()
        {
            return m_compColorChoise;
        }

        public List<Color> CheckUserChoise(List<Color> i_userChoise)
        {
            int indexResult;
            List<Color> colorsScore = new List<Color>();
            for (int i = 0; i < i_userChoise.Count; i++)
            {
                indexResult = m_compColorChoise.IndexOf(i_userChoise[i]);
                if (indexResult == i)
                {
                    colorsScore.Insert(0, Color.Black);
                }
                else if (indexResult != -1)
                {
                    colorsScore.Add(Color.Yellow);
                }
            }

            return colorsScore;
        }

        public int GetComputerChoiseLength()
        {
            return m_compColorChoise.Count;
        }
    }
}