# GradeHelper

GradeHelper is a Windows Forms project designed to assist students and teachers in viewing and managing the grades that students get in different courses.


## Usage

The program allows for easy and error-resistant managing of the way students are graded. You can enter the program in 3 modes: Professor mode, Assistant professor mode and Student mode. Each mode has distinct characteristics that allow for different actions.
<br/>
![Untitled1](https://user-images.githubusercontent.com/85490029/121184337-49c79200-c865-11eb-9c2a-093480c9a2aa.png)
### If you are a professor, you should select the first image or click on the text below it.
### If you are an assistant professor, select the second image or click on the text below it.
### Students as well as all those who want to look at the student table choose the third image or click on the text below it.

## For professors and assistant professors
![Untitled2](https://user-images.githubusercontent.com/85490029/121184342-4af8bf00-c865-11eb-8bb3-9d01c6bcad90.png)
<br/>
<br/>
First you need to enter a password to enter the corresponding main menu. 
###### The password for professors is 1234 and the password for assistant professors is 123.
![Untitled3](https://user-images.githubusercontent.com/85490029/121184344-4b915580-c865-11eb-903d-030e49e2dc78.png)
<br/>
Enter the student index you want to add to the student list.
<br/>
<br/>
#### Example with 4 parts
![Untitled4](https://user-images.githubusercontent.com/85490029/121184346-4b915580-c865-11eb-98d0-86544ba04e48.png)
<br/>
<br/>
#### Example with 10 parts, with a scrolling option
![Untitled5](https://user-images.githubusercontent.com/85490029/121184349-4c29ec00-c865-11eb-8bd5-a4d8a0c29f0b.png)

You choose the number of parts that make up the subject that is being graded.<br/>
For example, if the subject consists of a first part, a second part and a project task, you choose 3 parts.<br/>
Click the Generate Fields button. Once generated the fields should be filled with information.
Once they are completed you can click the Save button which will add your student to the student list.
<br/>
![Untitled6](https://user-images.githubusercontent.com/85490029/121184350-4cc28280-c865-11eb-8318-4040ba997293.png)
<br/>
<br/>
#### The view from the student menu
![Untitled7](https://user-images.githubusercontent.com/85490029/121184352-4cc28280-c865-11eb-8f5d-2a11facfad9b.png)
<br/>
<br/>
#### Deleting students
If you want to delete a student, you can only do so if you are a professor.
You need to enter the index of the student you want to delete and press the Delete Student button.
<br/>
![Untitled8](https://user-images.githubusercontent.com/85490029/121184354-4d5b1900-c865-11eb-93be-8f89e00e6e7c.png)
<br/>
<br/>
#### Editing students
If you want to edit a student you can only do so if you are a professor.
You need to enter all the information just like when adding a new student and press the Edit Student button.
<br/>
#### The view from the assistant professor menu
![Untitled9](https://user-images.githubusercontent.com/85490029/121184357-4d5b1900-c865-11eb-8a10-c350c06a4868.png)
<br/>
<br/>
## Data structures and functions

The project consists of 6 Windows Forms and 2 Classes. <br/><br/>
### Windows Forms:
* Form1.cs
* Login.cs
* MainMenuStudent.cs
* MainMenuProfessor.cs
* MainMenuAssistant.cs
* UserManual.cs
### Classes:
* Student.cs
* ExamPart.cs

The class ExamPart contains information about every part that will be contained in an exam.
It has the number of points the students got on the part, the minimum number of points for a student to pass
that specific part of the exam and the maximum number of points that can be earned on that specific part of the exam.

```
public class ExamPart
    {
        public double coefficient { get; set; }
        public double points { get; set; }
        public string name { get; set; }
        public double minimumPointsToPass { get; set; }
        public double maximum { get; set; }

        public ExamPart(double coefficient, double points, string name, double minimumPointsToPass, double maximum)
        {
            this.coefficient = coefficient;
            this.points = points;
            this.name = name;
            this.minimumPointsToPass = minimumPointsToPass;
            this.maximum = maximum;
        }

        public double value()
        {
            return coefficient * points/maximum*100;
        }
    }
```

the value() function returns the value that a part of an exam has on the overall grade.


```
private void button3_Click(object sender, EventArgs e)
        {
            int txtno;
            bool success = int.TryParse(textBox3.Text, out txtno);

            int pointX = 25;
            int pointY = 30;
            panel1.Controls.Clear();
            if (success)
                for (int i = 0; i < txtno; i++)
                {
                    Label label = new Label();
                    label.Text = (i + 1) + ".";
                    label.Location = new Point(pointX - 25, pointY + 4);
                    label.Width = 25;
                    panel1.Controls.Add(label);
                    TextBox a1 = new TextBox();
                    a1.Name = ("tb" + i * 10 + 1).ToString();
                    a1.Location = new Point(pointX, pointY);

                    TextBox a2 = new TextBox();
                    a2.Name = ("tb" + i * 10 + 2).ToString();
                    a2.Location = new Point(pointX + 150, pointY);

                    TextBox a3 = new TextBox();
                    a3.Name = ("tb" + i * 10 + 3).ToString();
                    a3.Location = new Point(pointX + 300, pointY);

                    TextBox a4 = new TextBox();
                    a4.Name = ("tb" + i * 10 + 4).ToString();
                    a4.Location = new Point(pointX + 450, pointY);

                    panel1.Controls.Add(a1);
                    panel1.Controls.Add(a2);
                    panel1.Controls.Add(a3);
                    panel1.Controls.Add(a4);
                    panel1.Show();
                    pointY += 40;
                }
        }
```
This function dynamically adds input fields for every part of the exam after the user clicks on the button Generate Fields.
The function first gets the number of text boxes for the parts that will need to be generated by the program. Each part has 4 textboxes.
I first try to parse the number of text boxes and if it is successfull, I start a loop to add a simple Label and the 4 text boxes in every iteration of the loop.
The 4 textboxes should have different locations so I change their location to the appropriate one.
I add names for every textbox so I can access them later.
At the end I add every text box to the panel where they will be displayed.
With panel1.Show() I display the panel with the dynamically added textboxes. The label for each part
serves the purpose to help the user know at what exact part he is at the moment.

### You can find the user manual to the program in the Help section.
<br/>
![Untitled10](https://user-images.githubusercontent.com/85490029/121194147-c448df80-c86e-11eb-8575-152a3677d642.png)
<br/><br/>
## Developed by: Blagoj Petkov 191097
Every part of the code is written by me.
<br/><br/>

## License
[MIT](https://choosealicense.com/licenses/mit/)