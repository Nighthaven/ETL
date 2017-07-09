using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;

namespace ETL.Prototype.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetField<T>(ref T pField, T pValue, [CallerMemberName] string pPropertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(pField, pValue)) return false;
            pField = pValue;
            OnPropertyChanged(pPropertyName);
            return true;
        }

        protected virtual void OnPropertyChanged(string pPropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(pPropertyName));
        }

        protected virtual void NotifyPropertyChanged(string pProperty)
        {
            OnPropertyChanged(pProperty);
        }

        protected static string GetPropertyName(Expression<Func<object>> pExpression)
        {
            MemberExpression body = pExpression.Body as MemberExpression;

            if (body == null)
            {
                UnaryExpression ubody = (UnaryExpression)pExpression.Body;
                body = ubody.Operand as MemberExpression;
            }

            return body.Member.Name;
        }
    }
}
