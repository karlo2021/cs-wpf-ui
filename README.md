# Bingo application

## Architecture Layers

<pre>
<b>Domain<b/> 
  <b>{project}<b/> classlib
  <b>{project-references}<b/>
  <b>{packages}<b/>
  
<b>Persistence<b/>
  <b>{project}<b/> classlib
  <b>{project-references}<b/> Domain Business
  <b>{packages}<b/> MicrosoftEntityFrameworkCore  MicrosoftEntityFrameworkCore.Design MicrosoftEntityFrameworkCore.SqlServer 
   
<b>Bussines<b/>
  <b>{project}<b/> classlib
  <b>{project-references}<b/> Domain 
  <b>{packages}<b/> MicrosoftEntityFrameworkCore
  
<b>UI<b/>
  <b>{project}<b/> WPF
  <b>{project-references}<b/> Domain Persistence Business
  <b>{packages}<b/>
</pre>

## Database

Run docker container <br/>
`docker compose -f .\scripts\sql-server.yml up`

Create Migration <br/>
`dotnet ef Migrations add --project .\BingoApp.Persistence\ -- "Server=localhost,8000;Database=BingoAppDb;User Id=SA;Password=Secure123"`

Update Database <br/>
`dotnet ef database update --project .\BingoApp.Persistence\ -- "Server=localhost,8000;Database=BingoAppDb;User Id=SA;Password=Secure123"`

## Bingo 

This is simple Bingo 3 out of 10

## **Create Ticket**

Add **Ticket Title** and select three numbers. 

![Create/Ticket](resources/create_ticket.JPG)

Click on **Create Ticket** and wait for message response in dialog box

![DialogBox](resources/create_ticket_dialog_box.JPG)

## **Look for your Ticket**

Type in your ticket **Title**

![Search-Ticket](resources/look_for_ticket.JPG)

## **Play Bingo**

Click on button **Run Bingo** and find out your luck

![Run-Bingo](resources/run_bingo.JPG)
