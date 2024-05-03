namespace DepositCalculator
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("DEPOSIT-INTEREST CALCULATOR\n");

            Body body = new Body();
            do
            {
                //take informations from user
                body.takeInformation();

                //calculation deposit
                body.calculateNewDeposit();

                //output
                body.printToUser();
            }
            while (body.tryAgain());

            Console.Write("\n\nPress any key to close");
            Console.ReadKey();
        }
    }
    public class Body
    {
        public double deposit, interest, interestDay, grossIncome, netIncome, netDeposit, withholdingTax;
        public void takeInformation()
        {
            double test;

            while (true)
            {
                try
                {
                    Console.Write("Deposit: ");
                    deposit = Convert.ToDouble(Console.ReadLine());
                    test = deposit / 0.666;
                    Console.WriteLine();
                    break;
                }
                catch
                {
                    Console.Write("\nInvalid input! ");
                }
            }
            while (true)
            {
                try
                {
                    Console.Write("Interest: ");
                    interest = Convert.ToDouble(Console.ReadLine());
                    test = interest / 0.666;
                    Console.WriteLine();
                    break;
                }
                catch
                {
                    Console.Write("\nInvalid input! ");
                }
            }
            while (true)
            {
                try
                {
                    Console.Write("Interest time(day): ");
                    interestDay = Convert.ToDouble(Console.ReadLine());
                    test = interestDay / 0.666;
                    Console.WriteLine();
                    break;
                }
                catch
                {
                    Console.Write("\nInvalid input! ");
                }
            }
            while (true)
            {
                try
                {
                    Console.Write("Withholding Tax: ");
                    withholdingTax = Convert.ToDouble(Console.ReadLine());
                    test = withholdingTax / 0.666;
                    Console.WriteLine();
                    break;
                }
                catch
                {
                    Console.Write("\nInvalid input! ");
                }
            }
        }
        public void calculateNewDeposit()
        {
            grossIncome = deposit * (interest / 100) * (interestDay / 366);
            netIncome = grossIncome - (grossIncome * withholdingTax / 100);
            netDeposit = deposit + netIncome;
        }
        public void printToUser()
        {
            Console.Clear();
            string grossIncomeText = grossIncome.ToString();
            string netIncomeText = netIncome.ToString();
            string netDepositText = netDeposit.ToString();

            Console.WriteLine($"Gross income: {grossIncomeText.Substring(0, grossIncomeText.IndexOf(',') + 3)}");
            Console.WriteLine($"Net income: {netIncomeText.Substring(0, netIncomeText.IndexOf(',') + 3)}");
            Console.WriteLine($"\nNet new deposit: {netDepositText.Substring(0, netDepositText.IndexOf(',') + 3)}");
        }
        public bool tryAgain()
        {
            Console.WriteLine("\n\n");
            string input;

            while (true)
            {
                try
                {
                    Console.Write("Try again(yes[y] no[n]) ");
                    input = Console.ReadLine()!;
                    input = input.ToLower();

                    if (input.Length > 1 || (input[0] != 'y' && input[0] != 'n'))
                    {
                        Console.Write("\nInvalid input! ");
                        continue;
                    }
                    if (input[0] == 'y')
                    {
                        Console.Clear();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    Console.Write("\nInvalid input! ");
                }
            }
        }
    }
}
