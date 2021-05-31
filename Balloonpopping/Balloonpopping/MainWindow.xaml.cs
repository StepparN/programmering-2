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

        List<Rectangle> itemRemover = new List<Rectangle>();

        ImageBrush backgroundImage = new ImageBrush();
        //Här sätts olika datatyper in som kommer att användas senare i koden
        int balloonSkins;
        int i;

        int missedBalloons;

        bool gameIsActive;

        int score;

        MediaPlayer player = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();

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

            intervals -= 10;

            if (intervals < 1)
            {
                ImageBrush balloonImage = new ImageBrush();

                balloonSkins += 1;

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
                //Denna kod avgör hur ballongerna ska se ut
                Rectangle newBalloon = new Rectangle
                {
                    //Här bestäms höjden och bredden på ballongerna
                    Tag = "balloon",
                    Height = 70,
                    Width = 50,
                    Fill = balloonImage
                };
                //Det här är vart ballongerna visas på skärmen
                Canvas.SetLeft(newBalloon, rand.Next(50, 400));
                Canvas.SetTop(newBalloon, 600);

                MyCanvas.Children.Add(newBalloon);

                intervals = rand.Next(90, 150);
            }
     
            foreach (var x in MyCanvas.Children.OfType<Rectangle>())
            {
                if ((string)x.Tag == "balloon")
                {
                    i = rand.Next(-5, 5);

                    Canvas.SetTop(x, Canvas.GetTop(x) - speed);
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - (i * -1));
                }
                //Om ballongerna kommer tillräckligt högt upp försvinner dem och man får en missad ballong
                if (Canvas.GetTop(x) < 20)
                {
                    itemRemover.Add(x);

                    missedBalloons += 1;
                }

            }

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
                if (e.OriginalSource is Rectangle)
                {
                    Rectangle activeRec = (Rectangle)e.OriginalSource;
                    //Det här är ljudfilen som spelas när man förstör en ballong
                    player.Open(new Uri("../../files/pop-sound.mp3", UriKind.RelativeOrAbsolute));
                    player.Play();
                    //Här får man ett poäng om man poppar en ballong
                    MyCanvas.Children.Remove(activeRec);

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
            foreach (var x in MyCanvas.Children.OfType<Rectangle>())
            {
                itemRemover.Add(x);
            }

            foreach (Rectangle y in itemRemover)
            {
                MyCanvas.Children.Remove(y);
            }
            //Tar bort allt från skärmen och startar om spelet
            itemRemover.Clear();

            StartGame();

        }

    }
}
