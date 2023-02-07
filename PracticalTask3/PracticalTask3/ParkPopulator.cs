using PracticalTask3.Vehicles;

namespace PracticalTask3
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
            vehicleBuilder.SetEngine(101, 1498, "petrol", "DJ51279");
            vehicleBuilder.SetChassis(4, "2C4GM68475R667819", 520);
            vehicleBuilder.SetTransmission(5, "manual", "Nissan");
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("Ford Focus");
            vehicleBuilder.SetEngine(101, 1596, "petrol", "1KD6157");
            vehicleBuilder.SetChassis(4, "KM8JU3AC6DU588418", 513);
            vehicleBuilder.SetTransmission(5, "automatic", "Ford");
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("Audi A3");
            vehicleBuilder.SetEngine(150, 1395, "petrol", "M50B25TU");
            vehicleBuilder.SetChassis(4, "WVGBV75N19W507096", 660);
            vehicleBuilder.SetTransmission(5, "automatic", "Audi");
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("Honda CR-V");
            vehicleBuilder.SetEngine(120, 1597, "diesel", "12H802065");
            vehicleBuilder.SetChassis(4, "JH4KA4650KC031815", 501);
            vehicleBuilder.SetTransmission(5, "manual", "Honda");
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("Aston Martin Vantage");
            vehicleBuilder.SetEngine(510, 3982, "petrol", "N52B3O01");
            vehicleBuilder.SetChassis(4, "2G1WF52K959355243", 462);
            vehicleBuilder.SetTransmission(5, "automatic", "Aston Martin");
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder = new TruckBuilder();

            vehicleBuilder.SetName("Ford Cargo 1842");
            vehicleBuilder.SetEngine(420, 12700, "turbodiesel", "BP15GB24348");
            vehicleBuilder.SetChassis(4, "1GCJK33104F173427", 11380);
            vehicleBuilder.SetTransmission(12, "automatic", "Ford");
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("International LT");
            vehicleBuilder.SetEngine(565, 14900, "diesel", "N55B30T0");
            vehicleBuilder.SetChassis(6, "JH4DB1660PS005158", 20865);
            vehicleBuilder.SetTransmission(14, "automated manual", "Navistar");
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("Tata LPT 2516");
            vehicleBuilder.SetEngine(160, 5883, "diesel", "6081AF001");
            vehicleBuilder.SetChassis(6, "2FMDK4KC4CBA27842", 19000);
            vehicleBuilder.SetTransmission(6, "manual", "Tata Motors");
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("Nissan P-CD53S");
            vehicleBuilder.SetEngine(295, 6920, "diesel", "CD53S10040");
            vehicleBuilder.SetChassis(6, "1G1ZT51806F128009", 7600);
            vehicleBuilder.SetTransmission(6, "manual", "Nissan");
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("HOWO cargo truck");
            vehicleBuilder.SetEngine(371, 9726, "diesel", "FXT00VA37488");
            vehicleBuilder.SetChassis(6, "JH4KA4530LC018693", 20000);
            vehicleBuilder.SetTransmission(10, "manual", "Sinotruk");
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder = new BusBuilder();

            vehicleBuilder.SetName("Mercedes-Benz Citaro");
            vehicleBuilder.SetEngine(295, 10700, "diesel", "EBLL134467");
            vehicleBuilder.SetChassis(4, "1FTJW36F2TEA03179", 19000);
            vehicleBuilder.SetTransmission(4, "automatic", "Mercedes-Benz");
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("Volvo 9700");
            vehicleBuilder.SetEngine(500, 12800, "diesel", "TU30502U623000F");
            vehicleBuilder.SetChassis(6, "1GKEL19WXRB546238", 26500);
            vehicleBuilder.SetTransmission(12, "automatic", "Volvo");
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("MAN Lion's city 12");
            vehicleBuilder.SetEngine(360, 9073, "diesel", "AH4HK1XYBW01");
            vehicleBuilder.SetChassis(4, "JH4DC2390SS000570", 15566);
            vehicleBuilder.SetTransmission(6, "automatic", "MAN");
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("Toyota-Coaster");
            vehicleBuilder.SetEngine(147, 2700, "petrol", "1GCHC29DX6E000001");
            vehicleBuilder.SetChassis(4, "J8DE5B16477903094", 2000);
            vehicleBuilder.SetTransmission(5, "manual", "Toyota");
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("Iveco Magelys Pro");
            vehicleBuilder.SetEngine(400, 8700, "diesel", "6R108OT");
            vehicleBuilder.SetChassis(4, "3B7HF13YXWG209744", 18000);
            vehicleBuilder.SetTransmission(8, "manual", "Iveco");
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder = new ScooterBuilder();

            vehicleBuilder.SetName("Aprilia SXR-160");
            vehicleBuilder.SetEngine(15, 125, "petrol", "BXS00782");
            vehicleBuilder.SetChassis(2, "1GKDT13W6P2533357", 140);
            vehicleBuilder.SetTransmission(5, "automatic", "Aprilia");
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("Jawa 42");
            vehicleBuilder.SetEngine(27, 294, "petrol", "2H200355");
            vehicleBuilder.SetChassis(2, "WVGBV7AX6CW559712", 250);
            vehicleBuilder.SetTransmission(6, "manual", "Jawa Moto");
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("Honda Wave 110 R");
            vehicleBuilder.SetEngine(8, 109, "petrol", "4FDO2365");
            vehicleBuilder.SetChassis(2, "1C6RD6KT4CS332867", 115);
            vehicleBuilder.SetTransmission(4, "manual", "Honda");
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("BMW 1250 GSA");
            vehicleBuilder.SetEngine(136, 1254, "petrol", "RF370CB11670");
            vehicleBuilder.SetChassis(2, "1FMZK04185GA30815", 216);
            vehicleBuilder.SetTransmission(6, "manual", "BMW Motorrad");
            vehiclePark.Add(vehicleBuilder.Build());

            vehicleBuilder.SetName("KLX 300SM");
            vehicleBuilder.SetEngine(24, 292, "petrol", "3CS16694");
            vehicleBuilder.SetChassis(2, "4F2CU08102KM50866", 239);
            vehicleBuilder.SetTransmission(6, "manual", "Kawasaki");
            vehiclePark.Add(vehicleBuilder.Build());

            return vehiclePark;
        }
    }
}
