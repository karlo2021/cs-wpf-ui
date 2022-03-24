# Web API

## Database

- Run docker container: `docker compose -f .\scripts\sql-server.yml up`
- Create Migration: `dotnet ef Migrations add --project .\BingoApp.Persistence\ -- "Server=localhost,8000;Database=BingoAppDb;User Id=SA;Password=Secure123"`
- Update Database: `dotnet ef database update --project .\BingoApp.Persistence\ -- "Server=localhost,8000;Database=BingoAppDb;User Id=SA;Password=Secure123"`

## BingoApp.UI

This is simple Bingo 3 out of 10

##**Create Ticket**

- ![Image](resources/user-interface.jpg)

Add **Ticket Title** and select three numbers. 

- ![Image](resources/create_ticket.jpg)

Click on **Create Ticket** and wait for message response in dialog box

- ![Image](resources/create_ticket_dialog_box.jpg)

##**Look for your Ticket**

Type in your ticket **Title**

- ![Image](resources/look_for_ticket.jpg)

##**Play Bingo**

Click on button **Run Bingo** and find out your luck

- ![Image](resources/run_bingo.jpg)
