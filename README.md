Project Title:
Classic Pong

Motivation:
Tasked with a project to create a game in C# and WPF and I suddenly had an idea to create a game I used to love in my younger days.



Code style
Indentation follows the Allman style


Screenshots


Tech/framework used
• C#
• WPF
• .NET Framework

Built with

Visual Studio Community Edition 2019


Code Example
The game consists of four classes.
Ball.cs
The ball class described the parameters of the ball. These are positions relative to the x and y coordinates and to which player the ball is flying. If IsBallDirectionRight is true then the ball goes to the player on the right.


ViewModel.cs
The view model class holds information about the paddles and players score and the ball they play with it implements the INOTIFYPROPERTYCHANGED interface to update the view when any object is changed.

MainWindow.xaml.cs
The main window containing the initialized components

Player.Xaml.cs
This class contains a textbox where I can pass the winner of the game to.

I decided to implement MVVM into my project rather than tradional UI development as I believe it makes the implementation of an application.

Challenges
The biggest challenge I had was implementing the collisions and setting the bounds, I tried many different methods and none seem to work. I did some research and found out I could use the vector structures to implement direction and magnitude.
I converted the value to radians and used a the vector structure the direction and speed in which the ball will move after it hits the paddles.



Installation
Simply download the zip file and extract and run the program






How to use?
Use the W key to move the left player up and the S key to move it down.
For the right player use the Up and Down keys to move the paddle





Credits
I would like to thank Markson for all his advice and help.
Also, I want to give credit to Brandon Steven for listening to all me and providing me with help.

I want to give credit Jamal on code review. His code helped a lot.

 https://codereview.stackexchange.com/questions/38451/pong-game-in-wpf


