/**
 * The `ICurrenciesClient` interface fetches currency exchange rates based on a specified base currency
 */
interface ICurrenciesClient {
  /**
   * This method fetches currency exchange rates based on a specified base currency.
   * @param {string} baseCurrency - The `getCurrencies` method is an asynchronous method that takes
   * a `baseCurrency` parameter as a string. The method fetches currency data from a specified URL
   * based on the provided `baseCurrency`. It then returns a Promise that resolves to a Record<string,
   * bigint> if the currency data is present on the provider.
   * @returns The `getCurrencies` method returns a Promise that resolves to either a Record<string,
   * bigint> object, null, or undefined.
   */
  getCurencies(
    baseCurrency: string,
  ): Promise<Record<string, bigint> | null | undefined>;
}

const ICurrenciesClient = Symbol('ICurrenciesClient');

export default ICurrenciesClient;
