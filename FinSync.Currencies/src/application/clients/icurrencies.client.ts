interface ICurrenciesClient {
  getCurencies(
    baseCurrency: string,
  ): Promise<Record<string, bigint> | null | undefined>;
}

const ICurrenciesClient = Symbol('ICurrenciesClient');

export default ICurrenciesClient;
