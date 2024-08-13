using Insure.X.Resource.Database.Entities.Client;
using Insure.X.Resource.Database.Entities.Investment;
using Insure.X.Resource.Database.Entities.Lookups;

namespace Insure.X.Resource.Database.Data;

public class InsureXDatabase
{
    private readonly static List<ClientEntity> _clients = new()
    {
        new ClientEntity { Id = 1, Firstname = "John", Surname = "Doe", IdNumber = "8001015009087" },
        new ClientEntity { Id = 2, Firstname = "Jane", Surname = "Smith", IdNumber = "8605030169086" },
        new ClientEntity { Id = 3, Firstname = "Michael", Surname = "Johnson", IdNumber = "9002125029080" },
        new ClientEntity { Id = 4, Firstname = "Emily", Surname = "Williams", IdNumber = "9507040085082" },
        new ClientEntity { Id = 5, Firstname = "David", Surname = "Brown", IdNumber = "8801155085085" },
        new ClientEntity { Id = 6, Firstname = "Sarah", Surname = "Jones", IdNumber = "9208170159083" },
        new ClientEntity { Id = 7, Firstname = "Matthew", Surname = "Miller", IdNumber = "9309275085089" },
        new ClientEntity { Id = 8, Firstname = "Laura", Surname = "Davis", IdNumber = "9903160025081" },
        new ClientEntity { Id = 9, Firstname = "James", Surname = "Garcia", IdNumber = "8508235078084" },
        new ClientEntity { Id = 10, Firstname = "Olivia", Surname = "Martinez", IdNumber = "9106015097088" },
        new ClientEntity { Id = 11, Firstname = "Daniel", Surname = "Rodriguez", IdNumber = "9708095061086" },
        new ClientEntity { Id = 12, Firstname = "Sophia", Surname = "Martinez", IdNumber = "9404040084080" },
        new ClientEntity { Id = 13, Firstname = "Liam", Surname = "Lopez", IdNumber = "8505155027087" },
        new ClientEntity { Id = 14, Firstname = "Chloe", Surname = "Gonzalez", IdNumber = "8902230165082" },
        new ClientEntity { Id = 15, Firstname = "Noah", Surname = "Hernandez", IdNumber = "9809110153086" },
        new ClientEntity { Id = 16, Firstname = "Mia", Surname = "King", IdNumber = "8304135036080" },
        new ClientEntity { Id = 17, Firstname = "Alexander", Surname = "Clark", IdNumber = "9107255001081" },
        new ClientEntity { Id = 18, Firstname = "Grace", Surname = "Lewis", IdNumber = "9205100025086" },
        new ClientEntity { Id = 19, Firstname = "Benjamin", Surname = "Walker", IdNumber = "9901105006088" },
        new ClientEntity { Id = 20, Firstname = "Ava", Surname = "Hall", IdNumber = "9703140012083" }
    };

    private readonly static List<InvestmentEntity> _investments = new()
    {
        new()
        {
            Id = 1,
            ClientId = 1,
            LumpSum = 5000m,
            StartDate = new DateTime(2023, 6, 1),
            AnnualInterestRate = 5.5m,
            InterestTypeId = 1
        },
        new()
        {
            Id = 2,
            ClientId = 2,
            LumpSum = 15000m,
            StartDate = new DateTime(2020, 1, 15),
            AnnualInterestRate = 3.8m,
            InterestTypeId = 2
        },
        new()
        {
            Id = 3,
            ClientId = 3,
            LumpSum = 100000m,
            StartDate = new DateTime(2018, 11, 30),
            AnnualInterestRate = 7.2m,
            InterestTypeId = 3
        },
        new()
        {
            Id = 4,
            ClientId = 5,
            LumpSum = 2500m,
            StartDate = new DateTime(2022, 7, 20),
            AnnualInterestRate = 4.0m,
            InterestTypeId = 1
        },
        new()
        {
            Id = 5,
            ClientId = 7,
            LumpSum = 75000m,
            StartDate = new DateTime(2019, 3, 10),
            AnnualInterestRate = 6.0m,
            InterestTypeId = 3
        },
        new()
        {
            Id = 6,
            ClientId = 8,
            LumpSum = 4500m,
            StartDate = new DateTime(2023, 1, 5),
            AnnualInterestRate = 4.5m,
            InterestTypeId = 2
        },
        new()
        {
            Id = 7,
            ClientId = 10,
            LumpSum = 20000m,
            StartDate = new DateTime(2021, 8, 15),
            AnnualInterestRate = 5.0m,
            InterestTypeId = 1
        },
        new()
        {
            Id = 8,
            ClientId = 10,
            LumpSum = 35000m,
            StartDate = new DateTime(2020, 12, 25),
            AnnualInterestRate = 6.2m,
            InterestTypeId = 3
        },
        new()
        {
            Id = 9,
            ClientId = 15,
            LumpSum = 10000m,
            StartDate = new DateTime(2022, 11, 1),
            AnnualInterestRate = 3.9m,
            InterestTypeId = 1
        },
        new()
        {
            Id = 10,
            ClientId = 18,
            LumpSum = 120000m,
            StartDate = new DateTime(2017, 4, 10),
            AnnualInterestRate = 7.5m,
            InterestTypeId = 2
        },
        new()
        {
            Id = 11,
            ClientId = 4,
            LumpSum = 8000m,
            StartDate = new DateTime(2021, 3, 20),
            AnnualInterestRate = 4.3m,
            InterestTypeId = 1
        },
        new()
        {
            Id = 12,
            ClientId = 6,
            LumpSum = 60000m,
            StartDate = new DateTime(2019, 11, 5),
            AnnualInterestRate = 5.6m,
            InterestTypeId = 3
        },
        new()
        {
            Id = 13,
            ClientId = 9,
            LumpSum = 3000m,
            StartDate = new DateTime(2022, 4, 18),
            AnnualInterestRate = 3.5m,
            InterestTypeId = 1
        },
        new()
        {
            Id = 14,
            ClientId = 11,
            LumpSum = 90000m,
            StartDate = new DateTime(2016, 2, 25),
            AnnualInterestRate = 6.8m,
            InterestTypeId = 2
        },
        new()
        {
            Id = 15,
            ClientId = 12,
            LumpSum = 50000m,
            StartDate = new DateTime(2020, 10, 14),
            AnnualInterestRate = 5.2m,
            InterestTypeId = 3
        },
        new()
        {
            Id = 16,
            ClientId = 13,
            LumpSum = 11000m,
            StartDate = new DateTime(2021, 6, 30),
            AnnualInterestRate = 4.7m,
            InterestTypeId = 1
        },
        new()
        {
            Id = 17,
            ClientId = 14,
            LumpSum = 23000m,
            StartDate = new DateTime(2019, 9, 12),
            AnnualInterestRate = 5.9m,
            InterestTypeId = 2
        },
        new()
        {
            Id = 18,
            ClientId = 16,
            LumpSum = 70000m,
            StartDate = new DateTime(2018, 8, 7),
            AnnualInterestRate = 6.4m,
            InterestTypeId = 3
        },
        new()
        {
            Id = 19,
            ClientId = 17,
            LumpSum = 8500m,
            StartDate = new DateTime(2024, 8, 13),
            AnnualInterestRate = 4.1m,
            InterestTypeId = 1
        },
        new()
        {
            Id = 20,
            ClientId = 19,
            LumpSum = 95000m,
            StartDate = new DateTime(2017, 7, 21),
            AnnualInterestRate = 7.1m,
            InterestTypeId = 2
        },
        new()
        {
            Id = 21,
            ClientId = 20,
            LumpSum = 6700m,
            StartDate = new DateTime(2023, 3, 11),
            AnnualInterestRate = 4.8m,
            InterestTypeId = 1
        },
        new()
        {
            Id = 22,
            ClientId = 2,
            LumpSum = 24000m,
            StartDate = new DateTime(2020, 9, 5),
            AnnualInterestRate = 5.0m,
            InterestTypeId = 3
        },
        new()
        {
            Id = 23,
            ClientId = 5,
            LumpSum = 32000m,
            StartDate = new DateTime(2021, 7, 28),
            AnnualInterestRate = 5.4m,
            InterestTypeId = 2
        },
        new()
        {
            Id = 24,
            ClientId = 8,
            LumpSum = 12000m,
            StartDate = new DateTime(2019, 11, 12),
            AnnualInterestRate = 4.6m,
            InterestTypeId = 1
        },
        new()
        {
            Id = 25,
            ClientId = 10,
            LumpSum = 80000m,
            StartDate = new DateTime(2016, 12, 1),
            AnnualInterestRate = 6.7m,
            InterestTypeId = 3
        },
        new()
        {
            Id = 26,
            ClientId = 12,
            LumpSum = 15000m,
            StartDate = new DateTime(2022, 6, 17),
            AnnualInterestRate = 4.9m,
            InterestTypeId = 1
        },
        new()
        {
            Id = 27,
            ClientId = 14,
            LumpSum = 53000m,
            StartDate = new DateTime(2018, 5, 24),
            AnnualInterestRate = 5.8m,
            InterestTypeId = 2
        },
        new()
        {
            Id = 28,
            ClientId = 15,
            LumpSum = 6600m,
            StartDate = new DateTime(2023, 4, 6),
            AnnualInterestRate = 4.2m,
            InterestTypeId = 1
        },
        new()
        {
            Id = 29,
            ClientId = 18,
            LumpSum = 92000m,
            StartDate = new DateTime(2017, 1, 13),
            AnnualInterestRate = 7.4m,
            InterestTypeId = 3
        },
        new()
        {
            Id = 30,
            ClientId = 19,
            LumpSum = 42000m,
            StartDate = new DateTime(2020, 8, 9),
            AnnualInterestRate = 5.3m,
            InterestTypeId = 2
        },
        new()
        {
            Id = 31,
            ClientId = 4,
            LumpSum = 15000m,
            StartDate = new DateTime(2022, 10, 11),
            AnnualInterestRate = 4.4m,
            InterestTypeId = 1
        },
        new()
        {
            Id = 32,
            ClientId = 7,
            LumpSum = 76000m,
            StartDate = new DateTime(2019, 3, 28),
            AnnualInterestRate = 6.1m,
            InterestTypeId = 3
        },
        new()
        {
            Id = 33,
            ClientId = 9,
            LumpSum = 4700m,
            StartDate = new DateTime(2023, 2, 3),
            AnnualInterestRate = 4.3m,
            InterestTypeId = 1
        },
        new()
        {
            Id = 34,
            ClientId = 11,
            LumpSum = 88000m,
            StartDate = new DateTime(2017, 12, 18),
            AnnualInterestRate = 6.5m,
            InterestTypeId = 2
        },
        new()
        {
            Id = 35,
            ClientId = 13,
            LumpSum = 54000m,
            StartDate = new DateTime(2018, 11, 4),
            AnnualInterestRate = 5.7m,
            InterestTypeId = 3
        },
        new()
        {
            Id = 36,
            ClientId = 16,
            LumpSum = 113000m,
            StartDate = new DateTime(2016, 3, 19),
            AnnualInterestRate = 7.0m,
            InterestTypeId = 3
        },
        new()
        {
            Id = 37,
            ClientId = 17,
            LumpSum = 9700m,
            StartDate = new DateTime(2021, 5, 27),
            AnnualInterestRate = 4.6m,
            InterestTypeId = 1
        },
        new()
        {
            Id = 38,
            ClientId = 20,
            LumpSum = 67000m,
            StartDate = new DateTime(2019, 7, 22),
            AnnualInterestRate = 5.6m,
            InterestTypeId = 2
        },
        new()
        {
            Id = 39,
            ClientId = 1,
            LumpSum = 55000m,
            StartDate = new DateTime(2020, 10, 30),
            AnnualInterestRate = 6.2m,
            InterestTypeId = 3
        },
        new()
        {
            Id = 40,
            ClientId = 3,
            LumpSum = 7600m,
            StartDate = new DateTime(2023, 5, 15),
            AnnualInterestRate = 4.7m,
            InterestTypeId = 1
        },
        new()
        {
            Id = 41,
            ClientId = 6,
            LumpSum = 25000m,
            StartDate = new DateTime(2018, 4, 17),
            AnnualInterestRate = 5.5m,
            InterestTypeId = 2
        },
        new()
        {
            Id = 42,
            ClientId = 8,
            LumpSum = 67000m,
            StartDate = new DateTime(2017, 11, 8),
            AnnualInterestRate = 6.1m,
            InterestTypeId = 3
        },
        new()
        {
            Id = 43,
            ClientId = 10,
            LumpSum = 33000m,
            StartDate = new DateTime(2019, 9, 6),
            AnnualInterestRate = 5.4m,
            InterestTypeId = 1
        },
        new()
        {
            Id = 44,
            ClientId = 12,
            LumpSum = 9500m,
            StartDate = new DateTime(2023, 6, 2),
            AnnualInterestRate = 4.2m,
            InterestTypeId = 1
        },
        new()
        {
            Id = 45,
            ClientId = 14,
            LumpSum = 49000m,
            StartDate = new DateTime(2021, 12, 3),
            AnnualInterestRate = 5.8m,
            InterestTypeId = 2
        },
        new()
        {
            Id = 46,
            ClientId = 16,
            LumpSum = 87000m,
            StartDate = new DateTime(2020, 1, 20),
            AnnualInterestRate = 6.4m,
            InterestTypeId = 3
        },
        new()
        {
            Id = 47,
            ClientId = 19,
            LumpSum = 7000m,
            StartDate = new DateTime(2023, 3, 8),
            AnnualInterestRate = 4.5m,
            InterestTypeId = 1
        },
        new()
        {
            Id = 48,
            ClientId = 4,
            LumpSum = 49000m,
            StartDate = new DateTime(2018, 9, 10),
            AnnualInterestRate = 5.9m,
            InterestTypeId = 3
        },
        new()
        {
            Id = 49,
            ClientId = 7,
            LumpSum = 81000m,
            StartDate = new DateTime(2019, 5, 29),
            AnnualInterestRate = 6.0m,
            InterestTypeId = 2
        },
        new()
        {
            Id = 50,
            ClientId = 11,
            LumpSum = 34000m,
            StartDate = new DateTime(2016, 8, 18),
            AnnualInterestRate = 6.3m,
            InterestTypeId = 3
        }
    };

    private readonly static List<InterestTypeEntity> _interestType = new()
    {
        new()
        {
            Id = 1,
            Description = "Simple"
        },
        new()
        {
            Id = 2,
            Description = "Compounded Monthly"
        },
        new()
        {
            Id = 3,
            Description = "Compounded Annually"
        }
    };

    public IQueryable<ClientEntity> Clients => _clients.AsQueryable();

    public IQueryable<InvestmentEntity> Investments => _investments.AsQueryable();

    public IQueryable<InterestTypeEntity> InterestTypes => _interestType.AsQueryable();
}
