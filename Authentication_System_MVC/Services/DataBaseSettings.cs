namespace Authentication_System_MVC.Services
{
    public class DataBaseSettings
    {
        public string ConnectionUrl { get; set; } = "mongodb+srv://dan_ostap:Frost310@cluster0.1ecvuza.mongodb.net/?retryWrites=true&w=majority ";
        public string DataBaseMane { get; set; } = "LogIn_Service";
        public string Collection { get; set; } = "Users";

    }
}
