using System;

namespace PRIMO_COMPITO_BACK__END
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("******** Calcolatore Imposta! ********");
                Console.WriteLine("Nome:");
                string name = Console.ReadLine();

                Console.WriteLine("Cognome:");
                string surname = Console.ReadLine();

                Console.WriteLine("Data di nascita:");
                int dataNascita;
                while (!int.TryParse(Console.ReadLine(), out dataNascita))
                {
                    Console.WriteLine("Inserisci una data di nascita valida (numero intero):");
                }

                Console.WriteLine("Codice Fiscale:");
                string codiceFiscale = Console.ReadLine();

                Console.WriteLine("Inserisci il genere (M/F):");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                string sesso = keyInfo.KeyChar.ToString();
                Console.WriteLine(); 

                Console.WriteLine("Comune di Residenza:");
                string comuneResidenza = Console.ReadLine();

                Console.WriteLine("Reddito Annuale:");
                int redditoAnnuale;
                while (!int.TryParse(Console.ReadLine(), out redditoAnnuale))
                {
                    Console.WriteLine("Inserisci un reddito annuale valido (numero intero):");
                }

                Contribuente myContribuente = new Contribuente(name, surname, dataNascita, codiceFiscale, sesso, comuneResidenza, redditoAnnuale);

                Console.Clear();
                Console.WriteLine("========================");
                Console.WriteLine("Dettagli inseriti:");
                Console.WriteLine($"Contribuente: {myContribuente.Name} {myContribuente.Surname}");
                
                Console.WriteLine($"Nato il: {myContribuente.DataNascita} ({myContribuente.Sesso})");
                Console.WriteLine($"Codice Fiscale: {myContribuente.CodiceFiscale}");
               
                Console.WriteLine($"Residente in: {myContribuente.ComuneResidenza}");
                Console.WriteLine($"Reddito dichiarato: {myContribuente.RedditoAnnuale}");
                Console.WriteLine("v       v");
                Console.WriteLine($"IMPOSTA DA VERSARE: {myContribuente.CalcolaImposta()}");
                Console.WriteLine("========================");

                Console.WriteLine("Per uscire, premere 'e'. Altrimenti, premere un tasto qualsiasi.");
                ConsoleKeyInfo exitKey = Console.ReadKey();
                if (exitKey.KeyChar == 'e' || exitKey.KeyChar == 'E')
                {
                    break; 
                }

                Console.Clear();


            }
        }
    }

    class Contribuente
    {
        private string _name;
        private string _surname;
        private int _dataNascita;
        private string _codiceFiscale;
        private string _sesso;
        private string _comuneResidenza;
        private int _redditoAnnuale;

        public string Name
        {
            get { return _name; }
            set
            {
                try
                {
                    while (!IsValidName(value))
                    {
                        Console.WriteLine("Errore: Il nome deve essere una stringa e non può superare i 15 caratteri.");
                        Console.Write("Inserisci nuovamente il nome: ");
                        value = Console.ReadLine();
                    }

                    _name = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore durante l'impostazione del nome: {ex.Message}");
                }
            }
        }

        private bool IsValidName(string value)
        {
            return !value.Any(char.IsDigit) && value.Length <= 15;
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                try
                {
                    while (!IsValidSurname(value))
                    {
                        Console.WriteLine("Errore: Il cognome deve essere una stringa e non può superare i 15 caratteri.");
                        Console.Write("Inserisci nuovamente il cognome: ");
                        value = Console.ReadLine();
                    }

                    _surname = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore durante l'impostazione del cognome: {ex.Message}");
                }
            }
        }

        private bool IsValidSurname(string value)
        {
            return !value.Any(char.IsDigit) && value.Length <= 15;
        }
        public int DataNascita
        {
            get { return _dataNascita; }
            set
            {
                do
                {
                    string inputValue = value.ToString();

                  
                    if (int.TryParse(inputValue, out int parsedValue) && inputValue.Length == 8)
                    {
                        _dataNascita = parsedValue;
                        break; 
                    }
                    else
                    {
                        Console.WriteLine("la data deve essere un numero di 8 cifre. Inserisci nuovamente:");
                        inputValue = Console.ReadLine();
                        if (int.TryParse(inputValue, out int newParsedValue) && inputValue.Length == 8)
                        {
                            value = newParsedValue;
                        }
                    }
                } while (true);
            }
        }




        public string CodiceFiscale
        {
            get { return _codiceFiscale; }
            set
            {
                do
                {
                   
                    if (value.Length == 16)
                    {
                        _codiceFiscale = value;
                        break; 
                    }
                    else
                    {
                        Console.WriteLine("Il codice fiscale deve essere esattamente di 16 caratteri.");
                        Console.WriteLine("Inserisci nuovamente il codice fiscale:");
                        value = Console.ReadLine();
                    }
                } while (true);
            }
        }

        public string Sesso
        {
            get { return _sesso; }
            set
            {
                try
                {
                    while (!IsValidSesso(value))
                    {
                        Console.WriteLine("Errore: Il sesso deve essere 'm' o 'f'.");
                        Console.Write("Inserisci nuovamente il sesso: ");
                        value = Console.ReadLine();
                    }

                    _sesso = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore durante l'impostazione del sesso: {ex.Message}");
                }
            }
        }

        private bool IsValidSesso(string value)
        {
            return value.ToLower() == "m" || value.ToLower() == "f";
        }


        public string ComuneResidenza
        {
            get { return _comuneResidenza; }
            set
            {
                try
                {
                    while (!IsValidComuneResidenza(value))
                    {
                        Console.WriteLine("Errore: Il comune di residenza deve essere lungo almeno 3 caratteri.");
                        Console.Write("Inserisci nuovamente il comune di residenza: ");
                        value = Console.ReadLine();
                    }

                    _comuneResidenza = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore durante l'impostazione del comune di residenza: {ex.Message}");
                }
            }
        }

        private bool IsValidComuneResidenza(string value)
        {
            return value.Length >= 3;
        }

        public int RedditoAnnuale
        {
            get { return _redditoAnnuale; }
            set
            {
                try
                {
                    while (!IsValidRedditoAnnuale(value))
                    {
                        Console.WriteLine("Errore: Il reddito annuale deve contenere almeno 4 cifre numeriche.");
                        Console.Write("Inserisci nuovamente il reddito annuale: ");

                        // You may want to handle the case when the user enters a non-numeric value.
                        int.TryParse(Console.ReadLine(), out value);
                    }

                    _redditoAnnuale = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore durante l'impostazione del reddito annuale: {ex.Message}");
                }
            }
        }

        private bool IsValidRedditoAnnuale(int value)
        {
           
            return Math.Abs(value).ToString().Length >= 4;
        }





        public Contribuente(string name, string surname, int dataNascita, string codiceFiscale, string sesso, string comuneResidenza, int redditoAnnuale)
        {
            Name = name;
            Surname = surname;
            DataNascita = dataNascita;
            CodiceFiscale = codiceFiscale;
            Sesso = sesso;
            ComuneResidenza = comuneResidenza;
            RedditoAnnuale = redditoAnnuale;
        }
        public decimal CalcolaImposta()
        {
            decimal reddito = RedditoAnnuale;
            decimal imposta = 0;

            if (reddito <= 15000)
            {
                imposta = reddito * 0.23m;
            }
            else if (reddito <= 28000)
            {
                imposta = 3450 + (reddito - 15000) * 0.27m;
            }
            else if (reddito <= 55000)
            {
                imposta = 6960 + (reddito - 28000) * 0.38m;
            }
            else if (reddito <= 75000)
            {
                imposta = 17220 + (reddito - 55000) * 0.41m;
            }
            else
            {
                imposta = 25420 + (reddito - 75000) * 0.43m;
            }

            return imposta;
        }
    }

}

