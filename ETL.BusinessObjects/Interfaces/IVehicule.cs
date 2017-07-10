namespace ETL.BusinessObjects
{
    public interface IVehicule
    {
        #region Properties

        int ID { get; set; }
        string Name { get; set; }
        string PlateNumber { get; set; }
        string Make { get; set; }
        string Model { get; set; }

        #endregion
    }
}
