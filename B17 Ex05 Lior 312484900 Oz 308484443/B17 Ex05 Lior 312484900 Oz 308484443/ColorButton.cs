using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace B17_Ex05_Lior_312484900_Oz_308484443
{
     class ColorButton : Button
     {
          Color m_color;
          

          public ColorButton(Color i_color)
          {
               m_color = i_color;
               BackColor = m_color;
               Size = new Size(50, 50);
          }
     }
}
