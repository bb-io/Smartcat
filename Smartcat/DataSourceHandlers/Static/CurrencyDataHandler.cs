using Blackbird.Applications.Sdk.Common.Dictionaries;
using System;

namespace Apps.Smartcat.DataSourceHandlers.Static;

public class CurrencyDataHandler : IStaticDataSourceHandler
{
    private static List<string> currency => new()
        {
            "AED",
            "ARS",
            "AUD",
            "BRL",
            "CAD",
            "CHF",
            "CLP",
            "CNY",
            "DKK",
            "EGP",
            "EUR",
            "GBP",
            "HKD",
            "IDR",
            "ILS",
            "INR",
            "ISK",
            "JPY",
            "KES",
            "KRW",
            "KZT",
            "LKR",
            "MAD",
            "MXN",
            "MYR",
            "NPR",
            "NZD",
            "PEN",
            "PHP",
            "PKR",
            "PLN",
            "RUB",
            "SEK",
            "SGD",
            "THB",
            "TRY",
            "TTD",
            "TWD",
            "UAH",
            "USD",
            "VND",
            "ZAR"

        };

    public Dictionary<string, string> GetData()
    {
        return currency.ToDictionary(currency => currency, currency => currency);
    }

}