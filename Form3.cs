using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryMatchingGame
{
    public partial class Form3 : Form
    {
        List<Player> final;                                                                               //A list of players type variables (from Player.cs class), final.
        public Form3(List<Player> top10)                                                                        
        {
            InitializeComponent();                                                                        //Initialize components.  
            final = new List<Player>();                                                                   //A list of players type variables (from Player.cs class), final.                          
            final = top10;                                                                                //List of players type variables, final gets top10 content.          

        }

        private void Form3_Load(object sender, EventArgs e)                                               //Form3_Load void.                  
        {
            if (final.Count() <= 10)                                                                      //If final.count() (from Player.cs class) is less than/equal to 10, then:                         
            {
                for(int i=0; i< final.Count(); i++)                                                        //A for loop.                              
                {
                    StreamWriter sw = new StreamWriter("tmp.txt", true);                                  //A StreamWriter variable, sw for tmp.txt file.                                              
                    {
                        sw.Write(final[i].name + "  TRIES : " + final[i].tries + Environment.NewLine);    //StreamWriter variable, sw records final.name and final.tries.                                                   
                    }
                    sw.Close();                                                                           //StreamWriter variable, sw closes.                                    
                }
            }
            else                                                                                          //Else if final.count() (from Player.cs class) is over 10, then:                           
            {
                for (int i = 0; i < 10; i++)                                                              //A for loop statement.                                          
                {
                    StreamWriter sw = new StreamWriter("tmp.txt", true);                                  //A StreamWriter variable, sw for tmp.txt file.                                            
                    {
                        sw.Write(final[i].name + "  TRIES : " + final[i].tries + Environment.NewLine);    //StreamWriter variable, sw records final.name and final.tries.                                                                        
                    }
                    sw.Close();                                                                           //StreamWriter variable, sw closes.                                               
                }
            }

            richTextBox1.LoadFile("tmp.txt", RichTextBoxStreamType.PlainText);                            //richTextBox1 loads tmp.txt file.                                          
            File.Delete("tmp.txt");                                                                       //Deletes tmp.txt file.                                                          
        }
    }
}
