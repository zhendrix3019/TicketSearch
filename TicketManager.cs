public class TicketManager
{
    private string csvFilePath;

    public TicketManager(string filePath)
    {
        csvFilePath = filePath;
    }

    public void AddTicket(Ticket ticket)
    {
        using (StreamWriter sw = File.AppendText(csvFilePath))
        {
            sw.WriteLine(ticket.ToString());
        }

        Console.WriteLine("Record added successfully!");
    }
     public IEnumerable<Ticket> GetAllTickets()
    {
        var tickets = new List<Ticket>();
        using (var sr = new StreamReader(csvFilePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                tickets.Add(Ticket.FromCsv(line));
            }
        }
        return tickets;
    }

    public IEnumerable<Ticket> SearchTickets(string term, string type)
    {
        var tickets = GetAllTickets();
        return type.ToLower() switch
        {
            "status" => tickets.Where(t => t.Status.Contains(term, StringComparison.OrdinalIgnoreCase)),
            "priority" => tickets.Where(t => t.Priority.Contains(term, StringComparison.OrdinalIgnoreCase)),
            "submitter" => tickets.Where(t => t.Submitter.Contains(term, StringComparison.OrdinalIgnoreCase)),
            _ => throw new ArgumentException("Invalid search type specified.")
        };
    }
}
