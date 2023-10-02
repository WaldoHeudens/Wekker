// Initialiseer het alarmtype (gebaseerd op de delegate) met een dummy-methode
Alarmtype alarmtype = new Alarmtype(dummy);

// Initialiseer de timer:  De callback methode is LooptAf.
// Opmerking:  De timer start niet totdat een tijd is ingegeven
Timer timer = new Timer(LooptAf);
int seconden = 10;
int sluimertijd = 5;

char keuze = ' ';  // Dit is de hoofdmenu-keuze

Console.WriteLine("Welkom bij de wekker");

do
{
    Console.WriteLine("Je hebt volgende mogelijkheden:");
    Console.WriteLine("     A    Stel de manier(en) in waarop je geallarmeerd wenst te worden");
    Console.WriteLine("     S    Stel de sluimertijd in (snooze)");
    Console.WriteLine("     T    Stel de tijd in waarop het alarm moet afgaan");
    Console.WriteLine("     X    Stop de wekker");
    Console.Write("Maak je keuze: ");
    keuze = (char) Console.Read();
    Console.ReadLine();
    switch (keuze)
    {
        case 'a':
        case 'A':
            Console.WriteLine("     Je hebt volgende alarmmogelijkheden");
            Console.WriteLine("             A    Zend de tekst [Het is tijd]");
            Console.WriteLine("             B    Maak lawaai");
            Console.WriteLine("             C    Laat de lichten aan en uitgaan");
            Console.WriteLine("             D    Kieper een emmer water door de kamer");
            Console.Write("     Maak je keuze (hoofdletter om te starten, kleine letter om te stoppen: ");
            char alarm = (char) Console.Read();
            Console.ReadLine();
            Console.WriteLine();
            switch (alarm)
            {
                case 'a':
                    alarmtype -= new Alarmtype(ZendTekst);
                    break;
                case 'A':
                    alarmtype += new Alarmtype(ZendTekst);
                    break;
                case 'b':
                    alarmtype -= new Alarmtype(MaakLawaai);
                    break;
                case 'B':
                    alarmtype += new Alarmtype(MaakLawaai);
                    break;
                case 'c':
                    alarmtype -= new Alarmtype(KnipperLichten);
                    break;
                case 'C':
                    alarmtype += new Alarmtype(KnipperLichten);
                    break;
                case 'd':
                    alarmtype -= new Alarmtype(KiepDeEmmer);
                    break;
                case 'D':
                    alarmtype += new Alarmtype(KiepDeEmmer);
                    break;
            }
            break;
        case 's':
        case 'S':
            Console.Write("Om de hoeveel seconden moet de wekker opnieuw aflopen? ");
            sluimertijd = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine();
            timer.Change(seconden * 1000, sluimertijd*1000);
            break;
        case 't':
        case 'T':
            Console.Write("Binnen hoeveel seconden moet de wekker aflopen? ");
            seconden = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine();
            timer.Change(seconden * 1000, sluimertijd*1000);
            break;
        case 'x': 
        case 'X':
            break;
    }
} while (keuze != 'x' || keuze != 'X');


void LooptAf(object? state)
{
    alarmtype();
}


void ZendTekst()
{
    Console.WriteLine();
    Console.WriteLine("******************************");
    Console.WriteLine("*    !!! HET IS TIJD !!!     *");
    Console.WriteLine("******************************");
    Console.WriteLine();
}

void MaakLawaai()
{
    Console.Beep();
}

void KnipperLichten()
{
    Console.WriteLine();
    Console.WriteLine("*********************************************");
    Console.WriteLine("*    !!! DE LICHTEN GAAN AAN EN UIT !!!     *");
    Console.WriteLine("*********************************************");
    Console.WriteLine();
}

void KiepDeEmmer()
{
    Console.WriteLine();
    Console.WriteLine("<B>Dat is allicht heel nat!<b>");
    Console.WriteLine();

}

// Deze is voor de eenvoud bij het initializen van een delegate: doet niets en zal nooit verdwijnen
void dummy()
{ 
}

delegate void Alarmtype();

