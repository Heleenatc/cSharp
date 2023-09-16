/*
 * Simple version of ATM for basic ATM operations viz., Withdrawal, Deposit and Check Balance
 * Very basic as it was done to understand basic features of cSharp and the .net framework
 * Guided project
 */

using System;
using System.Net.Http.Headers;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(String cardNum, int pin, String firstName, String lastName, double balance)
    {
        this.cardNum = cardNum; 
        this.pin = pin;            
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;

    }

    public String getCardNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getFirstName()
    {
        return firstName;
    }
    public String getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setCardNum(String newCardNum)
    {
        cardNum = newCardNum;
    }


    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;   
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.balance + deposit);
            Console.WriteLine("Thank you for your deposit. Your new balance is: " + currentUser.balance);
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to withdraw? ");
            double withdrawal = Double.Parse(Console.ReadLine());

            if(currentUser.getBalance() > withdrawal)
            { 
                
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You are good to go! Thank you :)");
            }
            else
            {
                Console.WriteLine("Insufficient Balance :(");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current Balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();

        cardHolders.Add(new cardHolder("1234567890", 1234, "John", "Mason", 5000.50));
        cardHolders.Add(new cardHolder("7639275027", 5688, "Jane", "Jones", 783076.00));
        cardHolders.Add(new cardHolder("3466454267", 4246, "Andrew", "Dickson", 67000.90));
        cardHolders.Add(new cardHolder("3684446789", 7744, "Nelson", "Mandela", 104066.78));
        cardHolders.Add(new cardHolder("9018500674", 7742, "John", "Bright", 880000.00));


        //prompt user
        Console.WriteLine("Welcome to Simple ATM");
        Console.WriteLine("Please insert your debit card: ");

        String debitCardNum = "";
        cardHolder currentUser;

        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);

                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Card not recognized. Please try again");
                }
            }
            catch 
            { 
                Console.WriteLine("Card not recognized. Please try again");
            }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.pin == userPin) 
                { 
                    break; 
                }
                else
                {
                    Console.WriteLine("Incorrect pin. Please try again.");
                }
            }
            catch
            {
                Console.WriteLine("Card not recognized. Please try again");
            }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + " :)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { 
            } 
            if(option == 1)
            {
                deposit(currentUser);
            }
            else if(option == 2)
            {
                withdraw(currentUser);
            }
            else if (option == 3)
            {
                balance(currentUser);
            }
            else if(option == 4)
            {
                break;
            }
            else
            {
                option = 0;
            }


        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day :)");
    }


}
