
![title2](https://user-images.githubusercontent.com/77536598/124756323-3ec75680-df24-11eb-9e71-d87fb63a8e91.png)



## **Introduction**

This is a Windows form application which was created using Visual Studio 2019. The aim of the project was to create an executable solution of an online booking system, which manages the data through a RDBMS. 

The program contains two dashboards, one for the user and another for the admin. Within the admin dashboard they have access to facilities such as Coach management, user management, Bookings and admin. Each of these features allow the admin to add, update, delete, search and export data in an excel format.

The customer dashboard on the other hand allows the user to view/ update their account details, view bookings and payments, add bookings and reserve seats through an on-screen GUI.
## **Screenshots**

Below are some screenshots of the application, which gives a better perspective of  both the **Customer account** and **employee backend**.

My intention here was to go for a modern, clean and well designed theme which would be ideal for both an internal company application (employee backend) and website environment (online customer account).

### **Login page**


![userLogin](https://user-images.githubusercontent.com/77536598/124354095-298bb880-dc02-11eb-891e-f65a404d93ee.png)

### **Customer Account**


![customerAccount](https://user-images.githubusercontent.com/77536598/124354135-5d66de00-dc02-11eb-9b60-fc2a21273d32.png)
<br/>

![AddBooking](https://user-images.githubusercontent.com/77536598/124354141-6952a000-dc02-11eb-849a-dc86c2d1d69e.png)
<br/>

![seatReservation](https://user-images.githubusercontent.com/77536598/124354156-7ff8f700-dc02-11eb-8c65-d1db925245d3.png)
<br/>

### **Employee backend**


![backend](https://user-images.githubusercontent.com/77536598/124354175-9e5ef280-dc02-11eb-961f-bd17ff711350.png)


## **What I Learnt**

* This project introduced me to SQL and how to store the bookings and related data in a sql server database. I learnt how to implement queries such as inserting, updating, removing, searching for related data and more. 

* The importance of using parameterized queries to prevent the occurence of SQL injection. 

* Use of version-control software.

* Advanced object-oriented design techniques using UML and design patterns.


## **Technologies**

This project was created with:

* C#
* Visual studio
* SQL server database

## **Launch**

To download the project from github copy the following clone repo address:
```
https://github.com/Aaron03-92/CoachBookingService.git
```

Paste the copied web address into the visual studio clone repository field and click the **"Clone Repository"** button.

### **Importing the database** 
<br/>

**1.**&nbsp; To import the database, the file **“TGCS_Database.dacpac”** must be opened within visual studio.

**2.**&nbsp; Right click on the local host database. They will be presented with a list of options, one of them being **“publish data tier application”**.

**3.**&nbsp; After clicking this option, they will be presented will the following screen:
<br/><br/>

![dac_pac](https://user-images.githubusercontent.com/77536598/124317291-d74d8780-db6e-11eb-885a-9d50a01e354f.jpg)
<br/><br/>


**4.**&nbsp; Here the user must select the **“TGCS_Database.dacpac”** file.

**5.**&nbsp; Click **publish**

**6.**&nbsp; The database will now be visible within the SQL server object explore, under **"Databases"**

## **License** 



