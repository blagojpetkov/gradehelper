# GradeHelper

GradeHelper is a Windows Forms project designed to assist students and teachers in viewing and managing the grades that students get in different courses.


## Usage

The program allows for easy and error-resistant managing of the way students are graded. You can enter the program in 3 modes: Professor mode, Assistant professor mode and Student mode. Each mode has distinct characteristics that allow for different actions.
<br/><br/>
![2](https://user-images.githubusercontent.com/85490029/121540898-23415c80-ca07-11eb-97ef-a7826a5ac9bc.png)
<br/>
![3](https://user-images.githubusercontent.com/85490029/121540900-23d9f300-ca07-11eb-8df0-fc8be6e70aef.png)
<br/>
At first you should create a subject or open subjects that you have already created. The program supports serialization.
<br/>
You choose the number of parts that make up the subject that is being graded.<br/>
For example, if the subject consists of a first part, a second part and a project task, you choose 3 parts.
<br/>
Click the Generate Fields button. Once generated the fields should be filled with information.
Once they are completed you can click the Save button which will add your subject to the subjects list.
<br/>

![1](https://user-images.githubusercontent.com/85490029/121540892-22a8c600-ca07-11eb-985b-f8bfd8df2117.png)
### If you are a professor, you should select the first image or click on the text below it.
### If you are an assistant professor, select the second image or click on the text below it.
### Students as well as all those who want to look at the student table choose the third image or click on the text below it.

## For professors and assistant professors
![4](https://user-images.githubusercontent.com/85490029/121540903-23d9f300-ca07-11eb-945d-5db0d05da22a.png)
<br/>
<br/>
First you need to enter a password to enter the corresponding main menu. Once entered the user is saved until he logs out by pressing the Log out button.
###### The password for professors is 1234 and the password for assistant professors is 123.
![5](https://user-images.githubusercontent.com/85490029/121540905-24728980-ca07-11eb-9ecf-32ffa4bf5fba.png)
<br/>
Enter the student index you want to add to the student list. Enter the subject and enter the grades that the students earned on the subject and press the Save button.
<br/>
<br/>
#### The view from the student menu
![6](https://user-images.githubusercontent.com/85490029/121540907-24728980-ca07-11eb-8f28-a4ab0a54ad19.png)
![7](https://user-images.githubusercontent.com/85490029/121540909-250b2000-ca07-11eb-9977-93ba0d5a791b.png)
<br/>
<br/>
#### Deleting students
If you want to delete a student, you can only do so if you are a professor.
You need to enter the index of the student you want to delete and press the Delete Student button.
<br/>
<br/>
#### Editing students
If you want to edit a student you can only do so if you are a professor.
You need to enter all the information just like when adding a new student and press the Save button.
<br/>
![8](https://user-images.githubusercontent.com/85490029/121540914-250b2000-ca07-11eb-81c3-8a4844ccaadf.png)
<br/>
You can Edit a subject by pressing the Edit Subject button
<br/>
## Data structures and functions

The project consists of 9 Windows Forms and 5 Classes. <br/><br/>
### Windows Forms:
* Form1.cs
* Login.cs
* MainMenuStudent.cs
* MainMenuProfessor.cs
* MainMenuAssistant.cs
* NewSubject.cs
* ChangeSubject.cs
* ChooseSubject.cs
* UserManual.cs
### Classes:
* Program.cs
* Student.cs
* Subject.cs
* User.cs
* ExamPart.cs


```
public class Subject
    {
        public int numParts { get; set; }
        public string name { get; set; }
        public List<ExamPart> parts { get; set; }
        public List<Student> students { get; set; }
        public Subject()
        {
            parts = new List<ExamPart>();
            students = new List<Student>();
        }
        
    }
```

The class Subject contains information about every part that will be contained in a subject.
It has a name, the number of parts it contains, a list of the parts it contains and a list of the students that attend that subject.


```
private void button3_Click(object sender, EventArgs e)
        {
            int txtno;
            bool success = int.TryParse(textBox3.Text, out txtno);

            int pointX = 25;
            int pointY = 10;
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
![9](https://user-images.githubusercontent.com/85490029/121540918-25a3b680-ca07-11eb-98a5-f4cdf5e5360f.png)
![10](https://user-images.githubusercontent.com/85490029/121540922-25a3b680-ca07-11eb-89e1-a7eadb3cb8b7.png)
## Developed by: Blagoj Petkov 191097
Every part of the code is written by me.
<br/><br/>

## License
[MIT](https://choosealicense.com/licenses/mit/)