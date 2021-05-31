using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Threading;

namespace Balloonpopping
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer gameTimer = new DispatcherTimer();
        //Här sätts värdena för hastigheten och intervallerna för ballongerna
        int speed = 3;
        int intervals = 90;
        Random rand = new Random();
        
        //Ballonger som kommer till toppen läggs till i den här listan så att man kan ta bort dem
        List<Rectangle> itemRemover = new List<Rectangle>();

        //Så att man kan importera och använda bakgrundsbilden
        ImageBrush backgroundImage = new ImageBrush();
        //Så att ballongerna får olika skins
        int balloonSkins;
        //Används för att kunna få ballongerna att röra sig fram och tillbaka
        int i;

        int missedBalloons;

        bool gameIsActive;

        int score;

        MediaPlayer player = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();
            //Gameengine håller koll på alla ballonger
            gameTimer.Tick += GameEngine;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            //I en bitmapimage lägger man in bakgrunden till spelet
            backgroundImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/files/background-Image.jpg"));
            MyCanvas.Background = backgroundImage;

            RestartGame();

        }

        private void GameEngine(object sender, EventArgs e)
        {
            //Det här skriver ut ens score
            scoreText.Content = "Score: " + score;
            //Hur snabbt spelet lägger till ballonger 
            intervals -= 10;

            if (intervals < 1)
            {
                ImageBrush balloonImage = new ImageBrush();

                balloonSkins += 1;
                //Om ballongernas nummer är mellan 1-5 läggs en specifik bild på ballongen med en färg
                if (balloonSkins > 5)
                {
                    balloonSkins = 1;
                }
                //Switch-casen lägger till de 5 ballongernas olika färger
                switch (balloonSkins)
                {
                    case 1:
                        balloonImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/files/balloon1.png"));
                        break;
                    case 2:
                        balloonImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/files/balloon2.png"));
                        break;
                    case 3:
                        balloonImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/files/balloon3.png"));
                        break;
                    case 4:
                        balloonImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/files/balloon4.png"));
                        break;
                    case 5:
                        balloonImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/files/balloon5.png"));
                        break;
                }
                //Denna kod säger att rectangle är ballongerna och bestämmer hur dem ska se ut
                Rectangle newBalloon = new Rectangle
                {
                    //Här bestäms höjden och bredden på ballongerna
                    Tag = "balloon",
                    Height = 70,
                    Width = 50,
                    Fill = balloonImage
                };
                //Det här är vart ballongerna visas på skärmen, de kan spawna mellan 50-400 på ett random ställe
                Canvas.SetLeft(newBalloon, rand.Next(50, 400));
                //När ballongerna når 600 på höjden försvinner dem
                Canvas.SetTop(newBalloon, 600);

                MyCanvas.Children.Add(newBalloon);

                intervals = rand.Next(90, 150);
            }
            //Den här loopen letar efter rectangle med tagen balloon
            foreach (var x in MyCanvas.Children.OfType<Rectangle>())
            {
                if ((string)x.Tag == "balloon")
                {
                    //Det här gör att ballongerna med balloon tagen kan röra upp och till vänster och höger
                    i = rand.Next(-5, 5);
                    Canvas.SetTop(x, Canvas.GetTop(x) - speed);
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - (i * -1));
                }
                //Om ballongerna kommer tillräckligt högt upp försvinner dem och man får en missad ballong
                if (Canvas.GetTop(x) < 20)
                {
                    //Ballongerna läggs till i itemremover
                    itemRemover.Add(x);

                    missedBalloons += 1;
                }

            }
            //Det här kodblocket letar efter rectangle i itemremover och tar bort den om den hittar någon
            foreach(Rectangle y in itemRemover)
            {
                MyCanvas.Children.Remove(y);
            }
            //Det här kodblocket gör att om man missar mer än 10 ballonger så förlorar man och kan starta igen
            if (missedBalloons > 10)
            {
                //Om spelet inte är aktivt stoppas det och game over kommer up
                gameIsActive = false;
                gameTimer.Stop();
                //Om man klickar ok startas spelet om
                MessageBox.Show("Game over" + Environment.NewLine + "Click ok to play again");

                RestartGame();
            }
            //Denna if-sats gör att ballongerna efter 10 i score blir snabbare vilket gör spelet svårare
            if (score > 10)
            {
                speed = 7;
            }


        }
        //Det här gör att när man trycker på musen och poppar en ballong så spelas ett ljud samt att man får ett poäng
        private void PopBalloons(object sender, MouseButtonEventArgs e)
        {
            if (gameIsActive)
            {
                //Om man klickar på en ballong körs koden nedanför
                if (e.OriginalSource is Rectangle)
                {
                    Rectangle activeRec = (Rectangle)e.OriginalSource;
                    //Det här är ljudfilen som öppnas och spelas när man förstör en ballong
                    player.Open(new Uri("../../files/pop_sound.mp3", UriKind.RelativeOrAbsolute));
                    player.Play();
                    
                    MyCanvas.Children.Remove(activeRec);
                    //Här får man ett poäng om man poppar en ballong
                    score += 1;
                }
            }


        }
        //Kodblocket nedan startar spelet och sätter alla poäng, intervallen mellan ballongerna, och hastigheten till dess startvärden
        private void StartGame()
        {
            gameTimer.Start();
            
            missedBalloons = 0;
            score = 0;
            intervals = 90;
            //Om spelet är aktivt är ballongernas hastighet 3
            gameIsActive = true;
            speed = 3;

        }
        //Den här koden startar helt enkelt om spelet och tar bort allt som finns på canvasen
        private void RestartGame()
        {
            //Om det finns några ballonger/rektanglar på canvasen läggs dem till itemremover
            foreach (var x in MyCanvas.Children.OfType<Rectangle>())
            {
                itemRemover.Add(x);
            }
            //Alla rektanglar som finns i itemremover listan tas bort
            foreach (Rectangle y in itemRemover)
            {
                MyCanvas.Children.Remove(y);
            }
            //Tar bort allt från skärmen och startar om spelet
            itemRemover.Clear();
            //Spelet startas om
            StartGame();

        }

    }
}
