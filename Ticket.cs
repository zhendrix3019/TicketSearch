public class Ticket
{
    public int TicketId { get; set; }
    public string Summary { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public string Submitter { get; set; }
    public string Assigned { get; set; }
    public string Watching { get; set; }

    public override string ToString()
    {
        return $"ID: {TicketId}, Summary: {Summary}, Status: {Status}, Priority: {Priority}, Submitter: {Submitter}, Assigned: {Assigned}, Watching: {Watching}";
    }

    public static Ticket FromCsv(string csvLine)
    {
        string[] values = csvLine.Split(',');
        return new Ticket
        {
            TicketId = int.Parse(values[0]),
            Summary = values[1],
            Status = values[2],
            Priority = values[3],
            Submitter = values[4],
            Assigned = values[5],
            Watching = values[6]
        };
    }
}