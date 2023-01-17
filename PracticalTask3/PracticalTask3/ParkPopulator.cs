using PracticalTask3.CarParts;
using PracticalTask3.Vehicles;

namespace PracticalTask3
{
    /// <summary>
    /// Contains vehicles' data and hides logic of their creation to avoid clutter.
    /// </summary>
    public static class ParkPopulator
    {
        public static List<IVehicle> Populate()
        {
            List<IVehicle> park = new();
            
            void CreateVehicle(string type, string name, int hp, int vol, string eType, string ser,
                int wh, string vin, int load, int gear, string tType, string manuf)
            {
                switch (type)
                {
                    case "Passenger car":
                        {
                            park.Add(new PassengerCar()
                            {
                                Name = name,
                                Engine = new Engine() { Power = hp, Volume = vol, Type = eType, Serial = ser },
                                Chassis = new Chassis() { Wheels = wh, Vin = vin, Load = load },
                                Transmission = new Transmission() { Gears = gear, Type = tType, Manufacturer = manuf }
                            });
                            break;
                        }
                    case "Truck":
                        {
                            park.Add(new Truck()
                            {
                                Name = name,
                                Engine = new Engine() { Power = hp, Volume = vol, Type = eType, Serial = ser },
                                Chassis = new Chassis() { Wheels = wh, Vin = vin, Load = load },
                                Transmission = new Transmission() { Gears = gear, Type = tType, Manufacturer = manuf }
                            });
                            break;
                        }
                    case "Bus":
                        {
                            park.Add(new Bus()
                            {
                                Name = name,
                                Engine = new Engine() { Power = hp, Volume = vol, Type = eType, Serial = ser },
                                Chassis = new Chassis() { Wheels = wh, Vin = vin, Load = load },
                                Transmission = new Transmission() { Gears = gear, Type = tType, Manufacturer = manuf }
                            });
                            break;
                        }
                    case "Scooter":
                        {
                            park.Add(new Scooter()
                            {
                                Name = name,
                                Engine = new Engine() { Power = hp, Volume = vol, Type = eType, Serial = ser },
                                Chassis = new Chassis() { Wheels = wh, Vin = vin, Load = load },
                                Transmission = new Transmission() { Gears = gear, Type = tType, Manufacturer = manuf }
                            });
                            break;
                        }
                }
            }

            //passenger cars
            CreateVehicle("Passenger car", "Nissan Almera", 101, 1498, "petrol", "DJ51279", 
                4, "2C4GM68475R667819", 520, 5, "manual", "Nissan");
            CreateVehicle("Passenger car", "Ford Focus", 101, 1596, "petrol", "1KD6157",
                4, "KM8JU3AC6DU588418", 513, 5, "automatic", "Ford");
            CreateVehicle("Passenger car", "Audi A3", 150, 1395, "petrol", "M50B25TU", 
               4, "WVGBV75N19W507096", 660, 5, "automatic", "Audi");
            CreateVehicle("Passenger car", "Honda CR-V", 120, 1597, "diesel", "12H802065",
                4, "JH4KA4650KC031815", 501, 5, "manual", "Honda");
            CreateVehicle("Passenger car", "Aston Martin Vantage", 510, 3982, "petrol", "N52B3O01",
                4, "2G1WF52K959355243", 462, 5, "automatic", "Aston Martin");

            //trucks
           CreateVehicle("Truck", "Ford Cargo 1842", 420, 12700, "turbodiesel", "BP15GB24348",
                4, "1GCJK33104F173427", 11380, 12, "automatic", "Ford");
           CreateVehicle("Truck", "International LT", 565, 14900, "diesel", "N55B30T0",
                6, "JH4DB1660PS005158", 20865, 14, "automated manual", "Navistar");
           CreateVehicle("Truck", "Tata LPT 2516", 160, 5883, "diesel", "6081AF001",
                6, "2FMDK4KC4CBA27842", 19000, 6, "manual", "Tata Motors");
           CreateVehicle("Truck", "Nissan P-CD53S", 295, 6920, "diesel", "CD53S10040",
                6, "1G1ZT51806F128009", 7600, 6, "manual", "Nissan");
           CreateVehicle("Truck", "HOWO cargo truck", 371, 9726, "diesel", "FXT00VA37488",
                6, "JH4KA4530LC018693", 20000, 10, "manual", "Sinotruk");

            //buses
           CreateVehicle("Bus", "Mercedes-Benz Citaro", 295, 10700, "diesel", "EBLL134467",
                4, "1FTJW36F2TEA03179", 19000, 4, "automatic", "Mercedes-Benz");
           CreateVehicle("Bus", "Volvo 9700", 500, 12800, "diesel", "TU30502U623000F",
                6, "1GKEL19WXRB546238", 26500, 12, "automatic", "Volvo");
           CreateVehicle("Bus", "MAN Lion's city 12", 360, 9073, "diesel", "AH4HK1XYBW01",
                4, "JH4DC2390SS000570", 15566, 6, "automatic", "MAN");
           CreateVehicle("Bus", "Toyota-Coaster", 147, 2700, "petrol", "1GCHC29DX6E000001",
                4, "J8DE5B16477903094", 2000, 5, "manual", "Toyota");
           CreateVehicle("Bus", "Iveco Magelys Pro", 400, 8700, "diesel", "6R108OT",
                4, "3B7HF13YXWG209744", 18000, 8, "manual", "Iveco");

            //scooters
           CreateVehicle("Scooter", "Aprilia SXR-160", 15, 125, "petrol", "BXS00782",
                2, "1GKDT13W6P2533357", 140, 5, "automatic", "Aprilia");
           CreateVehicle("Scooter", "Jawa 42", 27, 294, "petrol", "2H200355",
                2, "WVGBV7AX6CW559712", 250, 6, "manual", "Jawa Moto");
           CreateVehicle("Scooter", "Honda Wave 110 R", 8, 109, "petrol", "4FDO2365",
                2, "1C6RD6KT4CS332867", 115, 4, "manual", "Honda");
           CreateVehicle("Scooter", "BMW 1250 GSA", 136, 1254, "petrol", "RF370CB11670",
                2, "1FMZK04185GA30815", 216, 6, "manual", "BMW Motorrad");
           CreateVehicle("Scooter", "KLX 300SM", 24, 292, "petrol", "3CS16694", 
                2, "4F2CU08102KM50866", 239, 6, "manual", "Kawasaki");

           return park;
        }
    }
}
