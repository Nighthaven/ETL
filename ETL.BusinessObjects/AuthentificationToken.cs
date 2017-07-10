namespace ETL.BusinessObjects
{
    public class AuthentificationToken : IAuthentificationToken
    {
        #region Properties

        #region Implemented

        public string Value { get; set; }
        public int FleetOwnerID { get; set; }

        #endregion

        #endregion
    }
}
