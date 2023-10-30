 string csvFilePath = "Tickets.csv";
        var ticketManager = new TicketManager(csvFilePath);

        while (true)
        {
            Console.WriteLine("Would you like to (A)dd a new ticket, or (S)earch for existing tickets? (A/S)");
            var action = Console.ReadLine().ToUpper();

            if (action == "A")
            {
                var ticket = new Ticket();

                Console.WriteLine("Enter Ticket ID:");
                ticket.TicketId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Summary:");
                ticket.Summary = Console.ReadLine();

                Console.WriteLine("Enter Status:");
                ticket.Status = Console.ReadLine();

                Console.WriteLine("Enter Priority:");
                ticket.Priority = Console.ReadLine();

                Console.WriteLine("Enter Submitter:");
                ticket.Submitter = Console.ReadLine();

                Console.WriteLine("Enter Assigned:");
                ticket.Assigned = Console.ReadLine();

                Console.WriteLine("Enter Watching (separated by '|'):");
                ticket.Watching = Console.ReadLine();

                ticketManager.AddTicket(ticket);

                Console.WriteLine("Do you want to add another record? (yes/no)");
                string anotherRecord = Console.ReadLine().ToLower();
                if (anotherRecord != "yes")
                    break;
            }
            else if (action == "S")
            {
                Console.WriteLine("Enter search type (status/priority/submitter):");
                string type = Console.ReadLine();

                Console.WriteLine($"Enter {type} to search for:");
                string term = Console.ReadLine();

                var results = ticketManager.SearchTickets(term, type);
                int matchCount = results.Count();
                Console.WriteLine($"Found {matchCount} results:");
                foreach (var ticket in results)
                {
                    Console.WriteLine(ticket);
                }

                Console.WriteLine("End of search results.");
                break;
            }
            else
            {
                Console.WriteLine("Invalid action specified. Please choose 'A' to add or 'S' to search.");
            }
        }