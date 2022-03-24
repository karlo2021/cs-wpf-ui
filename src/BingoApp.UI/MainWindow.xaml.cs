// MainWindow.xaml.cs
//
// © 2022.

using BingoApp.Business.Service.Implementation;
using BingoApp.Business.Service.Abstraction;
using BingoApp.Persistence;
using BingoApp.Persistence.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BingoApp.UI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly ITicketService _ticketService;
    private readonly INumberService _numberService;

    public MainWindow()
    {
        var dbf = new BingoAppDatabaseContextFactory();
        var db = dbf.CreateDbContext(new string[] { });
        _ticketService = new TicketService(db);
        _numberService = new NumberService(db, _ticketService);

        InitializeComponent();
    }
    private void Register(object sender, RoutedEventArgs e)
    {
        var title = this.setTitle.Text;

        var numbers = this.setNumbers.Text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        
        try
        {
            _ticketService.CreateTicker(
                new Domain.Ticket(
                    default(int),
                    title,
                    DateTime.Now));

            _numberService.CreateNumbers(numbers, title);
        }

        catch
        {
            this.setTitle.Text = "";
            this.setNumbers.Text = "";
            this.setDate.Text = "";
            this.messageBox.Text = "Failed to create ticket!";
            return;
        }

        this.setTitle.Text = "";
        this.setDate.Text = DateTime.Now.ToString("dd-MM-yy");
        this.setNumbers.Text = "";
        this.messageBox.Text = "Tikcet created!";

        this.button0.IsEnabled = true;
        this.button1.IsEnabled = true;
        this.button2.IsEnabled = true;
        this.button3.IsEnabled = true;
        this.button4.IsEnabled = true;
        this.button5.IsEnabled = true;
        this.button6.IsEnabled = true;
        this.button7.IsEnabled = true;
        this.button8.IsEnabled = true;
        this.button9.IsEnabled = true;

    }

    private void Log_in(object sender, RoutedEventArgs e)
    {
        this.getTicketNumbers.Text = "";

        var title = this.getTitle.Text;
        try
        {
            var ticket = _ticketService.GetTicketDetails(title);
            this.getTicketId.Text = ticket.Id.ToString();
            this.getTicketDate.Text = ticket.Date.ToString();
            var numbers = _numberService.GetNumbers(title);
            foreach (var number in numbers)
            {
                this.getTicketNumbers.Text += number.Value.ToString() + " ";
            }
        }
        catch
        {
            this.getTicketId.Text = "";
            this.setNumbers.Text = "";
            this.setDate.Text = "";
            this.getTicketDate.Text = "";
            this.messageBox.Text = "Name invalid, failed to get ticket!";
            return;
        }
    }
    private void GenerateBingoNumbers(object sender, RoutedEventArgs e)
    {
        this.bingoNumbers.Text = "";
        this.winningTicket.Text = "";
        var tickets = _ticketService.GetTickets();
        var bingoNum = new List<int>();
        var rand = new Random();
        for (var i = 0; i < 3; i++)
        {
            int number;
            do
            {
                number = rand.Next(0, 9);
            }
            while (bingoNum.Contains(number));

            bingoNum.Add(number);
            this.bingoNumbers.Text += bingoNum.ElementAt<int>(i).ToString() + " ";

        }

        foreach (var ticket in tickets)
        {
            var numbers = _numberService.GetNumbers(ticket.Title);
            var correct = 0;
            foreach (var number in numbers)
            {
                if (bingoNum.Contains(Convert.ToInt32(number.Value)))
                {
                    correct++;
                }

                if (correct == 3)
                {
                    this.winningTicket.Text = number.TicketId.ToString();
                }
            }
        }
    }
    #region Buttons 0-9
    private void PickNumberZero(object sender, RoutedEventArgs e)
    {
        this.setNumbers.Text += "0 ";
        this.button0.IsEnabled = false;
    }
    private void PickNumberOne(object sender, RoutedEventArgs e)
    {
        this.setNumbers.Text += "1 ";
        this.button1.IsEnabled = false;
    }
    private void PickNumberTwo(object sender, RoutedEventArgs e)
    {
        this.setNumbers.Text += "2 ";
        this.button2.IsEnabled = false;
    }
    private void PickNumberThree(object sender, RoutedEventArgs e)
    {
        this.setNumbers.Text += "3 ";
        this.button3.IsEnabled = false;
    }
    private void PickNumberFour(object sender, RoutedEventArgs e)
    {
        this.setNumbers.Text += "4 ";
        this.button4.IsEnabled = false;
    }
    private void PickNumberFive(object sender, RoutedEventArgs e)
    {
        this.setNumbers.Text += "5 ";
        this.button5.IsEnabled = false;
    }
    private void PickNumberSix(object sender, RoutedEventArgs e)
    {
        this.setNumbers.Text += "6 ";
        this.button6.IsEnabled = false;
    }
    private void PickNumberSeven(object sender, RoutedEventArgs e)
    {
        this.setNumbers.Text += "7 ";
        this.button7.IsEnabled = false;
    }
    private void PickNumberEight(object sender, RoutedEventArgs e)
    {
        this.setNumbers.Text += "8 ";
        this.button8.IsEnabled = false;
    }
    private void PickNumberNine(object sender, RoutedEventArgs e)
    {
        this.setNumbers.Text += "9 ";
        this.button9.IsEnabled = false;
    }
    #endregion
}
