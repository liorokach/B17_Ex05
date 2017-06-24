using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace B17_Ex05_Lior_312484900_Oz_308484443
{
     public static class Program
     {
          public static void Main()
          {
               Application.EnableVisualStyles();
               PickColor p = new PickColor(8);
               p.ShowDialog();
               //Application.Run(new Form());
          }
     }
}
