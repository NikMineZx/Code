using System;
using System.Data;
using System.Data.SQLite;

namespace Data_base
{
    public class DatabaseManager
    {
        private SQLiteConnection connection;

        public DatabaseManager(string databasePath)
        {
            connection = new SQLiteConnection("Data Source=" + databasePath + ";Version=3;");
            connection.Open();

            string createTableQuery = "CREATE TABLE IF NOT EXISTS Vacancies (" +
                                      "Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                      "Position TEXT, " +
                                      "Department TEXT, " +
                                      "Salary INTEGER, " +
                                      "CompanyType TEXT, " +
                                      "ExperienceLevel TEXT)";
            ExecuteNonQuery(createTableQuery);
        }

        public void AddVacancy(string position, string department, int salary, string companyType, string experienceLevel)
        {
            string insertQuery = "INSERT INTO Vacancies (Position, Department, Salary, CompanyType, ExperienceLevel) " +
                                 "VALUES (@Position, @Department, @Salary, @CompanyType, @ExperienceLevel)";
            using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, connection))
            {
                cmd.Parameters.AddWithValue("@Position", position);
                cmd.Parameters.AddWithValue("@Department", department);
                cmd.Parameters.AddWithValue("@Salary", salary);
                cmd.Parameters.AddWithValue("@CompanyType", companyType);
                cmd.Parameters.AddWithValue("@ExperienceLevel", experienceLevel);
                cmd.ExecuteNonQuery();
            }
        }

        private void ExecuteNonQuery(string query)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public void CloseConnection()
        {
            connection.Close();
        }

        public void InsertVacancy()
        {
            AddVacancy("Designer", "Web Design", 10000, "Agency", "Intermediate");
            AddVacancy("Programmer", "Software Development", 12000, "Startup", "Junior");
            AddVacancy("Marketer", "Market Research", 20000, "Firm", "Senior");
            AddVacancy("Administrator", "System Administration", 18000, "Corporation", "Intermediate");
            AddVacancy("Analyst", "Financial Analysis", 25000, "Bank", "Senior");
            AddVacancy("Support Specialist", "IT Support", 15000, "Company", "Junior");
            AddVacancy("Data Specialist", "Data Analysis", 22000, "Tech Company", "Intermediate");
            AddVacancy("Consultant", "Business Consulting", 18000, "Consultancy Firm", "Intermediate");
            AddVacancy("Project Manager", "Project Management", 23000, "Construction Company", "Senior");
            AddVacancy("Teacher", "Education", 18000, "School", "Junior");
            AddVacancy("Medical Assistant", "Medical Care", 16000, "Hospital", "Intermediate");
            AddVacancy("Lawyer", "Legal Services", 27000, "Law Firm", "Senior");
            AddVacancy("Chef", "Culinary Arts", 20000, "Restaurant", "Intermediate");
            AddVacancy("Writer", "Content Creation", 15000, "Media Company", "Junior");
            AddVacancy("Data Engineer", "Big Data", 24000, "Tech Startup", "Intermediate");
            AddVacancy("Architect", "Architectural Design", 28000, "Architecture Firm", "Senior");
            AddVacancy("HR Manager", "Human Resources", 22000, "Multinational Corporation", "Senior");
            AddVacancy("Chemist", "Research and Development", 20000, "Pharmaceutical Company", "Intermediate");
            AddVacancy("Electrician", "Electrical Engineering", 18000, "Construction Company", "Junior");
            AddVacancy("Illustrator", "Illustration", 16000, "Publishing House", "Junior");
            AddVacancy("Logistics Coordinator", "Supply Chain Management", 21000, "Logistics Company", "Intermediate");
            AddVacancy("Translator", "Language Services", 17000, "Translation Agency", "Intermediate");
            AddVacancy("Financial Manager", "Financial Management", 26000, "Investment Firm", "Senior");
            AddVacancy("Social Worker", "Social Services", 19000, "Non-Profit Organization", "Intermediate");
            AddVacancy("Fashion Designer", "Fashion Design", 22000, "Fashion House", "Intermediate");
            AddVacancy("Pharmacist", "Pharmacy", 25000, "Healthcare Chain", "Senior");
            AddVacancy("Civil Engineer", "Civil Engineering", 27000, "Construction Firm", "Senior");
            AddVacancy("Marketing Manager", "Marketing Strategy", 28000, "Advertising Agency", "Senior");
            AddVacancy("Engineer", "Mechanical Engineering", 15000, "Corporation", "Senior");
            AddVacancy("Software Engineer", "Software Engineering", 30000, "Tech Giant", "Senior");
            AddVacancy("Graphic Designer", "Graphic Design", 19000, "Design Studio", "Intermediate");
            AddVacancy("Sales Representative", "Sales", 21000, "Retail Company", "Junior");
            AddVacancy("Network Engineer", "Network Administration", 25000, "Telecommunications Company", "Intermediate");
            AddVacancy("Research Scientist", "Scientific Research", 28000, "Research Institute", "Senior");
            AddVacancy("Customer Service Representative", "Customer Support", 17000, "Service Industry", "Junior");
            AddVacancy("Product Manager", "Product Development", 29000, "Tech Startup", "Senior");
            AddVacancy("Event Coordinator", "Event Planning", 20000, "Event Management Company", "Intermediate");
            AddVacancy("Quality Assurance Tester", "Quality Assurance", 22000, "Software Company", "Intermediate");
            AddVacancy("Operations Manager", "Operations Management", 27000, "Manufacturing Company", "Senior");
            AddVacancy("Interior Designer", "Interior Design", 23000, "Design Firm", "Intermediate");
            AddVacancy("Biomedical Engineer", "Biomedical Engineering", 26000, "Biotech Company", "Intermediate");
            AddVacancy("Insurance Agent", "Insurance Sales", 18000, "Insurance Agency", "Junior");
            AddVacancy("Legal Assistant", "Legal Support", 19000, "Law Office", "Junior");
            AddVacancy("Customer Success Manager", "Customer Relations", 24000, "Tech Company", "Intermediate");
            AddVacancy("Public Relations Specialist", "PR Management", 21000, "PR Agency", "Intermediate");
            AddVacancy("UX/UI Designer", "User Experience Design", 27000, "Tech Startup", "Intermediate");
            AddVacancy("Healthcare Administrator", "Healthcare Management", 25000, "Hospital", "Senior");
            AddVacancy("Environmental Scientist", "Environmental Research", 28000, "Environmental Agency", "Senior");
            AddVacancy("Maintenance Technician", "Facility Maintenance", 20000, "Property Management", "Intermediate");
            AddVacancy("Bank Teller", "Banking Services", 17000, "Bank", "Junior");
            AddVacancy("Executive Assistant", "Administrative Support", 23000, "Corporate Office", "Intermediate");
            AddVacancy("Fitness Instructor", "Fitness Training", 18000, "Gym", "Junior");
            AddVacancy("Investment Analyst", "Investment Analysis", 26000, "Investment Firm", "Intermediate");
            AddVacancy("Travel Agent", "Travel Services", 19000, "Travel Agency", "Junior");
            AddVacancy("Art Director", "Creative Direction", 29000, "Advertising Agency", "Senior");
            AddVacancy("Operations Coordinator", "Operations Support", 22000, "Logistics Company", "Intermediate");
            AddVacancy("Real Estate Agent", "Real Estate Sales", 24000, "Real Estate Agency", "Junior");
            AddVacancy("Technical Writer", "Technical Documentation", 20000, "Tech Company", "Intermediate");
            AddVacancy("Veterinarian", "Veterinary Medicine", 28000, "Animal Hospital", "Senior");
        }

        public void ReadAndPrintAllVacancies()
        {
            string query = "SELECT * FROM Vacancies";
            using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string position = reader.GetString(1);
                        string department = reader.GetString(2);
                        int salary = reader.GetInt32(3);
                        string companyType = reader.GetString(4);
                        string experienceLevel = reader.GetString(5);

                        Console.WriteLine($"ID: {id}, Position: {position}, Department: {department}, Salary: {salary}, CompanyType: {companyType}, ExperienceLevel: {experienceLevel}");
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string databasePath = "program_vacancy.db"; // Имя базы данных
            DatabaseManager dbManager = new DatabaseManager(databasePath);

            dbManager.InsertVacancy();
            Console.WriteLine("All finish");
            //dbManager.ReadAndPrintAllVacancies();
            dbManager.CloseConnection();
        }
    }
}
