using System;
using System.Linq;
using System.Collections.Generic;

namespace Baitap_04_03
{
    public class Vehicle
    {
        public string Id { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public string Place { get; set; }
        public int Year { get; set; }
    }

    public class Car : Vehicle
    {
        public int NumberOfSeats { get; set; }
        public string Color { get; set; }
        public string Gear { get; set; }
    }

    public class Truck : Vehicle
    {
        public string Fuel { get; set; }
        public float Weight { get; set; }
        public string Company { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Car> Cars = new List<Car>
            {
                new Car {Id = "C001", Brand = "Toyota", Price = 178000, Place = "Nhat Ban", Year = 2019, NumberOfSeats = 5, Color = "Red", Gear = "Manual"},
                new Car {Id = "C002", Brand = "Audi", Price = 500000, Place = "Duc", Year = 2012, NumberOfSeats = 4, Color = "White", Gear = "AutoMatic"},
                new Car {Id = "C003", Brand = "Ford", Price = 440000, Place = "My", Year = 2015, NumberOfSeats = 5, Color = "Red", Gear = "AutoMatic"},
                new Car {Id = "C004", Brand = "Mercedes Benz", Price = 1638000, Place = "Duc", Year = 2021, NumberOfSeats = 4, Color = "Black", Gear = "AutoMatic"},
                new Car {Id = "C005", Brand = "Mitsubishi", Price = 130000, Place = "My", Year = 2024, NumberOfSeats = 7, Color = "Red", Gear = "AutoMatic"},
                new Car {Id = "C006", Brand = "Huyndai", Price = 195000, Place = "Han Quoc", Year = 2004, NumberOfSeats = 5, Color = "Black", Gear = "AutoMatic"},
                new Car {Id = "C007", Brand = "Ford", Price = 325000, Place = "My", Year = 2010, NumberOfSeats = 7, Color = "Gray", Gear = "AutoMatic"},
                new Car {Id = "C008", Brand = "Audi", Price = 475000, Place = "Duc", Year = 2013, NumberOfSeats = 5, Color = "Blue", Gear = "AutoMatic"},
                new Car {Id = "C009", Brand = "Mitsubishi", Price = 285000, Place = "My", Year = 2016, NumberOfSeats = 5, Color = "Gray", Gear = "AutoMatic"},
                new Car {Id = "C010", Brand = "Huyndai", Price = 180000, Place = "Han Quoc", Year = 2015, NumberOfSeats = 5, Color = "Brown", Gear = "Manual"}
            };

            List<Truck> Trucks = new List<Truck> 
            { 
                new Truck {Id = "T001", Brand = "Huyndai", Price = 350000, Place = "Han Quoc", Year = 2015, Fuel = "Dau", Weight = 13000, Company ="Huyndai Thanh Cong VN"},
                new Truck {Id = "T002", Brand = "Kamaz", Price = 750000, Place = "Lien Bang Nga", Year = 2016, Fuel = "Dau", Weight = 15000, Company ="Kamaz Viet Nam"},
                new Truck {Id = "T003", Brand = "Tera", Price = 600000, Place = "Han Quoc", Year = 2023, Fuel = "Dau", Weight = 2000, Company ="Daehan Motors"},
                new Truck {Id = "T004", Brand = "Suzuki", Price = 240000, Place = "Nhat Ban", Year = 2018, Fuel = "Xang", Weight = 580, Company ="Suzuki Viet Nam"},
                new Truck {Id = "T005", Brand = "Hino", Price = 530000, Place = "Nhat Ban", Year = 2021, Fuel = "Dau", Weight = 5000, Company ="Hino Motors"}


            };

            //tạo danh sách lựa chọn
            Console.WriteLine("Vui long lua chon:");
            Console.WriteLine("\n1.Hien thi cac Car co gia trong khoang 100.000 đen 250.000;");
            Console.WriteLine("2.Hien thi cac Car co nam san xuat > 1990;");
            Console.WriteLine("3.Gom cac Car theo hang san xuat, tinh tong gia tri theo nhom;");
            Console.WriteLine("4.Hien thi danh sach Truck theo thu tu nam san xuat moi nhat;");
            Console.WriteLine("5.Hien thi ten cong ty chu quan cua Truck;");
            Console.WriteLine("6.Dung lai.\n");
            while (true)
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {

                    case 1:
                        var priceCars = from car in Cars
                                        where car.Price >= 100000 && car.Price <= 250000
                                        select car;
                        Console.WriteLine("\n1.Hien thi cac Car co gia trong khoang 100.000 đen 250.000:\n");
                        foreach (var car in priceCars)
                        {
                            Console.WriteLine($"Id: {car.Id}, Brand: {car.Brand}, Price: { car.Price}, Place: {car.Place}, Year: {car.Year}, Number Of Seats: {car.NumberOfSeats}, Color: {car.Color}, Gear: {car.Gear}");
                        }
                        break;

                    case 2:
                        var yearCars = from car in Cars
                                       where car.Year > 1990
                                       select car;
                        Console.WriteLine("\n2.Hien thi cac Car co nam san xuat > 1990:\n");
                        foreach (var car in yearCars)
                        {
                            Console.WriteLine($"Id: {car.Id}, Brand: {car.Brand}, Price: { car.Price}, Place: {car.Place}, Year: {car.Year}, Number Of Seats: {car.NumberOfSeats}, Color: {car.Color}, Gear: {car.Gear}");
                        }
                        break;

                    case 3:
                        var groupbyBrand = from car in Cars
                                           group car by car.Brand into brandGroup
                                           select new
                                           {
                                               Brand = brandGroup.Key,
                                               toTalPrice = brandGroup.Sum(car => car.Price)
                                           };
                        Console.WriteLine("\n3.Gom cac Car theo hang san xuat, tinh tong gia tri theo nhom:\n");
                        foreach (var group in groupbyBrand)
                        {
                            Console.WriteLine($"Brand: {group.Brand}, Total Price: {group.toTalPrice}");
                        }
                        break;

                    case 4:
                        var sortedTruck = Trucks.OrderByDescending(truck => truck.Year);
                        Console.WriteLine("\n4.Hien thi danh sach Truck theo thu tu nam san xuat moi nhat:\n");
                        foreach (var truck in sortedTruck)
                        {
                            Console.WriteLine($"Id: {truck.Id}, Brand: {truck.Brand}, Price: { truck.Price}, Place: {truck.Place}, Year: {truck.Year}, Fuel: {truck.Fuel}, Weight: {truck.Weight}, Company: {truck.Company}");
                        }
                        break;

                    case 5:
                        Console.WriteLine("\n5.Hien thi ten cong ty chu quan cua Truck:\n");
                        foreach (var truck in Trucks)
                        {
                            Console.WriteLine($"Company: {truck.Company}");
                        }
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Lua chon sai. Chon laiii !");
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
