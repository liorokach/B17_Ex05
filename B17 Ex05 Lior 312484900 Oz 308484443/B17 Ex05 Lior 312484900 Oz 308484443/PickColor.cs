using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace B17_Ex05_Lior_312484900_Oz_308484443
{
     public class PickColor : Form
     {
          ColorButton[] m_PickColor;
          int m_pickCounter = 0;
          const int k_separator = 12;
          Color[] m_colors = new Color[8];
          
         
          public PickColor(int i_NumOfButtons)
          {
               m_colors[0] = Color.Purple;
               m_colors[1] = Color.Red;
               m_colors[2] = Color.LawnGreen;
               m_colors[3] = Color.PaleTurquoise;
               m_colors[4] = Color.Blue;
               m_colors[5] = Color.Yellow;
               m_colors[6] = Color.Brown;
               m_colors[7] = Color.White;
               m_PickColor = new ColorButton[i_NumOfButtons];
               int top = Top + k_separator;
               int left = Left + k_separator;
               for (int i = 0; i < i_NumOfButtons; i++)
               {
                    m_PickColor[i] = new ColorButton(m_colors[i]);
                    m_PickColor[i].Click += new EventHandler(button_Click);
                    m_PickColor[i].Top = top;
                    m_PickColor[i].Left = left;
                    Controls.Add(m_PickColor[i]);
                    if (i_NumOfButtons / 2 == i + 1)
                    {
                         top = top + m_PickColor[i].Height + k_separator;
                         left = Left + k_separator;
                    }
                    else
                    {
                         left += m_PickColor[i].Width + k_separator;
                    }
               }
               Text = "Pick A Color";
               FormBorderStyle = FormBorderStyle.Fixed3D;
               Size = new Size(280, 180);
               StartPosition = FormStartPosition.CenterScreen;
          }


          private void button_Click(object sender, EventArgs e)
          {
               if (m_pickCounter < 4)
               {
                    ColorButton button = sender as ColorButton;
                    button.BackColor = Color.Gray;
                    button.Enabled = false;
                    m_pickCounter++;
               }
          }

          

          protected override void OnShown(EventArgs e)
          {
               base.OnShown(e);
          }

          private void InitializeComponent()
          {
               this.SuspendLayout();
               // 
               // PickColor
               // 
               this.ClientSize = new System.Drawing.Size(284, 261);
               this.Name = "PickColor";
               this.ResumeLayout(false);

          }
     }
}


