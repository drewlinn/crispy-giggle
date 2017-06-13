# _University Registrar_

#### _This program will allow the user to create students and courses and connect them to each other based on what courses are available and which ones a student is taking. _

#### By _**Kimlan Nguyen and Andrew**_

## Description

__

## Specifications

 | Behavior   |Input Example   | Output Example      | Why?|
 |----------------       |:----------:    |:------------:        |---------:|
 | User can create a student, with name, major, and date of enrollment |
 | User can create a course, with name, course number and completion |
 | User can create a department, with a name |
 | User can track all students in University |
 | User can track all course in University |
 | User can track all departments in University |
 | User can track students in course, and what courses they have passed or still need to take |
 | User can track all courses in a department |
 | User can track all students in a department |
 | Students can have more than one course |
 | Courses can have multiple students |
 | User can update a student and what courses they're in |
 | User can update a course and what students are in it |
 | User can update a department and what students and courses are in it |
 | User can delete a student record |
 | User can delete a course |
 | User can delete a department |
 | User can search for a student |
 | User can search for a course |
 | User can search for a department |




## Setup/Installation Requirements
* _This program requires installing C#, Git and asp.net5. Follow the instruction here https://www.learnhowtoprogram.com/c/getting-started-with-c/installing-c to install c# and asp.net5 on your computer._
* _Download or clone this file using Git._
* _To create a database on your computer, open Windows PowerShell. Type sqlcmd -S "(localdb)\mssqllocaldb"; CREATE DATABASE hair_salon; > GO > USE hair_salon; > GO > CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(255)); > CREATE TABLE clients (id INT IDENTITY(1,1), name VARCHAR(255), stylist_id INT); > GO
* _In Windows PowerShell navigate to the HairSalon folder._
* _Type "dnu restore" in the console to compile Nancy, exclude ""._
* _Type "dnx kestrel" in the console run the program, exclude ""._
* _Paste this link http://localhost:5004/ onto your web browser._

## Known Bugs

_Creating clients or stylists with the same name will create duplicates._

## Support and contact details

_Kimlan1510@gmail.com_

## Technologies Used

* _HTML_
* _C#_
* _Nancy_
* _Razor_
* _MSSQL_
* _Xunit_


### License

*This program is licensed under MIT License.*

Copyright (c) 2017 **_Kimlan Nguyen_**
