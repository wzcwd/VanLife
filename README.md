# VanLife: An online platform for People living in Vancouver

## 1. Introduction

The **VanLife** is an ASP.NET Core MVC project designed for users in the Vancouver area. The platform features three core modules:
- Job – for posting and browsing job opportunities
- Housing – for rental listings and housing needs
- Pet World – for sharing pet-related content and services

VanLife enables users to create and upload posts related to these categories, offering a user-friendly interface that makes it easy to connect with the local community. 

The system integrates robust authentication features using ASP.NET Core Identity, including user registration, login/logout, and account management. It also supports social media authentication via Google and Facebook, allowing users to sign in with their existing accounts.

VanLife features a responsive user interface built with Bootstrap, ensuring optimal viewing and interaction across a wide range of screen sizes— from browsers to mobile devices.
![VanLife Screenshot1](page1.png)
***
![VanLife Screenshot2](page2.png)
***
![VanLife Screenshot3](page3.png)
***
<img src="page4.png" alt="VanLife Screenshot4" width="400"/>

## Technologies Used

The project is developed using the following technologies:
- **ASP.NET Core MVC 9.0** - Web framework for building the application.
- **Entity Framework Core (EF Core) 9.0.2** - ORM for database interactions.
- **SQLite** - Lightweight relational database.
- **Bootstrap** - Responsive UI design.
- **X.PagedList.Mvc.Core 10.5.7** - Pagination support for the views.
- **Microsoft.AspNetCore.Identity.EntityFrameworkCore 9.0.0** – Identity management.
- **Microsoft.AspNetCore.Authentication.Facebook 9.0.0** – Social network login for Facebook.
- **Microsoft.AspNetCore.Authentication.Google 9.0.0** – Social network login for Google.
- **SendGrid 9.29.3** – Email service for verification code

## 2. Getting Started

0. **Restore Dependencies:**
   Before running the application, make sure to restore all NuGet packages:
   ```sh
   dotnet restore
   ```
1. **Apply Database Migrations:**
   Run the following commands to create new database:
   ```sh
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```
2. **Run the Application:**
   Start the application using the following command: please run the app with https to enable third-party authentication
   ```sh
   dotnet run --launch-profile https
   ```

## 3. Social Media Authentication Setup

To test Google and Facebook login, add the following configuration to your `appsettings.Development.json` file:

```json
"Authentication": {
  "Google": {
      "ClientId": "<your-client-id>",
      "ClientSecret": "<your-client-secret>"
  },
  "Facebook": {
      "AppId": "<your-app-id>",
      "AppSecret": "<your-app-secret>" 
  }
}
```
Replace the placeholders with your actual id and secret


## 4. Email Service Setup

To test email sending functionality using SendGrid, add the following configuration to your `appsettings.Development.json` file:

```json
"SendGrid": {
  "ApiKey": "<your-api-key>",
  "SenderEmail": "<your-sender-email>",
  "SenderName": "VanLife"
}
```

Replace the placeholders with your actual SendGrid API key and sender information. You can obtain an API key by signing up at [https://sendgrid.com](https://sendgrid.com).