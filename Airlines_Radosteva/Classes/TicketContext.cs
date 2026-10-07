using Airlines_Radosteva.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines_Radosteva.Classes
{
    public class TicketContext : Ticket
    {
        public TicketContext(int price, string from, string to, DateTime startTime, DateTime endTime) : base(price, from, to, startTime, endTime) { }
        public static List<TicketContext> AllTickets() {
            List<TicketContext> allTickets = new List<TicketContext>();

            MySqlConnection connection = WorkingDB.Connection.OpenConnection();
            MySqlDataReader ticketQuary = WorkingDB.Connection.Query("SELECT * FROM `Tickets` WHERE 1", connection);
            while (ticketQuary.Read()) {
                allTickets.Add(new TicketContext(
                    ticketQuary.GetInt32(3),
                    ticketQuary.GetString(1),
                    ticketQuary.GetString(2),
                    ticketQuary.GetDateTime(4),
                    ticketQuary.GetDateTime(5)
                ));
            }
            WorkingDB.Connection.CloseConnection(connection);

            return allTickets;
        }
    }
}
