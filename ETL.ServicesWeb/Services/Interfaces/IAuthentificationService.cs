using ETL.BusinessObjects;

namespace ETL.ServicesWeb.Services.Interfaces
{
    public interface IAuthentificationService
    {
        #region Methods

        IAuthentificationToken Login(string pUsername, string pPassword);
        bool Close(IAuthentificationToken pToken);

        #endregion
    }
}
