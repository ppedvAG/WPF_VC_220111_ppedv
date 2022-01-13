using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace Validation
{
    public class IPv4Validation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (Regex.IsMatch(value.ToString(), @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$"))
                return ValidationResult.ValidResult;
            else
                return new ValidationResult(false, "Bitte gib eine valide IPv4-Adresse ein.");
        }
    }


    public class ValidationMarkup : MarkupExtension
    {
        private Binding binding;

        //Konstruktor (Die Übergabeparameter sind die Werte, welche das Objekt in XAML erwartet)
        public ValidationMarkup(Binding binding, ValidationRuleCollection validationRules)
        {
            this.binding = binding;

            //Hinzufügen der übergebenen Regeln an die Bindung
            foreach (ValidationRule rule in validationRules)
            {
                binding.ValidationRules.Add(rule);
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            //Rückgabe der Bindung an XAML (bei Verwendung dieser MarkupExtension als Propertybelegung in XAML)
            return binding.ProvideValue(serviceProvider);
        }
    }

    public class ValidationRuleCollection : Collection<ValidationRule> { }
}