using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PrismXamarinStudy.ViewModels
{
    public class ExtendedBindableBase : INotifyPropertyChanged, INavigationService
    {
        private readonly INavigationService _navigationService;

        private readonly Dictionary<string, object> _propertyValueMap;

        public event PropertyChangedEventHandler PropertyChanged;        

        protected ExtendedBindableBase(INavigationService navigationService)
        { 
            _navigationService = navigationService;
            _propertyValueMap = new Dictionary<string, object>();
        }

        private void InternalPropertyUpdate(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> path)
        {
            var propertyName = GetPropertyName(path);
            InternalPropertyUpdate(propertyName);
        }

        protected T Get<T>(Expression<Func<T>> path)
        {
            return Get(path, default(T));
        }

        protected virtual T Get<T>(Expression<Func<T>> path, T defaultValue)
        {
            var propertyName = GetPropertyName(path);
            if (_propertyValueMap.ContainsKey(propertyName))
            {
                return (T)_propertyValueMap[propertyName];
            }
            else
            {
                try
                {
                    _propertyValueMap.Add(propertyName, defaultValue);
                }
                catch
                {
                }

                return defaultValue;
            }
        }

        protected virtual void Set<T>(Expression<Func<T>> path, T value)
        {
            Set(path, value, false);
        }

        protected virtual void Set<T>(Expression<Func<T>> path, T value, bool forceUpdate)
        {
            var oldValue = Get(path);
            var propertyName = GetPropertyName(path);

            if (!Equals(value, oldValue) || forceUpdate)
            {
                _propertyValueMap[propertyName] = value;
                OnPropertyChanged(path);
            }
        }

        protected static string GetPropertyName<T>(Expression<Func<T>> expression)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            var body = expression.Body;
            var memberExpression = body as MemberExpression;
            if (memberExpression == null)
            {
                memberExpression = (MemberExpression)((UnaryExpression)body).Operand;
            }
            return memberExpression.Member.Name;
        }

        public Task NavigateAsync(string name)
        {
            return _navigationService.NavigateAsync(name);
        }

        public Task<bool> GoBackAsync(NavigationParameters parameters = null, bool? useModalNavigation = default(bool?), bool animated = true)
        {
            return _navigationService.GoBackAsync(parameters, useModalNavigation, animated);
        }

        public Task NavigateAsync(Uri uri, NavigationParameters parameters = null, bool? useModalNavigation = default(bool?), bool animated = true)
        {
            return _navigationService.NavigateAsync(uri, parameters, useModalNavigation, animated);
        }

        public Task NavigateAsync(string name, NavigationParameters parameters = null, bool? useModalNavigation = default(bool?), bool animated = true)
        {
            return _navigationService.NavigateAsync(name, parameters, useModalNavigation, animated);
        }
    }
}
