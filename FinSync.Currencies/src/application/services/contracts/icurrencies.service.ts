interface ICurrenciesService {
  /**
   * This async function retrieves currency conversions based on a specified base currency.
   * @param {string} baseCurrency - The `baseCurrency` parameter is a string that represents the
   * currency for which you want to retrieve exchange rates and conversions.
   * @returns The function `getCurenciesAndConversions` is returning a Promise that resolves to a
   * Record<string, bigint> or null or undefined.
   */
  getCurenciesAndConversions(
    baseCurrency: string,
  ): Promise<Record<string, number> | null | undefined>;

  /**
   * The method asynchronously retrieves and returns an array of available currency acronyms.
   * @returns An array of strings containing the acronyms of available currencies.
   */
  getAvailableCurrenciesAcronyms(): Promise<Array<string>>;
}

const ICurrenciesService = Symbol('ICurrenciesService');

export default ICurrenciesService;
