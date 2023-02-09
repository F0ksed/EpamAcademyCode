using OopTask.Vehicles;
using OopTask.CarParts;

namespace OopTask
{
    /// <summary>
    /// Contains vehicles' data
    /// </summary>
    public static class ParkPopulator
    {
        public static List<IVehicle> Populate()
        {
            List<IVehicle> vehiclePark = new();
            IVehicleBuilder vehicleBuilder = new PassengerCarBuilder();

            vehicleBuilder.SetName("Nissan Almera");
            vehicleBuilder.SetEngine(new Engine { Power = 101, Volume = 1498, Type = "petrol", Serial = "DJ51279" });
            vehicleBuilder.SetChassis(new Chassis { Wheels = 4, Vin = "2C4GM68475R667819", Load = 520 });
            vehicleBuilder.SetTransmission(new Transmission { Gears = 5, Type = "manual", Manufacturer = "Nissan" });
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("Ford Focus");
            vehicleBuilder.SetEngine(new Engine { Power = 101, Volume = 1596, Type = "petrol", Serial = "1KD6157" });
            vehicleBuilder.SetChassis(new Chassis { Wheels = 4, Vin = "KM8JU3AC6DU588418", Load = 513 });
            vehicleBuilder.SetTransmission(new Transmission { Gears = 5, Type = "automatic", Manufacturer = "Ford" });
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("Audi A3");
            vehicleBuilder.SetEngine(new Engine { Power = 150, Volume = 1395, Type = "petrol", Serial = "M50B25TU" });
            vehicleBuilder.SetChassis(new Chassis { Wheels = 4, Vin = "WVGBV75N19W507096", Load = 660 });
            vehicleBuilder.SetTransmission(new Transmission { Gears = 5, Type = "automatic", Manufacturer = "Audi" });
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("Honda CR-V");
            vehicleBuilder.SetEngine(new Engine { Power = 120, Volume = 1597, Type = "diesel", Serial = "12H802065" });
            vehicleBuilder.SetChassis(new Chassis { Wheels = 4, Vin = "JH4KA4650KC031815", Load = 501 });
            vehicleBuilder.SetTransmission(new Transmission { Gears = 5, Type = "manual", Manufacturer = "Honda" });
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("Aston Martin Vantage");
            vehicleBuilder.SetEngine(new Engine { Power = 510, Volume = 3982, Type = "petrol", Serial = "N52B3O01" });
            vehicleBuilder.SetChassis(new Chassis { Wheels = 4, Vin = "2G1WF52K959355243", Load = 462 });
            vehicleBuilder.SetTransmission(new Transmission { Gears = 5, Type = "automatic", Manufacturer = "Aston Martin" });
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder = new TruckBuilder();

            vehicleBuilder.SetName("Ford Cargo 1842");
            vehicleBuilder.SetEngine(new Engine { Power = 420, Volume = 12700, Type = "turbodiesel", Serial = "BP15GB24348" });
            vehicleBuilder.SetChassis(new Chassis { Wheels = 4, Vin = "1GCJK33104F173427", Load = 11380 });
            vehicleBuilder.SetTransmission(new Transmission { Gears = 12, Type = "automatic", Manufacturer = "Ford" });
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("International LT");
            vehicleBuilder.SetEngine(new Engine { Power = 565, Volume = 14900, Type = "diesel", Serial = "N55B30T0" });
            vehicleBuilder.SetChassis(new Chassis { Wheels = 6, Vin = "JH4DB1660PS005158", Load = 20865 });
            vehicleBuilder.SetTransmission(new Transmission { Gears = 14, Type = "automated manual", Manufacturer = "Navistar" });
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("Tata LPT 2516");
            vehicleBuilder.SetEngine(new Engine { Power = 160, Volume = 5883, Type = "diesel", Serial = "6081AF001" });
            vehicleBuilder.SetChassis(new Chassis { Wheels = 6, Vin = "2FMDK4KC4CBA27842", Load = 19000 });
            vehicleBuilder.SetTransmission(new Transmission { Gears = 6, Type = "manual", Manufacturer = "Tata Motors" });
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("Nissan P-CD53S");
            vehicleBuilder.SetEngine(new Engine { Power = 295, Volume = 6920, Type = "diesel", Serial = "CD53S10040" });
            vehicleBuilder.SetChassis(new Chassis { Wheels = 6, Vin = "1G1ZT51806F128009", Load = 7600 });
            vehicleBuilder.SetTransmission(new Transmission { Gears = 6, Type = "manual", Manufacturer = "Nissan" });
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("HOWO cargo truck");
            vehicleBuilder.SetEngine(new Engine { Power = 371, Volume = 9726, Type = "diesel", Serial = "FXT00VA37488" });
            vehicleBuilder.SetChassis(new Chassis { Wheels = 6, Vin = "JH4KA4530LC018693", Load = 20000 });
            vehicleBuilder.SetTransmission(new Transmission { Gears = 10, Type = "manual", Manufacturer = "Sinotruk" });
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder = new BusBuilder();

            vehicleBuilder.SetName("Mercedes-Benz Citaro");
            vehicleBuilder.SetEngine(new Engine { Power = 295, Volume = 10700, Type = "diesel", Serial = "EBLL134467" });
            vehicleBuilder.SetChassis(new Chassis { Wheels = 4, Vin = "1FTJW36F2TEA03179", Load = 19000 });
            vehicleBuilder.SetTransmission(new Transmission { Gears = 4, Type = "automatic", Manufacturer = "Mercedes-Benz" });
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("Volvo 9700");
            vehicleBuilder.SetEngine(new Engine { Power = 500, Volume = 12800, Type = "diesel", Serial = "TU30502U623000F" });
            vehicleBuilder.SetChassis(new Chassis { Wheels = 6, Vin = "1GKEL19WXRB546238", Load = 26500 });
            vehicleBuilder.SetTransmission(new Transmission { Gears = 12, Type = "automatic", Manufacturer = "Volvo" });
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("MAN Lion's city 12");
            vehicleBuilder.SetEngine(new Engine { Power = 360, Volume = 9073, Type = "diesel", Serial = "AH4HK1XYBW01" });
            vehicleBuilder.SetChassis(new Chassis { Wheels = 4, Vin = "JH4DC2390SS000570", Load = 15566 });
            vehicleBuilder.SetTransmission(new Transmission { Gears = 6, Type = "automatic", Manufacturer = "MAN" });
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("Toyota-Coaster");
            vehicleBuilder.SetEngine(new Engine { Power = 147, Volume = 2700, Type = "petrol", Serial = "1GCHC29DX6E000001" });
            vehicleBuilder.SetChassis(new Chassis { Wheels = 4, Vin = "J8DE5B16477903094", Load = 2000 });
            vehicleBuilder.SetTransmission(new Transmission { Gears = 5, Type = "manual", Manufacturer = "Toyota" });
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("Iveco Magelys Pro");
            vehicleBuilder.SetEngine(new Engine { Power = 400, Volume = 8700, Type = "diesel", Serial = "6R108OT" });
            vehicleBuilder.SetChassis(new Chassis { Wheels = 4, Vin = "3B7HF13YXWG209744", Load = 18000 });
            vehicleBuilder.SetTransmission(new Transmission { Gears = 8, Type = "manual", Manufacturer = "Iveco" });
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder = new ScooterBuilder();

            vehicleBuilder.SetName("Aprilia SXR-160");
            vehicleBuilder.SetEngine(new Engine { Power = 15, Volume = 125, Type = "petrol", Serial = "BXS00782" });
            vehicleBuilder.SetChassis(new Chassis { Wheels = 2, Vin = "1GKDT13W6P2533357", Load = 140 });
            vehicleBuilder.SetTransmission(new Transmission { Gears = 5, Type = "automatic", Manufacturer = "Aprilia" });
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("Jawa 42");
            vehicleBuilder.SetEngine(new Engine { Power = 27, Volume = 294, Type = "petrol", Serial = "2H200355" });
            vehicleBuilder.SetChassis(new Chassis { Wheels = 2, Vin = "WVGBV7AX6CW559712", Load = 250 });
            vehicleBuilder.SetTransmission(new Transmission { Gears = 6, Type = "manual", Manufacturer = "Jawa Moto" });
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("Honda Wave 110 R");
            vehicleBuilder.SetEngine(new Engine { Power = 8, Volume = 109, Type = "petrol", Serial = "4FDO2365" });
            vehicleBuilder.SetChassis(new Chassis { Wheels = 2, Vin = "1C6RD6KT4CS332867", Load = 115 });
            vehicleBuilder.SetTransmission(new Transmission { Gears = 4, Type = "manual", Manufacturer = "Honda" });
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("BMW 1250 GSA");
            vehicleBuilder.SetEngine(new Engine { Power = 136, Volume = 1254, Type = "petrol", Serial = "RF370CB11670" });
            vehicleBuilder.SetChassis(new Chassis { Wheels = 2, Vin = "1FMZK04185GA30815", Load = 216 });
            vehicleBuilder.SetTransmission(new Transmission { Gears = 6, Type = "manual", Manufacturer = "BMW Motorrad" });
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("KLX 300SM");
            vehicleBuilder.SetEngine(new Engine { Power = 24, Volume = 292, Type = "petrol", Serial = "3CS16694" });
            vehicleBuilder.SetChassis(new Chassis { Wheels = 2, Vin = "4F2CU08102KM50866", Load = 239 });
            vehicleBuilder.SetTransmission(new Transmission { Gears = 6, Type = "manual", Manufacturer = "Kawasaki" });
            vehiclePark.Add(vehicleBuilder.Build());

            return vehiclePark;
        }
    }
}
