using System;

class BankKonto
{
    // Fasta attributer för tre typer av konton
    public string kontoinnehavare = "Ayub Mohamud";
    public decimal personkontoSaldo = 1000;
    public decimal sparkontoSaldo = 5000;
    public decimal investeringskontoSaldo = 3000;

    public string personkontoNummer = "2003";
    public string sparkontoNummer = "09";
    public string investeringskontoNummer = "20";

    // Visa saldot för ett specifikt konto
    public void VisaSaldo(string kontonummer)
    {
        if (kontonummer == personkontoNummer)
        {
            Console.WriteLine($"Saldo för personkonto: {personkontoSaldo} kr");
        }
        else if (kontonummer == sparkontoNummer)
        {
            Console.WriteLine($"Saldo för sparkonto: {sparkontoSaldo} kr");
        }
        else if (kontonummer == investeringskontoNummer)
        {
            Console.WriteLine($"Saldo för investeringskonto: {investeringskontoSaldo} kr");
        }
        else
        {
            Console.WriteLine("Felaktigt kontonummer!");
        }
    }

    // Sätt in pengar på ett specifikt konto
    public void SättInPengar(string kontonummer, decimal belopp)
    {
        if (belopp <= 0)
        {
            Console.WriteLine("Beloppet måste vara större än noll.");
            return;
        }

        if (kontonummer == personkontoNummer)
        {
            personkontoSaldo += belopp;
            Console.WriteLine($"Du har satt in {belopp} kr på personkonto.");
        }
        else if (kontonummer == sparkontoNummer)
        {
            sparkontoSaldo += belopp;
            Console.WriteLine($"Du har satt in {belopp} kr på sparkonto.");
        }
        else if (kontonummer == investeringskontoNummer)
        {
            investeringskontoSaldo += belopp;
            Console.WriteLine($"Du har satt in {belopp} kr på investeringskonto.");
        }
        else
        {
            Console.WriteLine("Felaktigt kontonummer!");
        }
    }

    // Ta ut pengar från ett specifikt konto
    public void TaUtPengar(string kontonummer, decimal belopp)
    {
        if (belopp <= 0)
        {
            Console.WriteLine("Beloppet måste vara större än noll.");
            return;
        }

        if (kontonummer == personkontoNummer)
        {
            if (personkontoSaldo >= belopp)
            {
                personkontoSaldo -= belopp;
                Console.WriteLine($"Du har tagit ut {belopp} kr från personkonto.");
            }
            else
            {
                Console.WriteLine("Otillräckligt saldo på personkonto.");
            }
        }
        else if (kontonummer == sparkontoNummer)
        {
            if (sparkontoSaldo >= belopp)
            {
                sparkontoSaldo -= belopp;
                Console.WriteLine($"Du har tagit ut {belopp} kr från sparkonto.");
            }
            else
            {
                Console.WriteLine("Otillräckligt saldo på sparkonto.");
            }
        }
        else if (kontonummer == investeringskontoNummer)
        {
            if (investeringskontoSaldo >= belopp)
            {
                investeringskontoSaldo -= belopp;
                Console.WriteLine($"Du har tagit ut {belopp} kr från investeringskonto.");
            }
            else
            {
                Console.WriteLine("Otillräckligt saldo på investeringskonto.");
            }
        }
        else
        {
            Console.WriteLine("Felaktigt kontonummer!");
        }
    }

    // Överför pengar mellan konton
    public void ÖverförPengar(string frånKontonummer, string tillKontonummer, decimal belopp)
    {
        if (belopp <= 0)
        {
            Console.WriteLine("Beloppet måste vara större än noll.");
            return;
        }

        // Kontrollera att kontonummer är korrekta
        if ((frånKontonummer == personkontoNummer || frånKontonummer == sparkontoNummer || frånKontonummer == investeringskontoNummer) &&
            (tillKontonummer == personkontoNummer || tillKontonummer == sparkontoNummer || tillKontonummer == investeringskontoNummer))
        {
            // Ta ut från källkonto
            TaUtPengar(frånKontonummer, belopp);
            // Sätt in på målkonto
            SättInPengar(tillKontonummer, belopp);
            Console.WriteLine($"Överförde {belopp} kr från konto {frånKontonummer} till konto {tillKontonummer}.");
        }
        else
        {
            Console.WriteLine("Felaktiga kontonummer för överföring.");
        }
    }
}

// Programklassen för att köra applikationen
class Program
{
    static void Main(string[] args)
    {
        BankKonto bankKonto = new BankKonto();
        bool körProgram = true;

        while (körProgram)
        {
            Console.WriteLine("\nVälkommen till bankapplikationen!");
            Console.WriteLine("1. Visa saldo");
            Console.WriteLine("2. Sätt in pengar");
            Console.WriteLine("3. Ta ut pengar");
            Console.WriteLine("4. Överför pengar");
            Console.WriteLine("5. Avsluta");

            Console.Write("Välj ett alternativ: ");
            string val = Console.ReadLine();

            switch (val)
            {
                case "1":
                    Console.Write("Ange kontonummer: ");
                    string kontonummer = Console.ReadLine();
                    bankKonto.VisaSaldo(kontonummer);
                    break;
                case "2":
                    Console.Write("Ange kontonummer: ");
                    string insättningsKonto = Console.ReadLine();
                    Console.Write("Ange belopp att sätta in: ");
                    decimal insättningsBelopp = Convert.ToDecimal(Console.ReadLine());
                    bankKonto.SättInPengar(insättningsKonto, insättningsBelopp);
                    break;
                case "3":
                    Console.Write("Ange kontonummer: ");
                    string uttagsKonto = Console.ReadLine();
                    Console.Write("Ange belopp att ta ut: ");
                    decimal uttagsBelopp = Convert.ToDecimal(Console.ReadLine());
                    bankKonto.TaUtPengar(uttagsKonto, uttagsBelopp);
                    break;
                case "4":
                    Console.Write("Ange från-kontonummer: ");
                    string frånKonto = Console.ReadLine();
                    Console.Write("Ange till-kontonummer: ");
                    string tillKonto = Console.ReadLine();
                    Console.Write("Ange belopp att överföra: ");
                    decimal överföringsBelopp = Convert.ToDecimal(Console.ReadLine());
                    bankKonto.ÖverförPengar(frånKonto, tillKonto, överföringsBelopp);
                    break;
                case "5":
                    körProgram = false;
                    Console.WriteLine("Avslutar programmet...");
                    break;
                default:
                    Console.WriteLine("Felaktigt val, försök igen.");
                    break;
            }
        }
    }
}