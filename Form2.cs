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
    public partial class GameWindow : Form
    {
        
        List<Image> pics;                                                                               //A list of image type variables, pics.      
        public Game game = new Game();                                                                  //A public game variable, game.        
        Random location = new Random();                                                                 //A random variable, location (Selects a random value from X and Y list and assign a new location to each card).
        List<Point> points = new List<Point>();                                                         //A list of points type variables, points (List to hold cards points).
        PictureBox PendingImage1;                                                                       //A pictureBox type variable PendingImage1 (Stores first flipped card into this variable).
        PictureBox PendingImage2;                                                                       //A pictureBox type variable PendingImage2 (Stores second flipped card into this variable).

        public GameWindow(List<Image> images, string player_name)                                       //GameWindow void.
        {
            pics = images;                                                                              //List of image type variables, pics equals to images.    
            game.name = player_name;                                                                    //game.name (From Game.cs class) equals to player_name.                    
            InitializeComponent();                                                                      //Initialize components.    
            
            for (int i = 0; i < 8; i++)                                                                 //A for loop statement.                                
            {
                pics.Add(images[i]);                                                                    //List of image type variables, pics adds i-element of list of image type variables, images.                                     
            }
        }

        private void GameWindow_Load(object sender, EventArgs e)                                        //GameWindow_Load void (Form2_Load).                    
        {
            game.gameover = false;                                                                      //Bool variable game.gameover (From Game.cs class) is false.                     
            game.tries = 0;                                                                             //Int variable game.tries (From Game.cs class) equals to zero.                        
            game.correct = 0;                                                                           //Int variable game.correct (From Game.cs class) equals to zero.                                                    
            game.sec = 0;                                                                               //Int variable game.sec (From Game.cs class) equals to zero.            
            ScoreCounter.Text = game.tries.ToString();                                                  //ScoreCounter shows game.tries (From Game.cs class), after been corverted to string.                                         
            label1.Text = "3";                                                                          //label1 shows "3".                            
            label2.Text = "Name : " + game.name;                                                        //label2 shows "Name : " and game.name (From Game.cs class).                    
            label3.Text = "Time : " + game.sec.ToString();                                              //label3 shows "Time : " and string-corverted game.sec (From Game.cs class).                                                 

            foreach (PictureBox picture in CardsHolder.Controls)                                        //A foreach (pictureBox in controls) loop statement.                                                                                   
            {
                picture.Enabled = false;                                                                //PictureBox variable, picture is not enabled.                            
                points.Add(picture.Location);                                                           //List of points type variables, points adds picture's location.                     
            }

            foreach (PictureBox picture in CardsHolder.Controls)                                        //A foreach (pictureBox in controls) loop statement.                                          
            {
                int next = location.Next(points.Count);                                                 //An int variable, next gets location of the next picture.                                                
                Point p = points[next];                                                                 //A Point variable, p gets next card point.                                                    
                picture.Location = p;                                                                   //PictureBox variable, picture equals to p.                                                                
                points.Remove(p);                                                                       //List of points type variables, points removes p.                                                            
            }

            timer2.Start();                                                                             //timer2 starts.    
            timer1.Start();                                                                             //timer1 starts.            
            Card1.Image = pics[1];                                                                      //Card1's image is the first element of list of image type variables, pics.            
            DupCard1.Image = pics[1];                                                                   //DupCard1's image is the first element of list of image type variables, pics.              
            Card2.Image = pics[2];                                                                      //Card2's image is the second element of list of image type variables, pics.                          
            DupCard2.Image = pics[2];                                                                   //DupCard2's image is the second element of list of image type variables, pics.                            
            Card3.Image = pics[3];                                                                      //Card3's image is the third element of list of image type variables, pics.                                      
            DupCard3.Image = pics[3];                                                                   //DupCard3's image is the third element of list of image type variables, pics.                                
            Card4.Image = pics[4];                                                                      //Card4's image is the forth element of list of image type variables, pics.                                                      
            DupCard4.Image = pics[4];                                                                   //DupCard4's image is the forth element of list of image type variables, pics.                 
            Card5.Image = pics[5];                                                                      //Card5's image is the fifth element of list of image type variables, pics.                                                                                                  
            DupCard5.Image = pics[5];                                                                   //DupCard5's image is the fifth element of list of image type variables, pics.                     
            Card6.Image = pics[6];                                                                      //Card6's image is the sixth element of list of image type variables, pics.      
            DupCard6.Image = pics[6];                                                                   //DupCard6's image is the sixth element of list of image type variables, pics.                     
            Card7.Image = pics[7];                                                                      //Card7's image is the seventh element of list of image type variables, pics.          
            DupCard7.Image = pics[7];                                                                   //DupCard7's image is the seventh element of list of image type variables, pics.                                  
            Card8.Image = pics[8];                                                                      //Card8's image is the eighth element of list of image type variables, pics.                      
            DupCard8.Image = pics[8];                                                                   //DupCard8's image is the eighth element of list of image type variables, pics.                       
        }

        private void timer1_Tick(object sender, EventArgs e)                                            //timer1_Tick void.    
        {
            timer1.Stop();                                                                              //timer1 stops.
            
            foreach (PictureBox picture in CardsHolder.Controls)                                        //A foreach loop statement.              
            {   
                picture.Enabled = true;                                                                 //PictureBox variable, picture is enabled.                                
                picture.Cursor = Cursors.Hand;                                                          //Cursor changes to hand.                        
                picture.Image = Properties.Resources.Cover;                                             //PictureBox variable, picture gets it's image from Properties.Resources.Cover.                      
            }
        }

        private void timer2_Tick(object sender, EventArgs e)                                            //timer2_Tick void.                        
        {
            int timer = Convert.ToInt32(label1.Text);                                                   //Int variable, timer gets label1's int-converted text.                
            timer = timer-1;                                                                            //Int variable, timer decreases it's value by 1.                
            label1.Text = Convert.ToString(timer);                                                      //label1's text gets string-converted timer's value.        

            if (timer == 0)                                                                             //If int variable, timer equals to zero, then:               
            {
                timer2.Stop();                                                                          //timer2 stops.                        
                timer4.Start();                                                                         //timer4 starts.        
            }
        }

        //Change Card Value Operation.
        #region Cards
        private void Card1_Click(object sender, EventArgs e)
        {
            Card1.Image = pics[1];
            if (PendingImage1 == null)
            {
                PendingImage1 = Card1;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card1;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card1.Enabled = false;
                    DupCard1.Enabled = false;
                    game.correct = game.correct + 1;
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                }
                else
                {
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                    timer3.Start();
                }
            }
        }
        private void DupCard1_Click(object sender, EventArgs e)
        {
            DupCard1.Image = pics[1];
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard1;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard1;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card1.Enabled = false;
                    DupCard1.Enabled = false;
                    game.correct = game.correct + 1;
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                }
                else
                {
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                    timer3.Start();
                }
            }
        }

        private void Card2_Click(object sender, EventArgs e)
        {
            Card2.Image = pics[2];
            if (PendingImage1 == null)
            {
                PendingImage1 = Card2;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card2;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card2.Enabled = false;
                    DupCard2.Enabled = false;
                    game.correct = game.correct + 1;
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                }
                else
                {
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                    timer3.Start();
                }
            }
        }

        private void DupCard2_Click(object sender, EventArgs e)
        {
            DupCard2.Image = pics[2];
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard2;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard2;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card2.Enabled = false;
                    DupCard2.Enabled = false;
                    game.correct = game.correct + 1;
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                }
                else
                {
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                    timer3.Start();
                }
            }
        }

        private void Card3_Click(object sender, EventArgs e)
        {
            Card3.Image = pics[3];
            if (PendingImage1 == null)
            {
                PendingImage1 = Card3;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card3;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card3.Enabled = false;
                    DupCard3.Enabled = false;
                    game.correct = game.correct + 1;
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                }
                else
                {
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                    timer3.Start();
                }
            }
        }

        private void DupCard3_Click(object sender, EventArgs e)
        {
            DupCard3.Image = pics[3];
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard3;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard3;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card3.Enabled = false;
                    DupCard3.Enabled = false;
                    game.correct = game.correct + 1;
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                }
                else
                {
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                    timer3.Start();
                }
            }
        }

        private void Card4_Click(object sender, EventArgs e)
        {
            Card4.Image = pics[4];
            if (PendingImage1 == null)
            {
                PendingImage1 = Card4;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card4;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card4.Enabled = false;
                    DupCard4.Enabled = false;
                    game.correct = game.correct + 1;
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                }
                else
                {
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                    timer3.Start();
                }
            }
        }

        private void DupCard4_Click(object sender, EventArgs e)
        {
            DupCard4.Image = pics[4];
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard4;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard4;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card4.Enabled = false;
                    DupCard4.Enabled = false;
                    game.correct = game.correct + 1;
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                }
                else
                {
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                    timer3.Start();
                }
            }
        }

        private void Card5_Click(object sender, EventArgs e)
        {
            Card5.Image = pics[5];
            if (PendingImage1 == null)
            {
                PendingImage1 = Card5;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card5;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card5.Enabled = false;
                    DupCard5.Enabled = false;
                    game.correct = game.correct + 1;
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                }
                else
                {
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                    timer3.Start();
                }
            }
        }

        private void DupCard5_Click(object sender, EventArgs e)
        {
            DupCard5.Image = pics[5];
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard5;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard5;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card5.Enabled = false;
                    DupCard5.Enabled = false;
                    game.correct = game.correct + 1;
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                }
                else
                {
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                    timer3.Start();
                }
            }
        }

        private void Card6_Click(object sender, EventArgs e)
        {
            Card6.Image = pics[6];
            if (PendingImage1 == null)
            {
                PendingImage1 = Card6;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card6;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card6.Enabled = false;
                    DupCard6.Enabled = false;
                    game.correct = game.correct + 1;
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                }
                else
                {
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                    timer3.Start();
                }
            }
        }

        private void DupCard6_Click(object sender, EventArgs e)
        {
            DupCard6.Image = pics[6];
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard6;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard6;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card6.Enabled = false;
                    DupCard6.Enabled = false;
                    game.correct = game.correct + 1;
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                }
                else
                {
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                    timer3.Start();
                }
            }
        }

        private void Card7_Click(object sender, EventArgs e)
        {
            Card7.Image = pics[7];
            if (PendingImage1 == null)
            {
                PendingImage1 = Card7;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card7;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card7.Enabled = false;
                    DupCard7.Enabled = false;
                    game.correct = game.correct + 1;
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                }
                else
                {
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                    timer3.Start();
                }
            }
        }

        private void DupCard7_Click(object sender, EventArgs e)
        {
            DupCard7.Image = pics[7];
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard7;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard7;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card7.Enabled = false;
                    DupCard7.Enabled = false;
                    game.correct = game.correct + 1;
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                }
                else
                {
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                    timer3.Start();
                }
            }
        }

        private void Card8_Click(object sender, EventArgs e)
        {
            Card8.Image = pics[8];
            if (PendingImage1 == null)
            {
                PendingImage1 = Card8;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = Card8;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card8.Enabled = false;
                    DupCard8.Enabled = false;
                    game.correct = game.correct + 1;
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                }
                else
                {
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                    timer3.Start();
                }
            }
        }

        private void DupCard8_Click(object sender, EventArgs e)
        {
            DupCard8.Image = pics[8];
            if (PendingImage1 == null)
            {
                PendingImage1 = DupCard8;
            }
            else if (PendingImage1 != null && PendingImage2 == null)
            {
                PendingImage2 = DupCard8;
            }
            if (PendingImage1 != null && PendingImage2 != null)
            {
                if (PendingImage1.Tag == PendingImage2.Tag)
                {
                    PendingImage1 = null;
                    PendingImage2 = null;
                    Card8.Enabled = false;
                    DupCard8.Enabled = false;
                    game.correct = game.correct + 1;
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                }
                else
                {
                    game.tries = game.tries + 1;
                    ScoreCounter.Text = game.tries.ToString();
                    timer3.Start();
                }
            }
        }
        #endregion

        private void timer3_Tick(object sender, EventArgs e)                                            //timer3_Tick void.
        {
            timer3.Stop();                                                                              //timer3 stops.        
            PendingImage1.Image = Properties.Resources.Cover;                                           //PendingImage1 gets it's image from Properties.Resources.Cover.                                         
            PendingImage2.Image = Properties.Resources.Cover;                                           //PendingImage2 gets it's image from Properties.Resources.Cover.                                
            PendingImage1 = null;                                                                       //PendingImage1 is null.                
            PendingImage2 = null;                                                                       //PendingImage2 is null.            
        }

        private void button1_Click(object sender, EventArgs e)                                          //Restart game button void (button1_Click).            
        {
            GameWindow_Load(sender, e);                                                                 //Reloads GameWindow form.                        
        }

        private void timer4_Tick(object sender, EventArgs e)                                            //timer4_Tick void.
        {
            game.sec = game.sec + 1;                                                                    //Int variable, game.sec (From Game.cs class) increases it's value by 1.                
            label3.Text = "Time : " + game.sec.ToString();                                              //label3 shows "Time : " and string-corverted game.sec (From Game.cs class).                      

            if (game.correct == 8)                                                                      //If int variable, game.correct (From Game.cs class) equals to 8, then:                
            {
                timer4.Stop();                                                                          //timer4 stops.
                MessageBox.Show("GAME OVER" + Environment.NewLine + "YOU FINISHED IN : "                //Success message appears,
                               + game.sec + " seconds" + Environment.NewLine + "AND YOU TRIED : "       //and shows game's time (game.sec),  
                               + game.tries + " TIMES");                                                //and tries (game.tries).        

                game.gameover = true;                                                                   //Bool variable game.gameover (From Game.cs class) is true. 
                FileInfo f1 = new FileInfo("top10.txt");                                                //A FileInfo variable, f1 for top10.txt file.            
                StreamWriter sw = new StreamWriter("top10.txt", true);                                  //A StreamWriter variable, sw for top10.txt file.             

                if (f1.Length == 0)                                                                     //If FileInfo variable, f1 equals to zero (top10.txt is empty), then:     
                {
                    sw.Write("NAME : " + game.name + "  TRIES : " + game.tries);                        //StreamWriter variable, sw writes to top10.txt file (First line).    
                }
                else if (f1.Length != 0)                                                                //Else if FileInfo variable, f1 does not equal to zero (top10.txt is not empty), then: 
                {
                    sw.Write(Environment.NewLine + "NAME : " + game.name + "  TRIES : " + game.tries);  //StreamWriter variable, sw writes to top10.txt file (New line).                                  
                }
                sw.Close();                                                                             //StreamWriter variable, sw closes.
            }
        }
    }
}
