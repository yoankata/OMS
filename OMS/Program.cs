// See https://aka.ms/new-console-template for more information
using OMS;
using OMS.Models;
using OMS.Utils;
using System.Linq;

const string defaultInputFolder = @"..\..\..\..\input";
const string promptMessage = 
    $"The input folder is assumed to be '{defaultInputFolder}', " +
    $"to change the default press ESC or press ENTER to continue!";

Console.WriteLine(promptMessage);
var pressedKey = Console.ReadKey();

while(pressedKey.Key != ConsoleKey.Enter && pressedKey.Key != ConsoleKey.Escape)
{
    Console.WriteLine(promptMessage);
    Console.ReadKey();
}

if(pressedKey.Key == ConsoleKey.Escape)
{
    // read input and create output files
    ProcessTransactions(defaultInputFolder);
}

if (pressedKey.Key == ConsoleKey.Enter)
{
    Console.Write("Please enter input folder: ");
    var newInputFolder = Console.ReadLine();
    if (Directory.Exists(newInputFolder))
        ProcessTransactions(newInputFolder);
    else
        throw new FileNotFoundException($"No such folder: {newInputFolder}!");
}

void ProcessTransactions(string inputFolder)
{
    if(!Directory.Exists(inputFolder))
        throw new DirectoryNotFoundException($"Folder '{inputFolder}' not found!");

    if (!File.Exists(Path.Combine(inputFolder, "transactions.csv")))
        throw new FileNotFoundException($"File 'transactions.csv' not found!");

    var transactions = Enumerable.Empty<Transaction>();
    var securities = Enumerable.Empty<Security>();
    var portfolios = Enumerable.Empty<Portfolio>();
    
    Console.WriteLine("Processing input files!");

    try
    {
        transactions = CSVFileProcessor.ReadCSV<Transaction>(inputFolder + @"\transactions.csv");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error proessing transactions file: {ex.Message}");
    }   
    
    try
    {
        securities = CSVFileProcessor.ReadCSV<Security>(inputFolder + @"\securities.csv");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error proessing securities file: {ex.Message}");
    }   
    
    try
    {
        portfolios = CSVFileProcessor.ReadCSV<Portfolio>(inputFolder + @"\portfolios.csv");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error proessing portfolios file: {ex.Message}");
    }

    Console.WriteLine("Input files successfully read!");
    var allTransactions =
        from tran in transactions
        join port in portfolios on tran.PortfolioId equals port.Id
        join sec in securities on tran.SecurityId equals sec.Id
        select new
        {
            ISIN = sec.ISIN,
            Cusip = sec.Cusip,
            Ticker= sec.Ticker,
            PortfolioCode = port.Code,
            Nominal = tran.Nominal,
            TransactionType = tran.TransactionType,
        };

    var aaaTransactions = from trans in allTransactions
        select new AAATransaction
        {
            ISIN = trans.ISIN,
            PortfolioCode = trans.PortfolioCode,
            Nominal = trans.Nominal,
            TransactionType = trans.TransactionType,
        };
    
    var bbbTransactions = from trans in allTransactions
        select new BBBTransaction
        {
            Cusip = trans.Cusip,
            PortfolioCode = trans.PortfolioCode,
            Nominal = trans.Nominal,
            TransactionType = trans.TransactionType,
        };

    var cccTransactions = from trans in allTransactions
        select new CCCTransaction
        {
            PortfolioCode = trans.PortfolioCode,
            Ticker = trans.Ticker,
            Nominal = trans.Nominal,
            TransactionType = (TransactionTypeConcise)((int)trans.TransactionType)
        };
    Console.WriteLine("Processing file AAA!");
    OMSFileCreator.CreateCSV<AAATransaction>(aaaTransactions);
    Console.WriteLine("Successfull created file AAA!");

    Console.WriteLine("Processing file BBB!");
    OMSFileCreator.CreateCSV<BBBTransaction>(bbbTransactions);
    Console.WriteLine("Successfull created file BBB!");

    Console.WriteLine("Processing file CCC!");
    OMSFileCreator.CreateCSV<CCCTransaction>(cccTransactions);
    Console.WriteLine("Successfull created file CCC!");

    Console.ReadKey();
}
