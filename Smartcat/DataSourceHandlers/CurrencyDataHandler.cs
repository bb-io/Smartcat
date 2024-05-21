using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Smartcat.DataSourceHandlers;

public class CurrencyDataHandler : BaseInvocable, IDataSourceHandler
{
    public CurrencyDataHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public Dictionary<string, string> GetData(DataSourceContext context)
    {
        var currency = new List<string>
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

        return currency
            .Where(currency => context.SearchString == null || currency.Contains(context.SearchString,
                StringComparison.OrdinalIgnoreCase))
            .ToDictionary(currency => currency, currency => currency);
    }

}