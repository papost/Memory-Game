using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryMatchingGame
{
    public partial class Form1 : Form
    {
        BinaryFormatter formater = new BinaryFormatter();                                                        //A BinaryFormatter variable, formater.
        FileStream fs;                                                                                           //A FileStream variable, fs.                               
        public List<Player> top10;                                                                               //A public list of player type variables (from Player.cs class), top10.                                                           
        public Form1()                                                                                           //Form1.                   
        {
            InitializeComponent();                                                                               //Initialize components.               
        }

        private void Form1_Load(object sender, EventArgs e)                                                      //Form1_Load void.                   
        {
            pictureBox1.Image = new Bitmap(Properties.Resources.Card1);                                          //pictureBox1 loads it's image from Properties.Resources.Card1.                              
            pictureBox2.Image = new Bitmap(Properties.Resources.Card2);                                          //pictureBox2 loads it's image from Properties.Resources.Card2.                                              
            pictureBox3.Image = new Bitmap(Properties.Resources.Card3);                                          //pictureBox3 loads it's image from Properties.Resources.Card3.                                                          
            pictureBox4.Image = new Bitmap(Properties.Resources.Card4);                                          //pictureBox4 loads it's image from Properties.Resources.Card4.                                          
            pictureBox5.Image = new Bitmap(Properties.Resources.Card5);                                          //pictureBox5 loads it's image from Properties.Resources.Card5.                                      
            pictureBox6.Image = new Bitmap(Properties.Resources.Card6);                                          //pictureBox6 loads it's image from Properties.Resources.Card6.                                                          
            pictureBox7.Image = new Bitmap(Properties.Resources.Card7);                                          //pictureBox7 loads it's image from Properties.Resources.Card7.                                                                              
            pictureBox8.Image = new Bitmap(Properties.Resources.Card8);                                          //pictureBox8 loads it's image from Properties.Resources.Card8.      
            
            try                                                                                                  //A try method.                                                   
            {                                                                                                   
                FileInfo f1 = new FileInfo("top10.txt");                                                         //A FileInfo variable, f1 for top10.txt file.                       
                if (f1.Length != 0)                                                                              //If f1 (top10.txt) is not empty, then:                   
                {   
                    richTextBox1.LoadFile("top10.txt", RichTextBoxStreamType.PlainText);                         //richTextBox1 loads top10.txt file.           
                    top10 = new List<Player>(10);                                                                //top10 gets 10 elements from list of player type variables (from Player.cs class).                            
                    foreach (string s in richTextBox1.Lines)                                                     //A foreach statement.                                        
                    {
                        string[] tmp = s.Split(new string[] { "  TRIES : " }, StringSplitOptions.None);          //An array of strings, tmp.                                                   
                        Player p = new Player(tmp[0], Convert.ToInt32(tmp[1]));                                  //A Player variable, p gets first and second int-converted elements from tmp array.                                       
                        top10.Add(p);                                                                            //top10 adds Player variable, p.                   
                    }
                    top10 = top10.OrderBy(x => x.tries).ToList();                                                //List of player type variables (from Player.cs class), top10 is sorted.                                            

                }
            }
            catch                                                                                                //Exception.                           
            {

            }

        }
        private void pictureBox1_Click(object sender, EventArgs e)                                               //pictureBox1_Click void.    
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
            //When pictureBox1 is clicked, opens file dialog in order to replace the picturebox1's image with an image of user's choice.   
        }
        private void pictureBox2_Click(object sender, EventArgs e)                                               //pictureBox2_Click void.          
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) pictureBox2.Image = new Bitmap(openFileDialog1.FileName);
            //When pictureBox2 is clicked, opens file dialog in order to replace the picturebox2's image with an image of user's choice.  
        }
        private void pictureBox3_Click(object sender, EventArgs e)                                               //pictureBox3_Click void.                  
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) pictureBox3.Image = new Bitmap(openFileDialog1.FileName);
            //When pictureBox3 is clicked, opens file dialog in order to replace the picturebox3's image with an image of user's choice.  
        }
        private void pictureBox4_Click(object sender, EventArgs e)                                               //pictureBox4_Click void.          
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) pictureBox4.Image = new Bitmap(openFileDialog1.FileName);
            //When pictureBox4 is clicked, opens file dialog in order to replace the picturebox4's image with an image of user's choice.  
        }
        private void pictureBox5_Click(object sender, EventArgs e)                                               //pictureBox5_Click void.                      
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) pictureBox5.Image = new Bitmap(openFileDialog1.FileName);
            //When pictureBox5 is clicked, opens file dialog in order to replace the picturebox5's image with an image of user's choice.  
        }
        private void pictureBox6_Click(object sender, EventArgs e)                                               //pictureBox6_Click void.                              
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) pictureBox6.Image = new Bitmap(openFileDialog1.FileName);
            //When pictureBox6 is clicked, opens file dialog in order to replace the picturebox6's image with an image of user's choice.  
        }
        private void pictureBox7_Click(object sender, EventArgs e)                                               //pictureBox7_Click void.                  
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) pictureBox7.Image = new Bitmap(openFileDialog1.FileName);
            //When pictureBox7 is clicked, opens file dialog in order to replace the picturebox7's image with an image of user's choice.  
        }
        private void pictureBox8_Click(object sender, EventArgs e)                                               //pictureBox8_Click void.                                  
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) pictureBox8.Image = new Bitmap(openFileDialog1.FileName);
            //When pictureBox8 is clicked, opens file dialog in order to replace the picturebox8's image with an image of user's choice.  
        }
        private void button1_Click(object sender, EventArgs e)                                                   //Replace image button void (button1_Click).                               
        {
            pictureBox1.Image = new Bitmap(Properties.Resources.Card1);                                          //Resets default pictureBox1's image from Properties.Resources.Card1.                                            
        }
        private void button2_Click(object sender, EventArgs e)                                                   //Replace image button void (button2_Click).                                                             
        {
            pictureBox2.Image = new Bitmap(Properties.Resources.Card2);                                          //Resets default pictureBox2's image from Properties.Resources.Card2.                                                                                               
        }
        private void button3_Click(object sender, EventArgs e)                                                   //Replace image button void (button3_Click).                                                         
        {
            pictureBox3.Image = new Bitmap(Properties.Resources.Card3);                                          //Resets default pictureBox3's image from Properties.Resources.Card3.                                                                                           
        }
        private void button4_Click(object sender, EventArgs e)                                                   //Replace image button void (button4_Click).                                         
        {
            pictureBox4.Image = new Bitmap(Properties.Resources.Card4);                                          //Resets default pictureBox4's image from Properties.Resources.Card4.                                                                           
        }
        private void button5_Click(object sender, EventArgs e)                                                   //Replace image button void (button5_Click).                                 
        {
            pictureBox5.Image = new Bitmap(Properties.Resources.Card5);                                          //Resets default pictureBox5's image from Properties.Resources.Card5.                                                                                                   
        }
        private void button6_Click(object sender, EventArgs e)                                                   //Replace image button void (button6_Click).                                                                     
        {
            pictureBox6.Image = new Bitmap(Properties.Resources.Card6);                                          //Resets default pictureBox6's image from Properties.Resources.Card6.                                                                                                                               
        }
        private void button7_Click(object sender, EventArgs e)                                                   //Replace image button void (button7_Click).                                                                                     
        {
            pictureBox7.Image = new Bitmap(Properties.Resources.Card7);                                          //Resets default pictureBox7's image from Properties.Resources.Card7.                                                                                                                                         
        }
        private void button8_Click(object sender, EventArgs e)                                                   //Replace image button void (button8_Click).                                                                                     
        {
            pictureBox8.Image = new Bitmap(Properties.Resources.Card8);                                          //Resets default pictureBox8's image from Properties.Resources.Card8.                                                                                                                                                   
        }
        private void button9_Click(object sender, EventArgs e)                                                   //Confirm user's name/Start button void (button9_Click).                                                                               
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))                                                        //If textBox1 is empty, then:                                                                   
            {
                MessageBox.Show("INSERT NAME");                                                                  //Warning message appears.                                               
            }
            else                                                                                                 //Else, If textBox1 is not empty, then:                                             
            {
                List<Image> photos = new List<Image>();                                                          //A list om image type variables, photos.                                                           
                foreach (Control s in this.Controls)                                                             //A foreach statement.                                                   
                {
                    if (s.GetType() == typeof(PictureBox))                                                       //If s in Controls is a pictureBox tool, then:                                                            
                    {
                        PictureBox p = (PictureBox)s;                                                            //A PictureBox variable, p.                                                                       
                        photos.Add(p.Image);                                                                     //PictureBox variable, p is added to list of image type variables, photos.                                                    
                    }   
                }

                GameWindow start = new GameWindow(photos, textBox1.Text);                                        //Creates a new instance of the Form2 class, highscores and includes to it list of image type variables, photos and textBox1"s text.                                                                            
                start.ShowDialog();                                                                              //Opens Form2.                                                                                                               
            }
        }

        private void button10_Click(object sender, EventArgs e)                                                  //Top10 button void (button10_Click).                                                                       
        {
            richTextBox1.Clear();                                                                                //Clears richTextBox1.           
            
            try                                                                                                  //A try method.                                                                             
            {
                FileInfo f1 = new FileInfo("top10.txt");                                                         //A FileInfo variable, f1 for top10.txt file.                                                                                             
                if (f1.Length != 0)                                                                              //If f1 (top10.txt) is not empty, then:                                                                                 
                {
                    richTextBox1.LoadFile("top10.txt", RichTextBoxStreamType.PlainText);                         //richTextBox1 loads top10.txt file.                                                                                               
                    top10 = new List<Player>(10);                                                                //top10 gets 10 elements from list of player type variables (from Player.cs class).                                                                                     
                    foreach (string s in richTextBox1.Lines)                                                     //A foreach statement.                                                                    
                    {
                        string[] tmp = s.Split(new string[] { "  TRIES : " }, StringSplitOptions.None);          //An array of strings, tmp.                                                                                                       
                        Player p = new Player(tmp[0], Convert.ToInt32(tmp[1]));                                  //A Player variable, p gets first and second int-converted elements from tmp array.                                                                                                   
                        top10.Add(p);                                                                            //top10 adds Player variable, p.                                                                            
                    }

                    top10 = top10.OrderBy(x => x.tries).ToList();                                                //List of player type variables (from Player.cs class), top10 is sorted.                                                                              
                    Form3 highscores = new Form3(top10);                                                         //Creates a new instance of the Form3 class, highscores and includes to it list of player type variables, top10.                                                                                            
                    highscores.ShowDialog();                                                                     //Opens Form3.                                                                               
                }
            }
            catch                                                                                                //Exception.                                               
            {
                MessageBox.Show("NO PLAYERS");                                                                   //Exception's message appears.                                                                       
            }                                                                                                                                                             
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)                                    //Start menu button void.
        {
            this.button9.PerformClick();                                                                         //At every click calls start button void (button9_Click).        
        }

        private void top10ToolStripMenuItem_Click(object sender, EventArgs e)                                    //Top10 menu button void.                                       
        {
            this.button10.PerformClick();                                                                        //At every click calls Top10 button void (button10_Click).    
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)                                     //Exit menu button void.                                      
        {
            Application.Exit();                                                                                  //Exits from the Application.  
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)                                    //About menu button void.         
        {
            MessageBox.Show("This game was made by Panagiotis Apostolopoulos, Dimitris Matsanganis and Pavlos Roumeliotis.");      
            //A Messagebox pops up with editors's name.
        }
    }
}