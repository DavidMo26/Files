using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace Files 
{
    internal class Program
    {
        static void Main(string[] args)
        {  
            //********Serialization for car******//
            Car car = new Car("Corola","Toyota",2020,"White",1122,4);
            XmlSerializer XmlSerForCar = new XmlSerializer(typeof(Car));
            using (Stream StreamForCar = new FileStream(@"C:\Files\Car\car.txt", FileMode.Create))
            XmlSerForCar.Serialize(StreamForCar, car);
            

            //*************Serialization for car array******//
            Car[] cars = new Car[3];
            cars[0] = new Car { Model = "Corola", Brand = "Toyota",Year=2015,Color="Green",Codan=1458,NumberOfSeats=4 };
            cars[1] = new Car { Model = "Swift", Brand = "Suzuki", Year = 2016, Color = "Blue", Codan = 4586, NumberOfSeats = 4 };
            cars[2] = new Car { Model = "Picanto", Brand = "Kia", Year = 2018, Color = "Black", Codan = 8534, NumberOfSeats = 4 };

            //*******Print Car and Car array****///
            XmlSerializer XmlSerForArr = new XmlSerializer(typeof(Car[]));
            using(Stream StreamForArr = new FileStream(@"C:\Files\Car\carsArray.txt",FileMode.Create))
                XmlSerForArr.Serialize(StreamForArr, cars);
            Console.WriteLine("Car : \n"+car);
            Console.WriteLine("\nCars array : " );
            for (int i = 0; i < cars.Length; i++)           
                Console.WriteLine(cars[i]);

            string path = Path.GetFullPath(@"C:\Files\Car\car.txt");
            Car c5 = new Car(path);
            Console.WriteLine("Constractor : ");
            Console.WriteLine(c5);




















            //using (Stream myFileDes = new FileStream(@"C:\Files\Car\car.txt", FileMode.Open))
            //{
            //    Car newBook = (Car)xmlSerializer.Deserialize(myFileDes);
            //}

            //Car c1 = new Car("Mazda", "3", 2021, "Blue", 1000, 4);
            //Car c2 = new Car("Suzuki", "Swift", 2017, "Green", 1822, 4);
            //Car c3 = new Car("Kia", "Picanto", 2019, "Black", 5622, 4);
            //Car[] cars = {c1,c2, c3};
            //XmlSerializer xmlSer = new XmlSerializer(typeof(Car[]));
            //using (Stream myFileWithUsing1 = new FileStream(@"C:\Files\Car\CarsArray.xml", FileMode.Create))
            //{
            //    xmlSer.Serialize(myFileWithUsing1, cars);
            //}
            //using (Stream myFileDes = new FileStream(@"C:\Files\Car\CarsArray.xml", FileMode.Open))
            //{
            //    Car[] newBook = (Car[])xmlSer.Deserialize(myFileDes);
            //}




        }
    }
}