import ICurrenciesClient from 'src/application/clients/icurrencies.client';

/**
 * The `CurrenciesClient` class fetches currency exchange rates based on a specified base currency
 */
class CurrenciesClient implements ICurrenciesClient {
  private readonly BASE_URL: string | null | undefined =
    process.env.CURRENCY_API_URI;

  async getCurencies(
    baseCurrency: string,
  ): Promise<Record<string, number> | null | undefined> {
    if (!this.BASE_URL || this.BASE_URL.trim().length < 1) return null;

    baseCurrency = baseCurrency.toLowerCase();

    const response = (await (
      await fetch(`${this.BASE_URL}/${baseCurrency.toLowerCase()}.json`)
    ).json()) as object;

    if (baseCurrency in response)
      return response[baseCurrency] as Record<string, number>;

    return null;
  }
}

export default CurrenciesClient;
