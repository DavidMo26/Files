using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Files
{
    public class Car
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public int Codan { get; set; }
        public int NumberOfSeats { get; set; }

        public Car()
        {
                
        }
        public Car(string path)
        {
            XmlSerializer XmlSerForCar = new XmlSerializer(typeof(Car));
            using (Stream StreamForCar = File.Open(path, FileMode.Open))
            {
              Car car = (Car)XmlSerForCar.Deserialize(StreamForCar);
                this.Model = car.Model;
                this.Brand = car.Brand;
                this.Year = car.Year;
                this.Color = car.Color;
                this.Codan = car.Codan;
                this.NumberOfSeats = car.NumberOfSeats;
            }                    
        }
        public Car(string Model,string Brand,int Year,string Color,int Codan,int NumberOfSeats)
        {
            this.Model = Model;
            this.Brand = Brand;
            this.Year = Year;
            this.Color = Color;
            this.Codan = Codan;
            this.NumberOfSeats = NumberOfSeats;
        }
        public int GetCodan()
        {
            return this.Codan;
        }
        public int GetNumberOfSeats()
        {
            return this.NumberOfSeats;
        }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
        static void SerializeACar(string Path,Car car)
        {
            XmlSerializer XmlSerForCar = new XmlSerializer(typeof(Car));
            using (Stream StreamForCar = new FileStream(Path, FileMode.Create))
                XmlSerForCar.Serialize(StreamForCar, car);
        }
        static void SerializeACarArray(string Path,Car[] cars)
        {
            XmlSerializer XmlSerForCar = new XmlSerializer(typeof(Car[]));
            using (Stream StreamForCar = new FileStream(Path, FileMode.Create))
                XmlSerForCar.Serialize(StreamForCar, cars);
        }
        static Car DeserializeACar(string Path)
        {
            XmlSerializer XmlSerForCar = new XmlSerializer(typeof(Car));
            using (Stream StreamForCar = File.Open(Path, FileMode.Open))
            {
                Car car = (Car)XmlSerForCar.Deserialize(StreamForCar);
                return car;
            }
        }
        static Car[] DeserializeCarArray(string Path)
        {
            XmlSerializer XmlSerForCar = new XmlSerializer(typeof(Car[]));
            using (Stream StreamForCar = File.Open(Path, FileMode.Open))
            {
                Car[] cars = (Car[])XmlSerForCar.Deserialize(StreamForCar);
                return cars;
            }
        }
        public bool CarCompare(string path)
        {
            Car c = Car.DeserializeACar(path);
            if(Compare(c))
                return true;
            else return false;
        }
        private bool Compare(Car c)
        {
            if(c.Model == this.Model && c.Brand == this.Brand&& c.Year == this.Year&&c.Color == this.Color&&c.Codan==this.Codan&&c.NumberOfSeats==this.NumberOfSeats)
                return true;
            else return false;
        }


    }
}
