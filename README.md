# Authentication
## Simple project which will provide Authentication with JWT Token
<p align="center">
   <a href="https://github.com/reyan-ahmed/Authentication/issues">
   <img alt="Report Issues" src="https://img.shields.io/bitbucket/issues/reyan-ahmed/Authentication?style=flat-square">
   <a href="https://github.com/reyan-ahmed/Authentication/releases">
   <img alt="release" src="https://img.shields.io/github/v/release/reyan-ahmed/Authentication?style=flat-square">
   <a href="https://github.com/reyan-ahmed/Authentication/blob/main/LICENSE">
   <img alt="license" src="https://img.shields.io/github/license/reyan-ahmed/Authentication?style=flat-square">
  <a href="#">
   <img alt="Linkedin" src="https://img.shields.io/github/repo-size/reyan-ahmed/Authentication?style=flat-square">
   
   
</p>


<br />

<p align="center">
  <a href="https://github.com/othneildrew/Best-README-Template">
    <img src="Application/wwwroot/images/si-advanced-authentication-feature.jpg" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">Authentication & Authorization with JWT Token</h3>

  <p align="center">
    This project is to support those who is new in identity & want to use **jwt** token Authentication.
    <br />
    <a href="https://github.com/reyanahmedhashmi/Authentication/blob/main/README.md"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="#">View Demo <b> coming soon</b></a>
    ·
    <a href="https://github.com/reyanahmedhashmi/Authentication/issues">Report Bug</a>
    ·
    <a href="https://github.com/reyanahmedhashmi/Authentication/issues">Request Feature</a>
  </p>
</p>

<details open="open">
  <summary>Table of Contents</summary>
  <ol>
    <li>
     <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#How-To-Build-Project">How to Build Project</a></li>
        <li><a href="#How-To-Run-Entity-Core">How to Run Entity Core</a></li>
        <li><a href="#How-To-Run-This-Project">How To Run This Project</a></li>
      </ul>
    </li>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
         <li><a href="#What-Is-Identity">What Is Identity</a></li>
        <li><a href="#User">User</a></li>
        <li><a href="#Role">Role</a></li>
        <li><a href="#Permision">Permision</a></li>
        <li><a href="#Seed-Default-Data">Seed Default Data</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgements">Acknowledgements</a></li>
  </ol>
</details>
  
## Getting Started
First, Clone this project or fork. And make sure you have dotnet core install. This project is created 3.1.  Please make sure you update the connection string in appsettings. 


## How to Build Project
First, Clone this project or fork. Please run the below mentioned commands to build it properly.

1. Clean
```sh
  dotnet clean
  ```

2. Restore dependencies
```sh
  dotnet restore
  ```

3. Build Project  
```sh
  dotnet build
  ```


## How to Run Entity Core
Second,  Add migration first then we will create database. As we are using separate project for Identity (DBContext file) . Then we need to explicitly mentioned where is our DBContext file (-c ) and what is our starting application (-s ). I want to keep migration file inside my Data/Migration folder that's why I mentioned (-o Data/Migraions). Please run below mentioned commands.

1. Add Migration
```sh
dotnet ef migrations add Initial -p Identity -s Application -c ApplicationDbContext -o Data/Migraions
```

2. Create database
```sh
dotnet ef database update -p Identity -s Application -c ApplicationDbContext 
```


## How To Run This Project
We are successfully build and create a database. Now, we can run this project. Please run following command.

1. Run project with watch. Any changes no need to re-build the project

```sh
dotnet watch run 
```
OR

2. Simply Run 

```sh
dotnet run
```


## About The Project
I am currently working on it. This will help to seperate the identity framework and handle user and role separately. I also added JWT token, So later if we want to change MVC application to Web API then just add identity class library and run some commands and we good to go.

## What is identity
ASP.NET Core Identity framework in brief. ASP.NET Core Identity framework is used to implement forms authentication. There are many options to choose from for identifying your users including Windows Authentication and all of the third-party identity providers like Google, Microsoft, Facebook, and GitHub etc

## User
We have Identity User table where all user data will be store. But we created Application user to extend the default identity user property. Like First Name & Last Name there can be add different properties depend on the requirements.  I Added only two property to give an example.

## Role
We are using here Identity Role default one. As I don't find anything which we need to modify in the defaulty Identity Role. Name and Id is enought to use role. All roles will be store inside Identity Role table.

## Permision
I have created Admin role which have the permision to add update and delete role and as well as the users. There is another role called default which I will use for the normal user.

## Seed Default Data
I am seeding some data by default so when you will run this application. Super admin and admin role will be automatically inserted into the database.

## Coming Soon 
I am working on few things, which is a part of my roadmap for this project.
1. Create Online demo for this project.
2. I want to make it as a Shell so mostly 90% need login and role mininum so just use it as a shell and start create your application using it.
3. User Profile
4. Edit of the Role and User
5. Edit and assign new role to existing user
6. Many More :)
 

## Usage
No need to create authentication from scratch, This project help you to start not from zero. It already have authentication with JWT token. You may use the MVC main application or create your own WEB API. But using identity class library, It may help you alot and this start-up and program file from main application. It have small small things which will save alot of time. Like seeding data, JWT, Role and user managment.


<!-- ROADMAP -->
## Roadmap

See the [open issues](https://github.com/reyanahmedhashmi/Authentication/issues) for a list of proposed features (and known issues).



<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request




