# Bingo application

## Architecture Layers

<pre>
  Domain
  {project} classlib
  {project-references}
  {packages}
  
  Persistence
  {project} classlib
  {project-references} Domain Business
  {packages} MicrosoftEntityFrameworkCore  MicrosoftEntityFrameworkCore.Design MicrosoftEntityFrameworkCore.SqlServer 
   
  Bussines
  {project} classlib
  {project-references} Domain 
  {packages} MicrosoftEntityFrameworkCore
  
  UI
  {project} WPF
  {project-references} Domain Persistence Business
  {packages}
</pre>

## Database

Run docker container <br/>
`docker compose -f .\scripts\sql-server.yml up`

Create Migration <br/>
`dotnet ef Migrations add --project .\BingoApp.Persistence\ -- "Server=localhost,8000;Database=BingoAppDb;User Id=SA;Password=Secure123"`

Update Database <br/>
`dotnet ef database update --project .\BingoApp.Persistence\ -- "Server=localhost,8000;Database=BingoAppDb;User Id=SA;Password=Secure123"`



## Application

Create your ticket or tickets. Your ticket should consist of title and three unique numbers

![Create/Ticket](resources/create_ticket.JPG)


Click on button **Create Ticket** and wait for message response in dialog box

![DialogBox](resources/create_ticket_dialog_box.JPG)



Type in your ticket **Title** to get information about your ticket

![Search-Ticket](resources/look_for_ticket.JPG)




Click on button **Run Bingo** and find out your luck

![Run-Bingo](resources/run_bingo.JPG)
