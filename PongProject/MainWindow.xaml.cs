using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.Media;

namespace PongProject
{
    public partial class MainWindow : Window 
    {
        private ViewModel vm = new ViewModel();
        DispatcherTimer timer = new DispatcherTimer();
        Menu men = new Menu();


        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;// specifies it as a basis for the bindings

            timer.Interval = TimeSpan.FromMilliseconds(15);
            timer.Start();
            timer.Tick += GameTickCalculation;


        }
        //private void aTimer_Tick(object sender, EventArgs e) { }

        private double angle = 155;
        private double speed = 5;
        private int padSpeed = 15;

        void GameTickCalculation(object sender, EventArgs e)
        {
            if (vm.BallYPosition <= 0)
                angle = angle + (180 - 2 * angle);

            if (vm.BallYPosition >= MainCanvas.ActualHeight - 20)
                angle = angle + (180 - 2 * angle);




            if (CheckCollision())
            {
                ChangeAngle();
                vm.changeBallDirection();
                SoundPlayer sndPlayer = new SoundPlayer(PongProject.Properties.Resources.Beep1);
                sndPlayer.Play();
            }

            double radians = (Math.PI / 180) * angle;
            Vector vector = new Vector { X = Math.Sin(radians), Y = -Math.Cos(radians) };
            vm.BallXPosition += vector.X * speed;
            vm.BallYPosition += vector.Y * speed;

            if (vm.BallXPosition >= MainCanvas.ActualWidth - 1)
            {
                vm.LeftResult += 1;
                GameResetBallPosition();
                if (vm.LeftResult >= 2)
                {
                    this.Close();
                    men.Show();
                    men.text1.Text = "Left Player Wins";
                }
                SoundPlayer sndPlayer = new SoundPlayer(PongProject.Properties.Resources.Beep2);// plays a sound evertime the player hits a paddle
                sndPlayer.Play();
            }
            if (vm.BallXPosition <= -1)
            {
                vm.RightResult += 1;

                GameResetBallPosition();
                if (vm.RightResult >= 2)
                {
                    this.Close();
                    men.Show();
                    men.text1.Text = "Right player wins";
                }
                SoundPlayer sndPlayer = new SoundPlayer(PongProject.Properties.Resources.Beep2);
                sndPlayer.Play();

            }
        }

        private void GameResetBallPosition()// method  Reset the ball position to the given position
        {
            vm.BallXPosition = 380;
            vm.BallYPosition = 210;
        }

        private void ChangeAngle()//
        {
            if (vm.IsBallDirectionRight)
                angle = 270 - ((vm.BallYPosition + 10) - (vm.RightPadPosition + 40));
            else
                angle = 90 + ((vm.BallYPosition + 10) - (vm.LeftPadPosition + 40));
        }

        private bool CheckCollision()// Checks the width of the paddle to return the ball
        {
            if (vm.IsBallDirectionRight)
                return vm.BallXPosition >= 744 && (vm.BallYPosition > vm.RightPadPosition - 56 && vm.BallYPosition < vm.RightPadPosition + 80);

            return vm.BallXPosition <= 56 && (vm.BallYPosition > vm.LeftPadPosition - 56 && vm.BallYPosition < vm.LeftPadPosition + 80);
        }

        private void MainWindow_OnKeyDown(object sender, KeyboardEventArgs e)//event handler for a button pressed
        {
            if (Keyboard.IsKeyDown(Key.W)) vm.LeftPadPosition = verifyBounds(vm.LeftPadPosition, -padSpeed);
            if (Keyboard.IsKeyDown(Key.S)) vm.LeftPadPosition = verifyBounds(vm.LeftPadPosition, padSpeed);

            //if (Keyboard.IsKeyDown(Key.X)) vm.RitPadPosition = verifyBounds(vm.RitPadPosition, -padSpeed);
            //if (Keyboard.IsKeyDown(Key.Z)) vm.RitPadPosition = verifyBounds(vm.RitPadPosition, padSpeed);

            if (Keyboard.IsKeyDown(Key.Up)) vm.RightPadPosition = verifyBounds(vm.RightPadPosition, -padSpeed);
            if (Keyboard.IsKeyDown(Key.Down)) vm.RightPadPosition = verifyBounds(vm.RightPadPosition, padSpeed);
        }

        private int verifyBounds(int position, int change)// Bounds is taken into account with the paddle height
        {
            position += change;

            if (position < 0)
                position = 0;
            if (position > (int)MainCanvas.ActualHeight - 90)
                position = (int)MainCanvas.ActualHeight - 90;


            return position;
        }

       
    }
}
