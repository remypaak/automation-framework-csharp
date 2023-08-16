using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseTestAutomation.Utilities.Helpers
{
    public class Asserts
    {
        public static void AreDatesEqual(string expected, DateTime? actual)
        {
            if (actual is null && expected == "")
            {
                return;
            }
            else if (actual is null)
            {
                throw new Exception($"We expect a string {expected} but it is null");
            }
            else if (expected == "")
            {
                throw new Exception($"We expect to get an empty string but it is actually {actual}");
            }

            string newActual = actual.Value.ToString("dd/MM/yyyy");
            DateTime expectedDateTime;
            if (DateTime.TryParse(expected, out expectedDateTime))
            {
                string newExpected = expectedDateTime.ToString("dd/MM/yyyy");
                Assert.That(newExpected, Is.EqualTo(newActual));
            }
            else
            {
                throw new Exception($"It was not possible to convert {expected} to a generic string representation of a date");
            }
        }

        public static void AreDatesEqual(DateTime? expected, string actual)
        {
            if (actual == "" && expected is null)
            {
                return;
            }
            else if (expected is null)
            {
                throw new Exception($"We expect an empty string but it is actually {actual}");
            }
            else if (actual == "")
            {
                throw new Exception($"We expect a string {expected} but it is null");
            }
            string newExpected = expected.Value.ToString("dd/MM/yyyy");
            DateTime actualDateTime;
            if (DateTime.TryParse(actual, out actualDateTime))
            {
                string newActual = actualDateTime.ToString("dd/MM/yyyy");
                Assert.That(newExpected, Is.EqualTo(newActual));
            }
            else
            {
                throw new Exception($"It was not possible to convert {actual} to a generic string representation of a date");
            }
        }

        public static void AreDatesEqual(DateTime expected, DateTime actual)
        {
            Assert.That(actual, Is.EqualTo(expected));
        }

        public static void AreAmountsEqual(string  expected, decimal actual)
        {
            decimal expectedDecimal;
            if (decimal.TryParse(expected, out expectedDecimal))
            {
                Assert.That(actual, Is.EqualTo(expectedDecimal));
            }
            else
            {
                throw new Exception($"It was not possible to parse {expected} to a decimal value");
            }
        }
    }
}
