namespace ETL.BusinessObjects
{
    public interface IAuthentificationToken
    {
        #region Properties

        string Value { get; set; }
        int FleetOwnerID { get; set; }

        #endregion
    }
}
