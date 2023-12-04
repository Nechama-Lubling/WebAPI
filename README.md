# Online Car Store Application

Welcome to our online car store application—a powerful and flexible solution that can easily adapt to various product stores based on the data provided. This application is written in API-c# using the .NET 7 framework, featuring a RESTful architecture for enhanced performance and scalability.

## Table of Contents

- [Key Features](#key-features)
- [Dependencies](#dependencies)
- [Installation](#installation)
- [Running the Program](#running-the-program)

## Key Features

- **Dependency Injection and Layered Architecture:** Our application is designed with a layered approach, facilitating communication between layers through Dependency Injection. This not only adheres to the DRY principle but also promotes encapsulation and simplifies testing.

- **Asynchronous Programming:** Leveraging asynchronous programming techniques, we ensure improved performance for a responsive user experience.

- **Database Management:** Utilizing SQL Database and EntityFrameworkCore in the DatabaseFirst method, we've streamlined data handling for efficiency.

- **DTO Layer and Object Mapping:** Employing a dedicated DTO layer helps in encapsulation, eliminating circular dependencies and flattening objects. Object mapping is seamlessly handled through the AutoMapper library.

- **Configurability:** We understand the importance of flexibility. Our application allows easy modification of crucial information through configuration files.

- **Logging and Error Handling:** Nlog is employed for comprehensive logging, with the added feature of email notifications in case of errors.
  
- **Middlewares:**  for Rating and error handling .

- **Password Strength:** Security is a top priority. We've implemented the zxcvbn-core library to enforce robust password policies.
  
- **Swagger Documentation:** To enhance transparency and usability, the application is thoroughly documented using Swagger.
  
- **Protection** - the application runs on https protocol.
  
- **Validations:** to check the integrity of the data.

- **Client-Side Implementation:** The client-side is developed with JavaScript, HTML, and CSS, providing a visually appealing and user-friendly interface.

## Dependencies

- Visual Studio 2022+ verssion .NET 7
- SQL Server
- Packages:
  - Microsoft.EntityFrameworkCore (tools, sqlserver)
  - AutoMapper.Extensions.Microsoft.DependencyInjection
  - NLog.MailKit
  - NLog.Web.AspNetCore
  - Swashbuckle.AspNetCore
  - Swashbuckle.AspNetCore.Swagger
  - zxcvbn-core

## Installing

1. download the program to your pc
```
Git clone https://github.com/Nechama-Lubling/WebAPI
```


2.create your database on your pc using code first
```
Add-migration MyDataBase
Update-Database

```
3.Insert data into database: from API/wwwroot/dataQuery.txt file.
```
insert...

```
4.change the Connection String in appsetings.json

## Run program
Run the program on your local machine and open it in your browser for an immersive online shopping experience.

## Help
For any question you can write to me:
nechamalubling@gmail.com

## Authors
Nechama Lubling
Rut Bresloyer
   
