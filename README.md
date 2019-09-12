Project Title:
Classic Pong

Motivation:
Tasked with a project to create a game in C# and WPF and I suddenly had an idea to create a game I used to love in my younger days.

Monday- I created my project with wpf and made changes to my main window. I added a canvas as a backdrop for my game and added two rectangles to represent my paddles and an ellipse object for my ball. A line object was added to the canvas to split it in two. I found out about the line object by looking online and found out it used to be in winforms however its not in the toolbox for wpf.

Tuesdsay- I implemented a view model class to contain properties about the different objects and provide data binding between the view and the model.  I added a  ​INotifyPropertyChanged​ interface so I can track changes to the objects in my window. I also binded the view control value to properties in the view model. I also created a ball class to store information to the ball and created an object in the viewmodel so I can use variables from the ball class in the view model.

Wednesday- I started to implement different methods for my project to do many things such as get the value of the canvas and prevent objects from going past it. I also implemented a ticker timer to update the ball as it moves across the screen.






Code style
Indentation follows the Allman style


Screenshots


Tech/framework used
• C#
• WPF
• .NET Framework

Built with

Visual Studio Community Edition 2019


Code Example:
The game consists of four classes.
Ball.cs
The ball class described the parameters of the ball. These are positions relative to the x and y coordinates and to which player the ball is flying. If IsBallDirectionRight is true then the ball goes to the player on the right.


ViewModel.cs
The view model class holds information about the paddles and players score and the ball they play with it implements the INOTIFYPROPERTYCHANGED interface to update the view when any object is changed. is also acts as the middle man between the view(Xaml) and the model.

MainWindow.xaml.cs
The main window containing the initialized components

Player.Xaml.cs
This class contains a textbox where I can pass the winner of the game to.

I decided to implement MVVM into my project rather than tradional UI development as I believe it makes the implementation of an application.

Challenges:
The biggest challenge I had was implementing the collisions and setting the bounds, I tried many different methods and none seem to work. I did some research and found out I could use the vector structures to implement direction and magnitude.
I converted the value to radians and used a the vector structure the direction and speed in which the ball will move after it hits the paddles.



Installation
Simply download the zip file and extract and run the program






How to use?
Use the W key to move the left player up and the S key to move it down.
For the right player use the Up and Down keys to move the paddle


Lessons Learned:





Credits
I would like to thank Markson for all his advice and help.
Also, I want to give credit to Brandon Steven for listening to all me and providing me with help.

I want to give credit Jamal on code review. His code helped a lot.

 https://codereview.stackexchange.com/questions/38451/pong-game-in-wpf


