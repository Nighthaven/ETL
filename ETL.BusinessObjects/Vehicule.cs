namespace ETL.BusinessObjects
{
    public class Vehicule : IVehicule
    {
        #region Properties

        #region Implemented

        public int ID { get; set; }
        public string Name { get; set; }
        public string PlateNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

        #endregion

        #endregion
    }
}
