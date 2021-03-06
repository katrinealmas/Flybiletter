﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Model
{

    public static class GenerateDepartures
    {
        /* Lager liste med Departure objekter. Alle felt fylt ut, med unntak av pris.
         * 
         */
        public static List<Departure> CreateDepartures(string from, string to, string date)
        {
            List<Departure> departures = new List<Departure>();
            Random random = new Random();
            int randomNumber = random.Next(8);

            var times = GenerateTimes(randomNumber);

            foreach (string i in times)
            {
                departures.Add(new Departure
                {
                    FlightId = GenerateFlightId(),
                    From = from,
                    To = to,
                    Date = date,
                    DepartureTime = i
                });
            }

            return departures;
        }

        /* Lager string array med sorterte tider, HashSet sørger for at det ikke blir duplikate verdier av tid.
         * 
         */
        public static string[] GenerateTimes(int departures)
        {
            string[] time = new string[departures];
            Random random = new Random();

            for (int i = 0; i < departures; i++)
            {
                TimeSpan start = new TimeSpan(random.Next(4, 23), random.Next(0, 59), 0);
                time[i] = start.ToString();
            }

            var noDuplicates = new HashSet<string>(time).ToArray();
            time = noDuplicates;
            Array.Sort(time);

            return time;
        }

        /* Genererer random id'er, dersom id allerede eksisterer i departure tabellene brukes rekursjon
         * for å opprette en ny. Ikke så effektivt når databasen nærmer seg 6^6 avganger, men gjør jobben.
         * 
         */
        public static string GenerateFlightId()
        {
            Random random = new Random();

            StringBuilder builder = new StringBuilder();
            builder.Append("SK");
            for (int i = 0; i < 6; i++)
            {
                builder.Append(random.Next(0, 9));
            }
            var flightId = builder.ToString();

            return flightId;
        }

        public static int[] GeneratePrice(int antall)
        {
            int[] price = new int[antall];

            Random random = new Random();

            for (int i = 0; i < antall; i++)
            {
                price[i] = random.Next(99, 5555);
            }

            return price;
        }


    }
}